using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Ncategoria
    {

        #region Insertar
        public static string Insertar(string nombre, string descripcion)
        {
            Dcategoria Categoria = new Dcategoria()
            {
                Nombre = nombre,
                Descripcion = descripcion
            };

            return Categoria.Insertar(Categoria);
        }
        #endregion


        #region Editar
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            Dcategoria Categoria = new Dcategoria()
            {
                IdCategoria = idcategoria,
                Nombre = nombre,
                Descripcion = descripcion
            };


            return Categoria.Editar(Categoria);
        }
        #endregion


        #region Eliminar
        public static string Eliminar(int idcategoria)
        {
            Dcategoria Categoria = new Dcategoria()
            {
                IdCategoria = idcategoria
            };


            return Categoria.Eliminar(Categoria);
        }
        #endregion


        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }
        #endregion


        #region BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            Dcategoria Categoria = new Dcategoria()
            {
                TextoBuscar = textobuscar
            };

            return Categoria.BuscarNombre(Categoria);
        }
        #endregion

    }
}
