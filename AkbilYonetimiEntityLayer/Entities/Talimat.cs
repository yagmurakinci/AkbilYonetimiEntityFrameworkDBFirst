using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiEntityLayer.Entities
{
    public class Talimat:IIDProperty
    {
        public DateTime OlusturulmaTarihi { get; set; }
        public string AkbilID { get; set; }
        public decimal YuklenecekMiktar { get; set; }
        public bool YuklendiMi { get; set; }
        public DateTime? YuklendigiTarihi { get; set; }
        public int Id { get ; set ; }
        //  public Nullable <DateTime> YuklendigiTarihi { get; set; }
    }
}
