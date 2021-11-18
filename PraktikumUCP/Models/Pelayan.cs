using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Pelayan
    {
        public Pelayan()
        {
            Pembayaran = new HashSet<Pembayaran>();
        }

        public int IdPelayan { get; set; }
        public string NamaPelayan { get; set; }
        public string NoTelpPelayan { get; set; }
        public string AlamatPelayan { get; set; }

        public ICollection<Pembayaran> Pembayaran { get; set; }
    }
}
