using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class Ntrabajador
    {

        #region Insertar

        public static string Insertar(string nombre, string apellido, string sexo, DateTime fechaNacimiento,
            string numeroDocumento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                Nombre = nombre,
                Apellido = apellido,
                Sexo = sexo,
                FechaNacimiento = fechaNacimiento,
                NumeroDocumento = numeroDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Acceso = acceso,
                Usuario = usuario,
                Password = password
            };

            return Trabajador.Insertar(Trabajador);
        }
        #endregion


        #region Editar
        public static string Editar(int idTrabajador, string nombre, string apellido, string sexo, DateTime fechaNacimiento,
            string numeroDocumento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                IdTrabajador = idTrabajador,
                Nombre = nombre,
                Apellido = apellido,
                Sexo = sexo,
                FechaNacimiento = fechaNacimiento,
                NumeroDocumento = numeroDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Acceso = acceso,
                Usuario = usuario,
                Password = password
            };

            return Trabajador.Editar(Trabajador);
        }
        #endregion


        #region Eliminar
        public static string Eliminar(int idTrabajador)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                IdTrabajador = idTrabajador
            };

            return Trabajador.Eliminar(Trabajador);
        }
        #endregion


        #region Mostrar
        public static DataTable Mostrar()
        {
            return new Dtrabajador().Mostrar();
        }
        #endregion


        #region BuscarNombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                TextoBuscar = textoBuscar
            };

            return Trabajador.BuscarNombre(Trabajador);
        }
        #endregion


        #region BuscarNumDocumento
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                TextoBuscar = textoBuscar
            };
            return Trabajador.BuscarNumDocumento(Trabajador);
        }
        #endregion


        #region BuscarApellido
        public static DataTable BuscarApellido(string textoBuscar)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                TextoBuscar = textoBuscar
            };

            return Trabajador.BuscarApellido(Trabajador);
        }
        #endregion


        #region Login
        public static DataTable Login(string usuario, string password)
        {
            Dtrabajador Trabajador = new Dtrabajador()
            {
                Usuario = usuario,
                Password = password

            };

            return Trabajador.Login(Trabajador);
        }
        #endregion
    }
}
