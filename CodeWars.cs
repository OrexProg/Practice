using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice
{
    public class CodeWars
    {
        #region Решено

        /// <summary>
        /// Все знаки кроме последних 4 заменить
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private string Maskify(string cc)
        {
            var result = new StringBuilder();

            for (int i = 0; i < cc.Length; i++)
            {
                if (i < cc.Length - 4)
                    result.Append("#");
                else
                    result.Append(cc[i]);
            }
            return result.ToString();
            //BP
            //return cc.Substring(cc.Length < 4 ? 0 : cc.Length - 4).PadLeft(cc.Length, '#');
        }

        /// <summary>
        /// Сумма всех чисел от 0 до value кратных 3 или 5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int SumNumbersMultOf3and5(int value)
        {
            if (value <= 0) return 0;
            var result = 0;
            for (int i = 0; i < value; i++)
            {
                var allNumbers = i.ToString().ToList().Select(x => Convert.ToInt32(x.ToString())).ToList();
                if ((allNumbers.Last() == 5 || allNumbers.Last() == 0) || allNumbers.Sum() % 3 == 0)
                    result += i;
            }
            return result;
        }

        /// <summary>
        /// Перемещение 0 в конец
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int[] MoveZeroes(int[] arr)
        {
            //BP
            //return arr.Where(x=>x!=0).Concat(arr.Where(x=>x==0)).ToArray();
            int[] result = new int[arr.Length];
            int currentPosition = 0;
            int countZero = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    countZero++;
                }
                else
                {
                    result[currentPosition++] = arr[i];
                }

            }

            for (int i = 0; i < countZero; i++)
            {
                result[currentPosition++] = 0;
            }

            return result;
        }
        #endregion


    }
}
