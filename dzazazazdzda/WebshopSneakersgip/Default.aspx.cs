using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Default : System.Web.UI.Page
    {
        Controller _cont = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["KlantID"] = 1;

            gvCatalogus.DataSource = _cont.LoadProductenData();
            gvCatalogus.DataBind();

            int aantal = Convert.ToInt32(gvCatalogus.Rows.Count - 1);
            for (int i = 0; i <= aantal; i++)
            {
                if (Convert.ToInt32(gvCatalogus.Rows[i].Cells[4].Text) == 0)
                {
                    gvCatalogus.Rows[i].Cells[5].Enabled = false;
                    gvCatalogus.Rows[i].Cells[5].Text = "Niet op voorraad!";
                }
            }
        }

        protected void gvCatalogus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ProductID"] = gvCatalogus.SelectedRow.Cells[0].Text;
            Session["Naam"] = gvCatalogus.SelectedRow.Cells[1].Text;
            Session["Foto"] = gvCatalogus.SelectedRow.Cells[2].Text;
            Session["Verkoopprijs"] = gvCatalogus.SelectedRow.Cells[3].Text;
            Session["Voorraad"] = gvCatalogus.SelectedRow.Cells[4].Text;
            Response.Redirect("Toevoegen.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Winkelmandje.aspx");
        }
    }
}