using System;
using System.Linq;

namespace shiftArray
{
    class Program
    {
        public const int LengthOfArray = 12;
        public static int K = 4;
        
        public static int Counter;
        public static int GCD = FindGCD(LengthOfArray, K);
        
        public static int FindGCD(int x, int y)
        {
            return y == 0 ? x : FindGCD(y, x % y);
        }
        
        public static void PrintArray(double[] array)
        {
            for (int i = 0; i < LengthOfArray; i++)
                Console.WriteLine(array[i]);
        }
        
        public static void PassArray(double[] array, int k, int index = 0)
        {
            Counter++;
            var targetIndex = index - k < 0 ? index - k + LengthOfArray : index - k;
            
            if (GCD != 1)
            {
                if (Counter % (LengthOfArray / GCD) != 0)
                    PassArray(array, k, targetIndex);
            }
            else if (Counter != LengthOfArray)
            {
                PassArray(array, k, targetIndex);
            }
            
            array[targetIndex] = array[index];
        }

        static void Main()
        {
            K = K > LengthOfArray ? K % LengthOfArray : K;
            
            var array = new double[LengthOfArray];
            for (int i = 0; i < LengthOfArray; i++)
                array[i] = i;
            
            for (int i = 0; i < GCD; i++)
            {
                var bufferEl = array[i];
                int targetBufferEl = i - K < 0
                    ? i - K + LengthOfArray
                    : i - K;
                PassArray(array, K, i);
                array[targetBufferEl] = bufferEl;
            }

            PrintArray(array);
        }
    }
}