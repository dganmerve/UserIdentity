using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class Tercih
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
        public bool Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeAciklamasi { get; set; }
        public bool ProjeninNiteligi { get; set; }
        public bool Onay { get; set; }
        public string UserId { get; set; }
    }

}