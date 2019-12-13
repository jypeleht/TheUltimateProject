using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.JarmoKarna
{
    public static class Program
    {
        static bool exit = false;
        static bool left = false;
        static bool right = false;

        public static void JarmoKarna()
        {
            Thread thread = new Thread(keyListener);
            thread.Start();
            int position = 9;
            int paceSetter = 1;

            while (!exit)
            {
                Console.WriteLine("Paina q-kirjain lopettaaksesi");

                for (int i = 0; i < 24; i++) //HACK radan kokoa suurennettu 16sta -> 24
                {
                    if (((i - paceSetter) % 4) == 0)
                    {
                        Console.WriteLine("|        |        |");
                    }
                    else
                    {
                        Console.WriteLine("|                 |");
                    }
                }

                if (left) position--;
                if (right) position++;

                for (int i = 0; i < 19; i++)
                {
                    if (i == position) Console.Write("*");
                    else Console.Write(" ");
                }

                left = false;
                right = false;

                Thread.Sleep(90); //HACK nopeutta lisätty vähäsen

                paceSetter++;

                if (paceSetter > 4) paceSetter = 1;

                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }

            exit = false;
        }

        private static void keyListener()
        {
            while (!exit)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        left = true;
                        right = false;
                        break;
                    case ConsoleKey.RightArrow:
                        left = false;
                        right = true;
                        break;
                    default:
                        left = false;
                        right = false;
                        break;
                }
            }
        }
    }
}
