using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCaching
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowFiles_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("FilesList.aspx?path=" + tbPath.Text);
        }
    }
}