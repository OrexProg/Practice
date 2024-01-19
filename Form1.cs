using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Interval = System.ValueTuple<int, int>;
namespace Practice
{
    public partial class Form1 : Form
    {

        private void btnResMath_Click(object sender, EventArgs e)
        {
            tbResMath.Text = ForMath.MaxPrimeDevisior(Convert.ToInt64(tbMathQuestion.Text)).ToString();
        }
        public Form1()
        {
            InitializeComponent();
            tbInput.Text = "...---... --..-- ...---... --..--";
            tbMathQuestion.Text = "13195";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
            var t = new Interval[] { (1, 4), (7, 10), (3, 5) };
            var t2 = new Interval[] { (5, 8), (3, 6), (1, 2) };
            var t3 = new int[] { -8,-7,-4,-3,-2, 2, 4,5,6 };
            string testText = tbInput.Text;
            var res = ForMath.IsPalindrome(12121);
            //tbOutput.Text = ForMath.SortSQRTArray(t3).ToList();
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
                    case "System.Char":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => Convert.ToChar(x.ToString()));
                    case "System.Double":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => Convert.ToDouble(x.ToString()));
                    case "System.String":
                        return (IEnumerable<T>)result.ToList().ConvertAll(x => x.ToString());
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
        public static bool IsPrime(long n)
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
        /// <summary>
        /// Расшифровка римских цифр
        /// </summary>
        /// <param name="roman"></param>
        /// <returns></returns>
        public static int Solution(string roman)
        {
            Dictionary<char, int> rome_dict = new Dictionary<char, int>() { { 'I', 1 },{'V',5},{'X',10},{'L',50},{'C',100},{'D',500}, { 'M', 1000 } };

            int result = 0;
            int max = 0;

            foreach (var c in roman.Reverse())
            {
                int value = rome_dict[c];

                if (value < max)
                {
                    result -= value;
                }
                else
                {
                    result += value;
                    max = value;
                }
            }
            return result;
        }
        /// <summary>
        /// Вывод кол-ва букв в слове 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Выводим списком</returns>
        public static Dictionary<char, int> Count(string str)
        {
            Dictionary<char, int> countLetter = new Dictionary<char, int>();
            var test = str.ToLower().Select(x => x);
            str.ToLower().GroupBy(x => x).ToList().ForEach(x => countLetter.Add(x.Key, test.Count(y => y == x.Key)));
            
            return countLetter;

            //Лучший вариант
            //return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }
        /// <summary>
        /// Вывод порядковых номеров сумма которых дает target
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count(); i++)
            {
                for(int j = 1; j < numbers.Count(); j++)
                {
                    if ( i != j && (numbers[i] + numbers[j] == target))
                    {
                        result.Add(i);
                        result.Add(j);

                        return result.ToArray();
                    }
                }
            }
            return new int[0];
        }
        //Супер умный вариант public static int[] TwoSum(int[] numbers, int target) => numbers.Select((x,i)=>new [] {i, Array.IndexOf(numbers,target-x,i+1)}).First(x => x[1] != -1);
        /// <summary>
        /// Замена букв на 13 после текущей буквы в алфавите
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Rot13(string message)
        {
            List<char> message_arr = message.ToList<char>();
            List<char> result_arr = new List<char>();
            string result = null;
            message_arr.ForEach(x =>
            {
                if (x > 64 && x < 91)
                {
                    result_arr.Add(Convert.ToChar((x + 13) > 90 ? 64 + (x + 13 - 90) : x + 13));
                }
                else if (x > 96 && x < 123)
                {
                    result_arr.Add(Convert.ToChar((x + 13) > 122 ? 96 + (x + 13 - 122) : x + 13));
                }
                else
                {
                    result_arr.Add(x);
                }
            });

            result_arr.ForEach(x =>
            {
                result += Convert.ToChar(x);
            });

            return result;


            /*Лучший вариант
             
             string result = "";
            foreach (var s in message)
            {
                if ((s >= 'a' && s <= 'm') || (s >= 'A' && s <= 'M'))
                    result += Convert.ToChar((s + 13)).ToString();
                else if ((s >= 'n' && s <= 'z') || (s >= 'N' && s <= 'Z'))
                    result += Convert.ToChar((s - 13)).ToString();
                else result += s;
            }
            return result;
             
            // Самый лучший вариант
            return String.Join("", message.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char)(x + 13) : (char)(x - 13) : x));

             */
        }
        /// <summary>
        /// Расшифровка азбуки морзе
        /// </summary>
        /// <param name="morseCode"></param>
        /// <returns></returns>
        public static string Decode(string morseCode)
        {
            Dictionary<string, string> morze_dict = new Dictionary<string, string>() {
                { ".-", "A"}, { "-...", "B"},{ "-.-.", "C"},{ "-..", "D"},
                { ".", "E"}, { "..-.", "F"}, { "--.", "G"}, { "....", "H"},
                { "..", "I"}, { ".---", "J"}, { "-.-", "K"}, { ".-..", "L"},
                { "--", "M"}, { "-.", "N"}, { "---", "O"}, { ".--.", "P"},
                { "--.-", "Q"}, { ".-.", "R"}, { "...", "S"}, { "-", "T"},
                { "..-", "U"}, { "...-", "V"}, { ".--", "W"}, { "-..-", "X"},
                { "-.--", "Y"},{ "--..", "Z"},{"...---...","SOS"},{"--..--","!"},{"-.-.--","!"},{".-.-.-","."},
            };
            string result = null;

            List<string> word = morseCode.Trim().Replace("  ", " 1 ").Split(' ').ToList();

            word.ForEach(x =>
            {
                if (x != "1")
                    result += morze_dict.GetValueOrDefault(x);
                else
                    result += " ";
            });

            return result.Trim();
        }

        /// <summary>
        /// Сложение больших чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Add(string a, string b)
        {
            string res = "";
            int c = 0, d = 0;

            //выравниваем количество разрядов путем дополнения нулями слева
            int max = Math.Max(a.Length, b.Length);
            if (a.Length < b.Length)
                a = a.PadLeft(max, '0');
            else
            if (a.Length > b.Length)
                b = b.PadLeft(max, '0');

            //складываем
            for (int i = max - 1; i >= 0; i--)
            {
                c = (d + (int)Char.GetNumericValue(a[i]) + (int)Char.GetNumericValue(b[i])) % 10;
                res += c.ToString();
                d = (d + (int)Char.GetNumericValue(a[i]) + (int)Char.GetNumericValue(b[i])) / 10;
            }
            if (d != 0)
                res += d;

            return new String(res.Reverse().ToArray());
        }
        /// <summary>
        /// Вывод диапозона чисел если больше 3 то через - если не подряд или 2 то через запятую
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Extract(int[] args)
        {
            List<int> numbers = args.ToList();
            numbers.Sort();

            if(numbers.Count == 2)
            {
                return numbers[0] + "," + numbers[1];
            }

            string result = numbers[0].ToString();
            int? max = null;
            int count = 0;
            bool isMax = false;
            for(int i = 1;i<numbers.Count; i++)
            {
                var t = numbers[i];
                if (numbers[i] <= 0)
                {
                    isMax = Math.Abs(numbers[i]) == Math.Abs(numbers[i - 1]) - 1;
                }
                else
                {
                    isMax = numbers[i] - 1 == numbers[i - 1];
                }

                if (isMax)
                {
                    max = numbers[i];
                    count++;
                }
                else
                {
                    if (max == null)
                        result += "," + numbers[i];
                    else
                    {
                        if (count >1 && max != null)
                        {
                            result +=  "-" + max + "," + numbers[i];
                            max = null;
                        }
                        else
                        {
                            result += max != null ?"," + max + "," + numbers[i] :"," + numbers[i];
                            max = null;
                        }
                        
                    }
                    count = 0;
                }
            }

            if(max != null && count > 1)
                result +=  "-" + max;
            else if(max!=null)
                result += "," + max;

            return result;  //TODO
        }
        /// <summary>
        /// Сумма интервалов 
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int SumIntervals((int, int)[] intervals)
        {
            List<(int,int)> t = intervals.Select(x => x).OrderBy(x => x.Item1).ThenBy(x=>x.Item2).ToList();

            t = t.Where(x => x.Item1 != 0 || x.Item2 != 0).ToList();
            
            for (int i = 1; i < t.Count - 1; i++)
            {
                if (t[i].Item1 < t[i - 1].Item2)
                {
                    t[i] = ( t[i - 1].Item2, t[i].Item2);
                }
            }
            
            return t.Select(x => x).Sum(x => x.Item2 - x.Item1);
        }

    }
}
