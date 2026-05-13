using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Practice
{
    public class CodeWars
    {
        public static string SpeedTest()
        {
            StringBuilder sb = new StringBuilder();
            var time = new Stopwatch();
            time.Start();
            CodeWars.Solution("samurai", "ai");
            CodeWars.Solution("sumo", "omo");
            CodeWars.Solution("ninja", "ja");
            CodeWars.Solution("sensei", "i");
            CodeWars.Solution("samurai", "ra");
            CodeWars.Solution("abc", "abcd");
            CodeWars.Solution("abc", "abc");
            time.Stop();
            sb.Append($"Мое время {time.ElapsedMilliseconds} Тики {time.ElapsedTicks}\r\n");
            time.Reset();
            time.Start();
            CodeWars.Solution("samurai", "ai");
            CodeWars.Solution("sumo", "omo");
            CodeWars.Solution("ninja", "ja");
            CodeWars.Solution("sensei", "i");
            CodeWars.Solution("samurai", "ra");
            CodeWars.Solution("abc", "abcd");
            CodeWars.Solution("abc", "abc");
            time.Stop();
            sb.Append($"Второе время {time.ElapsedMilliseconds} Тики {time.ElapsedTicks}\r\n");
            return sb.ToString();
        }
        /// <summary>
        /// Проверка на идеальное число
        /// Идеальное число это то которое можно представить ввиде степени n = m^k
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static (int, int)? IsPerfectPower(int n)
        {
            int k = 2;
            int kMax = (int)Math.Round(Math.Log2(n)) + 1;

            while (k <= kMax)
            {
                var m = Math.Pow(n, (double)1 / (double)k);
                m = Math.Round(m);
                if (Math.Pow(Math.Round(m),k) ==n)
                    return ((int)m, (int)k);

                k++;
            }

            return null;
        }

        #region Решено

        /// <summary>
        /// Нужно пострить квадрат 4 на 4 из блоков которые дают
        /// </summary>
        /// <param name="blocks"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        bool BuildSquare(int[] blocks)
        {
            if (blocks.Length < 4)
                return false;

            Dictionary<int, int> countBlocks = new Dictionary<int, int>();
            if (blocks.Where(x => x == 4).Count() > 3)
                return true;

            foreach (var item in blocks.GroupBy(x => x).Select(x => new int[] { x.Key, x.Count() }))
            {
                countBlocks.Add(item[0], item[1]);
            }

            int tall = 0;

            if (countBlocks.ContainsKey(4))
                tall = countBlocks[4];

            if (countBlocks.ContainsKey(3) && countBlocks.ContainsKey(1))
            {
                int maxCountPair = Math.Min(countBlocks[3], countBlocks[1]);
                countBlocks[1] = countBlocks[1] - maxCountPair;
                tall += maxCountPair;
                if (tall >= 4)
                    return true;
            }

            if (countBlocks.ContainsKey(2))
            {
                int maxPair2 = countBlocks[2] / 2;
                countBlocks[2] = countBlocks[2] - maxPair2;
                tall += maxPair2;
                if (tall >= 4)
                    return true;
                if (countBlocks.ContainsKey(1))
                {
                    var maxPair1 = countBlocks[1] / 2;
                    var pairs1and2 = Math.Min(maxPair1, countBlocks[2]);
                    tall += pairs1and2;
                    if (tall >= 4)
                        return true;
                    countBlocks[1] = countBlocks[1] - (pairs1and2 * 2);
                }
            }

            if (countBlocks.ContainsKey(1))
            {
                tall += countBlocks[1] / 4;
                if (tall >= 4)
                    return true;
            }

            return tall >= 4;
        }

        /// <summary>
        /// По милисекундам незначительно но по тикам 2 вариант значительно быстрее
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ending"></param>
        /// <returns></returns>
        static bool Solution2(string str, string ending) => str.EndsWith(ending);

        static bool Solution(string str, string ending)
        {
            //тоже самое можно сделать через   str.EndsWith(ending);

            var left = str.Length - 1;
            var right = ending.Length - 1;

            if (right > left)
                return false;

            while (right >= 0 && left >= 0)
            {
                if (str[left] != ending[right])
                    return false;
                left--;
                right--;
            }

            return true;
        }

        static List<char> list = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static string Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            StringBuilder result = new StringBuilder();
            int? previousPosition = null;
            var wordToChar = input.ToUpper().ToCharArray();

            foreach (var item in wordToChar)
            {
                int currentPosition = list.IndexOf(item);
                if (currentPosition != -1)
                {
                    if (previousPosition != null)
                    {
                        var newIndex = ((int)currentPosition + (int)previousPosition + 1) % list.Count();
                        result.Append(list[newIndex]);
                        previousPosition = currentPosition;
                    }
                    else
                    {
                        previousPosition = currentPosition;
                        result.Append(item);
                    }
                }
                else
                    result.Append(item);
            }

            return result.ToString();
        }
        static string Decode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            StringBuilder result = new StringBuilder();
            int? previousPosition = null;
            var wordToChar = input.ToUpper().ToCharArray();

            foreach (var item in wordToChar)
            {
                int currentPosition = list.IndexOf(item);
                if (currentPosition != -1)
                {
                    if (previousPosition != null)
                    {
                        var newIndex = ((int)currentPosition - (int)previousPosition - 1) % list.Count();
                        if (newIndex < 0)
                            newIndex += list.Count();
                        result.Append(list[newIndex]);
                        previousPosition = newIndex;
                    }
                    else
                    {
                        previousPosition = currentPosition;
                        result.Append(item);
                    }
                }
                else
                    result.Append(item);
            }

            return result.ToString();
        }

        /// <summary>
        /// Считаем максимальную длинну змейки
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private BigInteger Sum(BigInteger size)
        {
            if (size % 2 == 0)
                return (BigInteger)(size * size) / 2 + size - 1;
            else
                return ((BigInteger)size * size + 2 * size - 1) / 2;
        }
        /// <summary>
        /// Необходимо проверить сколько букв стоит в том же месте у второго слова
        /// </summary>
        /// <param name="correctWord"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        private int CountCorrectCharacters(string correctWord, string guess)
        {
            if (correctWord.Length != guess.Length)
                throw new InvalidOperationException();
            var result = 0;
            var len = correctWord.Length;
            for (int i = 0; i < len && i < guess.Length; i++)
            {
                if (correctWord[i] == guess[i])
                    result++;
            }
            return result;
        }

        /// <summary>
        /// Возвращаем время из секуннд в формате чч:мм:сс
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private string GetReadableTime(int seconds)
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
