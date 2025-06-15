using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bukuHuga
{
    public partial class dynamicProgramming_lantai : UserControl
    {
        public dynamicProgramming_lantai()
        {
            InitializeComponent();
        }
        long mod = 1000000;
        long calculateDp;
        private void dynamicProgramming_lantai_Load(object sender, EventArgs e)
        {
        }
        void calculate()
        {
            if (string.IsNullOrEmpty(Ncount.Text) || Convert.ToInt32(Ncount.Text) >1000) return;
            else
            {
                long n = long.Parse(Ncount.Text);
                long[] dp = new long[n+1];
                dp[0] = 1; // 1 cara untuk 1 lantai
                for (long i=1; i<=n; i++)
                {
                    long petak1x3 = (i - 3 < 0 ? 0 : dp[i-3]), petak3x1 = dp[i - 1];
                    if (i == 1) dp[i] = 1; //base case atau kasus dasar 
                    else   dp[i] = (petak3x1 + petak1x3) % mod;
                }

                calculateDp = dp[n];
                MessageBox.Show($"Banyak kemungkinan adalah: {calculateDp.ToString()}");
            }
        }
        private void btnHitungDP_Click(object sender, EventArgs e)
        {
            calculate();
        }
    }
}
