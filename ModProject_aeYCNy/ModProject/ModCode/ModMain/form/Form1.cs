﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD_aeYCNy.form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void itemBtn_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateFeatureForm createFeatureForm = new CreateFeatureForm();
            createFeatureForm.ShowDialog();
        }

        private void npcFormBtn_Click(object sender, EventArgs e)
        {
            NpcForm npcForm = new NpcForm();
            npcForm.ShowDialog();
        }
    }
}
