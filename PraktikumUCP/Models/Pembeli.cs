using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdPembeli { get; set; }
        public string NamaPembeli { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
