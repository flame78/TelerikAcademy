using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlUniversities.Items.Add(new ListItem("Telerik"));
                ddlUniversities.Items.Add(new ListItem("Soft Uni"));

                ddlSpecialities.Items.Add(new ListItem("C# Programmer"));
                ddlSpecialities.Items.Add(new ListItem("JavaScript Programer"));

                lbCourses.Items.Add(new ListItem("C# Part 1"));
                lbCourses.Items.Add(new ListItem("C# Part 2"));
                lbCourses.Items.Add(new ListItem("HTML"));
                lbCourses.Items.Add(new ListItem("CSS"));
                lbCourses.Items.Add(new ListItem("JavaScript fundamentals"));
                lbCourses.Items.Add(new ListItem("JavaScript apps"));
            }
            else
            {
                Wraper.Controls.Add(new HtmlGenericControl("h1") { InnerText = "Summary" });
                Wraper.Controls.Add(new HtmlGenericControl("p") { InnerText = "Sudent name: " + tbFirstName.Text + " " + tbLastName.Text });
                Wraper.Controls.Add(new HtmlGenericControl("p") { InnerText = "Faculty number: " + tbFacultyNumber.Text });
                Wraper.Controls.Add(new HtmlGenericControl("p") { InnerText = "University: " + ddlUniversities.SelectedItem.Text });
                Wraper.Controls.Add(new HtmlGenericControl("p") { InnerText = "Specialty: " + ddlSpecialities.SelectedItem.Text });

                var courses = new List<string>();

                foreach (ListItem course in lbCourses.Items)
                {
                    if(course.Selected)
                    {
                        courses.Add(course.Text);
                    }
                }

                Wraper.Controls.Add(new HtmlGenericControl("p") { InnerText = "Courses: " + string.Join(", ", courses) });
            }
        }
    }
}