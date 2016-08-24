using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DdetalleVenta
    {
        #region Contructores
        public DdetalleVenta()
        {

        }

        public DdetalleVenta(int idDetalleVenta, int idVenta, int idDetalleIngreso, int cantidad,
            decimal precioVenta, decimal descuento)
        {
            IdDetalleVenta = idDetalleVenta;
            IdVenta = idVenta;
            IdDetalleIngreso = idDetalleIngreso;
            Cantidad = cantidad;
            Descuento = descuento;

        }
        #endregion


        #region Propiedades
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdDetalleIngreso { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }

        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(DdetalleVenta DetalleVenta, ref SqlConnection SqlCon, ref SqlTransaction SqlTran)
        {

            string rpta = "";

            try
            {


                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "[spinsertar_detalle_venta]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@iddetalle_venta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalleVenta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@iddetalle_ingreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Value = DetalleVenta.IdDetalleIngreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = DetalleVenta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);



                //Ejecion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
        #endregion


    }
}
