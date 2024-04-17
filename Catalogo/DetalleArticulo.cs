﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class DetalleArticulo : Form
    {  
        public DetalleArticulo()
        {
            InitializeComponent();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetalleArticulo_Load(object sender, EventArgs e)
        {

        }

        private void OnMouseEnterButtonReturn(object sender, EventArgs e)
        {
            btnVolver.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EDEDED");
            // cursor pointer
            btnVolver.Cursor = Cursors.Hand;
        }

        private void OnMouseLeaveButtonReturn(object sender, EventArgs e)
        {
            btnVolver.ForeColor = System.Drawing.ColorTranslator.FromHtml("#EDEDED");
            btnVolver.Cursor = Cursors.Default;
        }   
    }
}