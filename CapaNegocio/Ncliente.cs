using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class Ncliente
    {

        #region Insertar

        public static string Insertar(string nombre, string apellido, string sexo, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string direccion, string telefono, string email)
        {
            Dcliente Cliente = new Dcliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                Sexo = sexo,
                FechaNacimiento = fechaNacimiento,
                TipoDocumento = tipoDocumento,
                NumeroDocumento = numeroDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };


            return Cliente.Insertar(Cliente);
        }
        #endregion


        #region Editar

        public static string Editar(int idCliente, string nombre, string apellido, string sexo, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string direccion, string telefono, string email)
        {
            Dcliente Cliente = new Dcliente()
            {
                IdCliente = idCliente,
                Nombre = nombre,
                Apellido = apellido,
                Sexo = sexo,
                FechaNacimiento = fechaNacimiento,
                TipoDocumento = tipoDocumento,
                NumeroDocumento = numeroDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            return Cliente.Editar(Cliente);
        }
        #endregion


        #region Eliminar
        public static string Eliminar(int idCliente)
        {
            Dcliente Obj = new Dcliente();
            Obj.IdCliente = idCliente;
            return Obj.Eliminar(Obj);
        }
        #endregion


        #region Mostrar

        public static DataTable Mostrar()
        {
            return new Dcliente().Mostrar();
        }
        #endregion


        #region BuscarNombre

        public static DataTable BuscarNombre(string textoBuscar)
        {
            Dcliente Cliente = new Dcliente()
            {
                TextoBuscar = textoBuscar
            };

            return Cliente.BuscarNombre(Cliente);
        }
        #endregion


        #region BuscarNumDocumento

        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            Dcliente Cliente = new Dcliente()
            {
                TextoBuscar = textoBuscar
            };

            return Cliente.BuscarNumDocumento(Cliente);
        }
        #endregion


        #region BuscarApellido

        public static DataTable BuscarApellido(string textoBuscar)
        {
            Dcliente Cliente = new Dcliente()
            {
                TextoBuscar = textoBuscar
            };

            return Cliente.BuscarApellido(Cliente);
        }
        #endregion
    }
}
