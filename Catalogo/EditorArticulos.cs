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
        public Articulo Articulo = null;
        public EditorArticulos()
        {
            InitializeComponent();
            this.Articulo = new Articulo();
        }

        public EditorArticulos(Articulo art)
        {
            InitializeComponent();
            this.Articulo = art;
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
                Articulo.Marca.Id = cboMarca.SelectedIndex;
                Articulo.Categoria.Id = cboCategoria.SelectedIndex;
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

        private void EditorArticulos_Load(object sender, EventArgs e)
        {
            //cboMarca.DataSource = MarcaNegocio...
            //cboMarca.ValueMember = "Id";
            //cboMarca.DisplayMember = "Nombre";
            //cboCategoria.DataSource = CategoriaNegocio...
            //cboCategoria.ValueMember = "Id";
            //cboCategoria.DisplayMember = "Nombre";
            if (Articulo != null)
            {
                txtNombre.Text = Articulo.Nombre;
                txtDescripcion.Text = Articulo.Descripcion;
                //cboMarca.SelectedValue = Articulo.Marca.Id;
                //cboCategoria.SelectedValue = Articulo.Categoria.Id;
                txtCodigo.Text = Articulo.Codigo.ToString();
                txtPrecio.Text = Articulo.Precio.ToString();

            }

        }
    }
}
