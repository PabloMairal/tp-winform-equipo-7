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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Dominio;

namespace Catalogo {
    public partial class ListadoArticulos : Form
    {
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        List<Articulo> Articulos = new List<Articulo>();
        public ListadoArticulos()
        {
            InitializeComponent();

        }

        public EventHandler OnEditorOpen;
        public EventHandler OnDetailOpen;

        private void _OnEditorOpen(CustomEventArgs e)
        {
            if (OnEditorOpen != null)
            {
                OnEditorOpen(this, e);
            }
        }
        private void _OnDetailOpen(CustomEventArgs e)
        {
            if (OnDetailOpen != null)
            {
                OnDetailOpen(this, e);
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            _OnEditorOpen(new CustomEventArgs { Articulo = null });
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            _OnDetailOpen(new CustomEventArgs { Articulo = new Articulo() });
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _OnEditorOpen(new CustomEventArgs { Articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem });

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtBuscador.Text;

            if (filtro != "")
            {
                listaFiltrada = Articulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));               
            }
            else
            {
                listaFiltrada = Articulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
        }

        private void ListadoArticulos_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("Entrando a ListadoArticulos");
            Articulos = articuloNegocio.ListarArticulos();
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = Articulos;
        }
    }
}
