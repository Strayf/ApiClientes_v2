using Domain.Helper;
using Web.Helper;

namespace Domain.Entity
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public void Validar(Notification notif)
        {
            if (Auxiliares.AcimaDoLimite(Logradouro, 50))
                notif.AddError("Logradouro acima de 50 caracteres não é permitido");

            if (Auxiliares.AcimaDoLimite(Estado, 40))
                notif.AddError("Estado acima de 40 caracteres não é permitido");

            if (Auxiliares.AcimaDoLimite(Cidade, 40))
                notif.AddError("Cidade acima de 40 caracteres não é permitido");

            if (Auxiliares.AcimaDoLimite(Bairro, 40))
                notif.AddError("Bairro acima de 40 caracteres não é permitido");
        }
    }
}
