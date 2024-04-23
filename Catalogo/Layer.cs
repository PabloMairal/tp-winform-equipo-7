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
    public partial class Layer : Form
    {
        ListadoArticulos frmListadoArticulos = new ListadoArticulos();
        public Layer()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            frmListadoArticulos.MdiParent = this;
            frmListadoArticulos.OnDetailOpen += new EventHandler(ListadoArticulos_OnDetailOpen);
            frmListadoArticulos.OnEditorOpen += new EventHandler(ListadoArticulos_OnEditorOpen);
            frmListadoArticulos.Enter += new EventHandler(ListadoArticulos_Enter);
            frmListadoArticulos.Show();
            fixListadoArticulos();

        }

        private void openWindow(Form frm)
        {
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void fixListadoArticulos(bool reload = false)
        {
            frmListadoArticulos.WindowState = FormWindowState.Maximized;
        }

        private void frmLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ListadoArticulos_OnDetailOpen(object sender, EventArgs e)
        {
            CustomEventArgs args = (CustomEventArgs)e;
            DetalleArticulo frmDetalle = new DetalleArticulo(args.Articulo);
            openWindow(frmDetalle);
        }
        private void ListadoArticulos_OnEditorOpen(object sender, EventArgs e)
        {
            CustomEventArgs args = (CustomEventArgs)e;
            EditorArticulos frmEditor = args.Articulo != null ? new EditorArticulos(args.Articulo) : new EditorArticulos();
            openWindow(frmEditor);
        }
        private void ListadoArticulos_Enter(object sender, EventArgs e)
        {
            fixListadoArticulos();
            foreach (Form frm in this.MdiChildren)
            {
                if (!(frm is ListadoArticulos))
                {
                    frm.Close();
                }

            }

        }
    }
}
