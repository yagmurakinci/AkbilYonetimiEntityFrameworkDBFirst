using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiDataLayer
{
     public interface ISayisalDonusluProsedur
    {
        int GeriSayisalDonusYapanProsedur(string prosedurAdi, Dictionary<string, object> girdiler=null); //dictionary yerine hashtable da kullanılabilir.
    }
}
