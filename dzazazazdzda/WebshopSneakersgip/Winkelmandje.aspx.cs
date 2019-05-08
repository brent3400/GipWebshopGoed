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
            lblKlantID.Text = Session["KlantID"].ToString();


            _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))

            gvWinkelmand.DataSource = _cont.LoadFromProductenInWinkelmand(Convert.ToInt32(Session["KlantID"]));
            gvWinkelmand.DataBind();
        }
    }
}