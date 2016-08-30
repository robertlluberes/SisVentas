using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Nproveedor
    {

        #region Insertar
        public static string Insertar(string razonsocial, string sectorcomercial, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string url)
        {
            Dproveedor Proveedor = new Dproveedor()
            {
                RazonSocial = razonsocial,
                SectorComercial = sectorcomercial,
                TipoDocumento = tipodocumento,
                NumDocumento = numdocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };

            return Proveedor.Insertar(Proveedor);
        }
        #endregion


        #region Editar

        public static string Editar(int idproveedor, string razonsocial, string sectorcomercial, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string url)
        {
            Dproveedor Proveedor = new Dproveedor()
            {
                IdProveedor = idproveedor,
                RazonSocial = razonsocial,
                SectorComercial = sectorcomercial,
                TipoDocumento = tipodocumento,
                NumDocumento = numdocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };

            return Proveedor.Editar(Proveedor);
        }
        #endregion


        #region Eliminar

        public static string Eliminar(int idproveedor)
        {
            Dproveedor Proveedor = new Dproveedor()
            {
                IdProveedor = idproveedor
            };

            return Proveedor.Eliminar(Proveedor);
        }
        #endregion


        #region Mostrar

        public static DataTable Mostrar()
        {
            return new Dproveedor().Mostrar();
        }
        #endregion


        #region BuscarRazonSocial

        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            Dproveedor Proveedor = new Dproveedor()
            {
                TextoBuscar = textobuscar
            };

            return Proveedor.BuscarRazonSocial(Proveedor);
        }
        #endregion


        #region BuscarProveedorDocumento

        public static DataTable BuscarProveedorDocumento(string textobuscar)
        {
            Dproveedor Proveedor = new Dproveedor()
            {
                TextoBuscar = textobuscar
            };

            return Proveedor.BuscarProveedorDocumento(Proveedor);
        }
        #endregion
    }
}
