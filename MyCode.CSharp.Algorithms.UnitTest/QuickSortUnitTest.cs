using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyCode.CSharp.Algorithms.UnitTest
{
    [TestClass]
    public class QuickSortUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> src = new List<int> { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
            QuickSort.Sort(src, 0, src.Count - 1);

            foreach (var item in src)
            {
                Trace.Write(string.Format("{0},", item));
            }
        }

        [TestMethod]
        public void PartitionTestMethod_1()
        {
            List<int> src = new List<int> { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
            int mid = QuickSort.Partition(src, 0, src.Count - 1);
            Assert.AreEqual(7, mid);
        }
    }
}
