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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
