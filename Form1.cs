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
            tbInput.Text = "A";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string testText = tbInput.Text;
            /*
            int[][] test = new int[][]
            {
                new int[] {18, 20}, new int[] {45, 2}, new int[] {61, 12}, new int[] {37, 6}, new int[] {21, 21},
                new int[] {78, 9}
            };
            
            IEnumerable<string> res = OpenOrSenior(test);
             */

            string result = null;

            UniqueInOrder(new char[] {'1','2','2','3','3'}) ;

            tbOutput.Text = result;
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
    }
}
