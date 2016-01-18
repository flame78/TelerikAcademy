using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageLifeCycleEvents
{
    public partial class Default : System.Web.UI.Page
    {
        delegate void Printer(string s);

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //var events = this.GetType().GetEvents();

            //foreach (var ev in this.GetType().GetEvents()  )
            //{
            //    var name = ev.Name;
            //    formPageEvents.Controls.Add(new Label() { Text = name + " Reflection<br />" });
            //}

            ShowCaller();

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_SaveState(object sender, EventArgs e)
        {
            ShowCaller();
        }


        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_DataBinding(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_Disposed(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_AbortTransaction(object sender, EventArgs e)
        {
            ShowCaller();
        }

        protected void Page_CommitTransaction(object sender, EventArgs e)
        {
            ShowCaller();
        }

        private void ShowCaller()
        {
            var m = new StackTrace().GetFrame(1).GetMethod();

            var methodName = m.Name;

            try
            {
                Debug.WriteLine(methodName + " called");
                formPageEvents.Controls.Add(new Label() { Text = methodName + " called.<br />" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}