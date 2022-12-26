using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimBusinessLayer
{
    public static class LogYoneticisi
    {
        public static void  LoguYaz(string mesaj)
        {
            try
            {
                // Log---> programa ait hata mesajı ya da bilgileri tuttuğumuz kayıtlardır
                //Loglar txt dosyasında tutulabilir
                //loglar veri tabanındaki log tablolarına yazılabilir
                //Loglamayı kolaylaştıran Nlog tarzı paketler indirilebilir
                string dosyaAdi = $"AkbilYonetimiProjesi_{DateTime.Now.ToString ("yyyyMMdd")}.txt";
                string dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dosyaAdi);

                StreamWriter yazici = new StreamWriter(append: true, path: dosyaYolu);
                yazici.AutoFlush = true;
                yazici.WriteLine($"{DateTime.Now.ToString()} - {mesaj}");
                yazici.Close();
            }
            catch 
            {
                //loglamada problem varsa email atılabilir
                //Dbye kaydedilebilir
            }
        }
    }
}
