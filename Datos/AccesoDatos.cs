using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public SqlCommand Comando
        {
            get { return comando;}
        }

        public AccesoDatos()
        {
            // CONN PABLO M
            //conexion = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_P3_DB; integrated security = true");
            // CONN PABLO P
            conexion = new SqlConnection("Data Source=localhost,15000;Initial Catalog=CATALOGO_P3_DB;User Id=sa;Password=Pablo2846!;TrustServerCertificate=True");
            comando = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void SetearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception)
            {
                CerrarConexion();
                throw;
            }
        }

        public void EjecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                CerrarConexion();
                throw;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }


    }
}
