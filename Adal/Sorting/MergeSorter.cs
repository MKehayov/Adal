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

            //TODO
        }
    }
}
