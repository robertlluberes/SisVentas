using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class Nproveedor
    {
        //Metodo Insertar que llama al mentodo insertar de la clase Dproveedor de la CapaDatos
        public static string Insertar(string razonsocial, string sectorcomercial, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string url)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.RazonSocial = razonsocial;
            Obj.SectorComercial = sectorcomercial;
            Obj.TipoDocumento = tipodocumento;
            Obj.NumDocumento = numdocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llama al mentodo Edita de la clase Dproveedor de la CapaDatos
        public static string Editar(int idproveedor, string razonsocial, string sectorcomercial, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string url)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.IdProveedor = idproveedor;
            Obj.RazonSocial = razonsocial;
            Obj.SectorComercial = sectorcomercial;
            Obj.TipoDocumento = tipodocumento;
            Obj.NumDocumento = numdocumento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al mentodo Eliminar de la clase Dproveedor de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.IdProveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al mentodo Mostrar de la clase Dproveedor de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dproveedor().Mostrar();
        }

        //Metodo BuscarRazonSocial que llama al mentodo BuscarRazonSocial de la clase Dproveedor de la CapaDatos
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazonSocial(Obj);
        }

        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase Dproveedor de la CapaDatos
        public static DataTable BuscarProveedorDocumento(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProveedorDocumento(Obj);
        }
    }
}
