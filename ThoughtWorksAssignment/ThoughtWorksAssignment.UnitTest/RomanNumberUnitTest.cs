using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ThoughtWorksAssignment.Old;

namespace ThoughtWorksAssignment.UnitTest
{
    [TestClass]
    public class RomanNumberUnitTest
    {
        [TestMethod]
        public void TestRomanToArabic_1_10()
        {
            Assert.AreEqual<int>(1, RomanNumber.ConvertRomanToArabic("I"));
            Assert.AreEqual<int>(2, RomanNumber.ConvertRomanToArabic("II"));
            Assert.AreEqual<int>(3, RomanNumber.ConvertRomanToArabic("III"));
            Assert.AreEqual<int>(4, RomanNumber.ConvertRomanToArabic("IV"));
            Assert.AreEqual<int>(5, RomanNumber.ConvertRomanToArabic("V"));
            Assert.AreEqual<int>(6, RomanNumber.ConvertRomanToArabic("VI"));
            Assert.AreEqual<int>(7, RomanNumber.ConvertRomanToArabic("VII"));
            Assert.AreEqual<int>(8, RomanNumber.ConvertRomanToArabic("VIII"));
            Assert.AreEqual<int>(9, RomanNumber.ConvertRomanToArabic("IX"));
            Assert.AreEqual<int>(10, RomanNumber.ConvertRomanToArabic("X"));
        }

        [TestMethod]
        public void TestRomanToArabic_10_100()
        {
            Assert.AreEqual<int>(10, RomanNumber.ConvertRomanToArabic("X"));
            Assert.AreEqual<int>(12, RomanNumber.ConvertRomanToArabic("XII"));
            Assert.AreEqual<int>(14, RomanNumber.ConvertRomanToArabic("XIV"));
            Assert.AreEqual<int>(16, RomanNumber.ConvertRomanToArabic("XVI"));
            Assert.AreEqual<int>(20, RomanNumber.ConvertRomanToArabic("XX"));
            Assert.AreEqual<int>(29, RomanNumber.ConvertRomanToArabic("XXIX"));
            Assert.AreEqual<int>(65, RomanNumber.ConvertRomanToArabic("LXV"));
            Assert.AreEqual<int>(98, RomanNumber.ConvertRomanToArabic("XCVIII"));
            Assert.AreEqual<int>(99, RomanNumber.ConvertRomanToArabic("XCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_100_1000()
        {
            Assert.AreEqual<int>(100, RomanNumber.ConvertRomanToArabic("C"));
            Assert.AreEqual<int>(212, RomanNumber.ConvertRomanToArabic("CCXII"));
            Assert.AreEqual<int>(300, RomanNumber.ConvertRomanToArabic("CCC"));
            Assert.AreEqual<int>(400, RomanNumber.ConvertRomanToArabic("CD"));
            Assert.AreEqual<int>(500, RomanNumber.ConvertRomanToArabic("D"));
            Assert.AreEqual<int>(600, RomanNumber.ConvertRomanToArabic("DC"));
            Assert.AreEqual<int>(700, RomanNumber.ConvertRomanToArabic("DCC"));
            Assert.AreEqual<int>(800, RomanNumber.ConvertRomanToArabic("DCCC"));
            Assert.AreEqual<int>(900, RomanNumber.ConvertRomanToArabic("CM"));
            Assert.AreEqual<int>(999, RomanNumber.ConvertRomanToArabic("CMXCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_1K_10K()
        {
            Assert.AreEqual<int>(1400, RomanNumber.ConvertRomanToArabic("MCD"));
            Assert.AreEqual<int>(1600, RomanNumber.ConvertRomanToArabic("MDC"));
            Assert.AreEqual<int>(1666, RomanNumber.ConvertRomanToArabic("MDCLXVI"));
            Assert.AreEqual<int>(1888, RomanNumber.ConvertRomanToArabic("MDCCCLXXXVIII"));
            Assert.AreEqual<int>(1899, RomanNumber.ConvertRomanToArabic("MDCCCXCIX"));
            Assert.AreEqual<int>(1900, RomanNumber.ConvertRomanToArabic("MCM"));
            Assert.AreEqual<int>(1976, RomanNumber.ConvertRomanToArabic("MCMLXXVI"));
            Assert.AreEqual<int>(1984, RomanNumber.ConvertRomanToArabic("MCMLXXXIV"));
            Assert.AreEqual<int>(1990, RomanNumber.ConvertRomanToArabic("MCMXC"));
            Assert.AreEqual<int>(3999, RomanNumber.ConvertRomanToArabic("MMMCMXCIX"));
        }

        [TestMethod]
        public void TestRomanToArabic_Invalid()
        {
            try
            {
                int i = RomanNumber.ConvertRomanToArabic("IIII");
                Assert.Fail("IIII is an invalid Roman Number, but conver to {0}", i);
            }
            catch (Old.InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = RomanNumber.ConvertRomanToArabic("VX");
                Assert.Fail("VX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (Old.InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = RomanNumber.ConvertRomanToArabic("IIX");
                Assert.Fail("IIX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (Old.InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                int i = RomanNumber.ConvertRomanToArabic("IXX");
                Assert.Fail("IXX is an invalid Roman Number, but conver to {0}", i);
            }
            catch (Old.InvalidRomanNumberException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
