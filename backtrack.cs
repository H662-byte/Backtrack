using System;
using System.Collections.Generic;
using System.Linq;

namespace backtrack
{
    class Program
    {
        static Dictionary<string, long> CompanyName_Value = new Dictionary<string, long>();
        static Dictionary<long, long> Value_Profit = new Dictionary<long, long>();
        static int Num;
        static long[] valueOfsaham;
        static long[] ProfitOfsaham;
        static long n;
        static long[] a;
        static long W;

        static void Backtrack(int i)
        {


            if (i >= Num)
            {
                CheckMax(valueOfsaham, ProfitOfsaham,W);
            }
            else
            {
                a[i] = 0;
                Backtrack(i + 1);
                a[i] = 1;
                Backtrack(i + 1);
            }

        }

        static void CheckMax(long[] w, long[] v, long Max)
        {

            long maxvalue = 0;
            long weight = 0;
            long value = 0;
            for (int i = 0; i < Num; i++)  
            {
                if (a[i] == 1)
                {
                    weight = weight + w[i];
                    value = value + v[i];
                }
            }
            if (weight <= Max)
            {
                if (value >= maxvalue)
                {
                    maxvalue = value;
                    Console.WriteLine("The maximum value is:" + maxvalue + " ");
                    Console.WriteLine("The selected item is (1 means selected, 0 means unselected): ");
                    for (int j = 0; j < n; j++)
                    {
                        if (a[j] == 0)
                        {
                            Console.WriteLine($" {j} is not selected \n");
                        }
                        else
                        {
                            Console.WriteLine($"{j} is  selected \n");
                        }

                    }

                }

            }
        }








        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of  inputs:");


           
            Num = Int32.Parse(Console.ReadLine());

            a = new long[Num];
            for (int i = 0; i < Num; i++)
            {
                string first;
                long second = 0;
                Console.WriteLine($"Enter The company Name :{i}");

                first = Console.ReadLine();
                Console.WriteLine($"Enter The Value :{i}");
                second = long.Parse(Console.ReadLine());
                CompanyName_Value.Add(first, second);

            }
             valueOfsaham = new long[Num];
             ProfitOfsaham = new long[Num];

            int k = 0;
            foreach (KeyValuePair<string, long> ele1 in CompanyName_Value)
            {
                Console.WriteLine($"ENter the Profit for this Company:{ele1.Key} with this Value{ele1.Value}");
                valueOfsaham[k] = ele1.Value;

                long profit;
                profit = long.Parse(Console.ReadLine());
                ProfitOfsaham[k] = profit;
                Value_Profit.Add(ele1.Value, profit);
                k++;
            }



            Console.WriteLine("Your Inputs are :\nvalueOfsaham  -  Profit ");
            foreach (KeyValuePair<long, long> ele1 in Value_Profit)
            {
                Console.WriteLine("{0}              :     {1} ",
                            ele1.Key, ele1.Value);
            }

            Console.WriteLine();

            // long[] val = new long[] { 60, 100, 120 };
            //long[] wt = new long[] { 10, 20, 30 };

            Console.WriteLine("Please Enter The Max limit:\n");
             W = long.Parse(Console.ReadLine());
            //int n = val.Length;
            long n = valueOfsaham.Length;

            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();

            Backtrack(0);
            SW.Stop();
            Console.WriteLine(SW.ElapsedMilliseconds.ToString());


            Console.ReadLine();
        }
    }
}
