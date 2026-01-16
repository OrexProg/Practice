using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static Practice.Form1;

namespace Practice
{
    public class Algorithms
    {
        public static string ReturnAnswer()
        {
            var alg = new Algorithms();
            string ans = null;
            /*
             
             */
            var t2 = alg.ThreeSum(new int[] { -2, 0, 1, 1, 2 });

            return ans;
        }



        //*/
        #region Solve
        /// <summary>
        /// Вернуть список масиивов (из 3 чисел) сумма которых даст 0 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        IList<IList<int>> ThreeSum(int[] nums)
        {
            var resulList = new List<IList<int>>();

            var numsList = nums.ToList();

            if (numsList.Count < 3)
                return resulList;
            else if (numsList.Count == 3)
            {
                if (numsList.Sum() == 0)
                {
                    resulList.Add(numsList);
                    return resulList;
                }
            }

            numsList.Sort();

            for (int i = 0; i < numsList.Count - 1; i++)
            {
                var currentPoint = numsList[i];
                var left = i + 1;
                var right = numsList.Count - 1;
                while (left < right)
                {
                    var sumPoint = numsList[left] + numsList[right] + currentPoint;
                    if (sumPoint == 0)
                    {
                        var answer = new List<int> { currentPoint, numsList[left], numsList[right] };
                        resulList.Add(answer);
                        while (left < right && numsList[left] == answer[1])
                            left++;
                        while (right > left && numsList[right] == answer[2])
                            right--;
                    }
                    switch (sumPoint)
                    {
                        case < 0:
                            left++;
                            break;
                        case > 0:
                            right--;
                            break;
                    }
                }
                while (i < numsList.Count - 1 && numsList[i] == numsList[i + 1])
                    i++;
            }
            return resulList.ToList();
        }
        /// <summary>
        /// Вывод единственного повторяющегося числа из списка
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        int SingleNumber(int[] nums)
        {
            var result = -1;

            result = nums.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Проверка что предложение полиндром
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        bool IsPalindrome(string s)
        {
            s = s.ToLower();
            var len = s.Length;
            var begin = 0;
            var end = len - 1;
            bool result = true;
            while (begin < end && result)
            {
                char leftSym;
                char rightSym;

                while (!char.IsLetterOrDigit(s[begin]) && begin < end)
                {
                    begin++;
                }
                leftSym = s[begin];
                while (!char.IsLetterOrDigit(s[end]) && begin < end)
                {
                    end--;
                }
                rightSym = s[end];
                if (begin == end)
                    result = true;
                if (rightSym != leftSym)
                    result = false;
                begin++;
                end--;
            }

            return result;
        }
        /// <summary>
        /// Поиск медианы в отсортированных массивах
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int arr1Len = nums1.Length;
            int arr2Len = nums2.Length;
            int allCount = arr1Len + arr2Len;
            List<int> result = new List<int>();
            int median = allCount / 2;

            int left = 0;
            int right = 0;

            for (int i = 0; i <= median; i++)
            {
                if (left > arr1Len - 1)
                {
                    result.Add(nums2[right]);
                    right++;
                    continue;
                }

                if (right > arr2Len - 1)
                {
                    result.Add(nums1[left]);
                    left++;
                    continue;
                }

                if (nums1[left] > nums2[right])
                {
                    result.Add(nums2[right]);
                    right++;
                }
                else
                {
                    result.Add(nums1[left]);
                    left++;
                }
            }

            int count = result.Count;

            if (allCount % 2 == 0)
            {
                return (double)(result[count - 1] + result[count - 2]) / (double)2;
            }
            else
                return (double)result[count - 1];

        }

        /// <summary>
        /// Максимальная площадь
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            //
            int len = height.Length;
            int leftPosition = 0;
            int rightPosition = len - 1;
            int result = Math.Min(height[leftPosition], height[rightPosition]) * (len - 1);

            while (leftPosition < rightPosition)
            {
                int currentSquare = Math.Min(height[leftPosition], height[rightPosition]) * (rightPosition - leftPosition);
                result = Math.Max(result, currentSquare);

                if (height[leftPosition] > height[rightPosition])
                    rightPosition--;
                else
                    leftPosition++;
            }

            return result;
        }
        /// <summary>
        /// Преобразование строки в число (если первые символы можно преобразовать в число)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            s = s.TrimStart(' ');
            if (string.IsNullOrEmpty(s))
                return 0;

            bool only_num = true;
            StringBuilder sb = new StringBuilder();

