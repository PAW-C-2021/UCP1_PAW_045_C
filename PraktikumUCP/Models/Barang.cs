using System;
using System.Collections.Generic;

namespace PraktikumUCP.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdBarang { get; set; }
        public int? IdSupplier { get; set; }
        public string NamaBarang { get; set; }
        public int? StockBarang { get; set; }
        public int? HargaBarang { get; set; }

        public Supplier IdSupplierNavigation { get; set; }
        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
