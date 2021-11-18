using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Pembayaran = new HashSet<Pembayaran>();
        }

        public int IdTransaksi { get; set; }
        public int? IdBarang { get; set; }
        public int? IdPembeli { get; set; }
        public int? JmlBrgDibeli { get; set; }
        public DateTime? TglTransaksi { get; set; }

        public Barang IdBarangNavigation { get; set; }
        public Pembeli IdPembeliNavigation { get; set; }
        public ICollection<Pembayaran> Pembayaran { get; set; }
    }
}
