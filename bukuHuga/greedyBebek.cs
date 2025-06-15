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
    public partial class greedyBebek : UserControl
    {
        public struct Kandang
        {
            public int kapasitas;
            public int biaya;
            public Kandang(int kapasitas, int biaya)
            {
                this.kapasitas = kapasitas;
                this.biaya = biaya;
            }
        }
        string calculated = "";
        public greedyBebek()
        {
            InitializeComponent();
        }
        private Kandang[] kandangPairs;
        private int[] bebekArray;
        private void greedyBebek_Load(object sender, EventArgs e)
        {
            label12.Text = $"Hasilnya adalah: {calculated}";
        }
        void calculateGreedy()
        {

            TextBox[] allTextBoxes = { kand1, biaya1, kand2, biaya2, bebek1, bebek2, bebek3, bebek4, bebek5, bebek6 };
            foreach (var tb in allTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    MessageBox.Show("Semua input harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Cek biaya dan kapasitas
            int[] biayaArr = { int.Parse(biaya1.Text), int.Parse(biaya2.Text) };
            int[] kapasitasArr = { int.Parse(kand1.Text), int.Parse(kand2.Text) };

            if (biayaArr.Any(b => b > 20))
            {
                MessageBox.Show("Input biaya tidak boleh lebih dari 20!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kapasitasArr.Any(k => k > 10))
            {
                MessageBox.Show("Input kapasitas tidak boleh lebih dari 10!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Contoh pengambilan dari TextBox (pastikan TextBox sudah ada di Designer)
            int kapasitas1 = int.Parse(kand1.Text);
            int biaya1_ = int.Parse(biaya1.Text);
            int kapasitas2 = int.Parse(kand2.Text);
            int biaya2_ = int.Parse(biaya2.Text);

            kandangPairs = new Kandang[]
{
    new Kandang(kapasitas1, biaya1_),
    new Kandang(kapasitas2, biaya2_)
};
            kandangPairs = kandangPairs.OrderBy(x => x.biaya).ToArray();
            int b1 = int.Parse(bebek1.Text);
            int b2 = int.Parse(bebek2.Text);
            int b3 = int.Parse(bebek3.Text);
            int b4 = int.Parse(bebek4.Text);
            int b5 = int.Parse(bebek5.Text);
            int b6 = int.Parse(bebek6.Text);

            // Masukkan ke array
            bebekArray = new int[] { b1, b2, b3, b4, b5, b6 };

            
            int kanda = 0, tot = 0;
            // Urutkan descending
            bebekArray = bebekArray.OrderByDescending(x => x).ToArray();
            for (int i = 0; i < bebekArray.Length; i++)
            {
                if ( kandangPairs[kanda].kapasitas == 0)
                    kanda++;
                if (kanda >= kandangPairs.Length)
                    break;
                tot += bebekArray[i] * kandangPairs[kanda].biaya;
                kandangPairs[kanda].kapasitas--;
            }
            MessageBox.Show($"Total biaya: {tot}", "Hasil Perhitungan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            calculated = tot.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateGreedy();
        }
    }

}
