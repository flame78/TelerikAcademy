using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateRandomNumber(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();
                RandomNumber.InnerText = random.Next(int.Parse(TextLowerRange.Value.ToString()), int.Parse(TextUpperRange.Value)+1).ToString();
                RandomNumber.Visible = true;
            }
            catch (Exception)
            {
            }
        }
    }
}