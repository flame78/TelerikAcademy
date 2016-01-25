using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Countries
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            int id;

            if (int.TryParse(context.Request["id"], out id))
            {
                var countriesContext = new CountriesEntities();

                var country = countriesContext.Countries.Find(id);

                if (country.Flag != null)
                {
                //    Thread.Sleep(1000);
                    context.Response.ContentType = "image/png";
                    context.Response.BinaryWrite(country.Flag);
                }
                context.Response.End();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}