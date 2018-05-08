using System;
namespace Lab3
{
    abstract public class FTask: ITestable
    {
        protected static int[] x;
        protected static int[] y;

        protected FTask(int[] x, int[] y)
        {
            FTask.x = x;
            FTask.y = y;
        }

        public void RunTest()
        {
            Console.WriteLine("Rezultatas: " + this.Execute());
        }

        abstract protected int Execute();

        protected static int D(int m, int n)
        {
            if (x[m] == y[n])
                return 1;
            return 0;
        }
    }
}
