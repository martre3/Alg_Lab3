using System;
using System.Linq;

namespace Lab3
{
    public class DataSetsSorter: IDataSetsSorter, ITestable
    {
        private int[] dataSet;
        private int setsCount;

        public DataSetsSorter(int[] dataSet, int setsCount)
        {
            this.dataSet = dataSet;
            this.setsCount = setsCount;
        }

        public void RunTest()
        {
            this.Sort();    
        }

        public void Sort()
        {
            ISort sortAlg = SortFactory.CreateSort(SortType.HeapSort);

            for (int i = 0; i < setsCount; i++)
            {
                int[] copy = dataSet.Select(a => a).ToArray(); 
                sortAlg.Sort(copy);
            }
        }
    }
}
