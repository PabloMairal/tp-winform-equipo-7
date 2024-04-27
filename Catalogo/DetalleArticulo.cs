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

        private void LoadImage(string url)
        {
            try
            {
                pbxImagenes.Load(url);
            }
            catch (Exception)
            {
                pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetalleArticulo_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = "Cod: " + articulo.Codigo;
            lblTitulo.Text = articulo.Nombre;
            rtxtDescripcion.Text = articulo.Descripcion;
            lblPrecio.Text ="$ " +  articulo.Precio.ToString("0.00");
            lblCategoria.Text = articulo.Categoria.Nombre;
            lblMarca.Text = articulo.Marca.Nombre;
            

            if (articulo.Imagenes.Count > 0)
            {
                LoadImage(articulo.Imagenes[ImagenActual]);
                if (articulo.Imagenes.Count == 1)
                {
                    btnBack.Visible = false;
                    btnNext.Visible = false;
                }
            }
            else
            {
                LoadImage("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
                btnBack.Visible = false;
                btnNext.Visible = false;
            }

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
                LoadImage(articulo.Imagenes[ImagenActual]);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ImagenActual < articulo.Imagenes.Count - 1)
            {
                ImagenActual += 1;
                LoadImage(articulo.Imagenes[ImagenActual]);
            }
        }
    }
}
