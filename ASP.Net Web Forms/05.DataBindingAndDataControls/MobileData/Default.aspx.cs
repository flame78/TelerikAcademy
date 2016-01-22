using MobileData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileData
{
    public partial class Default : System.Web.UI.Page
    {
        public static List<Producer> producers;
        public static List<Extra> features;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SeedData();
                ddlProducers.DataBind();
                ddlProducers_SelectedIndexChanged(null, null);

                var typeOfEngineArray = new string[5];
                foreach (EngineType engineType in Enum.GetValues(typeof(EngineType)))
                {
                    typeOfEngineArray[(int)engineType] = engineType.ToString();
                }

                rblTypeOfEngine.DataSource = typeOfEngineArray;
                rblTypeOfEngine.SelectedIndex = 0;
                rblTypeOfEngine.DataBind();

                cblExtras.DataSource = features;
                cblExtras.DataTextField = "Name";
                cblExtras.DataBind();
            }

        }


        protected void Submit_Click(object s, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append("<br/>Make: " + ddlProducers.SelectedItem.Text);
            sb.Append("<br/>Model: " + ddlModels.SelectedItem.Text);
            sb.Append("<br/>Engine type: " + rblTypeOfEngine.SelectedItem.Text);
            sb.Append("<br/>Features:");

            foreach(ListItem item in cblExtras.Items)
            {
                if (item.Selected)
                {
                    sb.AppendLine("<br/>      -" + item.Text);
                }
            }

            lblInfo.Text = sb.ToString();
        }

        private void SeedData()
        {
            producers = new List<Producer>();

            var bmw = new Producer()
            {
                Name = "BMW",
                Models = new List<Model>() {
                new Model() {Name="1", BasePrice=1000 },
                new Model() {Name="135", BasePrice=1100 },
                new Model() {Name="325", BasePrice=1200 },
                new Model() {Name="700", BasePrice=2000 },
                new Model() {Name="Z1", BasePrice=4000 },
            }
            };
            producers.Add(bmw);

            var mercedes = new Producer()
            {
                Name = "Mercedes",
                Models = new List<Model>() {
                new Model() {Name="110", BasePrice=1000 },
                new Model() {Name="200", BasePrice=1100 },
                new Model() {Name="C250", BasePrice=1200 },
                new Model() {Name="E60", BasePrice=2000 },
                new Model() {Name="S600", BasePrice=4000 },
            }
            };
            producers.Add(mercedes);

            features = new List<Extra>() {
            new Extra("Air condition"),
            new Extra("CD player"),
            new Extra("Immobilizer"),
            new Extra("Fog lamp"),
            new Extra("Sport seats"),
            new Extra("Alloy wheels"),
            new Extra("Panoramic roof"),
            new Extra("Full leather"),
            };

        }

        protected void ddlProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlModels.DataSource = producers[ddlProducers.SelectedIndex].Models;
            ddlModels.DataBind();
        }
    }
}