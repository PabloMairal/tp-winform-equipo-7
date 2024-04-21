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

namespace Catalogo {
    public partial class ListadoArticulos : Form
    {
        public ListadoArticulos()
        {
            InitializeComponent();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();


            articuloNegocio.TestConnection();

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

        private void button1_Click(object sender, EventArgs e)
        {
            _OnEditorOpen(new CustomEventArgs { Articulo = null });
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            _OnDetailOpen(new CustomEventArgs { Articulo = new Articulo() });
        }
    }
}
