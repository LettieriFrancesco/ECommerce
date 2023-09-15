using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["ID"]);
                    Prodotto selectedProduct = GetProductById(productId);

                    if(selectedProduct != null)
                    {
                        NomeProdotto.InnerHtml = selectedProduct.Nome;
                        DescrizioneProdotto.InnerHtml = selectedProduct.DescrizioneDettaglio;
                        PrezzoProdotto.InnerHtml = selectedProduct.Prezzo.ToString("C");
                        imgProdotto.ImageUrl = "/Content/Img/" + selectedProduct.Immagine;
                    }
                    else
                    {
                        lblMessaggioErrore.Text = "Prodotto non trovato.";
                    }

                }
                else
                {
                    lblMessaggioErrore.Text = "Non è stato possibile caricare i prodotti.";
                }
            }
           
        }

        private Prodotto GetProductById(int productId)
        {
            List<Prodotto> prodotti = GetProductList();
            return prodotti.FirstOrDefault(p => p.ID == productId);
        }
        private List<Prodotto> GetProductList()
        {
            List<Prodotto> prodotti = new List<Prodotto>
            {
                 new Prodotto {ID = 1, Nome = "Air Pods 2", DescrizioneHome = "La seconda generazione AirPods di casa Apple", DescrizioneDettaglio ="Le AirPods 2 generazione Apple. Le Airpods seconda generazione Apple sono auricolari Bluetooth di nuova generazione della marca Apple utili per parlare al telefono, per ascoltare musica o radio oppure per sentire l'audio di un film. Si tratta di un accessorio estremamente comodo e pratico da usare grazie all’assenza di fili fastidiosi. Le Apple Airpods 2 sono la soluzione ideale per chi vuole godere di una buona qualità del suono, ma senza l'impiccio di dover collegare le cuffie al proprio smartphone (di solito un iPhone) collegandole tramite cavo.", Prezzo = 139.00m, Immagine = "Airpods2.png"},
                    new Prodotto {ID = 2, Nome = "AirPods Pro", DescrizioneHome = "AirPods Pro di terza generazione",DescrizioneDettaglio="Gli AirPods (terza generazione) sono resistenti al sudore e all'acqua in attività e sport non acquatici e hanno un rating di grado IPX4. La resistenza al sudore e all'acqua non è una caratteristica permanente. Dimensioni e peso possono variare a seconda della configurazione e del processo di fabbricazione." ,Prezzo = 230.00m, Immagine = "AppleAirpods.png"},
                    new Prodotto {ID = 3, Nome = "MacBook Air", DescrizioneHome = "MacBook Air 13",DescrizioneDettaglio="MacBook Air è ricco di app utili a fare praticamente tutto ciò che vuoi. Modifica e condividi foto e video; crea presentazioni; ascolta la musica, leggi libri, guarda film e altro ancora. Scopri nuove app su App Store, comprese le app per iPhone e iPad che adesso funzionano anche su Mac con Apple Silicon." ,Prezzo = 1250.00m, Immagine = "applemacbookair.jpg"},
                    new Prodotto {ID = 4, Nome = "Imac 24", DescrizioneHome = "Apple Imac 24",DescrizioneDettaglio="Supporta simul­taneamente la risoluzione nativa, con 1 miliardo di colori, sullo schermo integrato e:\r\n\r\nun monitor esterno con risoluzione fino a 6K a 60Hz\r\nUscita video digitale Thunderbolt 3\r\n\r\nUscita DisplayPort nativa via USB‑C\r\nFunziona come uscita VGA, HDMI, DVI e Thunderbolt 2 tramite adattatori (in vendita separatamente)" ,Prezzo = 2450.00m, Immagine = "Imac.png"},
                    new Prodotto {ID = 5, Nome = "Ipad Air ", DescrizioneHome = "Ipad Air di casa Apple", DescrizioneDettaglio="\r\nLiquid Retina\r\nMulti‑Touch retroilluminato LED da 10,9\" (diagonale) con tecnologia IPS\r\nRisoluzione di 2360×1640 pixel a 264 ppi (pixel per pollice)\r\nAmpia gamma cromatica (P3)\r\nTrue Tone\r\nRivestimento oleorepellente a prova di impronte\r\nDisplay a laminazione completa\r\nRivestimento antiriflesso\r\nRiflettanza 1,8%\r\nLuminosità 500 nit\r\nCompatibile con Apple Pencil (2ª generazione)",Prezzo = 1300.00m, Immagine = "IPadPNG.png"},
                    new Prodotto {ID = 6, Nome = "Ipad Pro", DescrizioneHome = "Ipad Pro - 2^ Generazione",DescrizioneDettaglio="Apple iPad Pro 12.9 (2021) è uno tablet iOS. Lo schermo ha una risoluzione di 2048 x 2732 pixel e una diagonale di 12,9 pollici. È realizzato in tecnologia mini-LED LCD. La batteria non removibile di questo dispositivo è da 9720 mAh.", Prezzo = 1470.00m, Immagine = "ipadpro129.png"},
                    new Prodotto {ID = 7, Nome = "Iphone 12 Pro",DescrizioneHome = "Apple Iphone 12 Pro", DescrizioneDettaglio="iPhone 12 Pro ha uno schermo da 6,1 pollici con tecnologia OLED da 1176 x 2532 pixel. Lo schermo supporta la tecnologia HDR/Dolby Vision, ma non ha un refresh rate aumentato. Il modulo fotografico è composto da tre sensori da 12 megapixel: una principale stabilizzata, uno zoom 2x stabilizzato e una grandangolare.",Prezzo = 1220.00m, Immagine = "iPhone12.png"},
                    new Prodotto {ID = 8, Nome = "MacBook Pro", DescrizioneHome = "Apple MacBook Pro 13", DescrizioneDettaglio="MacBook Pro 13\" è più veloce e potente che mai. Con il nuovissimo chip M2, un sistema di raffreddamento attivo e fino a 20 ore di autonomia,1 affronta con agilità anche i carichi di lavoro più impegnativi. In più, racchiude uno spettacolare display Retina, una videocamera FaceTime HD e microfoni di qualità professionale nello stesso compatto design di sempre: è il più portatile dei nostri portatili Pro.",Prezzo = 1500.00m, Immagine = "macbookpro13.png"},
            };
            return prodotti;
        }

        protected void ButtonAggiungiCarrello_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int productId = Convert.ToInt32(Request.QueryString["ID"]);
                Prodotto selectedProduct = GetProductById(productId);

                if(selectedProduct != null)
                {
                    List<Prodotto>carrello = Session["Carrello"] as List<Prodotto> ?? new List<Prodotto>();
                    carrello.Add(selectedProduct);

                    Session["Carrello"] = carrello;
                }
            }
            Response.Redirect("Carrello.aspx");
        }
    }
}