using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //var db = new TelerikAcademyEntities();

            //var allTowns = db.Towns
            //    .Where(t => t.Name.Contains("p"));

            //foreach (var town in allTowns)
            //{
            //    Console.WriteLine(town.Name);

            //    foreach (var adress in town.Addresses)
            //    {
            //        Console.WriteLine("--"+adress.AddressText);
            //    }
            //}

            using (var db = new InternetUsageEntities())
            {

                var newRecord = new InternetUsageRecord();
                var br = new Browser();
                br.BrowserName = "Opera";
                var s = new Site();
                s.SiteAdress = "http://google.com";
                var m = new MacAdress();
                m.Mac = "0:1:2:3:4:5:6:7";
                newRecord.Browser = br;
                newRecord.DateTime = DateTime.Now;
                newRecord.Site = s;
                newRecord.MacAdress = m;

                db.InternetUsageRecords.Add(newRecord);
                db.SaveChanges();

                var res = db.Database.SqlQuery<InternetUsageRecord>("SELECT * FROM InternetUsageRecords");

                var c = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM InternetUsageRecords");

                Console.WriteLine(c.FirstOrDefault());

                foreach (var rec in res)
                {
                    Console.WriteLine(rec.DateTime);
                }

                var r2 = db.InternetUsageRecords.Join(
                    db.Browsers,
                    r => r.BrowserId,
                    b => b.Id,
                    (r, b) => new
                    {
                        Timee = r.DateTime,
                        Browserr = b.BrowserName
                    });

                foreach (var item in r2)
                {
                    Console.WriteLine(item.Timee+" "+item.Browserr);   
                }

                var groupedByBrowser = db.InternetUsageRecords
                    .GroupBy(r => r.Browser.BrowserName);
                    
                   

                foreach (var group in groupedByBrowser)
                {

                    Console.WriteLine(group.First().Browser.BrowserName);

                    var ordered = group.OrderByDescending(r => r.DateTime);
                    foreach (var item in ordered)
                    {
                    Console.WriteLine(item.DateTime+" "+item.Browser.BrowserName);
    
                    }
                }
            }

        }
    }
}
