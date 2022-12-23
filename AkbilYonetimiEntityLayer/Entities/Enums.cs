using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiEntityLayer.Entities
{
    public class Enums
    {
        public static Array AkbilTipleriniGetir()
        {
            var akbilTipleri = Enum.GetValues(typeof(AkbilTipleri));
            return akbilTipleri;
        }
    }

    public enum AkbilTipleri
    {
        StandartAkbil=1,
        OgrenciAkbili=2,
        AnneAkbil=3
    }
}
