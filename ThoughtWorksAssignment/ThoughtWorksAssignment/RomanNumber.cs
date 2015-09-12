using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtWorksAssignment.Old
{
    public class RomanNumber
    {
        public enum RomanBase
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }

        private RomanNumber() { }

        public static int ConvertRomanToArabic(string roman)
        {
            List<int> queue = new List<int>();

            int counter = 0;
            int repeatCounter = 0;
            while (true)
            {
                if (counter == roman.Length)
                    break;
                int tmp = ConvertSingleRomanToArabic(roman[counter].ToString());

                if (queue.Count == 0)
                {
                    queue.Add(tmp);
                }
                else
                {
                    if (tmp == queue[queue.Count - 1])
                    {
                        repeatCounter++;
                        if (repeatCounter > 2)
                            throw new InvalidRomanNumberException();
                        queue.Add(tmp);
                    }
                    else if (tmp < queue[queue.Count - 1])
                    {
                        queue.Add(tmp);
                        repeatCounter = 0;
                    }
                    else
                    {
                        int previous = queue[queue.Count - 1];
                        switch (tmp)
                        {
                            case 5:
                            case 10:
                                if (previous != 1)
                                    throw new InvalidRomanNumberException();
                                break;
                            case 50:
                            case 100:
                                if (previous != 10)
                                    throw new InvalidRomanNumberException();
                                break;
                            case 500:
                            case 1000:
                                if (previous != 100)
                                    throw new InvalidRomanNumberException();
                                break;
                        }
                        queue[queue.Count - 1] = tmp - previous;
                        if (queue.Count > 1 && queue[queue.Count - 1] > queue[queue.Count - 2])
                            throw new InvalidRomanNumberException();
                        repeatCounter = 0;
                    }
                }
                counter++;
            }

            return queue.Sum();
        }

        public static int ConvertSingleRomanToArabic(string roman)
        {
            RomanBase tmp = RomanBase.I;
            if (!Enum.TryParse<RomanBase>(roman, true, out tmp))
                throw new InvalidRomanNumberException();
            return (int)tmp;
        }

        public static string ConvertArabicToRoman(int arabic)
        {
            throw new NotImplementedException();
        }
    }

    public class InvalidRomanNumberException : Exception
    {
        public override string Message
        {
            get
            {
                return "No a valid Roman Number! Roman Number is composed by I,V,X,L,C,D,M.";
            }
        }
    }
}
