using System;
using System.Linq;
using System.Threading;

namespace Lab3
{
    public class DataSetsThreadedSorter: IDataSetsSorter, ITestable
    {
        private int[] dataSet;
        private int setsCount;

        static int finishedThreads;

        static readonly object countLock = new object();

        public DataSetsThreadedSorter(int[] dataSet, int setsCount)
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
            DataSetsThreadedSorter.finishedThreads = 0;

            ISort sortAlg = SortFactory.CreateSort(SortType.HeapSort);

            for (int i = 0; i < setsCount; i++)
            {
                int[] copy = dataSet.Select(a => a).ToArray();
                ThreadStart starter = delegate { ThreadSort(sortAlg, copy); };
                new Thread(starter).Start();
            }

            while(DataSetsThreadedSorter.finishedThreads < setsCount)
            {
                Thread.Sleep(100);
            }
        }

        private static void ThreadSort(ISort sortAlg, int[] dataSet)
        {
            sortAlg.Sort(dataSet);

            lock (countLock)
            {
                finishedThreads++;
            }
        }
    }
}
