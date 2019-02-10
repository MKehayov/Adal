namespace Adal.Sorting
{
    using System;
    using System.Collections.Generic;

    internal static class MergeSorter
    {
        internal static void Sort<T>(IList<T> dataCollection, Func<T, T, bool> directionCompareFunction) 
            where T : IComparable
        {
            if (dataCollection == null)
            {
                throw new ArgumentNullException("Parameter " + nameof(dataCollection) + ", cannot be null!");
            }

            InternalSort(dataCollection, 0, dataCollection.Count - 1, directionCompareFunction);
        }

        private static void InternalSort<T>(IList<T> dataCollection, int startIndex, int endIndex, Func<T, T, bool> directionCompareFunction)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int midIndex = (startIndex + endIndex) / 2;

            InternalSort(dataCollection, startIndex, midIndex, directionCompareFunction);
            InternalSort(dataCollection, midIndex + 1, endIndex, directionCompareFunction);
            InternalMerge(dataCollection, startIndex, midIndex, endIndex, directionCompareFunction);
        }

        private static void InternalMerge<T>(IList<T> dataCollection, int startIndex, int midIndex, int endIndex, Func<T, T, bool> directionCompareFunction)
        {
            int leftHalfLength = midIndex - startIndex + 1;
            int rightHalfLength = endIndex - midIndex;

            IList<T> leftHalfArray = new T[leftHalfLength];
            IList<T> rightHalfArray = new T[rightHalfLength];

            for (int i = 0; i < leftHalfLength; i++)
            {
                leftHalfArray[i] = dataCollection[startIndex + i];
            }

            for (int i = 0; i < rightHalfLength; i++)
            {
                rightHalfArray[i] = dataCollection[midIndex + i + 1];
            }

            int leftHalfIndex = 0;
            int rightHalfIndex = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftHalfIndex >= leftHalfLength)
                {
                    dataCollection[i] = rightHalfArray[rightHalfIndex];
                    rightHalfIndex++;
                }
                else if (rightHalfIndex >= rightHalfLength)
                {
                    dataCollection[i] = leftHalfArray[leftHalfIndex];
                    leftHalfIndex++;
                }
                else
                {
                    if (!directionCompareFunction(leftHalfArray[leftHalfIndex], rightHalfArray[rightHalfIndex]))
                    {
                        dataCollection[i] = leftHalfArray[leftHalfIndex];
                        leftHalfIndex++;
                    }
                    else
                    {
                        dataCollection[i] = rightHalfArray[rightHalfIndex];
                        rightHalfIndex++;
                    }
                }
            }
        }
    }
}
