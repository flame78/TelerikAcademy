using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Countries
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCountries_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
        }

        protected void gvCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;

            if (command == "New")
            {
                (dsCountries as IDataSource).GetView(string.Empty).Insert(new OrderedDictionary(), DefaultOperationCallback);
            }

        }

        private static bool DefaultOperationCallback(int affectedRows, Exception ex)
        {
            return false;
        }

        protected void lbContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsCountries.Where = "it.[ContinentId] = " + lbContinents.SelectedValue;
            gvCountries.SelectedIndex = -1;
            dsTowns.Where = "";
        }

        protected void gvCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsTowns.Where = "it.[CountryId] = " + gvCountries.SelectedValue;
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var dbContext = new CountriesEntities();

            Stream fileStream = null;

            if (fuFlag.HasFile && gvCountries.SelectedDataKey != null)
            {
                if (fuFlag.PostedFile.ContentType.StartsWith("image/"))
                {
                    fileStream = fuFlag.PostedFile.InputStream;

                    var flag = new Bitmap(new Bitmap(fileStream), new Size(23, 15));

                    var selectedCountry = dbContext.Countries.Find(gvCountries.SelectedDataKey.Value);

                    Stream newFlagStream = new MemoryStream();
                    flag.Save(newFlagStream, ImageFormat.Png);
                    var flagData = new byte[newFlagStream.Length + 1];
                    newFlagStream.Position = 0;
                    newFlagStream.Read(flagData, 0, (int)newFlagStream.Length);
                    selectedCountry.Flag = flagData;
                    dbContext.SaveChanges();
                    gvCountries.DataBind();
                }
            }
        }
    }
}