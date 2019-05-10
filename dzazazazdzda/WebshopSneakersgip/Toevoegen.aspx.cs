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
            if (_cont.CheckInWinkelmand(Convert.ToInt32(Session["ProductID"])) == true)
            {
                lblText.Visible = true; txtAantal.Visible = true; btnOk.Visible = true;
                lblFouttext.Visible = false; btnCatalogus.Visible = false;

                Session["NewVoorraad"] = Convert.ToInt32(Session["Voorraad"]) - Convert.ToInt32(txtAantal.Text);
                _cont.UpdateVoorraadMin(Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Session["Voorraad"]));

                _cont.UploadToWinkelmand(Convert.ToInt32(Session["KlantID"]), Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text));

                Response.Redirect("Winkelmandje.aspx");
            }
            else
            {
                lblText.Visible = false; txtAantal.Visible = false; btnOk.Visible = false;
                lblFouttext.Visible = true; btnCatalogus.Visible = true;
            }
           
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}