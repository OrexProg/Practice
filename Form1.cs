using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbInput.Text = "indivisibility";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();

            string testText = tbInput.Text;
            var result = DuplicateCount(testText);
            tbOutput.Text = result.ToString();
        }
        /// <summary>
        /// Преобразование слов в верблюжий стиль
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCase(string str)
        {
            var result = str.Split('-','_');
            string t = result[0];
            foreach (string v in result.Skip(1))
            {
                t += v[0].ToString().ToUpper() + v.Substring(1, v.Length - 1);
            }

            str = t;
            return str;
        }
        /// <summary>
        /// Преобразование всех слов в предложениях в большие буквы
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToJadenCase(string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
            //или
            //return String.Join(" ", phrase.Split().Select(i => Char.ToUpper(i[0]) + i.Substring(1)));
        }
        /// <summary>
        /// Возврат значений в зависимости от параметров
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            return data.Select(x => x[0] >= 55 && x[1] > 7 ? "Senior" : "Open").ToList();
            /*
            List<string> info =  new List<string>();

            foreach (var r in data)
            {
                if (r[0] > 55 && r[1] > 7)
                {
                    info.Add("Senior");
                }
                else
                {
                    info.Add("Open");
                }
            }

            return info;
            */
        }
        /// <summary>
        /// Замена букв, если в слове буква повторяется тогда возвращаем ) иначе (
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string DuplicateEncode(string word)
        {
            string result = null;
            var test = word.ToLower().Select(x => x);
            word.ToLower().ToList().ForEach(x=> result += test.Count(y=>y == x) > 1? ")":"(");
            return result;
        }
        /// <summary>
        /// Подсчет кол-во букв в слове
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string CountLetterIntoText(string word)
        {
            Dictionary<char,int> countLetter = new Dictionary<char, int>();
            string result = null;
            var test = word.ToLower().Select(x => x);
            word.ToLower().GroupBy(x=>x).ToList().ForEach(x=> countLetter.Add(x.Key, test.Count(y => y == x.Key)));

            foreach (var c in countLetter)
            {
                result += c.Key + " " + c.Value + "\r\n";
            }
            return result;
        }
        /// <summary>
        /// Выбор позиции числа которое отличается от других
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int Test(string numbers)
        {
            int result = 0;
            List<int> allNum = new List<int>();
            numbers.Split(' ').ToList().ForEach(x => allNum.Add(Convert.ToInt32(x)));

            result = allNum.Select(x => x).Where(x => x % 2 == 0).Count() == 1 ? 
                allNum.IndexOf(allNum.Find(x => x % 2 == 0)) : allNum.IndexOf(allNum.Find(x => x % 2 != 0));

            return result + 1;
        }
        /// <summary>
        /// Narcissistic Number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Narcissistic(int value)
        {
            double resNumber = 0;
            var allNumbers = value.ToString().ToList();
            allNumbers.ForEach(x=> resNumber += Math.Pow(Convert.ToInt32(x.ToString()),allNumbers.Count()));

            return resNumber == value;
        }
        /// <summary>
        /// Уникальные значения массива
        ///
        /// uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
        /// uniqueInOrder("ABBCcAD")         == {'A', 'B', 'C', 'c', 'A', 'D'}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iterable"></param>
        /// <returns></returns>
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            string result = "";
            var typeT = typeof(T).FullName;
            var test = iterable.ToList();
            if (test.Count > 0)
            {
                string someChar = test[0].ToString();
                result += someChar;
                foreach (var t in test)
                {
                    if (someChar != t.ToString())
                    {
                        result += t.ToString();
                        someChar = t.ToString();
                    }
                }

                switch (typeT)
                {
                    case "System.Int32":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => Convert.ToInt32(x.ToString()));
                        break;
                    case "System.Char":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => Convert.ToChar(x.ToString()));
                        break;
                    case "System.Double":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => Convert.ToDouble(x.ToString()));
                        break;
                    case "System.String":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => x.ToString());
                        break;

                }

            }

            return (IEnumerable<T>)result.ToList();

            //правильный способ return iterable.Where((x, i) => i == 0 || !Equals(x, iterable.ElementAt(i-1)));
        }
        //
        /// <summary>
        /// Преобразование набора чисел в формат тел
        /// </summary>
        /// <param name="numbers">набор чисел</param>
        /// <returns>формат тел (123) 456-7890</returns>
        public static string CreatePhoneNumber(int[] numbers)
        {
            List<int> num = numbers.ToList();
            string result = "(";

            num.Take(3).ToList().ForEach(x => result += x);

            result += ") ";

            num.GetRange(3,3).ForEach(x => result += x);

            result += "-";

            num.GetRange(6,4).ForEach(x => result += x);

            return result;

            //Правильный вариант
            //return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
        }

        public static string SpinWords(string sentence)
        {
            string result = null;

            List<string> allWords = sentence.Split(' ').ToList<string>();

            allWords.ForEach(x =>
            {
                if (x.Length >= 5)
                {
                    char[] word = x.ToArray();
                    word.Reverse().ToList<char>().ForEach(y => result += y.ToString());
                    result += ' ';
                }
                else
                    result += x + ' ';
            });

            return result.TrimEnd();

            //Лучший вариант
            //return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
        }
        /// <summary>
        /// Проверка на простое число
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(int n)
        {
            n = Math.Abs(n);
            if (n == 2)
                return true;
            if (n % 2 == 0 || n<2)
            {
                return false;
            }

            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;

            /*      Лучшее решение
             if (n <= 2 || n % 2 == 0) return n == 2;
    for (int i = 3; i <= Math.Sqrt(n); i += 2) if (n % i == 0) return false;
    return true;
             */

        }
        /// <summary>
        /// Проверка на правильно расставленные скобки
        /// </summary>
        /// <param name="braces"></param>
        /// <returns></returns>
        public static bool validBraces(String braces)
        {
            string prev = "";
            while (braces.Length != prev.Length)
            {
                prev = braces;
                braces = braces
                    .Replace("()", String.Empty)
                    .Replace("[]", String.Empty)
                    .Replace("{}", String.Empty);
            }
            return (braces.Length == 0);
        }
        /// <summary>
        /// Количество нечетных чисел в n строке треугольника
        ///
        /*                 1
                        3     5
                     7     9    11
                13    15    17    19
            21    23    25    27    29*/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long rowSumOddNumbers(long n)
        {
            Int64 first_number = Convert.ToInt64(Math.Pow(n, 2) - (n-1));
            Int64 result = 0;

            for(int i = 0; i < n; i++)
            {
                result += first_number;
                first_number += 2;
            }

            return result;

            //Ну а если хорошо подумать и включить математическое мышление то можно заметить что сумма каждой строки это куб номера строки и правильное решение будет Math.Pow(n,3)
        }
        /// <summary>
        /// Количество повторяющихся букв
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(x => x).Where(x => x.Count() > 1).Count();
        }

    }
}
