using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Npresentacion
    {
        //Metodo Insertar que llama al mentodo insertar de la clase DCategoria de la CapaDatos
        #region Insertar
        public static string Insertar(string nombre, string descripcion)
        {
            Dpresentacion Obj = new Dpresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }
        #endregion

        //Metodo Editar que llama al mentodo Edita de la clase DCategoria de la CapaDatos
        #region Editar
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            Dpresentacion Obj = new Dpresentacion();
            Obj.IdPresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }
        #endregion

        //Metodo Eliminar que llama al mentodo Eliminar de la clase DCategoria de la CapaDatos
        #region Eliminar
        public static string Eliminar(int idpresentacion)
        {
            Dpresentacion Obj = new Dpresentacion();
            Obj.IdPresentacion = idpresentacion;
            return Obj.Eliminar(Obj);
        }
        #endregion

        //Metodo Mostrar que llama al mentodo Mostrar de la clase DCategoria de la CapaDatos
        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Dpresentacion().Mostrar();
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase DCategoria de la CapaDatos
        #region BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            Dpresentacion Obj = new Dpresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        #endregion
    }
}
