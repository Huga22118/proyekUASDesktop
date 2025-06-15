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
    public partial class Form2 : Form
    {
        bool getAsterisk = false;
        bukuEntities3 dbLog = new bukuEntities3();
        public Form2()
        {
            InitializeComponent();
        }
        userAkun reg = new userAkun();
   
        private void label4_Click(object sender, EventArgs e)
        {

        }
        void getAccount()
        {
            if (string.IsNullOrEmpty(txtNUserName.Text.Trim()) || string.IsNullOrEmpty(txtNPassWord.Text.Trim()) || string.IsNullOrEmpty(txtNConfirm.Text.Trim()) || string.IsNullOrEmpty(txtNEmail.Text.Trim())
                || txtNConfirm.Text.Trim() != txtNPassWord.Text.Trim())
            {
                MessageBox.Show("Input yang benar!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reg.username = txtNUserName.Text.Trim();
            reg.password = txtNPassWord.Text.Trim();
            reg.email = txtNEmail.Text.Trim();
            dbLog.userAkuns.Add(reg);
            dbLog.SaveChanges();
            MessageBox.Show("Akun berhasil dibuat!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            var ma = new Main();
            ma.FormClosed += (s, args) => Application.Exit();
            ma.Show();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAccount();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.txtNConfirm.PasswordChar = checkBox1.Checked ? '\0' : '*';
            this.txtNPassWord.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtNConfirm.PasswordChar = checkBox1.Checked ? '\0' : '*';
            this.txtNPassWord.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
