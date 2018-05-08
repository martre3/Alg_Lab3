using System;
namespace Lab3
{
    public class FirstAssignment : IAssignment
    {
        private int dataSize = 7500000;
        private int setCount = 1;

        public void Execute()
        {
            UpdateParameters();

            Console.WriteLine("Masyvu kiekis: {0}", setCount);
            Console.WriteLine("Masyvo ilgis: {0}", dataSize);
            int[] dataSet = new RandomDataSetGenerator().Generate(dataSize);

            IDataSetsSorter sorter = new DataSetsSorter(dataSet, setCount);
            SpeedTest speedTest = new SpeedTest(sorter as ITestable);
            speedTest.ExecuteTest();
            Console.WriteLine("Laikas masyvus rikiuojant is eiles: {0}", speedTest.getStopwatch().ElapsedTicks);

            IDataSetsSorter threadedSorter = new DataSetsThreadedSorter(dataSet, setCount);
            speedTest = new SpeedTest(threadedSorter as ITestable);
            speedTest.ExecuteTest();
            Console.WriteLine("Laikas masyvus rikiuojant lygiagreciai: {0}", speedTest.getStopwatch().ElapsedTicks);
        }

        private void UpdateParameters()
        {
            ParametersDialog dialog = new ParametersDialog();
            dataSize = dialog.ShowMessageAndGetEnteredInt("Iveskite masyvo elementu skaiciu", dataSize);
            setCount = dialog.ShowMessageAndGetEnteredInt("Iveskite masyvu kieki", setCount);
        }
    }
}
