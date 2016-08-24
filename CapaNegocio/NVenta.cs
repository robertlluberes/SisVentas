using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class NVenta
    {

        public static string Insertar(int idCliente, int idTrabajador, DateTime fecha, string tipoComprobante,
            string serie, string correlativo, decimal itbis, DataTable dtDetalles)
        {
            Dventa Obj = new Dventa();
            Obj.IdCliente = idCliente;
            Obj.IdTrabajador = idTrabajador;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Itbis = itbis;

            var ListaDetalles = new List<DdetalleVenta>();

            foreach (DataRow filasDetalles in dtDetalles.Rows)
            {
                DdetalleVenta detalleIngreso = new DdetalleVenta();
                detalleIngreso.IdDetalleIngreso = Convert.ToInt32(filasDetalles["iddetalle_ingreso"].ToString());
                detalleIngreso.Cantidad = Convert.ToInt32(filasDetalles["cantidad"].ToString());
                detalleIngreso.PrecioVenta = Convert.ToDecimal(filasDetalles["precio_venta"].ToString());
                detalleIngreso.Descuento = Convert.ToDecimal(filasDetalles["descuento"].ToString());

                ListaDetalles.Add(detalleIngreso);
            }
            return Obj.Insertar(Obj, ListaDetalles);
        }


        public static string Eliminar(int idIngreso)
        {
            Dventa Obj = new Dventa();
            Obj.IdVenta = idIngreso;
            return Obj.Eliminar(Obj);
        }


        public static DataTable Mostrar()
        {
            return new Dventa().Mostrar();
        }


        public static DataTable BuscarFechas(string fechaInicio, string fechaFin)
        {
            Dventa Obj = new Dventa();
            return Obj.BuscarFechas(fechaInicio, fechaFin);
        }


        public static DataTable MostrarDetalles(string textoBuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.MostrarDetalles(textoBuscar);
        }


        public static DataTable BuscarArticuloVentaNombre(string textoBuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.BuscarAritculoVentaNombre(textoBuscar);
        }


        public static DataTable BuscarAritculoVentaCodigo(string textoBuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.BuscarAritculoVentaCodigo(textoBuscar);
        }
    }
}
