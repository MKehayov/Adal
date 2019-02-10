namespace Adal.Sorting
{
    using System;
    using System.Collections.Generic;

    internal static class SelectionSorter
    {
        internal static void Sort<T>(IList<T> dataCollection, Func<T, T, bool> directionCompareFunction)
            where T : IComparable
        {
            if (dataCollection == null)
            {
                throw new ArgumentNullException("Parameter " + nameof(dataCollection) + ", cannot be null!");
            }


            int minMaxValueElementIndex;
            bool shouldSwap = false;

            for (int i = 0; i < dataCollection.Count; i++)
            {
                minMaxValueElementIndex = i;

                for (int j = i + 1; j < dataCollection.Count; j++)
                {
                    if (directionCompareFunction(dataCollection[minMaxValueElementIndex], dataCollection[j]))
                    {
                        minMaxValueElementIndex = j;
                        shouldSwap = true;
                    }
                }

                if (shouldSwap)
                {
                    var tmp = dataCollection[i];
                    dataCollection[i] = dataCollection[minMaxValueElementIndex];
                    dataCollection[minMaxValueElementIndex] = tmp;

                    shouldSwap = false;
                }
            }
        }
    }
}
