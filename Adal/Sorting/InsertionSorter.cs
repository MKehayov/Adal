namespace Adal.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class InsertionSorter
    {
        internal static void Sort<T>(IList<T> dataCollection, Func<T, T, bool> directionCompareFunction)
            where T : IComparable
        {
            if (dataCollection == null)
            {
                throw new ArgumentNullException("Parameter " + nameof(dataCollection) + ", cannot be null!");
            }

            for (int i = 1; i < dataCollection.Count; i++)
            {
                var elementToSort = dataCollection[i];

                int j = i - 1;
                while (j >= 0 && !directionCompareFunction(elementToSort, dataCollection[j]))
                {
                    dataCollection[j + 1] = dataCollection[j];
                    j = j - 1;
                }
                dataCollection[j + 1] = elementToSort;
            }
        }
    }
}
