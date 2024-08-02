using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task_1
{
    internal class Square
    {

        private char symbol;
        private int length;

        public Square(char symbolP, int lengthP)
        {
            symbol = symbolP;
            length = lengthP;
        }

        public void drawSquare()
        {
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                    Console.Write(symbol + " ");
                Console.WriteLine();
            }
        }

        public void drawEmptySquare()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == 0 || i == length - 1 || j == 0 || j == length - 1)
                        Console.Write(symbol + " ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }
        }

    }
}
