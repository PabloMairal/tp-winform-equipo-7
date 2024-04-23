using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM [dbo].[MARCAS]");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["Id"];
                    marca.Nombre = (string)datos.Lector["Descripcion"];

                    marcas.Add(marca);
                }

                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(Marca marca)
        {
            // Agregar marca en BDD
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into MARCAS (Descripcion) values (@Descripcion);");
                datos.SetearParametro("@Descripcion", marca.Nombre);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Marca marca)
        {
            // Modificar marca en BDD
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update MARCAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetearParametro("@Descripcion", marca.Nombre);
                datos.SetearParametro("@Id", marca.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void Eliminar(int id)
        {
            // Eliminar marca de BDD
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from MARCAS where Id = @Id");
                datos.SetearParametro("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}

