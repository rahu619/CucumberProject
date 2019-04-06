using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cucumber.BLL
{
    public class NumberToWord : INumberToWord
    {

        private readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };


        public string GetWords(double input)
        {

            if (input == 0) return "Zero";

            else
            {
                var beforeDecimalPoint = (int)Math.Abs(Math.Truncate(input));
                var afterDecimalPoint = (int)(Math.Round((Math.Abs(input) - beforeDecimalPoint), 2) * 100);

                var currency = $"{Get(beforeDecimalPoint)} Dollars{(afterDecimalPoint > 0 ? $" and {Get(afterDecimalPoint)} cents" : string.Empty)}";

                return $"{((input < 0) ? "Negative " : null)}{currency}";


            }

        }


        /// <summary>
        /// Converts numerical data to words
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string Get(int input)
        {
            var output = new List<string>();

            while (input > 0)
            {
                if (input > 0 && input < 10)
                {
                    output.Add(Ones[input]);
                    break;
                }
                else if (input >= 10 && input < 20)
                {
                    output.Add(Teens[input % 10]);
                    break;
                }
                else if (input < 100)
                {
                    output.Add(Tens[input / 10].AddExtra(input));
                    input %= 10;
                }

                else if (input < 1000)
                {
                    output.Add($"{Get(input / 100)} Hundred".AddExtra(input));
                    input %= 100;
                }

                else if (input < 1000000)
                {
                    output.Add($"{Get(input / 1000)} Thousand".AddExtra(input));
                    input %= 1000;
                }

                else if (input < 1000000000)
                {
                    output.Add($"{Get(input / 1000000)} Million".AddExtra(input));
                    input %= 1000000;
                }

                else if (input >= 1000000000)
                {
                    output.Add($"{Get(input / 1000000000)} Billion".AddExtra(input));
                    input %= 1000000000;
                }



            }

            return string.Join("", output);

        }



    }

    /// <summary>
    /// Adds non-alphanumerical values to the currency words
    /// </summary>
    public static class Extensions
    {

        public static string AddExtra(this string output, int input) =>
            (input % 10 == 0) ? output : string.Concat(output, (input < 100) ? "-" : " and ");
    }
}