namespace Adal.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class Sorting
    {
        private static Func<T, T, bool> GetSortDirectionFunction<T>(SortDirection sortDirection)
            where T : IComparable
        {
            switch (sortDirection)
            {
                case SortDirection.Asc:
                    return (a, b) => (a.CompareTo(b) > 0);
                case SortDirection.Desc:
                    return (a, b) => (a.CompareTo(b) < 0);
                default:
                    throw new ArgumentException("Unknown sort direction!");
            }
        }

        public static void SelectionSort<T>(IList<T> dataCollection, SortDirection sortDirection = SortDirection.Asc)
            where T : IComparable
        {
            SelectionSorter.Sort(dataCollection, GetSortDirectionFunction<T>(sortDirection));
        }

        public static void MergeSort<T>(IList<T> dataCollection, SortDirection sortDirection = SortDirection.Asc)
            where T : IComparable
        {
            MergeSorter.Sort(dataCollection, GetSortDirectionFunction<T>(sortDirection));            
        }
    }
}
