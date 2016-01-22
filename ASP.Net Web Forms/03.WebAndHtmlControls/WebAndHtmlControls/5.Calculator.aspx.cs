using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class Calculator : System.Web.UI.Page
    {
        private static decimal value;
        private static decimal oldValue;
        private static char command;
        private static bool displayOldValue;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (displayOldValue)
            {
                Value.Text = oldValue.ToString();
            }
            else
            {
                Value.Text = value.ToString();
            }
        }

        protected void DigitClick(object sender, CommandEventArgs e)
        {
            try
            {
                value = decimal.Parse(value.ToString() + e.CommandArgument);
                displayOldValue = false;
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ClearClick(object sender, EventArgs e)
        {
            value = 0;
            command = (char)0;
            oldValue = 0;
        }

        protected void CalculationCommandClick(object sender, CommandEventArgs e)
        {
            var newCommand = e.CommandArgument.ToString()[0];


            if (newCommand == '=')
            {
                if (command != 0)
                {
                    value = ExecuteCommand(command);
                }
                command = (char)0;
                displayOldValue = false;
            }
            else if (newCommand == 'S')
            {
                if (command != 0)
                {
                    value = ExecuteCommand(command);
                }
                value = ExecuteCommand(newCommand);
                command = (char)0;
                displayOldValue = false;
            }
            else
            {
                if (command != 0)
                {
                    value = ExecuteCommand(command);
                }
                oldValue = value;
                displayOldValue = true;
                value = 0;
                command = newCommand;
            }
        }

        private decimal ExecuteCommand(char command)
        {
            decimal result=0;

            try
            {
                switch (command)
                {
                    case '+':
                        result = oldValue + value;
                        break;
                    case '-':
                        result = oldValue - value;
                        break;
                    case '*':
                        result = oldValue * value;
                        break;
                    case '/':
                        result = oldValue / value;
                        break;
                    case 'S':
                        result = (decimal)Math.Sqrt((double)value);
                        break;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message + "');", true);
            }

            return result;
        }
    }
}