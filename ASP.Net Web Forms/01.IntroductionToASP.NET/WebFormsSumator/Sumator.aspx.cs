using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculateSum_Click(object sender, EventArgs e)
        {
            double firstNumber=0;
            double secondNumber=0;

            try
            {
                firstNumber = double.Parse(tbFirstNumber.Text);
                secondNumber = double.Parse(tbSecondNumber.Text);
                lblSum.Text = (firstNumber + secondNumber).ToString();
            }
            catch (Exception)
            {
            } 
            
        }
    }
}