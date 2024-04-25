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
                //Validaciones campos obligatorios
                //if(string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                //   string.IsNullOrWhiteSpace(txtNombre.Text) ||
                //   string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                //   string.IsNullOrWhiteSpace(txtPrecio.Text))
                //{
                //    MessageBox.Show("Por favor complete todos los campos");
                //    return;
                //}
                Articulo.Codigo = txtCodigo.Text;
                Articulo.Nombre = txtNombre.Text;
                Articulo.Descripcion = txtDescripcion.Text;
                Articulo.Marca = (Marca)cboMarca.SelectedItem;
                Articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                Articulo.Precio = decimal.Parse(txtPrecio.Text);
                
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
            PlaceHolder();
            if (Articulo != null)
            {
                txtNombre.Text = Articulo.Nombre;
                txtDescripcion.Text = Articulo.Descripcion;
                cboMarca.SelectedValue = Articulo.Marca.Id;
                cboCategoria.SelectedValue = Articulo.Categoria.Id;
                txtCodigo.Text = Articulo.Codigo.ToString();
                txtPrecio.Text = Articulo.Precio.ToString();
                txtUrl.Text = Articulo.Imagenes[0];
            }
            else
            {
                Articulo = new Articulo();
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


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ImagenActual < Articulo.Imagenes.Count -1)
            {
                ImagenActual += 1;
                txtUrl.Text = Articulo.Imagenes[ImagenActual];
            }
            else if (ImagenActual == Articulo.Imagenes.Count -1)
            {
                ImagenActual += 1;
                txtUrl.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(ImagenActual != 0)
            {
                ImagenActual -= 1;

                txtUrl.Text = Articulo.Imagenes[ImagenActual];
            }
        }

        private void btnEliminarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                //Elimina de la lista una imagen, excepto la primera
                if (ImagenActual != 0 && ImagenActual < Articulo.Imagenes.Count)
                {
                    Articulo.Imagenes.Remove(txtUrl.Text);
                    ImagenActual -= 1;
                    txtUrl.Text = Articulo.Imagenes[ImagenActual];
                }
                //Elimina de la lista la primera imagen cuando hay más de una foto
                else if (ImagenActual == 0 && Articulo.Imagenes.Count > 1)
                {
                    Articulo.Imagenes.Remove(txtUrl.Text);
                    txtUrl.Text = Articulo.Imagenes[ImagenActual];
                }
                //Elimina de la lista la primera imagen si es la única foto
                else if (ImagenActual == 0 && Articulo.Imagenes.Count == 1)
                {

                    Articulo.Imagenes.Remove(txtUrl.Text);
                    txtUrl.Text = "";
                }
                //else
                //{
                //    txtUrl.Text = "";
                //    PlaceHolder();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pbxImagenes.Load(txtUrl.Text);
            }
            catch (Exception ex)
            {
                PlaceHolder();
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            //Si es el primer articulo, lo agrega a la lista
            if (txtUrl.Text != "" && !(Articulo.Imagenes.Contains(txtUrl.Text))
                && Articulo.Imagenes.Count == 0)
            {
                Articulo.Imagenes.Add(txtUrl.Text);
            }
            //Si se cambia una imagen por otra, la reemplaza en la lista
            else if (txtUrl.Text != "" && !(Articulo.Imagenes.Contains(txtUrl.Text))
                && ImagenActual < Articulo.Imagenes.Count)
            {
                Articulo.Imagenes[ImagenActual] = txtUrl.Text;
            }
            //Si es una imagen nueva, la agrega a la lista
            else if(txtUrl.Text != "" && !(Articulo.Imagenes.Contains(txtUrl.Text))
                && ImagenActual == Articulo.Imagenes.Count)
            {
                Articulo.Imagenes.Add(txtUrl.Text);
            }
        }

        private void PlaceHolder()
        {
            pbxImagenes.Load("https://www.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
        }
    }
}
