﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetvetPOS_Inventory_System
{
    public partial class modalAddStocks : Form
    {
        public string Barcode { get; set; }
        public int CurrentStocks { get; set; }
        public int NewStocks { get; set; }
        public int AdditionalStocks { get; set; }


        public modalAddStocks(string barcode, string productName, int currentStocks)
        {
            InitializeComponent();
            Barcode = barcode;
            CurrentStocks = currentStocks;

            lblTitle.Text = Barcode;
            lblProductName.Text = productName;
            lblCurrentStocks.Text = CurrentStocks.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtStocks.Text))
            {
                AdditionalStocks = int.Parse(txtStocks.Text);
                if (AdditionalStocks != 0)
                    DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void modalAddStocks_Load(object sender, EventArgs e)
        {

        }

        private void txtStocks_TextChanged(object sender, EventArgs e)
        {
            MyExtension.Validation.filterToNumeric(sender as TextBox);
            computeNewStocks();
        }

        void computeNewStocks()
        {
            if (string.IsNullOrWhiteSpace(txtStocks.Text))
            {
                lblNewStocks.Text = string.Empty;
                return;
            }
            else
            {
                int currentStocks = int.Parse(lblCurrentStocks.Text);
                int add = int.Parse(txtStocks.Text);
                lblNewStocks.Text = (currentStocks + add).ToString();
            }
        }

        private void txtStocks_Leave(object sender, EventArgs e)
        {
            computeNewStocks();
        }
    }
}
