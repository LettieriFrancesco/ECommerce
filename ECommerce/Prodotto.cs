using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce
{
    public class Prodotto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string DescrizioneHome { get; set; }
        public string DescrizioneDettaglio { get; set; }
        public decimal Prezzo { get; set; }
        public string Immagine { get; set; }
    }
}