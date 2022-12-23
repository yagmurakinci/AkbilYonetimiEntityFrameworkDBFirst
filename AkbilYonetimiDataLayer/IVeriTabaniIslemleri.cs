using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiDataLayer
{
    public interface IVeriTabaniIslemleri : ISayisalDonusluProsedur
    {
        string ConnectionStringCumlesi { get; set; }

        //CRUD --> create read update delete
        //VeriyiListele     //veriEkle     //veriSil    //veriGuncelle

        DataTable VeriGetir(string tabloAdi, string kolonlar = "*", string kosullar = null);
        string VeriEklemeCumlesiOlustur(string tabloAdi , Dictionary<string,object> kolonlar ); //kolonları nasıl alabiliriz??
        int KomutIsle(string eklemeyadaGuncellemeCumlesi); // executenonquery
        string VeriGuncellemeCumlesiOlustur(string tabloAdi, Hashtable kolonlar, string kosullar = null); //kolonları nasıl alabiliriz??

        int VeriSil(string tabloAdi, string kosullar = null);

        Dictionary<string, object> VeriOku(string tabloAdi, string[] kolonlar, string kosullar = null);


    }
}
