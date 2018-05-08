using System;
namespace Lab3
{
    public class RandomDataSetGenerator
    {
        private Random random = new Random();

        public int[] Generate(int amount)
        {
            int[] dataSet = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                dataSet[i] = random.Next();
            }

            return dataSet;
        }
    }
}
