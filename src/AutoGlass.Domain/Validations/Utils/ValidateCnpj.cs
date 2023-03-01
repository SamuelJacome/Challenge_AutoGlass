using System.Collections.Generic;
using System.Linq;

namespace AutoGlass.Domain.Validations.Utils
{
    public class ValidateCnpj
    {
        public const int LengthCnpj = 14;

        public static bool Validate(string cpnj)
        {
            var cnpjNumbers = JustNumbers(cpnj);

            if (!LengthCnpjValid(cnpjNumbers)) return false;
            return !HasRepeatedNumber(cnpjNumbers) && HasDigitsValid(cnpjNumbers);
        }

        private static bool LengthCnpjValid(string value)
        {
            return value.Length == LengthCnpj;
        }

        private static bool HasRepeatedNumber(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasDigitsValid(string valor)
        {
            var number = valor.Substring(0, LengthCnpj - 2);

            var digitoVerificador = new DigitVerify(number)
                .WithMultipliers(2, 9)
                .Replace("0", 10, 11);
            var firstDigit = digitoVerificador.CalculateDigit();
            digitoVerificador.AddDigit(firstDigit);
            var secondDigit = digitoVerificador.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(LengthCnpj - 2, 2);
        }

        public class DigitVerify
        {
            private string _number;
            private const int module = 11;
            private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
            private readonly IDictionary<int, string> _substitutions = new Dictionary<int, string>();
            private bool _complementarDoModulo = true;

            public DigitVerify(string number)
            {
                _number = number;
            }

            public DigitVerify WithMultipliers(int firstMultipliers, int lastmultipliers)
            {
                _multipliers.Clear();
                for (var i = firstMultipliers; i <= lastmultipliers; i++)
                    _multipliers.Add(i);

                return this;
            }

            public DigitVerify Replace(string replaced, params int[] digits)
            {
                foreach (var i in digits)
                {
                    _substitutions[i] = replaced;
                }
                return this;
            }

            public void AddDigit(string digit)
            {
                _number = string.Concat(_number, digit);
            }

            public string CalculateDigit()
            {
                return !(_number.Length > 0) ? "" : GetDigitSum();
            }

            private string GetDigitSum()
            {
                var sum = 0;
                for (int i = _number.Length - 1, m = 0; i >= 0; i--)
                {
                    var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                    sum += product;

                    if (++m >= _multipliers.Count) m = 0;
                }

                var mod = (sum % module);
                var resultado = _complementarDoModulo ? module - mod : mod;

                return _substitutions.ContainsKey(resultado) ? _substitutions[resultado] : resultado.ToString();
            }
        }

        public static string JustNumbers(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}