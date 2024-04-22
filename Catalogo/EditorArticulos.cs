using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class EditorArticulos : Form
    {
        public Articulo Articulo { get; set; }
        public EditorArticulos()
        {
            InitializeComponent();
            this.Articulo = new Articulo();
        }

        public EditorArticulos(Articulo art)
        {
            InitializeComponent();
            this.Articulo = art;
            txtNombre.Text = art.Nombre;
            txtDescripcion.Text = art.Descripcion;
            txtCodigo.Text = art.Codigo.ToString();
            txtMarca.Text = art.IdMarca.ToString();
            txtCategoria.Text = art.IdCategoria.ToString();
            txtPrecio.Text = art.Precio.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                Articulo.Codigo = int.Parse(txtCodigo.Text);
                Articulo.Nombre = txtNombre.Text;
                Articulo.Descripcion = txtDescripcion.Text;
                Articulo.Marca.Id = int.Parse(txtMarca.Text);
                Articulo.Categoria.Id = int.Parse(txtCategoria.Text);
                Articulo.Precio = decimal.Parse(txtPrecio.Text);

                articuloNegocio.guardarArticulo(Articulo);
                MessageBox.Show("Articulo creado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
