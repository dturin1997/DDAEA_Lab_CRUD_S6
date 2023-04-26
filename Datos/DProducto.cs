using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Security.Cryptography;

namespace Datos
{
    public class DProducto
    {
        private string connectionString= "Data Source=DESKTOP-TURIN\\SQLEXPRESS;Initial Catalog=db_lab_s6;Integrated Security=True;";

       
        public   List<Producto> Listar()
        {
            List<Producto> productos;

            try 
            {
                List<SqlParameter> parameters=new List<SqlParameter>();
                SqlParameter param1;
                SqlParameter param2;

                param1 = new SqlParameter();
                param1.ParameterName = "@Nombre";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = "";

                param2 = new SqlParameter();
                param2.ParameterName = "@Activo";
                param2.SqlDbType = SqlDbType.Bit;
                param2.Value = true;

                parameters.Add(param1);
                parameters.Add(param2);

                
                SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, "USP_GetProducto", CommandType.StoredProcedure, parameters.ToArray());
                productos = new List<Producto>();


                while (reader.Read())
                {

                    Producto producto = new Producto();
                    producto.Id = (int)reader["Id"];
                    producto.Nombre = reader["Nombre"].ToString();
                    producto.Precio = (int)reader["Precio"];
                    producto.FechaCreacion = (DateTime)reader["FechaCreacion"];
                    producto.Activo = (bool)reader["Activo"];

                    productos.Add(producto);

                }

                //Muestro la información
                return productos;


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            


        }

        public void Insertar(Producto producto)
        {
            try
            {                
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter param1;
                SqlParameter param2;
                SqlParameter param3;
                SqlParameter param4;
                SqlParameter param5;

                param1 = new SqlParameter();
                param1.ParameterName = "@Id";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.Id;

                param2 = new SqlParameter();
                param2.ParameterName = "@Nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = producto.Nombre;

                param3 = new SqlParameter();
                param3.ParameterName = "@Precio";
                param3.SqlDbType = SqlDbType.Int;
                param3.Value = producto.Precio;

                param4 = new SqlParameter();
                param4.ParameterName = "@FechaCreacion";
                param4.SqlDbType = SqlDbType.DateTime;
                param4.Value = producto.FechaCreacion;

                param5 = new SqlParameter();
                param5.ParameterName = "@Activo";
                param5.SqlDbType = SqlDbType.Bit;
                param5.Value = producto.Activo;

                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);
                parameters.Add(param5);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_InsertProducto", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Actualizar(Producto producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter param1;
                SqlParameter param2;
                SqlParameter param3;
                SqlParameter param4;
                SqlParameter param5;

                param1 = new SqlParameter();
                param1.ParameterName = "@Id";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.Id;

                param2 = new SqlParameter();
                param2.ParameterName = "@Nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = producto.Nombre;

                param3 = new SqlParameter();
                param3.ParameterName = "@Precio";
                param3.SqlDbType = SqlDbType.Int;
                param3.Value = producto.Precio;

                param4 = new SqlParameter();
                param4.ParameterName = "@FechaCreacion";
                param4.SqlDbType = SqlDbType.DateTime;
                param4.Value = producto.FechaCreacion;

                param5 = new SqlParameter();
                param5.ParameterName = "@Activo";
                param5.SqlDbType = SqlDbType.Bit;
                param5.Value = producto.Activo;

                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);
                parameters.Add(param5);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_UpdateProducto", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Eliminar(Producto producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter param1;
                SqlParameter param2;

                param1 = new SqlParameter();
                param1.ParameterName = "@Id";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.Id;

                param2 = new SqlParameter();
                param2.ParameterName = "@Activo";
                param2.SqlDbType = SqlDbType.Bit;
                param2.Value = producto.Activo;

                parameters.Add(param1);
                parameters.Add(param2);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_DeleteProducto", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Producto> ListarSinSQLHelper()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param1 = null;
            SqlParameter param2 = null;
            SqlCommand command = null;
            List<Producto> productos = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_GetProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                param1 = new SqlParameter();
                param1.ParameterName = "@Nombre";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Value = "";

                param2 = new SqlParameter();
                param2.ParameterName = "@Activo";
                param2.SqlDbType = SqlDbType.Bit;
                param2.Value = null;

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                SqlDataReader reader = command.ExecuteReader();
                productos = new List<Producto>();


                while (reader.Read())
                {

                    Producto producto = new Producto();
                    producto.Id = (int)reader["Id"];
                    producto.Nombre = reader["Nombre"].ToString();
                    producto.Precio = (int)reader["Precio"];
                    producto.FechaCreacion = (DateTime)reader["FechaCreacion"];
                    producto.Activo = (bool)reader["Activo"];

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
                param1 = null;
                param2 = null;
                productos = null;

            }


        }

        public void InsertarSinSQLHelper(Producto producto)
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
