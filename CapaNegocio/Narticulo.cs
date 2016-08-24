using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Narticulo
    {
        //Metodo Insertar que llama al mentodo insertar de la clase Darticulo de la CapaDatos
        #region Insertar
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idCategoria, int idPresentacion)
        {
            Darticulo Obj = new Darticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idCategoria;
            Obj.IdPresentacion = idPresentacion;

            return Obj.Insertar(Obj);
        }
        #endregion

        //Metodo Editar que llama al mentodo Edita de la clase Darticulo de la CapaDatos
        #region Editar
        public static string Editar(int idArticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idCategoria, int idPresentacion)
        {
            Darticulo Obj = new Darticulo();
            Obj.IdArticulo = idArticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.IdCategoria = idCategoria;
            Obj.IdPresentacion = idPresentacion;
            return Obj.Editar(Obj);
        }
        #endregion

        //Metodo Eliminar que llama al mentodo Eliminar de la clase Darticulo de la CapaDatos
        #region Eliminar
        public static string Eliminar(int idArticulo)
        {
            Darticulo Obj = new Darticulo();
            Obj.IdArticulo = idArticulo;
            return Obj.Eliminar(Obj);
        }
        #endregion

        //Metodo Mostrar que llama al mentodo Mostrar de la clase Darticulo de la CapaDatos
        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Darticulo().Mostrar();
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase Darticulo de la CapaDatos
        #region BuscarNombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            Darticulo Obj = new Darticulo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
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
