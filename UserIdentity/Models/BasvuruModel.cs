using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserIdentity.Models
{
    public class BasvuruModel
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string ProjeAdi { get; set; }
        public string Aciklama { get; set; }
        public bool SehirSec { get; set; }
        public bool Onay { get; set; }
        public DateTime dateTime { get; set; }
        public string UserId { get; set; }
    }
}