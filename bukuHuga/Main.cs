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
    public partial class Main : Form
    {
        bukuEntities3 db = new bukuEntities3();
        int id;
        public Main()
        {
            InitializeComponent();
        }
        aksesBuku aksesMyAss = new aksesBuku();
        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bukuDataSet.aksesBuku' table. You can move, or remove it, as needed.
            loadContent();
            id = 0;
        }
        void loadContent()
        {
            var data = db.aksesBukus.ToList();
            dataGridView2.DataSource = data;
            dataGridView2.Columns["idBuku"].Visible = false; // Hide the ID column
            dataGridView2.ReadOnly = true;
            if (dataGridView2.Columns.Contains("Hapus"))
            {
                dataGridView2.Columns.Remove("Hapus");
            }
            if (dataGridView2.Columns.Contains("Transaksis"))
            {
                dataGridView2.Columns["Transaksis"].Visible = false;
            }
            DataGridViewImageColumn btnDel = new DataGridViewImageColumn
            {
                Image = Properties.Resources.trash,
                Name = "Hapus",
                HeaderText = "Hapus",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView2.Columns.Add(btnDel);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void insert()
        {
            if (string.IsNullOrEmpty(txtNNamaBuku.Text) || string.IsNullOrEmpty(txtNPenulis.Text) ||
        string.IsNullOrEmpty(txtNHarga.Text) || string.IsNullOrEmpty(txtNStok.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int harga, stok;
            if (!int.TryParse(txtNHarga.Text, out harga))
            {
                MessageBox.Show("Harga harus berupa angka!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNStok.Text, out stok))
            {
                MessageBox.Show("Stok harus berupa angka!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            aksesMyAss.namaBuku = txtNNamaBuku.Text;
            aksesMyAss.namaPenulis = txtNPenulis.Text;
            aksesMyAss.hargaBuku = Convert.ToInt32(txtNHarga.Text);
            aksesMyAss.stokBarang = Convert.ToInt32(txtNStok.Text);
            db.aksesBukus.Add(aksesMyAss);
            db.SaveChanges();
            MessageBox.Show("Data Berhasil Disimpan");
            loadContent();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                id = (int)row.Cells["idBuku"].Value;
                txtNNamaBuku.Text = row.Cells["namaBuku"].Value.ToString();
                txtNPenulis.Text = row.Cells["namaPenulis"].Value.ToString();
                txtNHarga.Text = row.Cells["hargaBuku"].Value.ToString();
                txtNStok.Text = row.Cells["stokBarang"].Value.ToString();
                MessageBox.Show($"Buku ke-{id.ToString()} terpilih");
                if (row.Cells["Hapus"].Selected){
                    var bukuToDelete = db.aksesBukus.FirstOrDefault(b => b.idBuku == id);
                    if (bukuToDelete != null)
                    {
                        DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            var transaksiTerkait = db.Transaksis.Where(t => t.idBuku == bukuToDelete.idBuku).ToList();
                            foreach (var transaksi in transaksiTerkait)
                            {
                                db.Transaksis.Remove(transaksi);
                            }
                            db.aksesBukus.Remove(bukuToDelete);
                            db.SaveChanges();
                            MessageBox.Show("Data Berhasil Dihapus");
                            loadContent();
                            txtNNamaBuku.Text = "";
                            txtNPenulis.Text = "";
                            txtNHarga.Text = "";
                            txtNStok.Text = "";
                            id = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        void update()
        {
            if (id == 0)
            {
                MessageBox.Show("Pilih data yang ingin diupdate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var bukuToUpdate = db.aksesBukus.FirstOrDefault(b => b.idBuku == id);
            if (bukuToUpdate != null)
            {
                bukuToUpdate.namaBuku = txtNNamaBuku.Text;
                bukuToUpdate.namaPenulis = txtNPenulis.Text;
                bukuToUpdate.hargaBuku = Convert.ToInt32(txtNHarga.Text);
                bukuToUpdate.stokBarang = Convert.ToInt32(txtNStok.Text);
                db.SaveChanges();
                MessageBox.Show("Data Berhasil Diupdate");
                loadContent();
            }
            else
            {
                MessageBox.Show("Data tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void transaction()
        {
            if (id == 0)
            {
                MessageBox.Show("Pilih buku yang ingin dibeli!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var selectedBuku = db.aksesBukus.FirstOrDefault(b => b.idBuku == id);
                if (selectedBuku != null)
                {
                    using (var frmTrans = new transaction(selectedBuku))
                    {
                        frmTrans.ShowDialog();
                    }
                    db.Dispose();
                    db = new bukuEntities3();
                    loadContent();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        void search()
        {
            string keyword = txtNSearchBuku.Text.Trim().ToLower();
            var filteredData = db.aksesBukus.Where(b => b.namaBuku.ToLower().Contains(keyword) || b.namaPenulis.ToLower().Contains(keyword)).ToList();
            dataGridView2.DataSource = filteredData;
            dataGridView2.Columns["idBuku"].Visible = false;
            if (dataGridView2.Columns.Contains("Hapus"))
            {
                dataGridView2.Columns.Remove("Hapus");
            }
            DataGridViewImageColumn btnDel = new DataGridViewImageColumn
            {
                Image = Properties.Resources.trash,
                Name = "Hapus",
                HeaderText = "Hapus",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView2.Columns.Add(btnDel);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            transaction();
        }
    }
}
