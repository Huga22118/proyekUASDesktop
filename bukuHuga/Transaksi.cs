//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bukuHuga
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaksi
    {
        public int idTransaksi { get; set; }
        public int idBuku { get; set; }
        public int jumlahBeli { get; set; }
        public int totalHarga { get; set; }
        public System.DateTime tanggalTransaksi { get; set; }
    
        public virtual aksesBuku aksesBuku { get; set; }
    }
}
