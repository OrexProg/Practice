using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ForMath
    {
        /// <summary>
        /// Подсчет суммы чисел кратных 5 и 3
        /// </summary>
        /// <param name="maxNum">до какого числа ищем</param>
        /// <returns></returns>
        public static int SumCrat5and3(int maxNum)
        {
            int result = 0;
            for(int i = 0; i < maxNum; i++)
            {
                if(i.ToString().Last() == '5' || i.ToString().Last() == '0')
                {
                    result += i;
                    continue;
                }
                int check = 0;
                i.ToString().ToList().ForEach(x =>
                {
                    check += Convert.ToInt32(x);
                });
                if (check % 3 == 0)
                {
                    result += i;
                }
            }
            return result;
        }
        /// <summary>
        /// Поиск суммы четных чисел фибоначи
        /// </summary>
        /// <param name="maxNum">макимальное число фибоначи</param>
        /// <returns></returns>
        public static int SumEvenNumFi(int maxNum)
        {
            Int32 result = 2;
            int prev1 = 1;
            int prev2 = 2;
            while (result < maxNum)
            {
                int now = prev1 + prev2;
                if (now % 2 == 0)
                    result += now;
                prev1 = prev2;
                prev2 = now;
            }

            return result;
        }

        /// <summary>
        /// Поиск максимально больших делителей(простых) числа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string MaxPrimeDevisior(long num)
        {
            string result = null;

            long primeNum = 0;
            long currentNum = num;
            while (primeNum != 1)
            {
                primeNum = NextNumber(currentNum, ref result);
                currentNum = currentNum / primeNum ;
            }
            return result;
        }
        //Поиск простых делителей
        private static long NextNumber(long number,ref string resultText)
        {
            long curentNum = 1;
            long divis = FindDivision(number, ref curentNum);
            long divisPrime = number / divis;
            while (!Form1.IsPrime(divisPrime)&&number != divis)
            {
                divis = FindDivision(number,ref divis);
                divisPrime = number / divis;
            }
            resultText += number == divis ? number : divisPrime + ",";

            return divisPrime;
        }

        private static long FindDivision(long num,ref long curentNum)
        {
            for(long i = curentNum+1; i < num; i++)
            {
                if (num % i == 0)
                {
                    curentNum = i;
                    return i;
                }
                   
            }
            return num;
        }

    }
}
