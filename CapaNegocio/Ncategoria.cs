using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Ncategoria
    {
        //Metodo Insertar que llama al mentodo insertar de la clase DCategoria de la CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llama al mentodo Edita de la clase DCategoria de la CapaDatos
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.IdCategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al mentodo Eliminar de la clase DCategoria de la CapaDatos
        public static string Eliminar(int idcategoria)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.IdCategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al mentodo Mostrar de la clase DCategoria de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }

        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase DCategoria de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
