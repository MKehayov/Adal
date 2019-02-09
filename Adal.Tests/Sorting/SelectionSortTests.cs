namespace Adal.Tests.Sorting
{
    using Adal.Sorting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class SelectionSortTests
    {
        private readonly int[] arrayToBeSorted = new int[] { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
        private readonly int[] sortedArray = new int[] { 2, 3, 4, 5, 15, 19, 26, 27, 36, 38, 44, 46, 47, 48, 50 };

        [TestMethod]
        public void TestIfArrayCorrectlySorted()
        {
            var result = Sorting<int>.SelectionSort(arrayToBeSorted);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], result[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfReturnedExceptionWhenInputNull()
        {
            var result = Sorting<int>.SelectionSort(null);
        }
    }
}
