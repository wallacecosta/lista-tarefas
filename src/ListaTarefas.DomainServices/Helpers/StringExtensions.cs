namespace ListaTarefas.DomainServices.Helpers
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException("id obrigatório");

            if (!Guid.TryParse(str, out Guid retorno))
                throw new ArgumentException("id inválido");

            return retorno;
        }
    }
}
