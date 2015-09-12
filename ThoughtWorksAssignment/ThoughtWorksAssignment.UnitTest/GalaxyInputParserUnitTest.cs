using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ThoughtWorksAssignment.UnitTest
{
    [TestClass]
    public class GalaxyInputParserUnitTest
    {
        [TestMethod]
        public void TestUnitDefinition()
        {
            List<string> inputs = new List<string>();
            inputs.Add("glob is I");
            inputs.Add("prok is V");
            inputs.Add("pish is X");
            inputs.Add("tegj is L");

            RomanNumberConvertor convertor = new RomanNumberConvertor();
            GalaxyInputParser parser = new GalaxyInputParser(convertor);
            parser.Parse(inputs);

            Assert.AreEqual<string>("I", parser.UnitDictionary["glob"]);
            Assert.AreEqual<string>("V", parser.UnitDictionary["prok"]);
            Assert.AreEqual<string>("X", parser.UnitDictionary["pish"]);
            Assert.AreEqual<string>("L", parser.UnitDictionary["tegj"]);
        }

        [TestMethod]
        public void TestWealthDefinition()
        {
            List<string> inputs = new List<string>();
            inputs.Add("glob is I");
            inputs.Add("prok is V");
            inputs.Add("pish is X");
            inputs.Add("tegj is L");
            inputs.Add("glob glob Silver is 34 Credits");
            inputs.Add("glob prok Gold is 57800 Credits");
            inputs.Add("pish pish Iron is 3910 Credits");

            RomanNumberConvertor convertor = new RomanNumberConvertor();
            GalaxyInputParser parser = new GalaxyInputParser(convertor);
            parser.Parse(inputs);

            Assert.AreEqual<double>(17, parser.WealthDictionary["Silver"]);
            Assert.AreEqual<double>(14450, parser.WealthDictionary["Gold"]);
            Assert.AreEqual<double>(195.5, parser.WealthDictionary["Iron"]);
        }

        [TestMethod]
        public void TestWealthDefinition_1()
        {
            Dictionary<string, string> unitDic = new Dictionary<string, string>();
            unitDic.Add("glob", "I");
            unitDic.Add("prok", "V");
            unitDic.Add("pish", "X");
            unitDic.Add("tegj", "L");

            RomanNumberConvertor convertor = new RomanNumberConvertor();
            GalaxyInputParser parser = new GalaxyInputParser(convertor);

            KeyValuePair<string, double> kvp = parser.ParseWealthPrice_1(unitDic, "glob glob Silver is 34 Credits");
            Assert.AreEqual<string>("Silver", kvp.Key);
            Assert.AreEqual<double>(17, kvp.Value);

            kvp = parser.ParseWealthPrice_1(unitDic, "glob prok Gold is 57800 Credits");
            Assert.AreEqual<string>("Gold", kvp.Key);
            Assert.AreEqual<double>(14450, kvp.Value);

            kvp = parser.ParseWealthPrice_1(unitDic, "pish pish Iron is 3910 Credits");
            Assert.AreEqual<string>("Iron", kvp.Key);
            Assert.AreEqual<double>(195.5, kvp.Value);
        }

        [TestMethod]
        public void TestUnitQuestion()
        {
            List<string> inputs = new List<string>();
            inputs.Add("glob is I");
            inputs.Add("prok is V");
            inputs.Add("pish is X");
            inputs.Add("tegj is L");
            //inputs.Add("glob glob Silver is 34 Credits");
            //inputs.Add("glob prok Gold is 57800 Credits");
            //inputs.Add("pish pish Iron is 3910 Credits");
            inputs.Add("how much is pish tegj glob glob ?");

            RomanNumberConvertor convertor = new RomanNumberConvertor();
            GalaxyInputParser parser = new GalaxyInputParser(convertor);
            parser.Parse(inputs);

            Assert.AreEqual<string>("pish tegj glob glob is 42", parser.Output[0]);
        }

        [TestMethod]
        public void TestWealthQuestion()
        {
            List<string> inputs = new List<string>();
            inputs.Add("glob is I");
            inputs.Add("prok is V");
            inputs.Add("pish is X");
            inputs.Add("tegj is L");
            inputs.Add("glob glob Silver is 34 Credits");
            inputs.Add("glob prok Gold is 57800 Credits");
            inputs.Add("pish pish Iron is 3910 Credits");
            inputs.Add("how much is pish tegj glob glob ?");
            inputs.Add("how many Credits is glob prok Silver ?");
            inputs.Add("how many Credits is glob prok Gold ?");
            inputs.Add("how many Credits is glob prok Iron ?");
            inputs.Add("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");

            RomanNumberConvertor convertor = new RomanNumberConvertor();
            GalaxyInputParser parser = new GalaxyInputParser(convertor);
            parser.Parse(inputs);

            Assert.AreEqual<string>("pish tegj glob glob is 42", parser.Output[0]);
            Assert.AreEqual<string>("glob prok Silver is 68 Credits", parser.Output[1]);
            Assert.AreEqual<string>("glob prok Gold is 57800 Credits", parser.Output[2]);
            Assert.AreEqual<string>("glob prok Iron is 782 Credits", parser.Output[3]);
            Assert.AreEqual<string>("I have no idea what you are talking about", parser.Output[4]);
        }
    }
}
