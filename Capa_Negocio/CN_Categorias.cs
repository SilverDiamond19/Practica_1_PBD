using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Categorias
    {
        public static DataTable Mostrar()
        {
            return new CD_Categorias ().MostrarCategorias ();
        }

        public static string Insertar (string nombre)
        {
            CD_Categorias obj = new CD_Categorias ();
            obj.NombreCategoria = nombre;

            return new CD_Categorias().InsertarCategoria(obj);
        }
    }
}
