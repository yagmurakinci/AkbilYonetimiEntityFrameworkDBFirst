using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYonetimiEntityLayer.Entities
{
    public class Kullanici:IIDProperty, IKayitTarihiProperty
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "İsim alanı en fazla 50 karakter olmalıdır!")]
        public string Isim { get; set; }
        [StringLength(50, ErrorMessage = "İsim alanı en fazla 50 karakter olmalıdır!")]
        public string Soyisim { get; set; }
        public string Email { get; set; }
        [StringLength(8, ErrorMessage = "Parola alanı en fazla 50 karakter olmalıdır!")]
        public string Parola { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime KayitTarihi { get ; set ; }
    }
}
