using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Categorias
    {
        private int idCategoria;
        private string nombreCategoria;
        private string buscar;

        public int ID_Categoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }    
        }

        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; }
        }

        public string Buscar
        {
            get { return buscar; }  
            set { buscar = value; } 
        }

        public CD_Categorias ()
        {

        }

        public CD_Categorias (int _idCategoria, string _nombreCategoria, string _buscar)
        {
            this.ID_Categoria = _idCategoria;   
            this.NombreCategoria = _nombreCategoria; 
            this.Buscar = _buscar;  
        }

        public DataTable MostrarCategorias ()
        {
            DataTable tabla = new DataTable("Categorias");
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                SqlCommand comando = new SqlCommand();
                comando.Connection = sqlcon;
                comando.CommandText = "MostrarCategorias";
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                tabla = null;
            }
            return tabla;
        }

        public string InsertarCategoria (CD_Categorias categoria)
        {
            string query = "";

            SqlConnection sqlcon = new SqlConnection ();

            try
            {
                sqlcon.ConnectionString = CD_Conexion.Connection;
                sqlcon.Open ();

                SqlCommand comando = new SqlCommand ();
                comando.Connection = sqlcon;

                comando.CommandText = "InsertarCategoria";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parId_Categoria = new SqlParameter ();
                parId_Categoria.ParameterName = "@ID_Categoria";
                parId_Categoria.SqlDbType = SqlDbType.Int;
                parId_Categoria.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parId_Categoria);

                SqlParameter parNomnbreCategoria = new SqlParameter ();
                parNomnbreCategoria.ParameterName = "@NombreCategoria";
                parNomnbreCategoria.SqlDbType = SqlDbType.NVarChar;
                parNomnbreCategoria.Size = 50;
                parNomnbreCategoria.Value = categoria.NombreCategoria;
                comando.Parameters.Add (parNomnbreCategoria);

                query = comando.ExecuteNonQuery() == 1 ? "Okay" : "No se ingreso el registro";
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close ();
                }
            }
            return query;
        }





    }
}
