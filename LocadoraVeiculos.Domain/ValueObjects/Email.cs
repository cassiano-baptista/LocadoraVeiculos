using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Domain.ValueObjects
{
    public class Email
    {
        public string Valor { get; private set; }

        public Email(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("O e-mail é obrigatório.");

            if (!EValido(valor))
                throw new ArgumentException("O e-mail informado é inválido.");

            Valor = valor.Trim();
        }

        private static bool EValido(string email)
        {
            var padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, padrao);
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
