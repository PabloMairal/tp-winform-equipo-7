using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo
{
    internal class Articulo
    {
        public Articulo()
        {

        }

        private int ID;
        public int IDArt
        {
            get { return ID; }
            set
            {
                if (value == IDArt)
                    return;
            }
        }

        public string Descripcion { get; set; }
        
        public float Costo {  get; set; }

        public string Marca { get; set; }

        public bool Estado { get; set; }

        
    }
}
  