using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThoughtWorksAssignment
{
    public class GalaxyInputParser
    {
        public Dictionary<string, string> UnitDictionary { get; set; }
        public Dictionary<string, double> WealthDictionary { get; set; }
        public List<string> Output { get; set; }
        private IArabicConvertable convertor;

        private static readonly string NOIDEAMESSAGE = "I have no idea what you are talking about";

        public GalaxyInputParser(IArabicConvertable arg)
        {
            this.UnitDictionary = new Dictionary<string, string>();
            this.WealthDictionary = new Dictionary<string, double>();
            this.Output = new List<string>();
            this.convertor = arg;
        }

        public void Parse(List<string> inputs)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < inputs.Count; i++)
            {
                // Unit Definition
                Regex reg = new Regex(@"^(\w+)\s(\w+)\s(\w+)$");
                Match match = reg.Match(inputs[i]);
                if (match.Success)
                {
                    this.UnitDictionary.Add(match.Groups[1].Value, match.Groups[3].Value);
                    continue;
                }

                // Wealth Price Definition
                reg = new Regex(@"\sis\s\d+\sCredits");
                match = reg.Match(inputs[i]);
                if (match.Success)
                {
                    ParseWealthPrice(inputs[i]);
                    continue;
                }

                // Unit question
                reg = new Regex(@"^how much is", RegexOptions.IgnoreCase);
                match = reg.Match(inputs[i]);
                if (match.Success)
                {
                    AnswerUnitQuestion(inputs[i]);
                    continue;
                }

                // Price Question
                reg = new Regex(@"^how many Credits is", RegexOptions.IgnoreCase);
                match = reg.Match(inputs[i]);
                if (match.Success)
                {
                    AnswerWealthPriceQuestion(inputs[i]);
                    continue;
                }

                // Unknown Input
                this.Output.Add(NOIDEAMESSAGE);
            }
        }

        private void ParseWealthPrice(string sentence)
        {
            Regex reg = new Regex(@"(\w+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(sentence);
            string romanNumber = string.Empty;
            string wealth = string.Empty;
            int price = 0;
            for (int j = 0; j < matches.Count; j++)
            {
                string value = matches[j].Value;
                if (this.UnitDictionary.ContainsKey(value))
                {
                    romanNumber = romanNumber + this.UnitDictionary[value];
                }
                else if (string.Compare(value, "is", true) == 0)
                {
                    wealth = matches[j - 1].Value;
                    price = Int32.Parse(matches[j + 1].Value);
                    break;
                }
            }

            try
            {
                int arabic = convertor.ConvertToArabic(romanNumber);
                this.WealthDictionary.Add(wealth, (double)price / arabic);
            }
            catch (Exception)
            {
                this.Output.Add(NOIDEAMESSAGE);
            }
        }

        private void AnswerUnitQuestion(string sentence)
        {
            StringBuilder strBuilder = new StringBuilder();
            Regex reg = new Regex(@"(\w+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(sentence);
            int counter = 0;
            bool validFlag = false;
            string romanNum = string.Empty;
            while (true)
            {
                if (counter == matches.Count)
                    break;
                string value = matches[counter].Value;
                if (string.Compare(value, "is", true) == 0)
                {
                    validFlag = true;
                    counter++;
                    continue;
                }
                else if (string.Compare(value, "?") == 0)
                    break;

                if (validFlag)
                {
                    if (!this.UnitDictionary.ContainsKey(value))
                    {
                        this.Output.Add(NOIDEAMESSAGE);
                        break;
                    }
                    romanNum = romanNum + this.UnitDictionary[value];
                    strBuilder.AppendFormat("{0} ", value);
                }
                counter++;
            }

            try
            {
                int arabic = convertor.ConvertToArabic(romanNum);
                strBuilder.AppendFormat("is {0}", arabic);
                this.Output.Add(strBuilder.ToString());
            }
            catch (Exception)
            {
                this.Output.Add(NOIDEAMESSAGE);
            }
        }

        private void AnswerWealthPriceQuestion(string sentence)
        {
            StringBuilder strBuilder = new StringBuilder();
            Regex reg = new Regex(@"(\w+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(sentence);
            int counter = 0;
            bool startFlag = false;
            string romanNum = string.Empty;
            double wealth = 0;

            while (true)
            {
                if (counter == matches.Count)
                    break;
                string value = matches[counter].Value;
                if (string.Compare(value, "is", true) == 0)
                {
                    startFlag = true;
                    counter++;
                    continue;
                }
                else if (string.Compare(value, "?") == 0)
                    break;

                if (startFlag)
                {
                    if (this.UnitDictionary.ContainsKey(value))
                    {
                        romanNum = romanNum + this.UnitDictionary[value];
                        strBuilder.AppendFormat("{0} ", value);
                    }
                    else if (this.WealthDictionary.ContainsKey(value))
                    {
                        wealth = this.WealthDictionary[value];
                        strBuilder.AppendFormat("{0} ", value);
                    }
                    else
                    {
                        this.Output.Add(NOIDEAMESSAGE);
                        break;
                    }
                }
                counter++;
            }

            try
            {
                int arabic = convertor.ConvertToArabic(romanNum);
                strBuilder.AppendFormat("is {0} Credits", wealth * arabic);
                this.Output.Add(strBuilder.ToString());
            }
            catch (Exception)
            {
                this.Output.Add(NOIDEAMESSAGE);
            }
        }

        public KeyValuePair<string, double> ParseWealthPrice_1(Dictionary<string, string> unitDic, string sentence)
        {

            Regex reg = new Regex(@"(\w+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(sentence);
            string number = string.Empty;
            string wealth = string.Empty;
            int price = 0;
            for (int j = 0; j < matches.Count; j++)
            {
                string value = matches[j].Value;
                if (unitDic.ContainsKey(value))
                {
                    number = number + unitDic[value];
                }
                else if (string.Compare(value, "is", true) == 0)
                {
                    wealth = matches[j - 1].Value;
                    price = Int32.Parse(matches[j + 1].Value);
                    break;
                }
            }

            int arabic = convertor.ConvertToArabic(number);

            return new KeyValuePair<string, double>(wealth, (double)price / arabic);
        }
    }
}
