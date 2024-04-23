using Dominio;
using Negocio;
using System;
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
    public partial class MarcasCategoriasForm : Form
    {
        public MarcasCategoriasForm()
        {
            InitializeComponent();

        }
        public int idForm { get; set; }
        public bool element { get; set; }

        private void btnGuardarAux_Click(object sender, EventArgs e)
        {

            if (validarInput(txtNombre.Text))
            {
                if (element == true)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    if (idForm == -1)
                    {
                        Categoria categ = new Categoria();
                        categ.Nombre = txtNombre.Text;
                        categoriaNegocio.Agregar(categ);
                    }
                    else
                    {
                        Categoria categ = new Categoria();
                        categ.Id = idForm;
                        categ.Nombre = txtNombre.Text;
                        categoriaNegocio.Modificar(categ);
                    }
                }
                else
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    if (idForm == -1)
                    {
                        Marca marca = new Marca();
                        marca.Nombre = txtNombre.Text;
                        marcaNegocio.Agregar(marca);
                    }
                    else
                    {
                        Marca marca = new Marca();
                        marca.Id = idForm;
                        marca.Nombre = txtNombre.Text;
                        marcaNegocio.Modificar(marca);
                    }
                }

                Close();
            }
        }

        public void modificarTitulo(string titulo)
        {
            lblTituloAux.Text = titulo;
        }

        private bool validarInput(string txt)
        {
            try
            {
                if (txt.Length == 0)
                {
                    throw new Exception("El nombre no puede estar vacío");
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
