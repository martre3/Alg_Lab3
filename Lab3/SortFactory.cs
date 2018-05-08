using System;
namespace Lab3
{
    public static class SortFactory
    {
        public static ISort CreateSort(SortType type)
        {
            switch(type)
            {
                case SortType.HeapSort:
                    return new HeapSort();
                default:
                    return null;
            }
        }
    }
}
