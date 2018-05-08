using System;
using System.Threading;

namespace Lab3
{
    public class ThreadedRecursive: FTask
    {
        
        static int[] results;
        static int threadsCompleted;
        static readonly object resultLock = new object();

        public ThreadedRecursive(int[] x, int[] y)
            : base(x, y)
        {

        }

        protected override int Execute()
        {
            return SplitToThreads(x.Length - 1, y.Length - 1);
        }

        private int SplitToThreads(int m, int n)
        {
            ThreadedRecursive.results = new int[3];
            ThreadedRecursive.threadsCompleted = 0;

            StartThread(m - 1, n, 0);
            StartThread(m, n - 1, 1);
            StartThread(m - 1, n - 1, 2);

            while(ThreadedRecursive.threadsCompleted < 3)
            {
                Thread.Sleep(100);
            }

            return Math.Min(1 + ThreadedRecursive.results[0], Math.Min(1 + ThreadedRecursive.results[1], D(m, n) + ThreadedRecursive.results[2]));
        }

        private void StartThread(int m, int n, int placeInResultArray)
        {
            ThreadStart starter = delegate { ExecuteThread(m, n, placeInResultArray); };
            new Thread(starter).Start();
        }

        private static void ExecuteThread(int m, int n, int placeInResultArray)
        {
            int result = F(m, n);

            lock (resultLock)
            {
                results[placeInResultArray] = result;
                threadsCompleted++;
            }
        }

        private static int F(int m, int n)
        {
            if (n == 0)
                return m;

            if (m == 0)
                return n;

            return Math.Min(1 + F(m - 1, n), Math.Min(1 + F(m, n - 1), D(m, n) + F(m - 1, n - 1)));
        }
    }
}
