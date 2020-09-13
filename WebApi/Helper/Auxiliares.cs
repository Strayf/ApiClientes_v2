namespace Web.Helper
{
    public static class Auxiliares
    {
        public static bool AcimaDoLimite(string texto, int limite)
        {
            if (texto.Length > limite)
                return true;
            else return false;
        }
    }
}