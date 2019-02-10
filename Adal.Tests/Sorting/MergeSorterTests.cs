namespace Adal.Tests.Sorting
{
    using Adal.Sorting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class MergeSorterTests
    {
        private readonly int[] arrayToBeSorted = new int[] { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
        private readonly int[] sortedArray = new int[] { 2, 3, 4, 5, 15, 19, 26, 27, 36, 38, 44, 46, 47, 48, 50 };

        [TestMethod]
        public void TestIfArrayCorrectlySortedAsc()
        {
            var testArray = arrayToBeSorted;

            Sorting.MergeSort(testArray);

            for (int i = 0; i < testArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], testArray[i]);
            }
        }

        [TestMethod]
        public void TestIfArrayCorrectlySortedDesc()
        {
            var testArray = arrayToBeSorted;

            Sorting.MergeSort(testArray, SortDirection.Desc);

            for (int i = 0; i < testArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[sortedArray.Length - 1 - i], testArray[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfReturnedExceptionWhenInputNull()
        {
            Sorting.MergeSort<int>(null);
        }
    }
}
