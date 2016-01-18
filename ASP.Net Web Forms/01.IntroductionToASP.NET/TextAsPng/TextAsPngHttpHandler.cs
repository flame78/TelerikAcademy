using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace TextAsPng
{
    public class TextAsPngHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var text = context.Request.Path;

            text = text.Substring(1);

            HttpResponse response = context.Response;
            response.ContentType = "image/png";


            PointF location = new PointF(10f, 10f);

            Bitmap bitmap = new Bitmap(800, 600);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 20))
                {
                    graphics.DrawString(text, arialFont, Brushes.Blue, location);
                }
            }

            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);

            response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
