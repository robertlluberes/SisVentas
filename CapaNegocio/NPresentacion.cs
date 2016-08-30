using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Npresentacion
    {

        #region Insertar

        public static string Insertar(string nombre, string descripcion)
        {
            Dpresentacion Presentacion = new Dpresentacion()
            {
                Nombre = nombre,
                Descripcion = descripcion
            };

            return Presentacion.Insertar(Presentacion);
        }
        #endregion


        #region Editar

        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            Dpresentacion Presentacion = new Dpresentacion()
            {
                IdPresentacion = idpresentacion,
                Nombre = nombre,
                Descripcion = descripcion
            };

            return Presentacion.Editar(Presentacion);
        }
        #endregion


        #region Eliminar
        public static string Eliminar(int idpresentacion)
        {
            Dpresentacion Presentacion = new Dpresentacion()
            {
                IdPresentacion = idpresentacion
            };

            return Presentacion.Eliminar(Presentacion);
        }
        #endregion


        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Dpresentacion().Mostrar();
        }
        #endregion


        #region BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            Dpresentacion Presentacion = new Dpresentacion()
            {
                TextoBuscar = textobuscar
            };

            return Presentacion.BuscarNombre(Presentacion);
        }
        #endregion
    }
}
