using Autofac.Extras.Moq;
using Domain.Entity;
using Domain.Interface.Repository;
using Domain.Service;
using Moq;
using Web.Helper;
using Xunit;

namespace API.Test
{
    public class EnderecoTeste
    {

        [Theory]
        [InlineData("Teste A", "Teste B", "Teste C", "Teste D")]
        public void LimitesDeCaracteresAceitaveis(string logradouro, string estado, string cidade, string bairro)
        {
            Assert.False(Auxiliares.AcimaDoLimite(logradouro, 50));
            Assert.False(Auxiliares.AcimaDoLimite(estado, 40));
            Assert.False(Auxiliares.AcimaDoLimite(cidade, 40));
            Assert.False(Auxiliares.AcimaDoLimite(bairro, 40));
        }

        [Theory]
        [InlineData("01234567890012345678900123456789001234567890012345678900", "012345678900123456789001234567890012345678900", "012345678900123456789001234567890012345678900", "012345678900123456789001234567890012345678900")]
        public void LimitesDeCaracteresInaceitaveis(string logradouro, string estado, string cidade, string bairro)
        {
            Assert.True(Auxiliares.AcimaDoLimite(logradouro, 50));
            Assert.True(Auxiliares.AcimaDoLimite(estado, 40));
            Assert.True(Auxiliares.AcimaDoLimite(cidade, 40));
            Assert.True(Auxiliares.AcimaDoLimite(bairro, 40));
        }

        [Fact]
        public void EnderecoResgatadoCorretamente()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEnderecoRepository>()
                    .Setup(x => x.GetEndereco(1))
                    .Returns(GetEndereco());

                var cls = mock.Create<EnderecoService>();
                var esperado = GetEndereco();

                var real = cls.GetEndereco(1);

                Assert.True(real != null);
                Assert.Equal(esperado.Logradouro, real.Logradouro);
                Assert.Equal(esperado.Cidade, real.Cidade);
                Assert.Equal(esperado.Estado, real.Estado);
                Assert.Equal(esperado.Bairro, real.Bairro);
            }

        }

        [Fact]
        public void EnderecoCadastradoCorretamente()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Endereco endereco = GetEndereco();
                mock.Mock<IEnderecoRepository>()
                    .Setup(x => x.Add(endereco));

                var cls = mock.Create<EnderecoService>();
                cls.Add(endereco);

                mock.Mock<IEnderecoRepository>()
                    .Verify(x => x.Add(endereco), Times.Exactly(1));

            }

        }

        private Endereco GetEndereco()
        {
            return new Endereco() { Logradouro = "A", Bairro = "B", Cidade = "C", Estado = "D" };
        }
    }
}
