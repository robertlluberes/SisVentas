using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DdetalleIngreso
    {
        #region Constructores
        public DdetalleIngreso()
        {

        }

        public DdetalleIngreso(int idDetalleIngreso, int idIngreso, int idArticulo, decimal precioCompra,
            decimal precioVenta, int stockInicial, int stockActual, DateTime fechaProduccion, DateTime fechaVecimiento)
        {
            IdDetalleIngreso = idDetalleIngreso;
            IdIngreso = idIngreso;
            IdArticulo = idArticulo;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            StockInicial = stockInicial;
            StockActual = stockActual;
            FechaProduccion = fechaProduccion;
            FechaVencimiento = fechaVecimiento;
        }
        #endregion


        #region Propiedades
        public int IdDetalleIngreso { get; set; }
        public int IdIngreso { get; set; }
        public int IdArticulo { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockInicial { get; set; }
        public int StockActual { get; set; }
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaVencimiento { get; set; }


        #endregion


        #region MetodoInsertar
        //Metodo Insertar
        public string Insertar(DdetalleIngreso DetalleArticulo, ref SqlConnection SqlCon, ref SqlTransaction SqlTran)
        {

            string rpta = "";

            try
            {


                //Establecer el comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTran;
                SqlCmd.CommandText = "[spinsertar_detalle_ingreso]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros para el SqlCmd (StoreProcedure)
                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@iddetalle_ingreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = DetalleArticulo.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = DetalleArticulo.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precio_compra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleArticulo.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleArticulo.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@stock_inicial";
                ParStockInicial.SqlDbType = SqlDbType.Int;
                ParStockInicial.Value = DetalleArticulo.StockInicial;
                SqlCmd.Parameters.Add(ParStockInicial);

                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@stock_actual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = DetalleArticulo.StockActual;
                SqlCmd.Parameters.Add(ParStockActual);

                SqlParameter ParFechaProduccion = new SqlParameter();
                ParFechaProduccion.ParameterName = "@fecha_produccion";
                ParFechaProduccion.SqlDbType = SqlDbType.Date;
                ParFechaProduccion.Value = DetalleArticulo.FechaProduccion;
                SqlCmd.Parameters.Add(ParFechaProduccion);

                SqlParameter ParFechaVenta = new SqlParameter();
                ParFechaVenta.ParameterName = "@fecha_vencimiento";
                ParFechaVenta.SqlDbType = SqlDbType.Date;
                ParFechaVenta.Value = DetalleArticulo.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFechaVenta);

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