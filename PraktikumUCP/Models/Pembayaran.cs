using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public int? IdPelayan { get; set; }
        public int? IdTransaksi { get; set; }
        public int? TotalPembayaran { get; set; }

        public Pelayan IdPelayanNavigation { get; set; }
        public Transaksi IdTransaksiNavigation { get; set; }
    }
}
