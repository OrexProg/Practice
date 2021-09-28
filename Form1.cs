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
            tbInput.Text = "How can mirrors be real if our eyes aren't real";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 7 - 7 % 2;
            string testText = tbInput.Text;

            tbOutput.Text = ToJadenCase(testText);
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
    }
}
