using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bukuHuga
{
    public partial class Form1 : Form
    {
        bool getAsterisk = false;
        bukuEntities3 dbLog = new bukuEntities3();
        public Form1()
        {
            InitializeComponent();
            
        }

        Form2 reg = new Form2();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNUserName_TextChanged(object sender, EventArgs e)
        {

        }
        void getLog()
        {
            var log = dbLog.userAkuns.FirstOrDefault(x => x.username == txtNUserName.Text && x.password == txtNPassWord.Text);
           if (log != null)
            {
                this.Hide();
                var reg = new Main();
                reg.FormClosed += (s, args) => Application.Exit();
                reg.Show();
            }
            else
            {
                MessageBox.Show("Akun tidak ditemukan!", "Input correct account!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getLog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = getAsterisk;
            this.txtNPassWord.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtNPassWord.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var reg = new Form2();
            reg.FormClosed += (s, args) => Application.Exit();
            reg.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var re = new algorithm();
            re.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected))
            {
                var algoForm = new algorithm();
                algoForm.Show();
                // Contoh: tampilkan UserControl berbeda sesuai pilihan
                UserControl uc = null;
                if (selected == "Kandang Bebek")
                    uc = new greedyBebek();
                else if (selected == "Memasang Lantai")
                  uc = new dynamicProgramming_lantai();
                else if (selected == "Menyirami Taman")
                    uc = new wateringGarden();

                if (uc != null)
                {
                    algoForm.ShowUserControlInPanel(uc);
                    algoForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Pilih algoritma terlebih dahulu.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
