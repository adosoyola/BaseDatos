using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration; //cadena de conexion
using System.Configuration.Internal;

namespace CapaNegocio
{
    public class Carrera
    {
        //cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        //Mapear las columnas de la tabla en propiedades de la clase
        public string CodCarrera { get; set; }
        public string  NombreCarrera { get; set; }

        //Implementar los metodos de la clase
        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCarrera";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool Agregar()
        {
            using(SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "insert into TCarrera values(CodCarrera=@CodCarrera, Carrera=@NombreCarrera)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                comando.Parameters.AddWithValue("@NombreCarrera", NombreCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if(i == 1) return true;
                else return false;
            }
        }

        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "delete from TCarrera where CodCarrera = @CodCarrera";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }
        public bool Actualizar() 
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "update TCarrera set Carrera = @NombreCarrera where CodCarrera=@CodCarrera";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                comando.Parameters.AddWithValue("@NombreCarrera", NombreCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCarrera where CodCarrera= @CodCarrera";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
    }
}
