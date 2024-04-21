using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        // Traer, subir, modificar base de datos
        private AccesoDatos datos = new AccesoDatos();
        public void TestConnection()
        {  
            try
            {
                datos.setearConsulta("SELECT * FROM ARTICULOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Console.WriteLine(datos.Lector["Nombre"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
