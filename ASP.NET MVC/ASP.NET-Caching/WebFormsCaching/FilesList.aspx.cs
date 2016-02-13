namespace WebFormsCaching
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Caching;

    public partial class FilesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = this.Request.QueryString["path"] ?? @"c:\";

            if (this.Cache[path] == null)
            {
                DirectoryInfo d = new DirectoryInfo(path);
                var files = d.GetFiles("*.*").Select(f => f.Name).ToList();
                files.Add(string.Format("Path: {0} -- cached in {1} UTC",path,DateTime.UtcNow));

                var dependency = new CacheDependency(path);
                this.Cache.Insert(
                    path,
                    files,
                    dependency,
                    DateTime.Now.AddYears(999),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null); 
            }

            this.lvFiles.DataSource = this.Cache[path] as List<string>;
            this.lvFiles.DataBind();
        }
    }
}