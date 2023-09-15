using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Carrello : System.Web.UI.Page
    {
        List<Prodotto> carrello = new List<Prodotto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carrello = Session["Carrello"] as List<Prodotto>;
                if (carrello != null)
                {
                    GridView1.DataSource = carrello;
                    GridView1.DataBind();
                    lblTotale.Text =$"Totale:{CalcolaTotaleCarrello()}" ;
                    btnSvuotaCarrello.Visible = carrello.Count > 0;
                    if(carrello.Count == 0)
                    {
                        carrelloVuoto.InnerHtml = "Il tuo carrello è vuoto! <a href='Default.aspx'>Premi qui</a> e ritorna al catalogo prodotti";
                    }
                }
                else
                {
                    carrelloVuoto.InnerHtml = "Il tuo carrello è vuoto! <a href='Default.aspx'>Premi qui</a> e ritorna al catalogo prodotti";
                    btnSvuotaCarrello.Visible = false;
                }
            }
        }

        protected void btnSvuotaCarrello_Click(object sender, EventArgs e)
        {
            Session.Remove("Carrello");
            Response.Redirect(Request.RawUrl);
            btnSvuotaCarrello.Visible = false;
        }

        protected string CalcolaTotaleCarrello()
        {
            List<Prodotto> carrello = Session["Carrello"] as List<Prodotto>;
            if (carrello != null)
            {
                decimal totale = carrello.Sum(p => p.Prezzo);
                return totale.ToString("C");
            }
            return "0.00";
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            int id = Convert.ToInt32(button.CommandArgument);

            if (Session["Carrello"] != null)
            {
                List<Prodotto> carrello = Session["Carrello"] as List<Prodotto>;
                Prodotto prodottoDaRimuovere = carrello.FirstOrDefault(p => p.ID == id);

                if (prodottoDaRimuovere != null)
                {
                    List<Prodotto>carrelloAggiornato = new List<Prodotto>(carrello);
                    carrelloAggiornato.Remove(prodottoDaRimuovere);
                    carrello.Remove(prodottoDaRimuovere);
                    Session["Carrello"] = carrelloAggiornato;
                }
            }
            GridView1.DataSource = Session["Carrello"] as List<Prodotto>;
            GridView1.DataBind();
            lblTotale.Text = $"Prezzo: {CalcolaTotaleCarrello()}";
            btnSvuotaCarrello.Visible = Session["Carrello"] != null && ((List<Prodotto>)Session["Carrello"]).Count > 0;

            if (Session["Carrello"] == null || ((List<Prodotto>)Session["Carrello"]).Count == 0)
            {
                lblTotale.Text = "Il tuo carrello è vuoto! <a href='Default.aspx'>Premi qui</a> e ritorna al catalogo prodotti";
                btnSvuotaCarrello.Visible = false;
            }
        }
    }
}