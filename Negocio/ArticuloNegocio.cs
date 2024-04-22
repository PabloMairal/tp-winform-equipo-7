using Catalogo;
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

        public void guardarArticulo(Articulo articulo)
        {
            try
            { 
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.Comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                datos.Comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                datos.Comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                datos.Comando.Parameters.AddWithValue("@IdMarca", articulo.IdMarca);
                datos.Comando.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
                datos.Comando.Parameters.AddWithValue("@Precio", articulo.Precio);
                datos.ejecutarAccion();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally { datos.cerrarConexion();}
        }


    }
}
