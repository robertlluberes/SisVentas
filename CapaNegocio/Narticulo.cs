using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Narticulo
    {

        #region Insertar
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idCategoria, int idPresentacion)
        {
            Darticulo articulo = new Darticulo()
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                Imagen = imagen,
                IdCategoria = idCategoria,
                IdPresentacion = idPresentacion
            };

            return articulo.Insertar(articulo);
        }
        #endregion


        #region Editar
        public static string Editar(int idArticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idCategoria, int idPresentacion)
        {
            Darticulo Articulo = new Darticulo()
            {
                IdArticulo = idArticulo,
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                Imagen = imagen,
                IdCategoria = idCategoria,
                IdPresentacion = idPresentacion
            };

            return Articulo.Editar(Articulo);
        }
        #endregion


        #region Eliminar
        public static string Eliminar(int idArticulo)
        {
            Darticulo Articulo = new Darticulo()
            {
                IdArticulo = idArticulo
            };

            return Articulo.Eliminar(Articulo);
        }
        #endregion


        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Darticulo().Mostrar();
        }
        #endregion


        #region BuscarNombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            Darticulo Articulo = new Darticulo()
            {
                TextoBuscar = textoBuscar
            };

            return Articulo.BuscarNombre(Articulo);
        }
        #endregion


        #region StockArticulos
        public static DataTable StockArticulos()
        {
            return new Darticulo().StockArticulos();
        }
        #endregion


    }
}
