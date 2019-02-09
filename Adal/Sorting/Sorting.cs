namespace Adal.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class Sorting<T> where T : IComparable
    {
        public static T[] SelectionSort(ICollection<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Parameter " + nameof(data) + ", cannot be null!");
            }
        
            T[] sortedData = new T[data.Count];
            data.CopyTo(sortedData, 0);

            int minValueElementIndex;
            bool shouldSwap = false;

            for (int i = 0; i < sortedData.Length; i++)
            {
                minValueElementIndex = i;

                for (int j = i + 1; j < sortedData.Length; j++)
                {
                    if (sortedData[minValueElementIndex].CompareTo(sortedData[j]) > 0)
                    {
                        minValueElementIndex = j;
                        shouldSwap = true;
                    }
                }

                if (shouldSwap)
                {
                    var tmp = sortedData[i];
                    sortedData[i] = sortedData[minValueElementIndex];
                    sortedData[minValueElementIndex] = tmp;

                    shouldSwap = false;
                }
            }

            return sortedData;
        }
    }
}
