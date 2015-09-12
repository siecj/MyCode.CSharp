using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThoughtWorksAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                inputs.Add(line);
            }

            GalaxyInputParser parser = new GalaxyInputParser(new RomanNumberConvertor());
            parser.Parse(inputs);

            foreach (var line in parser.Output)
            {
                Console.WriteLine(line);
            }

        }
    }
}
