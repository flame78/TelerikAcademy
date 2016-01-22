using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TreeViewXml
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tvXml_SelectedNodeChanged(object sender, EventArgs e)
        {
            lbSelectedNode.Text = xds.GetXmlDocument().SelectSingleNode(tvXml.SelectedNode.DataPath).InnerXml;

        }
    }
}