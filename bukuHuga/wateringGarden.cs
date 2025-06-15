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
    public partial class wateringGarden : UserControl
    {
        public wateringGarden()
        {
            InitializeComponent();
        }
        long N = 6;
        long ans = 1000000007; // trying as high as possible;

        private void wateringGarden_Load(object sender, EventArgs e)
        {

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            calculateGarden();
        }

        void calculateGarden()
        {
            
            long temp = ans;
            TextBox[] allTextBoxes = { ember1, ember2, ember3, ember4, ember5, ember6 };
            foreach (var data in allTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(data.Text) || string.IsNullOrEmpty(data.Text))
                {
                    MessageBox.Show("Semua input harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!long.TryParse(data.Text, out long value) || value < 0)
                {
                    MessageBox.Show("Input harus berupa angka positif!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (value > ans)
                {
                    MessageBox.Show($"Input tidak boleh lebih dari {temp}!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!long.TryParse(kebun.Text, out long val) || val < value)
                {
                    MessageBox.Show("Panjang Kebun harus melebihi dari tiap ember atau Panjang Kebun harus berupa angka positif", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            long maxi = long.Parse(kebun.Text);
            long[] ember = { long.Parse(ember1.Text), long.Parse(ember2.Text), long.Parse(ember3.Text),
                                 long.Parse(ember4.Text), long.Parse(ember5.Text), long.Parse(ember6.Text) };
            // main algorithm
            for (long i=0; i<N; i++)
            {
                if (maxi % ember[i] != 0) continue;
                ans = Math.Min(ans, maxi / ember[i]);
            }
            MessageBox.Show($"Minimum Jam yang diperlukan adalah: {ans.ToString()}", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ans = temp;
        }
    }
}
