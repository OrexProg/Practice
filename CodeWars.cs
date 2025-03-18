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
        /// Возвращаем время из секуннд в формате чч:мм:сс
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string GetReadableTime(int seconds)
        {
            /*
              Лучший вариант
            var t = TimeSpan.FromSeconds(seconds);
        return string.Format("{0:00}:{1:00}:{2:00}", (int)t.TotalHours, t.Minutes, t.Seconds);
             
             */

            int h = 0;
            int m = 0;
            int s = 0;

            if (seconds > 360060)
            {
                return "99;59;59";
            }
            if (seconds <= 59)
                return "00:00:" + (seconds > 9 ? seconds.ToString() : "0" + seconds.ToString());
            if (seconds <= 3599)
            {
                h = 0;
                m = seconds / 60;
                s = seconds - 60 * m;
            }
            else
            {
                h = seconds / 3600;
                var t = (seconds - 3600 * h);
                m = t / 60;
                s = t - m * 60;
            }

            return string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
        }
        public int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> result = new List<int>();

            result = a.ToList().Where(x => !b.ToList().Contains(x)).ToList();

            return result.ToArray();
        }

        public int DigitalRoot(long n)
        {
            long result = n;

            while (result.ToString().Length > 1)
            {
                result = result.ToString().ToList().Sum(x => Int32.Parse(x.ToString()));
            }

            return (int)result;
        }
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
