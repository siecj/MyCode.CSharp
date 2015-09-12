using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThoughtWorksAssignment.UnitTest
{
    [TestClass]
    public class RomanConvertorUnitTest
    {
        [TestMethod]
        public void TestRomanToArabic_1_10()
        {
            IArabicConvertable conv = new RomanNumberConvertor();
            Assert.AreEqual<int>(1, conv.ConvertToArabic("I"));
            Assert.AreEqual<int>(2, conv.ConvertToArabic("II"));
            Assert.AreEqual<int>(3, conv.ConvertToArabic("III"));
            Assert.AreEqual<int>(4, conv.ConvertToArabic("IV"));
            Assert.AreEqual<int>(5, conv.ConvertToArabic("V"));
            Assert.AreEqual<int>(6, conv.ConvertToArabic("VI"));
            Assert.AreEqual<int>(7, conv.ConvertToArabic("VII"));
            Assert.AreEqual<int>(8, conv.ConvertToArabic("VIII"));
            Assert.AreEqual<int>(9, conv.ConvertToArabic("IX"));
            Assert.AreEqual<int>(10, conv.ConvertToArabic("X"));
        }

        [TestMethod]
        public void TestRomanToArabic_10_100()
        {
            IArabicConvertable conv = new RomanNumberConvertor();
            Assert.AreEqual<int>(10, conv.ConvertToArabic("X"));
            Assert.AreEqual<int>(12, conv.ConvertToArabic("XII"));
            Assert.AreEqual<int>(14, conv.ConvertToArabic("XIV"));
            Assert.AreEqual<int>(16, conv.ConvertToArabic("XVI"));
            Assert.AreEqual<int>(20, conv.ConvertToArabic("XX"));
            Assert.AreEqual<int>(29, conv.ConvertToArabic("XXIX"));
            Assert.AreEqual<int>(65, conv.ConvertToArabic("LXV"));
            Assert.AreEqual<int>(98, conv.ConvertToArabic("XCVIII"));
            Assert.AreEqual<int>(99, conv.ConvertToArabic("XCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_100_1000()
        {
            IArabicConvertable conv = new RomanNumberConvertor();
            Assert.AreEqual<int>(100, conv.ConvertToArabic("C"));
            Assert.AreEqual<int>(212, conv.ConvertToArabic("CCXII"));
            Assert.AreEqual<int>(300, conv.ConvertToArabic("CCC"));
            Assert.AreEqual<int>(400, conv.ConvertToArabic("CD"));
            Assert.AreEqual<int>(500, conv.ConvertToArabic("D"));
            Assert.AreEqual<int>(600, conv.ConvertToArabic("DC"));
            Assert.AreEqual<int>(700, conv.ConvertToArabic("DCC"));
            Assert.AreEqual<int>(800, conv.ConvertToArabic("DCCC"));
            Assert.AreEqual<int>(900, conv.ConvertToArabic("CM"));
            Assert.AreEqual<int>(999, conv.ConvertToArabic("CMXCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_1K_10K()
        {
            IArabicConvertable conv = new RomanNumberConvertor();
            Assert.AreEqual<int>(1400, conv.ConvertToArabic("MCD"));
            Assert.AreEqual<int>(1600, conv.ConvertToArabic("MDC"));
            Assert.AreEqual<int>(1666, conv.ConvertToArabic("MDCLXVI"));
            Assert.AreEqual<int>(1888, conv.ConvertToArabic("MDCCCLXXXVIII"));
            Assert.AreEqual<int>(1899, conv.ConvertToArabic("MDCCCXCIX"));
            Assert.AreEqual<int>(1900, conv.ConvertToArabic("MCM"));
            Assert.AreEqual<int>(1976, conv.ConvertToArabic("MCMLXXVI"));
            Assert.AreEqual<int>(1984, conv.ConvertToArabic("MCMLXXXIV"));
            Assert.AreEqual<int>(1990, conv.ConvertToArabic("MCMXC"));
            Assert.AreEqual<int>(3999, conv.ConvertToArabic("MMMCMXCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_Invalid()
        {
            IArabicConvertable conv = new RomanNumberConvertor();
            try
            {
                int i = conv.ConvertToArabic("IIII");
                Assert.Fail("IIII is an invalid Roman Number, but conver to {0}", i);
            }
            catch (InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = conv.ConvertToArabic("VX");
                Assert.Fail("VX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = conv.ConvertToArabic("IIX");
                Assert.Fail("IIX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = conv.ConvertToArabic("IXX");
                Assert.Fail("IXX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
