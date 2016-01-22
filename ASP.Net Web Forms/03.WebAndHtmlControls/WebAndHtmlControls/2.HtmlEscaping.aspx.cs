using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class HtmlEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBoxSampleText.Text=="")
            {
                TextBoxSampleText.Text = "<h1>Heading</h1>Text<script>alert('bug!')</script>";
            }
        }

        protected void ButtonShowTextClick(object sender, EventArgs e)
        {
            var textBox = new TextBox();
            textBox.Text = TextBoxSampleText.Text;
            var label = new Label();
            label.Text = Server.HtmlEncode(TextBoxSampleText.Text);
            var literal = new Literal();
            literal.Mode = LiteralMode.Encode;
            literal.Text = TextBoxSampleText.Text;
            var notEscapedText = new Literal();
            notEscapedText.Text = TextBoxSampleText.Text;
            notEscapedText.Mode = LiteralMode.PassThrough;
            FormHtmlEscaping.Controls.Add(new HtmlGenericControl("hr"));
            FormHtmlEscaping.Controls.Add(textBox);
            FormHtmlEscaping.Controls.Add(new HtmlGenericControl("hr"));
            FormHtmlEscaping.Controls.Add(label);
            FormHtmlEscaping.Controls.Add(new HtmlGenericControl("hr"));
            FormHtmlEscaping.Controls.Add(literal);
            FormHtmlEscaping.Controls.Add(new HtmlGenericControl("hr"));
            FormHtmlEscaping.Controls.Add(notEscapedText);

        }
    }
}