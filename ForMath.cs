using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static Practice.Form1;

namespace Practice
{
    public class ForMath
    {
        /// <summary>
        /// Подсчет суммы чисел кратных 5 и 3
        /// </summary>
        /// <param name="maxNum">до какого числа ищем</param>
        /// <returns></returns>
        private static int SumCrat5and3(int maxNum)
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
        private static int SumEvenNumFi(int maxNum)
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
        private static string MaxPrimeDevisior(long num)
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
        //Переделать под Вычитание и поиск в Dictionary
        private int[] TwoSum(int[] nums, int target)
        {
            for(int i = 0;i<nums.Length - 1; i++)
            {
                for(int j = i+1;j<nums.Length;j++)
                    if (nums[i] + nums[j] == target)
                        return new int[] {i,j};
            }

            return null;
        }

        private static int[] SortSQRTArray(int[] nums)
        {
            var result = new int[nums.Length];
            var rightPosition = nums.Length - 1;
            var nextRight = rightPosition;

            for (int i = 0; i< nums.Length - 1; i++)
            {
                if (nextRight == -1)
                {
                    result[0] = (int)Math.Pow(nums[i], 2);
                    break;
                }
                   
                var left = (int)Math.Pow(nums[i], 2);
                var right = (int)Math.Pow(nums[rightPosition], 2);

                if (left <= right)
                {
                    result[nextRight] = right;
                    rightPosition--;
                    i--;
                }
                else
                    result[nextRight] = left;

                nextRight--;
            }
            return result;
        }

        private static bool HalvesAreAlike(string s)
        { 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var left = s.ToLower().Substring(0, s.Length / 2);
            var right = s.ToLower().Substring(s.Length / 2);

            int rightCount = 0;
            int leftCount = 0;

            for(int i = 0; i < left.Length; i++)
            {
                if (vowels.Contains(left[i]))
                     leftCount++; 
            }

            for (int i = 0; i < right.Length; i++)
            {
                if (vowels.Contains(right[i]))
                    rightCount++;
            }

            return leftCount == rightCount;
        }

        private static bool IsPalindrome(int x)
        {
            var a = x.ToString();

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i-1] != a[a.Length - i])
                    return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <returns>Возвращает одинаковое начало всех слов в списке</returns>
        private static string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            if (strs.Count() <= 1)
                return strs[0];

            var firstWorld = strs[0];
            if (firstWorld.Length == 0)
                return "";

            for(int i = 0; i < firstWorld.Length; i++)
            {
                var letter = firstWorld[i];
                
                for(int j = 1; j < strs.Count(); j++)
                {
                    if (i >= strs[j].Length)
                        return result;
                    if(letter != strs[j][i])
                        return result;
                }
                result += letter;
            }

