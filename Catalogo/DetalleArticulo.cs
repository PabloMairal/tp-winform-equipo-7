using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Catalogo
{
    public partial class DetalleArticulo : Form
    {  
        private Articulo articulo;
        private int ImagenActual = 0;
        public DetalleArticulo(Articulo art)
        {
            InitializeComponent();
            articulo = art;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ImagenActual != 0)
            {
                ImagenActual -= 1;
                pbxImagenes.Load(articulo.Imagenes[ImagenActual]);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ImagenActual < articulo.Imagenes.Count - 1)
            {
                ImagenActual += 1;
                pbxImagenes.Load(articulo.Imagenes[ImagenActual]);
            }
        }
    }
}
