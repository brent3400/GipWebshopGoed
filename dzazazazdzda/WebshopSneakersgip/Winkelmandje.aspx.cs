using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Winkelmandje : System.Web.UI.Page
    {
        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (_cont.CheckWinkelmand() == true)
            {
                lblKlantID.Text = Session["KlantID"].ToString();
                lblNaam.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[0];
                lblAdres.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[1];
                lblPcGe.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[2] + " " +
                _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[3];

                lblDatum.Text = DateTime.Now.ToLongDateString();

                gvWinkelmand.DataSource = _cont.LoadFromProductenInWinkelmand(Convert.ToInt32(Session["KlantID"]));
                gvWinkelmand.DataBind();

                lblExclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalExclBTW);
                lblBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().BTW);
                lblInclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalInclBTW);
            }
            else
            {
                Response.Redirect("MandjeLeeg.aspx");
            }
           
        }

        protected void gvWinkelmand_SelectedIndexChanged(object sender, EventArgs e)
        {       
            _cont.DeleteFromWinkelmand(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(Session["KlantID"]));

            _cont.UpdateVoorraadPlus(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[4].Text), Convert.ToInt32(Session["NewVoorraad"]));

            if (_cont.CheckWinkelmand() == true)
            {
                gvWinkelmand.DataSource = _cont.LoadFromProductenInWinkelmand(Convert.ToInt32(Session["KlantID"]));
                gvWinkelmand.DataBind();
            }
            else
            {
                Response.Redirect("MandjeLeeg.aspx");
            }
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnBestellen_Click(object sender, EventArgs e)
        {
            _cont.UploadOrder(lblDatum.Text, Convert.ToInt32(Session["KlantID"]));
        }
    }
}