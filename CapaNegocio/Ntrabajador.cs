using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class Ntrabajador
    {
        //Metodo Insertar que llama al mentodo insertar de la clase Dtrabajador de la CapaDatos
        #region Insertar
        public static string Insertar(string nombre, string apellido, string sexo, DateTime fechaNacimiento,
            string numeroDocumento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.NumeroDocumento = numeroDocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }
        #endregion

        //Metodo Editar que llama al mentodo Edita de la clase Dtrabajador de la CapaDatos
        #region Editar
        public static string Editar(int idTrabajador, string nombre, string apellido, string sexo, DateTime fechaNacimiento,
            string numeroDocumento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.IdTrabajador = idTrabajador;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.NumeroDocumento = numeroDocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }
        #endregion

        //Metodo Eliminar que llama al mentodo Eliminar de la clase Dtrabajador de la CapaDatos
        #region Eliminar
        public static string Eliminar(int idTrabajador)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.IdTrabajador = idTrabajador;
            return Obj.Eliminar(Obj);
        }
        #endregion

        //Metodo Mostrar que llama al mentodo Mostrar de la clase Dtrabajador de la CapaDatos
        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Dtrabajador().Mostrar();
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase Dtrabajador de la CapaDatos
        #region BuscarNombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BuscarNumDocumento de la clase Dtrabajador de la CapaDatos
        #region BuscarNumDocumento
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNumDocumento(Obj);
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BuscarApellido de la clase Dtrabajador de la CapaDatos
        #region BuscarApellido
        public static DataTable BuscarApellido(string textoBuscar)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellido(Obj);
        }
        #endregion

        //Metodo BucarNombre que llama al mentodo BuscarApellido de la clase Dtrabajador de la CapaDatos
        #region Login
        public static DataTable Login(string usuario, string password)
        {
            Dtrabajador Obj = new Dtrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
        #endregion
    }
}
