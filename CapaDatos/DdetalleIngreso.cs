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
        public string Insertar(DdetalleIngreso DetalleArticulo, ref SqlConnection conexionSql, ref SqlTransaction transaccionSql)
        {

            string respuesta = "";

            try
            {


                //Establecer el comando SQL
                var comandoSql = new SqlCommand("[spinsertar_detalle_ingreso]", conexionSql, transaccionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //Parametros para el comandoSql (StoreProcedure)
                var parIdDetalleIngreso = new SqlParameter("@iddetalle_ingreso", SqlDbType.Int);
                parIdDetalleIngreso.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parIdDetalleIngreso);

                var parIdIngreso = new SqlParameter("@idingreso", SqlDbType.Int);
                parIdIngreso.Value = DetalleArticulo.IdIngreso;
                comandoSql.Parameters.Add(parIdIngreso);

                var parIdArticulo = new SqlParameter("@idarticulo", SqlDbType.Int);
                parIdArticulo.Value = DetalleArticulo.IdArticulo;
                comandoSql.Parameters.Add(parIdArticulo);

                var parPrecioCompra = new SqlParameter("@precio_compra", SqlDbType.Money);
                parPrecioCompra.Value = DetalleArticulo.PrecioCompra;
                comandoSql.Parameters.Add(parPrecioCompra);

                var parPrecioVenta = new SqlParameter("@precio_venta", SqlDbType.Money);
                parPrecioVenta.Value = DetalleArticulo.PrecioVenta;
                comandoSql.Parameters.Add(parPrecioVenta);

                var parStockInicial = new SqlParameter("@stock_inicial", SqlDbType.Int);
                parStockInicial.Value = DetalleArticulo.StockInicial;
                comandoSql.Parameters.Add(parStockInicial);

                var parStockActual = new SqlParameter("@stock_actual", SqlDbType.Int);
                parStockActual.Value = DetalleArticulo.StockActual;
                comandoSql.Parameters.Add(parStockActual);

                var parFechaProduccion = new SqlParameter("@fecha_produccion", SqlDbType.Date);
                parFechaProduccion.Value = DetalleArticulo.FechaProduccion;
                comandoSql.Parameters.Add(parFechaProduccion);

                var parFechaVenta = new SqlParameter("@fecha_vencimiento", SqlDbType.Date);
                parFechaVenta.Value = DetalleArticulo.FechaVencimiento;
                comandoSql.Parameters.Add(parFechaVenta);

                //Ejecucion del comando
                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }
        #endregion
    }
}