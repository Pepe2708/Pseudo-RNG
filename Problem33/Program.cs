using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem33
{
    class Program
    {
        public static int sampleSize = 1000;
        public static int[] nums = new int[sampleSize];

        static void Main(string[] args)
        {
            IterativeRNG(0, 25173, 13849, (int)Math.Pow(2, 16)); // 25 173x + 13 849 (mod 2^16)

            CalculateAverage(nums);

            IndividualNumberQuantity(nums);

            DetectCycle(nums);

            Console.ReadKey();
        }

        static void RecursiveRNG(int seed, int k, int m, int mod)
        {
            int num = seed;
            num = (k * num + m) % mod;
            Console.WriteLine(num >> 7);
            RecursiveRNG(num, k, m, mod);
        }

        static void IterativeRNG(int seed, int k, int m, int mod)
        {
            int num = seed;
            for (int i = 0; i < sampleSize; i++)
            {
                num = (k * num + m) % mod;
                nums[i] = num >> 7;
            }
        }

        static void CalculateAverage(int[] nums)
        {
            Console.WriteLine("Average number: " + (float)nums.Sum() / (float)nums.Count());
        }

        static void IndividualNumberQuantity(int[] nums)
        {
            List<int> quantities = new List<int>();
            Array.Sort(nums);
            int temp = 0;
            for (int i = 1; i < nums.Count(); i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    quantities.Add(i - temp);
                    temp = i;
                }
            }

            Console.WriteLine("Average number quanity: " + (float)quantities.Sum() / (float)quantities.Count());
        }

        static void DetectCycle(int[] nums) // Only works if seed = 0
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                int temp = 0;
                if (nums[i] == nums[0])
                {
                    if (i - temp == 4)
                    {
                        if (i > 4)
                        {
                            Console.WriteLine("Cycle detected at: " + i);
                        }
                    }
                    temp = i;
                }
            }
            Console.WriteLine("No cycle detected");
        }
    }
}
