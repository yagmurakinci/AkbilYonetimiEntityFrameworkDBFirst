using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiEntityLayer.Entities
{
    public class Akbil:IKayitTarihiProperty
    {
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Akbil Seri Numarasi 16 haneli olmalıdır!")]
        public string AkbilNo { get; set; }
        public decimal Bakiye { get; set; }
        public DateTime SonKullanimTarihi { get; set; }
        public int AkbilSahibiID { get; set; }
        public AkbilTipleri AkbilTipi { get; set; }
        public DateTime KayitTarihi { get ; set ; }

        //Akbil tipi gelecek
    }
}
