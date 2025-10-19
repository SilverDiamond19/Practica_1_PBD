using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace Capa_Datos
{
    public class CD_Clientes
    {
        private int id_cliente;
        private string nombre;
        private string apellido;
        private string email;
        private string buscar;

        public int ID_Cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; } 
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }   
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Buscar
        {
            get { return buscar; }
            set { buscar = value; }
        }

        public CD_Clientes ()
        {

        }

        public CD_Clientes (int _id_cliente, string _nombre, string _apellido, string _email, string _buscar)
        {
            this.ID_Cliente = _id_cliente;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.email = _email;
            this.buscar = _buscar;
        }

        public DataTable MostrarClientes ()
        {
            DataTable tabla = new DataTable ("Clientes");
            SqlConnection sqlcon = new SqlConnection();

           try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                SqlCommand comando = new SqlCommand();
                comando.Connection = sqlcon;
                comando.CommandText = "MostrarClientes";
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);  
                adaptador.Fill (tabla);
            }
            catch (Exception ex)
            {
                tabla = null;
            }
            return tabla;   
        }

        public string InsertarCliente (CD_Clientes cliente)
        {
            string query = "";
            SqlConnection sqlcon = new SqlConnection ();
            try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand ();
                cmd.Connection = sqlcon;

                cmd.CommandText = "InsertarCliente1";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_Cliente = new SqlParameter ();
                parId_Cliente.ParameterName = "@ID_Cliente";
                parId_Cliente.SqlDbType = SqlDbType.Int;
                parId_Cliente.Direction = ParameterDirection.Output;
                cmd.Parameters.Add (parId_Cliente); 

                SqlParameter parnombrE = new SqlParameter ();
                parnombrE.ParameterName = "@Nombre";
                parnombrE.SqlDbType = SqlDbType.NVarChar;
                parnombrE.Size = 50;
                parnombrE.Value = cliente.Nombre;
                cmd.Parameters.Add(parnombrE);

                SqlParameter parapellidO = new SqlParameter();
                parapellidO.ParameterName = "@Apellido";
                parapellidO.SqlDbType = SqlDbType.NVarChar;
                parapellidO.Size = 50;
                parapellidO.Value = cliente.Apellido;
                cmd.Parameters.Add(parapellidO);

                SqlParameter paremaiL = new SqlParameter();
                paremaiL.ParameterName = "@Email";
                paremaiL.SqlDbType = SqlDbType.NVarChar;
                paremaiL.Size = 100;
                paremaiL.Value = cliente.Email;
                cmd.Parameters.Add(paremaiL);

                query = cmd.ExecuteNonQuery () == 1 ? "Okay." : "No se ingreso el registro.";
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return query;
        }

        public string EditarCliente(CD_Clientes cliente)
        {
            string query = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;

                cmd.CommandText = "EditarCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_Cliente = new SqlParameter();
                parId_Cliente.ParameterName = "@ID_Cliente";
                parId_Cliente.SqlDbType = SqlDbType.Int;
                parId_Cliente.Value = cliente.ID_Cliente;
                cmd.Parameters.Add(parId_Cliente);

                SqlParameter parnombrE = new SqlParameter();
                parnombrE.ParameterName = "@Nombre";
                parnombrE.SqlDbType = SqlDbType.NVarChar;
                parnombrE.Size = 50;
                parnombrE.Value = cliente.Nombre;
                cmd.Parameters.Add(parnombrE);

                SqlParameter parapellidO = new SqlParameter();
                parapellidO.ParameterName = "@Apellido";
                parapellidO.SqlDbType = SqlDbType.NVarChar;
                parapellidO.Size = 50;
                parapellidO.Value = cliente.Apellido;
                cmd.Parameters.Add(parapellidO);

                SqlParameter paremaiL = new SqlParameter();
                paremaiL.ParameterName = "@Email";
                paremaiL.SqlDbType = SqlDbType.NVarChar;
                paremaiL.Size = 100;
                paremaiL.Value = cliente.Email;
                cmd.Parameters.Add(paremaiL);

                query = cmd.ExecuteNonQuery() == 1 ? "Ok." : "No se actualizo el registro.";
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return query;
        }

        public string Eliminar(CD_Clientes clientes)
        {
            string query = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;

                cmd.CommandText = "sp_eliminarCategoria";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@ID";
                parId.SqlDbType = SqlDbType.Int;
                //parId.Direction = ParameterDirection.Output;
                parId.Value = clientes.id_cliente;
                cmd.Parameters.Add(parId);


                query = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Elimino el Registro";
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return query;
        }

    }
}
