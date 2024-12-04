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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
         
            var values=db.TblGuide.ToList();
            dataGridView1.DataSource = values;  
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           TblGuide tblGuide=new TblGuide();
            tblGuide.GuideName=txtName.Text;
            tblGuide.GuideSurname=txtSurname.Text;
            db.TblGuide.Add(tblGuide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi.");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarı ile silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.TblGuide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarı ile Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values=db.TblGuide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}