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
    public partial class transaction : Form
    {
        bukuEntities3 buk = new bukuEntities3();
        private aksesBuku buku;
        public transaction(aksesBuku selectedBuku)
        {
            InitializeComponent();
            buku = selectedBuku;
        }

        private void btnBeli_Click(object sender, EventArgs e)
        {
            beli();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void beli()
        {
            int jumlahBeli = int.Parse(txtJumlahBeli.Text);
            if (jumlahBeli > buku.stokBarang)
            { MessageBox.Show("Stok tidak cukup!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;}
            int harga = int.Parse(txtNominalUang.Text);bool kurang = harga < jumlahBeli * buku.hargaBuku;
            if (kurang)
            {
                MessageBox.Show("Uang tidak cukup!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kurangi stok
            using (var db = new bukuEntities3())
            {
                var bukuDb = db.aksesBukus.FirstOrDefault(b => b.idBuku == buku.idBuku);
                if (bukuDb != null)
                {
                    bukuDb.stokBarang -= jumlahBeli;
                    // Simpan transaksi
                    Transaksi trx = new Transaksi
                    {
                        idBuku = bukuDb.idBuku,
                        jumlahBeli = jumlahBeli,
                        totalHarga = jumlahBeli * bukuDb.hargaBuku,
                        tanggalTransaksi = DateTime.Now
                    };
                    db.Transaksis.Add(trx);
                    db.SaveChanges();
                    int kembalian = harga-(jumlahBeli * buku.hargaBuku);
                    if (kembalian == 0) MessageBox.Show("Transaksi berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show($"Transaksi berhasil! Kembalian Anda: {kembalian}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }
        private void transaction_Load(object sender, EventArgs e)
        {
            labelNamaBarang.Text = buku.namaBuku.ToString();
            labelHarga.Text = buku.hargaBuku.ToString();
            labelStok.Text = buku.stokBarang.ToString();
            labelPenulis.Text = buku.namaPenulis.ToString();
        }
    }
}
