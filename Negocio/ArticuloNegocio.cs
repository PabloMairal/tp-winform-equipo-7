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
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> Articulos = new List<Articulo>();
            try
            {
                datos.SetearConsulta("select a.Id, Codigo, Nombre, a.Descripcion as Descripcion,m.Id as IdMarca, m.Descripcion as Marca, c.Id as IdCategoria , c.Descripcion as Categoria, Precio from ARTICULOS a left join MARCAS m on a.IdMarca = m.Id left join CATEGORIAS c on a.IdCategoria = c.Id");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo Articulo = new Articulo();
                    Marca Marca = new Marca();
                    Categoria Categoria = new Categoria();

                    Articulo.Id = (int)datos.Lector["Id"];
                    Articulo.Codigo = (string)datos.Lector["Codigo"];
                    Articulo.Nombre = (string)datos.Lector["Nombre"];
                    Articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    Marca.Id = (int)(datos.Lector["IdMarca"]);
                    Marca.Nombre = (string)datos.Lector["Marca"];
                    Articulo.Marca = Marca;
                    Categoria.Id = (int)(datos.Lector["IdCategoria"]);
                    Categoria.Nombre = (string)datos.Lector["Categoria"];
                    Articulo.Categoria = Categoria;
                    BuscarImagenes(Articulo);
                    Articulo.Precio = (decimal)datos.Lector["Precio"];
                    Articulos.Add(Articulo);

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
            return Articulos;
        }

        public void BuscarImagenes(Articulo Articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select I.ImagenUrl From IMAGENES I Inner Join ARTICULOS A ON IdArticulo = A.Id WHERE I.IdArticulo = " +  Articulo.Id);
                datos.EjecutarLectura();
                while(datos.Lector.Read())
                {
                    Articulo.Imagenes.Add((string)datos.Lector["ImagenUrl"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GuardarImagenes(Articulo Articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var Imagen in Articulo.Imagenes)
                {
                    datos.SetearConsulta("Insert into IMAGENES (IdArticulo, ImagenUrl) values (@IdArticulo, @ImagenUrl)");
                    datos.SetearParametro("@IdArticulo", Articulo.Id);
                    datos.SetearParametro("@ImagenUrl", Imagen);
                    datos.EjecutarAccion();
                }
            }
            catch (Exception)
            {

                throw;
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
                //Busca el Id del articulo creado para asignarlo a la imagen
                Articulo.Id = datos.EjecutarScalar();
                GuardarImagenes(Articulo);

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

        public bool ValidarArticulosPorMrcCtg(int id, string columna)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select Id from ARTICULOS where " + columna + "=@id");
                datos.SetearParametro("@id", id);
                datos.EjecutarLectura();
                return !datos.Lector.Read();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
