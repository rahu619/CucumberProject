using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cucumber.BLL
{
    public class NumberToWord
    {
        double input;

        private readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public NumberToWord(double input)
        {
            this.input = input;
        }

        public string Get()
        {
            if (input == 0) return "Zero";

            else
            {
                var beforeDecimalPoint = (int)Math.Abs(Math.Truncate(this.input));
                var afterDecimalPoint = (int)(Math.Round((Math.Abs(this.input) - beforeDecimalPoint), 2) * 100);

                var currency = $"{Process(beforeDecimalPoint)} Dollars{(afterDecimalPoint > 0 ? $" and {Process(afterDecimalPoint)} cents" : string.Empty)}";

                return $"{((input < 0) ? "Negative " : null)}{currency}";


            }

        }


        string Process(int input)
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
                    var _output = Tens[input / 10];
                    output.Add($"{_output}{((input > 0) ? "-" : null)}");
                    input %= 10;
                }
                else if (input < 1000)
                {
                    output.Add($"{Process(input / 100)} Hundred and ");
                    input %= 100;
                }
                else if (input > 1000)
                {
                    output.Add($"{Process(input / 1000)} Thousand and ");
                    input %= 1000;
                }
                else if (input > 1000000)
                {
                    output.Add($"{Process(input / 1000000)} million and ");
                    input %= 1000000;
                }


            }

            return string.Join("", output);

        }

    }
}