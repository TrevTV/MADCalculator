using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MADCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z^$.|?*+(){}/`~_=';:><[]+$");
            bool hasOnlyAlpha = regex.IsMatch(numbersBox.Text);
            if (string.IsNullOrWhiteSpace(numbersBox.Text) || hasOnlyAlpha)
            {
                MessageBox.Show("I need numbers to do the math...", "Missing Numbers");
                return;
            }

            string[] numbers = numbersBox.Text.Split(',');
            List<int> ints = new List<int>() { };

            foreach (string number in numbers)
            {
                int x = Int32.Parse(number);
                ints.Add(x);
            }

            int sum = ints.Sum();
            int mean = sum / ints.Count;
            meanBox.Text = mean.ToString();

            List<int> mads = new List<int>() { };
            foreach (int number in ints)
            {
                int x = number - mean;
                if (x < 0) { x *= -1; }
                mads.Add(x);
            }

            float mad = (float)mads.Sum() / (float)mads.Count();
            answerBox.Text = mad.ToString();
        }
    }
}