            return result;
        }

        private static int RemoveDuplicates(int[] nums)
        {
            var result = nums.GroupBy(x => x).Count();
            int[] newNums = new int[result];
            int max = 0;
            int count = 0;
            for(int i = 0;i< nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                    newNums[count] = max;
                    count++;
                }

            }
            nums = newNums;
            return result;
        }
        /// <summary>
        /// Вывести кол-во букв, которые не повторяются (подряд)
        /// пример   "abcabcbb" => 3 "abc"
        /// "pwwkew" => 3 "wke"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1) return s.Length;
            int max = 0;
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < s.Length; i++)
            {
                if (result.ToString().Contains(s[i]))
                {
                    var indx =  result.ToString().IndexOf(s[i]);
                    max = result.Length >= max ? result.Length : max;
                    result = result.Remove(0, indx == 0 ? 1 : indx+1);
                }
                result.Append(s[i]);
            }

            return Math.Max(max,result.Length);
        }
        /// <summary>
        /// Нфйти позицию вхождения одного string в другой
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        private static int StrStr(string haystack, string needle)
        {
            //Самое простое решение
            var t= haystack.IndexOf(needle);

            if (needle.Length > haystack.Length)
                return -1;

            int firstWordPos = 0;
            int secondWordPos = 0;
            int errorPlace = 0;
            while(firstWordPos < haystack.Length)
            {
                if (haystack[firstWordPos] == needle[secondWordPos])
                {
                    firstWordPos++;
                    secondWordPos++;
                }
                else
                {
                    errorPlace++;
                    secondWordPos = 0;
                    firstWordPos = errorPlace;
                }
                if (secondWordPos == needle.Length)
                    return errorPlace;
            }

            return -1;
        }
        /// <summary>
        /// Найти позицию (отсортированного массива) вхождения числа target 
        /// если ее нет то укажите позицию где она должна быть
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int SearchInsert(int[] nums, int target)
        {
            for(int i = 0;i< nums.Length; i++)
            {
                if (nums[i] == target) 
                    return i;
                if (nums[i] > target)
                    return i--;
            }

            return nums.Length;
        }
        /// <summary>
        /// Поиск длины последнего слова
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LengthOfLastWord(string s)
        {
            var list = s.Split(' ');

            for(int i = list.Length-1; i>=0;i--)
            {
                if (list[i].Length > 0)
                    return list[i].Length;
            }
            
            return 0;

            /*
             Лучшее решение return (s.TrimEnd()).Split(' ').Last().Length;
             */
        }
        
        private static int[] PlusOne(int[] digits)
        {
            int currentNum = digits[^1]+1;

            if(currentNum/10 ==0)
            {
                digits[^1] = currentNum;
                return digits;
            }

            digits[^1] = digits[^1] + 1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i]/ 10 == 0)
                    return digits;

                if (i > 0)
                {
                    digits[i-1] = digits[i-1] + (digits[i]/10);
                    digits[i] = digits[i]%10;
                }
            }
            var result = new int[digits.Length+1];
            result[0] = 1;

            return result;
        }
        /// <summary>
        /// Сложение бинарных чисел
        /// </summary>
        /// <param name="a">бинарное число</param>
        /// <param name="b">бинарное число</param>
        /// <returns></returns>
        private static string AddBinary(string a, string b)
        {
            if (a==b&&a=="0")
            {
                return "0";
            }

            var len = Math.Max(a.Length, b.Length);
            short nextNum = 0;
            short[] result = new short[len+1];

            var countA = a.Length-1;
            var countB = b.Length-1;

            for(int i = len; i >= 0; i--)
            {
                short first = 0;
                short second = 0;
                
                if(countA >= 0)
                {
                    first = short.Parse(a[countA].ToString());
                    countA--;
                }
                    
                if (countB >= 0)
                {
                    second = short.Parse(b[countB].ToString());
                    countB--;
                }

                var sum = nextNum + first + second ;

                switch (sum)
                {
                    case 0:
                        result[i] = 0;
                        nextNum = 0;
                        break;
                    case 1:
                        result[i] = 1;
                        nextNum = 0;
                        break;
                    case 2:
                        result[i] = 0;
                        nextNum = 1;
                        break;
                    case 3:
                        result[i] = 1;
                        nextNum = 1;
                        break;
                }
            }

            return string.Join("", result.SkipWhile(x=>x==0).Select(x => x.ToString()).ToList());
        }
        /// <summary>
        /// Кол-во возможных способов забраться по лестнице (с шагом 1 или 2)
        /// </summary>
        /// <param name="n">кол-во ступенек</param>
        /// <returns>кол-во вариантов</returns>
        private static int ClimbStairs(int n)
        {
            //просто числа Фибоначчи из результата

            if (n <= 1)
            {
                return 1;
            }

            int prev1 = 1;
            int prev2 = 1;
            int current = 0;

            for (int i = 2; i <= n; i++)
            {
                current = prev1 + prev2;
                prev1 = prev2;
                prev2 = current;
            }

            return current;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (m == 0)
            {
                for(int i = 0;i<nums2.Length;i++)
                {
                    nums1[i] = nums2[i];
                }
            
            }


            int maxLen = m+n;
            int[] copyLeft = (int[])nums1.Clone();
            int place = 0;
            int leftArayPosition = 0;
            int rightArayPosition = 0;

            while(place < maxLen )
            {

                if(leftArayPosition < m && rightArayPosition <n)
                {
                    if (copyLeft[leftArayPosition] <= nums2[rightArayPosition])
                    {
                        nums1[place] = copyLeft[leftArayPosition];
                        leftArayPosition++;
                    }
                    else
                    {
                        nums1[place] = nums2[rightArayPosition];
                        rightArayPosition++;
                    }
                }
                else
                {
                    if (leftArayPosition < m)
                        nums1[place] = copyLeft[leftArayPosition++];
                    else
                        nums1[place] = nums2[rightArayPosition++]; 
                }
                

                place++;
            }
        }
    }

}
