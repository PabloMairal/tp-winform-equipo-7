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
using Dominio;
using System.Net;
using System.Text.RegularExpressions;

namespace Catalogo
{
    public partial class EditorArticulos : Form
    {
        int ImagenActual = 0;
        public Articulo Articulo = null;
        public EditorArticulos()
        {
            InitializeComponent();
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
                //if(string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                //   string.IsNullOrWhiteSpace(txtNombre.Text) ||
                //   string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                //   string.IsNullOrWhiteSpace(txtPrecio.Text))
                //{
                //    MessageBox.Show("Por favor complete todos los campos");
                //    return;
                //}
                if(Articulo == null)
                {
                    Articulo = new Articulo();
                }
                Articulo.Codigo = txtCodigo.Text;
                Articulo.Nombre = txtNombre.Text;
                Articulo.Descripcion = txtDescripcion.Text;
                Articulo.Marca = (Marca)cboMarca.SelectedItem;
                Articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                Articulo.Precio = decimal.Parse(txtPrecio.Text);
                if(txtUrl.Text != "")
                {
                    Articulo.Imagenes.Add(txtUrl.Text);
                }
                
                if(Articulo.Id == 0)
                {
                articuloNegocio.guardarArticulo(Articulo);
                MessageBox.Show("Articulo creado exitosamente");
                }
                else
                {
                    articuloNegocio.guardarArticulo(Articulo);
                    MessageBox.Show("Articulo modificado exitosamente");
                }
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
            MarcaNegocio MarcaNegocio = new MarcaNegocio();
            cboMarca.DataSource = MarcaNegocio.ListarMarcas();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Nombre";
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            cboCategoria.DataSource = CategoriaNegocio.ListarCategorias();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Nombre";
            pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            if (Articulo != null)
            {
                txtNombre.Text = Articulo.Nombre;
                txtDescripcion.Text = Articulo.Descripcion;
                cboMarca.SelectedValue = Articulo.Marca.Id;
                cboCategoria.SelectedValue = Articulo.Categoria.Id;
                txtCodigo.Text = Articulo.Codigo.ToString();
                txtPrecio.Text = Articulo.Precio.ToString();
                try
                {
                    txtUrl.Text = Articulo.Imagenes[0];
                    pbxImagenes.Load(txtUrl.Text);
                }
                catch (Exception)
                {
                    pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MarcasCategorias MarcasCategorias = new MarcasCategorias("Marca");
            MarcasCategorias.ShowDialog();

        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            MarcasCategorias MarcasCategorias = new MarcasCategorias("Categorias");
            MarcasCategorias.ShowDialog();
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            try
            {
                pbxImagenes.Load(txtUrl.Text);
            }
            catch (Exception ex)
            {
                pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ImagenActual += 1;
            if (ImagenActual < Articulo.Imagenes.Count)
            {
                txtUrl.Text = Articulo.Imagenes[ImagenActual];
                try
                {
                    pbxImagenes.Load(txtUrl.Text);
                }
                catch (Exception)
                {
                    pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
                }
            }
            else
            {
                pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
                txtUrl.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(ImagenActual != 0)
            {
                ImagenActual -= 1;

                txtUrl.Text = Articulo.Imagenes[ImagenActual];
                try
                {
                    pbxImagenes.Load(txtUrl.Text);
                }
                catch (Exception)
                {
                    pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
                }
            }
        }
    }
}
