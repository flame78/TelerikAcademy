namespace Phonebook.ConsoleClient.Strategy.Formater
{
    using System.Text;

    using Phonebook.ConsoleClient.Contracts;

    internal class PhoneNumberFormater : IPhoneNumberFormater
    {
        private const string DefaultCountryCode = "+359";

        public string Format(string number)
        {
            var result = new StringBuilder();

            foreach (var ch in number)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    result.Append(ch);
                }
            }

            if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
            {
                result.Remove(0, 1);
                result[0] = '+';
            }

            while (result.Length > 0 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            if (result.Length > 0 && result[0] != '+')
            {
                result.Insert(0, DefaultCountryCode);
            }

            return result.ToString();
        }
    }
}