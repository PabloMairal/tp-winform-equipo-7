using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo
{
    internal class Marca
    {
        public Marca(int Id, string Nombre) { 
            this.Id = Id;
            this.Nombre = Nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
