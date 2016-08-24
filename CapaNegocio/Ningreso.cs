using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class Ningreso
    {
        //Metodo Insertar que llama al mentodo insertar de la clase Dingreso de la CapaDatos
        public static string Insertar(int idTrabajador, int idProveedor, DateTime fecha, string tipoComprobante,
            string serie, string correlativo, decimal itbis, string estado, DataTable dtDetalles)
        {
            Dingreso Obj = new Dingreso();
            Obj.IdTrabajador = idTrabajador;
            Obj.IdProveedor = idProveedor;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipoComprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Itbis = itbis;
            Obj.Estado = estado;

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
            return Obj.Insertar(Obj, ListaDetalles);
        }

        //Metodo Anular que llama al mentodo Anular de la clase Dingreso de la CapaDatos
        public static string Anular(int idIngreso)
        {
            Dingreso Obj = new Dingreso();
            Obj.IdIngreso = idIngreso;
            return Obj.Anular(Obj);
        }

        //Metodo Mostrar que llama al mentodo Mostrar de la clase Dingreso de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dingreso().Mostrar();
        }


        //Metodo BuscarFechas que llama al mentodo BuscarFechas de la clase Dingreso de la CapaDatos
        public static DataTable BuscarFechas(string fechaInicio, string fechaFin)
        {
            Dingreso Obj = new Dingreso();
            return Obj.BuscarFechas(fechaInicio, fechaFin);
        }


        //Metodo BucarNombre que llama al mentodo BucarNombre de la clase Dingreso de la CapaDatos
        public static DataTable MostrarDetalles(string textoBuscar)
        {
            Dingreso Obj = new Dingreso();
            return Obj.MostrarDetalles(textoBuscar);
        }

    }
}
