using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_120_A.Models
{
    public partial class Trx
    {
        public string IdTrx { get; set; }
        public DateTime? TanggalTrx { get; set; }
        public string IdPembeli { get; set; }
        public string IdBarang { get; set; }
        public string IdAdmin { get; set; }
        public int? JumlahProduk { get; set; }
        public int? TotalTrx { get; set; }

        public virtual Adminnn IdAdminNavigation { get; set; }
        public virtual Barangg IdBarangNavigation { get; set; }
        public virtual Pelanggann IdPembeliNavigation { get; set; }
    }
}
