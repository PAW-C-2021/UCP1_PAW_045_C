using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Barang = new HashSet<Barang>();
        }

        public int IdSupplier { get; set; }
        public string NamaSupplier { get; set; }
        public string NoTlpSupplier { get; set; }
        public string AlamatSupplier { get; set; }
        public string JenisBarang { get; set; }

        public ICollection<Barang> Barang { get; set; }
    }
}
