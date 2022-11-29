namespace Exercise_5_Garage.UI
{
    internal class ConsoleUI : IUI
    {
        public string InputData()
        {
            return Console.ReadLine()!;
        }
        public void OutputData(string outText)
        {
            Console.Write(outText);
        }
    }
}
