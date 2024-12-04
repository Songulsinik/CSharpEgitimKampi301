﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.TblLocation.Count().ToString();
            lblSumCapacity.Text = db.TblLocation.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text=db.TblLocation.Count().ToString();
            lblAvgCapacity.Text = db.TblLocation.Average(x => x.LocationCapacity).ToString();
            lblAvgLocationPrice.Text=db.TblLocation.Average(x=>x.LocationPrice).ToString();

            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lblLastCountry.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();

            lblCappadociaLCapacity.Text = db.TblLocation.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

            var romeGuideId = db.TblLocation.Where(x => x.LocationCity == "Ege Turu").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.TblLocation.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.TblLocation.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.TblLocation.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text = db.TblLocation.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.TblGuide.Where(x => x.GuideName == "Songül" && x.GuideSurname == "Şinik").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.TblLocation.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
        }

       
    }
}