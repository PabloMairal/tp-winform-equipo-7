using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

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
                datos.SetearConsulta("SELECT * FROM ARTICULOS");
                datos.EjecutarLectura();
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
                datos.CerrarConexion();
            }
        }

        public void guardarArticulo(Articulo Articulo)
        {
            try
            {
                if (Articulo.Id == 0)
                {
                    datos.SetearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                }
                else
                {
                    datos.SetearConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                    datos.SetearParametro("@Id", Articulo.Id);
                }
                datos.SetearParametro("@Codigo", Articulo.Codigo);
                datos.SetearParametro("@Nombre", Articulo.Nombre);
                datos.SetearParametro("@Descripcion", Articulo.Descripcion);
                datos.SetearParametro("@IdMarca", Articulo.Marca.Id);
                datos.SetearParametro("@IdCategoria", Articulo.Categoria.Id);
                datos.SetearParametro("@Precio", Articulo.Precio);
                datos.EjecutarAccion();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally 
            { 
                datos.CerrarConexion();
            }
        }


    }
}