            if (s[0] == '-' || s[0] == '+' || char.IsDigit(s[0]))
            {
                sb.Append(s[0]);

                for (int i = 1; i < s.Length; i++)
                {
                    if (char.IsDigit(s[i]))
                        sb.Append(s[i]);
                    else
                        break;
                }
            }
            else
                return 0;

            long result = 0;

            if (!long.TryParse(sb.ToString(), out result))
            {
                if (sb.ToString().Length > 0)
                {
                    if (s[0] == '-')
                        return int.MinValue;
                    else
                        return int.MaxValue;
                }
                else
                    return 0;
            }


            if (result > int.MaxValue)
                return int.MaxValue;
            if (result < int.MinValue)
                return int.MinValue;

            return (int)result;
        }
        /// <summary>
        /// Поиск максимальной потенциальной прибыли
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Count() < 2)
                return 0;

            int current = prices[0];
            int profit = 0;

            for (int i = 1; i < prices.Count(); i++)
            {
                if (prices[i] < current)
                    current = prices[i];
                else
                {
                    var res = prices[i] - current;
                    if (res > 0)
                    {
                        profit = Math.Max(profit, res);
                    }
                }
            }

            return profit;
        }
        /// <summary>
        /// Поиск произвольной строки в пирамиде Паскаля
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0)
                return new List<int> { 1 };
            if (rowIndex == 1)
                return new List<int> { 1, 1 };
            if (rowIndex == 2)
                return new List<int> { 1, 2, 1 };

            List<int> result = new List<int>();

            result.Add(1);
            result.Add(rowIndex);
            var half = rowIndex / 2;
            for (int i = 1; i < half; i++)
            {
                long m = (long)(result[i]) * (long)(rowIndex - i);
                result.Add(int.Parse((m / (i + 1)).ToString()));
            }

            var secondPart = new List<int>(result);

            if (rowIndex % 2 == 0)
            {
                secondPart.RemoveAt(result.Count - 1);
            }

            secondPart.Reverse();

            result = result.Concat(secondPart).ToList();

            return result;
        }
        public int Reverse(int x)
        {
            int result = 0;
            if (x <= Int32.MinValue)
                return 0;
            string strResult = Math.Abs(x).ToString();

            char[] charArray = strResult.ToCharArray();
            Array.Reverse(charArray);
            string reverseResult = string.Format("{0}{1}", x > 0 ? "" : "-", new string(charArray));
            Int32.TryParse(reverseResult, out result);

            return result;
        }
        private static TreeNode AddNode(TreeNode node, int num)
        {
            if (num < node.val)
            {
                if (node.left == null)
                    node.left = new TreeNode(num);
                else
                    AddNode(node.left, num);
            }
            else
            {
                if (node.right == null)
                    node.right = new TreeNode(num);
                else
                    AddNode(node.right, num);
            }
            return node;
        }
        public static TreeNode CreateNodeSort(int[] nums)
        {
            if (!nums.Any()) return null;
            TreeNode node = new TreeNode(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                AddNode(node, nums[i]);
            }

            return node;
        }
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
        /// Найти позицию вхождения одного string в другой
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

        private static void Merge(int[] nums1, int m, int[] nums2, int n)
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
        /// <summary>
        /// Сравнение 2 бинарных деревьев
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            if (p.val != q.val)
                return false;
            else
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        private static int CountSubstrings(string s)
        {
            return s.ToList().Count();
        }

        private bool CheckSimetric(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return true;

            if(left?.val != right?.val) 
                return false;

            return CheckSimetric(left.right, right.left) && CheckSimetric(left.left,right.right);
        }
        public bool IsSymmetric(TreeNode root)
        {

            if(root.left.val != root.right.val)
                return false;

            return CheckSimetric(root.left,root.right);
        }
        //Подсчет глубины
        private  int CheckRoot(int result, TreeNode left, TreeNode right)
        {
            if (left?.val != null || right?.val != null)
                result++;
            else
                return ++result;

            return Math.Max(CheckRoot(result,left.left,left.right),CheckRoot(result,right.left,right.right));  
        }
        public  int MaxDepth(TreeNode root)
        {
            int result = 0;
            result = CheckRoot(result, root.left, root.right);
            return result;
        }
        /// <summary>
        /// Подсчет глубины улучшенный
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int MaxDepthBest(TreeNode root)
        {
            int left = MaxDepthBest(root.left);
            int right = MaxDepthBest(root.right);

            return Math.Max(left, right) + 1;
        }

        private int MinDepth(TreeNode root)
        {
            if(root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;

            if(root.left == null) 
                return MinDepth(root.right) +1;

            if(root.right == null)
                return MinDepth(root.left) +1;


            return Math.Min(MinDepth(root.right), MinDepth(root.left)) + 1;
        }
        /// <summary>
        /// Проверка суммы ветвей с целевым значением
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }

            bool leftSum = HasPathSum(root.left, targetSum - root.val ?? 0);
            bool rightSum = HasPathSum(root.right, targetSum - root.val ?? 0);

            return leftSum || rightSum;
        }

        private static List<int> AddList(List<int> prevList ) 
        {
            List<int> result = new List<int>();

            if (prevList.Count == 0)
                return new List<int> { 1 };

            if(prevList.Count == 1) 
                return new List<int> { 1,1 };

            int current = 0;

            for(int i = 0;i<prevList.Count;i++)
            {
                result.Add(prevList[i] + current);
                current = prevList[i];
            }

            result.Add(1);

            return result;
        }
        /// <summary>
        /// Построение треугольника Паскаля
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        private static IList<IList<int>> Generate(int numRows)
        {
            if(numRows <= 0)
                return null;
            if(numRows == 1)
                return new List<IList<int>>() { new List<int> { 1 } };

            IList<IList<int>> result = new List<IList<int>>();
            List<int> prevList = new List<int>();

            for (int i = 0; i < numRows; i++)
            {
               prevList = AddList(prevList);
                result.Add(prevList);
            }

            return result;
        }
        /// <summary>
        /// Поиск самого большого палиндрома
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string LongestPalindrome(string s)
        {
            if(s.Length==1)
                return s;
            StringBuilder manacharString = new StringBuilder();
            manacharString.Append("^#");
            for(int i = 0;i< s.Length;i++)
                manacharString.Append((char)s[i]).Append("#");

            manacharString.Append("$");
           
            int[] P = new int[manacharString.Length];
            int C = 0, R = 0;

            for (int i = 1; i < manacharString.Length - 1; i++)
            {
                P[i] = (R > i) ? Math.Min(R - i, P[2 * C - i]) : 0;
                while (manacharString[i + 1 + P[i]] == manacharString[i - 1 - P[i]])
                    P[i]++;
                   
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            int max_len = P.Max();
            int center_index = Array.IndexOf(P, max_len);
            return s.Substring((center_index - max_len) / 2, max_len);
        }
private string ConvertWordBest(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= 1)
            {
                return s;
            }

            string[] result = new string[numRows];

            int currentPosition = 0;
            int direction = 1;
            foreach (char c in s)
            {
                result[currentPosition] += c;

                currentPosition += direction;

                if (currentPosition == numRows - 1 || currentPosition == 0) 
                    direction *= -1;
            }

            return string.Concat(result);
        }

        #region Конвертируем арабское число в римское
        /// <summary>
        /// Конвертируем арабское число в римское
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            string numS = num.ToString();
            List<int> romanArr = new List<int> { 1, 5, 10, 50, 100, 500, 1000 };
            Dictionary<int, string> romanDict = new Dictionary<int, string>()
            {
                {1,"I" },
                {5,"V" },
                {10,"X" },
                {50,"L" },
                {100,"C" },
                {500,"D" },
                {1000,"M" }
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= numS.Length - 1; i++)
            {
                int currentNum = Int32.Parse(numS[i].ToString());
                int digit = (int)Math.Pow(10, numS.Length - 1 - i);

                switch (currentNum)
                {
                    case 1:
                    case 2:
                    case 3:
                        var index = romanArr.IndexOf(digit);
                        var val = romanDict.FirstOrDefault(x => x.Key == digit);
                        sb.Append(AddRoman(romanDict.ElementAt(index).Value, currentNum));
                        break;
                    case 5:
                        val = romanDict.FirstOrDefault(x => x.Key == currentNum * digit);
                        sb.Append(val.Value);
                        break;
                    case 4:
                        index = romanArr.IndexOf((currentNum + 1) * digit);
                        sb.Append(romanDict.ElementAt(index - 1).Value);
                        sb.Append(romanDict.ElementAt(index).Value);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        var dif = currentNum - 5;
                        index = romanArr.IndexOf(digit);
                        sb.Append(romanDict.ElementAt(index + 1).Value);
                        sb.Append(AddRoman(romanDict.ElementAt(index).Value, dif));
                        break;
                    case 9:
                        index = romanArr.IndexOf((currentNum + 1) * digit);
                        sb.Append(romanDict.ElementAt(index - 2).Value);
                        sb.Append(romanDict.ElementAt(index).Value);
                        break;

                }
            }

            return sb.ToString();
        }

        private string AddRoman(string word, int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
                sb.Append(word);

            return sb.ToString();
        }
        #endregion

        #endregion
        
    };

}
