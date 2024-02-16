using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace descompunere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int[] nrprime = {
        1,2,3,4,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97,101,103,107,109,113,127,131,137,139,149,151,157,163,167,173,179,181,191,193,197,199,211,223,227,229,233,239,241,251,257,263,269,271,277,281,283,293,307,311,313,317,331,337,347,349,353,359,367,373,379,383,389,397,401,409,419,421,431,433,439,443,449,457,461,463,467,479,487,491,499,503,509,521,523,541,547,557,563,569,571,577,587,593,599,601,607,613,617,619,631,641,643,647,653,659,661,673,677,683,691,701,709,719,727,733,739,743,751,757,761,769,773,787,797,809,811,821,823,827,829,839,853,857,859,863,877,881,883,887,907,911,919,929,937,941,947,953,967,971,977,983,991,997
        };
        public List<int> fatoridivN = new List<int>();

        public bool ePrim(int x)
        {
            bool r = true;
            for (int i = 2; i < (x / 2); i++)
            {
                if (x % i == 0) { r = false;return r; }
            }
            return r;
        }
        public void findPrimeNumbers(int n, ref TextBox t)
        {
            for (int j = 1; j < n; j++)
            {
                bool r = ePrim(j);
                if (r == true) { t.Text += j.ToString() + ","; }
            }
        }
        public int findAllPrimeDividingANumber(int x, ref TextBox t)
        {
            fatoridivN = new List<int>();
            int y = (x / 2);
            int r = -1;
            t.Text += x.ToString() + ":";
            for (int i =  0; i < nrprime.Length; i++)
            {
              
                if (x % nrprime[i] == 0)
                {
                    r = nrprime[i]; 
                    t.Text += nrprime[i].ToString()+",";
                    fatoridivN.Add(nrprime[i]);
                }
            }
            t.Text += "\r\n";
            return r;
        }
        public void findAllNumbersDivizibleWithAPrime()
        {
            for (int i = 0; i < 1000; i++)
            {
                findAllPrimeDividingANumber(i,ref this. textBox1);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            findAllNumbersDivizibleWithAPrime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            findPrimeNumbers(1000, ref this.textBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = (ePrim(int.Parse(this.textBox2.Text))).ToString();
        }
        public int findBiggesPrimeDivizorOfXInAList(int x, ref List<int> l)
        { 
            int r = l.Count-1;
            for (int i = r; i >= 0; i--)
            {
                if (x < r) { return i; }
            }
            return r;
        }
        public void decompunereNumarInFactoriPrimi()
        {
            textBox1.Text = "";
            int x = int.Parse(this.textBox2.Text);
            int z = 0;
            textBox1.Text += x.ToString()+":";
            while (x > 1)
            {
                findAllPrimeDividingANumber(x, ref this.textBox1);

                if (x >= this.fatoridivN[this.fatoridivN.Count - 1])
                {
                    z = this.fatoridivN[this.fatoridivN.Count - 1];
                    textBox5.Text += z.ToString() + ",";
                }
                else
                {
                    z = this.fatoridivN[findBiggesPrimeDivizorOfXInAList(x, ref this.fatoridivN)];
                    textBox5.Text += z.ToString() + ",";
                }
                
                
                x = x / z;
                textBox1.Text += x.ToString()+",";
                
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            findAllPrimeDividingANumber(int.Parse(this.textBox2.Text), ref this.textBox3);

            /*
                574 / 41 =  14
                14 / 7 = 2
                2 / 2 = 1
                1 / 1 = 1

             */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decompunereNumarInFactoriPrimi();
            /*
                500:100,20,4,1,
                500:1,2,4,5,
                500:1,2,4,5,
                100:1,2,4,5,
                20:1,2,4,5,
                4:1,2,4,

             */
        }
    }
}
