using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class Ningreso
    {

        #region Insertar

        public static string Insertar(int idTrabajador, int idProveedor, DateTime fecha, string tipoComprobante,
    string serie, string correlativo, decimal itbis, string estado, DataTable dtDetalles)
        {
            Dingreso Ingreso = new Dingreso()
            {
                IdTrabajador = idTrabajador,
                IdProveedor = idProveedor,
                Fecha = fecha,
                TipoComprobante = tipoComprobante,
                Serie = serie,
                Correlativo = correlativo,
                Itbis = itbis,
                Estado = estado
            };

            var ListaDetalles = new List<DdetalleIngreso>();

            foreach (DataRow filasDetalles in dtDetalles.Rows)
            {
                DdetalleIngreso detalleIngreso = new DdetalleIngreso();
                detalleIngreso.IdArticulo = Convert.ToInt32(filasDetalles["idarticulo"].ToString());
                detalleIngreso.PrecioCompra = Convert.ToDecimal(filasDetalles["precio_compra"].ToString());
                detalleIngreso.PrecioVenta = Convert.ToDecimal(filasDetalles["precio_venta"].ToString());
                detalleIngreso.StockInicial = Convert.ToInt32(filasDetalles["stock_inicial"].ToString());
                detalleIngreso.StockActual = Convert.ToInt32(filasDetalles["stock_inicial"].ToString());
                detalleIngreso.FechaProduccion = Convert.ToDateTime(filasDetalles["fecha_produccion"].ToString());
                detalleIngreso.FechaVencimiento = Convert.ToDateTime(filasDetalles["fecha_vencimiento"].ToString());

                ListaDetalles.Add(detalleIngreso);
            }
            return Ingreso.Insertar(Ingreso, ListaDetalles);
        }
        #endregion


        #region Anular

        public static string Anular(int idIngreso)
        {
            Dingreso Ingreso = new Dingreso()
            {
                IdIngreso = idIngreso
            };

            return Ingreso.Anular(Ingreso);
        }
        #endregion


        #region Mostrar

        public static DataTable Mostrar()
        {
            return new Dingreso().Mostrar();
        }

        #endregion


        #region BuscarFecha

        public static DataTable BuscarFechas(string fechaInicio, string fechaFin)
        {
            Dingreso Ingreso = new Dingreso();

            return Ingreso.BuscarFechas(fechaInicio, fechaFin);
        }
        #endregion


        #region MostrarDetalles

        public static DataTable MostrarDetalles(string textoBuscar)
        {
            Dingreso Ingreso = new Dingreso();

            return Ingreso.MostrarDetalles(textoBuscar);
        }
        #endregion

    }
}
