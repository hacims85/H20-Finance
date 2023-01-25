using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NFT
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public int Uye_ID { get; set; }
        public decimal Fiyat { get; set; }
    }
}
