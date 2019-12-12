using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WindowsFormsApp1.TapaniTarri
{
    public static class Program
    {
       


        public static void TapaniTarri()
        {
            int luku1 = 10; //Tämä määrää, montako numeroa sortataan
            int[] arr = new int[luku1];
            int luku2 = 0;
            Random rnd = new Random();
            do
            {

                int satunnaiskerroin = rnd.Next(0, luku1 + 10);  // creates a number between 0 and luku2
                                                                 //arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
                arr[luku2] = satunnaiskerroin;
                ++luku2;
            }
            while (luku1 > luku2);

            Console.WriteLine("Original array : ");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            Console.WriteLine();

            DateTime time1 = DateTime.Now;
            Console.WriteLine("Alkuaika: " + time1);

            Console.WriteLine();

            //Insertion_Sort() seuraavassa for (i = 0; i < arr.Length - 1; i++) -SILMUKASSA
            int flag, val, i, j;

            for (i = 1; i < arr.Length; i++)
            {
                val = arr[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;

                        //Console.WriteLine("Insertionsort-arvo silmukassa: " + val);
                    }
                    else flag = 1;
                }
            }

           
            Console.WriteLine();

            DateTime time2 = DateTime.Now;
            Console.WriteLine("Loppuaika: " + time2);

            Console.WriteLine();
            Console.WriteLine("Sorted array : ");

            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            Console.WriteLine();

            //DateTime time2 = DateTime.Now;
            //Console.WriteLine("Loppuaika: " + time2);

            Console.WriteLine("Lukuja sortattu:" + luku1);

            Console.ReadKey();
        }

        //internal static void TapaniTarri()
        //{
            //throw new NotImplementedException();
       // }
    }
}
