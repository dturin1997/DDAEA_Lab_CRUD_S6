using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class DProducto
    {
        private string connectionString= "Data Source=LAB707-03\\SQLEXPRESS01;Initial Catalog=db_lab_s5;Integrated Security=True;";

       
        public   List<Producto> Listar()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Producto> productos = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_GetProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Nombre";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = "";

                command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                productos = new List<Producto>();


                while (reader.Read())
                {

                    Producto producto = new Producto();
                    producto.Id = (int)reader["Id"];
                    producto.Nombre = reader["Nombre"].ToString();
                    producto.Precio = (int)reader["Precio"];
                    producto.FechaCreacion = (DateTime)reader["FechaCreacion"];

                    productos.Add(producto);

                }

                connection.Close();

                //Muestro la información
                return productos;


            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            finally
            {
                connection = null;
                command = null;
                param = null;
                productos = null;

            }


        }

        public void Insertar(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_InsertProducto", connection); // Nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@FechaCreacion", producto.FechaCreacion);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
