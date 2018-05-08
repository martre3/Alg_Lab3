using System;
using System.IO;
using System.Diagnostics;

namespace Lab3
{
    class SpeedTest
    {
        private ITestable test;
        private Stopwatch stopWatch;

        public SpeedTest(ITestable test)
        {
            this.test = test;
            stopWatch = new Stopwatch();
        }

        public void ExecuteTest()
        {
            stopWatch.Start();
            test.RunTest();
            stopWatch.Stop();
        }

        public Stopwatch getStopwatch()
        {
            return stopWatch;
        }
    }
}
