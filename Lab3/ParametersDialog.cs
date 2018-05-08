using System;
namespace Lab3
{
    public class ParametersDialog
    {

        public int ShowMessageAndGetEnteredInt(string message, int defaultValue)
        {
            PrintMessage(message, defaultValue);
            return GetInput(message, defaultValue);
        }

        private void PrintMessage(String message, int defaultValue)
        {
            Console.Write(message + "[" + defaultValue + "]:"); 
        }

        private int GetInput(string message, int defaultValue)
        {
            int? newValue = null;
            while (newValue == null)
            {
                string enteredValue = Console.ReadLine();
                if (enteredValue.Length == 0)
                {
                    return defaultValue;
                }
                try
                {
                    newValue = Convert.ToInt32(enteredValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    PrintMessage(message, defaultValue);
                }
            }
            return (int)newValue;
        }
    }
}
