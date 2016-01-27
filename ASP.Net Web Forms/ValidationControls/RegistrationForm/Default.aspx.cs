using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void RadioButtonListGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RadioButtonListGender.SelectedValue)
            {
                case "1":
                    divMale.Visible = true;
                    divFemale.Visible = false;
                    break;
                case "2":
                    divFemale.Visible = true;
                    divMale.Visible = false;
                    break;
                default:
                    divFemale.Visible = false;
                    divMale.Visible = false;
                    break;
            }
        }

        protected void CVCBAccept_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CheckBoxAccept.Checked;
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Validate();

            if (IsValid)
            {
                Response.Write("Registered");
                Response.End();
            }
        }
    }
}