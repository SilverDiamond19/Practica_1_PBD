using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Clientes
    {
        public static DataTable Mostrar ()
        {
            return new CD_Clientes ().MostrarClientes ();
        }

        public static string Insertar (string nombre, string apellido, string email)
        {
            CD_Clientes obj = new CD_Clientes ();
            obj.Nombre = nombre;
            obj.Apellido = apellido;    
            obj.Email = email;

            return obj.InsertarCliente(obj);
        }

        public static string Editar(int id, string nombre, string apellido, string email)
        {
            CD_Clientes obj = new CD_Clientes();
            obj.ID_Cliente = id;
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Email = email;

            return obj.EditarCliente(obj);
        }

        public static string Eliminar(int id)
        {
            CD_CATEGORIA obj = new CD_CATEGORIA();
            obj.ID = id;
            return new CD_CATEGORIA().Eliminar(obj);
        }

        
    }
}
