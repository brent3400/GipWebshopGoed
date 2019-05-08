using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Toevoegen : System.Web.UI.Page
    {
        Controller _cont = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblProductID.Text = Session["ProductID"].ToString();
            lblNaam.Text = Session["Naam"].ToString();
            lblVerkoopprijs.Text = Session["Verkoopprijs"].ToString();
            lblVoorraad.Text = Session["Voorraad"].ToString();
            imgProduct.ImageUrl = @"~\Files\" + Session["Foto"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _cont.UpdateVoorraad(Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Session["Voorraad"]));
            _cont.UploadToWinkelmand(Convert.ToInt32(Session["KlantID"]), Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text));
            Response.Redirect("Winkelmandje.aspx");
        }
    }
}