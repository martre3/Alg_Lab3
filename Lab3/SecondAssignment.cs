using System;
namespace Lab3
{
    public class SecondAssignment: IAssignment
    {
        int xSize = 10;
        int ySize = 10;

        public void Execute()
        {
            UpdateParameters();

            int[] x = new RandomDataSetGenerator().Generate(xSize);
            int[] y = new RandomDataSetGenerator().Generate(ySize);

            Console.WriteLine(xSize + " x " + ySize);
            SpeedTest speedTest = new SpeedTest(new Recursive(x, y));
            speedTest.ExecuteTest();
            Console.WriteLine("Laikas vykdant rekursyviai: {0}", speedTest.getStopwatch().ElapsedTicks);

            speedTest = new SpeedTest(new ThreadedRecursive(x, y));
            speedTest.ExecuteTest();
            Console.WriteLine("Laikas vykdant rekursyviai gijose: {0}", speedTest.getStopwatch().ElapsedTicks);
        }

        private void UpdateParameters()
        {
            ParametersDialog dialog = new ParametersDialog();
            xSize = dialog.ShowMessageAndGetEnteredInt("Iveskite pirmo masyvo dydi", xSize);
            ySize = dialog.ShowMessageAndGetEnteredInt("Iveskite antro masyvo dydi", ySize);
        }
    }
}
