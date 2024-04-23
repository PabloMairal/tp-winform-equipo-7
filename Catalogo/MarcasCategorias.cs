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
    public partial class MarcasCategorias : Form
    {
        public MarcasCategorias(string tabName)
        {
            InitializeComponent();
            tabControl.SelectedIndex = tabName == "Categorias" ? 0 : 1;
        }

        public void CargarMarcasCategorias()
        {
            try
            {
                // Categorias
                CategoriaNegocio categoriasNegocio = new CategoriaNegocio();
                dgvCategorias.DataSource = categoriasNegocio.ListarCategorias();
                dgvCategorias.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dgvCategorias.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Marcas
                MarcaNegocio marcasNegocio = new MarcaNegocio();
                dgvMarcas.DataSource = marcasNegocio.ListarMarcas();
                dgvMarcas.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dgvMarcas.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MarcasCategorias_Load(object sender, EventArgs e)
        {
            CargarMarcasCategorias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (tabControl.SelectedTab.Name == "tabCategorias")
                {
                    if (dgvCategorias.CurrentRow == null)
                    {
                        MessageBox.Show("Por favor seleccione un item a eliminar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Categoria categ = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                    if (negocio.ValidarArticulosPorMrcCtg(categ.Id, "IdCategoria"))
                    {
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        categoriaNegocio.Eliminar(categ.Id);
                    }
                    else
                    {
                        MessageBox.Show("No se pueden eliminar categorias relacionadas a un artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    if (dgvMarcas.CurrentRow == null)
                    {
                        MessageBox.Show("Por favor seleccione un item a eliminar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Marca marca = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    if (negocio.ValidarArticulosPorMrcCtg(marca.Id, "IdMarca"))
                    {
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        marcaNegocio.Eliminar(marca.Id);
                    }
                    else
                    {
                        MessageBox.Show("No se pueden eliminar marcas relacionadas a un artículo.");
                    }
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor seleccione un item a modificar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CargarMarcasCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MarcasCategoriasForm form = new MarcasCategoriasForm();
            string titulo = seleccionarIdTitulo(form) ? "Modificar Categoria" : "Modificar Marca";
            form.modificarTitulo(titulo);
            if (form.idForm == -1) MessageBox.Show("Por favor seleccione un item a modificar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else form.ShowDialog();
            CargarMarcasCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcasCategoriasForm form = new MarcasCategoriasForm();
            seleccionarIdTitulo(form);
            string titulo = seleccionarIdTitulo(form) ? "Agregar Categoria" : "Agregar Marca";
            form.modificarTitulo(titulo);
            form.idForm = -1;
            form.ShowDialog();
            CargarMarcasCategorias();
        }


        private bool seleccionarIdTitulo(MarcasCategoriasForm form)
        {
            try
            {
                if (tabControl.SelectedTab.Name == "tabCategorias")
                {
                    form.element = true;
                    if (dgvCategorias.CurrentRow == null) form.idForm = -1;
                    else form.idForm = ((Categoria)dgvCategorias.CurrentRow.DataBoundItem).Id;
                }
                else
                {
                    form.element = false;   
                    if (dgvMarcas.CurrentRow == null) form.idForm = -1;
                    else form.idForm = ((Marca)dgvMarcas.CurrentRow.DataBoundItem).Id;
                }

                return form.element;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                form.idForm = -1;
                return false;
            }
        }
    }
}
