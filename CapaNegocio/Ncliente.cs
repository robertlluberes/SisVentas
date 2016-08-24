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
            Dcliente Obj = new Dcliente();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.TipoDocumento = tipoDocumento;
            Obj.NumeroDocumento = numeroDocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }
        #endregion


        #region Editar
        public static string Editar(int idCliente, string nombre, string apellido, string sexo, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string direccion, string telefono, string email)
        {
            Dcliente Obj = new Dcliente();
            Obj.IdCliente = idCliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.TipoDocumento = tipoDocumento;
            Obj.NumeroDocumento = numeroDocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
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
            Dcliente Obj = new Dcliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
        #endregion


        #region BuscarNumDocumento
        public static DataTable BuscarNumDocumento(string textoBuscar)
        {
            Dcliente Obj = new Dcliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNumDocumento(Obj);
        }
        #endregion


        #region BuscarApellido
        public static DataTable BuscarApellido(string textoBuscar)
        {
            Dcliente Obj = new Dcliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellido(Obj);
        }
        #endregion
    }
}
