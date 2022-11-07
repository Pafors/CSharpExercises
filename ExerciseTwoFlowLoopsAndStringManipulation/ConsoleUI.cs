using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    internal class ConsoleUI: IUI
    {
        public string InputData()
        {
            return Console.ReadLine()!;
        }

        public void OutputData(string outData)
        {
            // Selected to use "Write" instead of "WriteLine" for more flexibility, you can always add an '\n' if needed
            Console.Write(outData);
        }
    }
}
