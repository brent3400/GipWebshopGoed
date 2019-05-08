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
            gvWinkelmand.DataSource = _cont.LoadFromProducten(Convert.ToInt32(Session["ProductID"]));
            gvWinkelmand.DataBind();
        }
    }
}