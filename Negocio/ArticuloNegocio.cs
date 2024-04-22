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

        public void guardarArticulo(Articulo Articulo)
        {
            try
            {
                if (Articulo.Id == 0)
                {
                    datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                }
                else
                {
                    datos.setearConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = '@Nombre', Descripcion = '@Descripcion', IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                    datos.Comando.Parameters.AddWithValue("@Id", Articulo.Id);
                }
                datos.Comando.Parameters.AddWithValue("@Codigo", Articulo.Codigo);
                datos.Comando.Parameters.AddWithValue("@Nombre", Articulo.Nombre);
                datos.Comando.Parameters.AddWithValue("@Descripcion", Articulo.Descripcion);
                datos.Comando.Parameters.AddWithValue("@IdMarca", Articulo.Marca.Id);
                datos.Comando.Parameters.AddWithValue("@IdCategoria", Articulo.Categoria.Id);
                datos.Comando.Parameters.AddWithValue("@Precio", Articulo.Precio);
                datos.ejecutarAccion();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally 
            { 
                datos.cerrarConexion();
            }
        }


    }
}
