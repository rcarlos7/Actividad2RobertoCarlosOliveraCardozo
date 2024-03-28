using SistemasVentas.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas.DAL
{
    public class DetalleVentaDal
    {
        public DataTable ListarDetallesVentaDal()
        {
            string consulta = "SELECT DETALLEVENTA.IDDETALLEVENTA, PERSONA.NOMBRE AS CLIENTE, PRODUCTO.NOMBRE AS PRODUCTO, DETALLEVENTA.CANTIDAD, " +
                                     "DETALLEVENTA.PRECIOVENTA, DETALLEVENTA.SUBTOTAL, DETALLEVENTA.ESTADO " +
                              "FROM DETALLEVENTA INNER JOIN " +
                                                "VENTA ON DETALLEVENTA.IDVENTA = VENTA.IDVENTA INNER JOIN " +
                                                "CLIENTE ON VENTA.IDCLIENTE = CLIENTE.IDCLIENTE INNER JOIN " +
                                                "PRODUCTO ON DETALLEVENTA.IDPRODUCTO = PRODUCTO.IDPRODUCTO INNER JOIN " +
                                                "PERSONA ON CLIENTE.IDPERSONA = PERSONA.IDPERSONA";

            return Conexion.EjecutarDataTabla(consulta, "Consulta");
        }

        public void InsertarDetalleVentaDal(DetalleVenta detalleVenta)
        {
            string consulta = "insert into detalleVenta values(" + detalleVenta.IdVenta + "," +
                                                               "" + detalleVenta.IdProducto + "," +
                                                               "" + detalleVenta.Cantidad + "," +
                                                               "" + detalleVenta.PrecioVenta + "," +
                                                               "" + detalleVenta.SubTotal + "," +
                                                               "'" + detalleVenta.Estado + "')";
            Conexion.Ejecutar(consulta);
        }

        public DetalleVenta ObtenerDetalleVentaId(int id)
        {
            string consulta = "select * from detalleventa where iddetalleventa = " + id;
            DataTable tabla = Conexion.EjecutarDataTabla(consulta, "asdas");
            DetalleVenta detalleVenta = new DetalleVenta();
            if (tabla.Rows.Count > 0)
            {
                detalleVenta.IdDetalleVenta = Convert.ToInt32(tabla.Rows[0]["idDetalleVenta"]);
                detalleVenta.IdVenta = Convert.ToInt32(tabla.Rows[0]["idVenta"]);
                detalleVenta.IdProducto = Convert.ToInt32(tabla.Rows[0]["idProducto"]);
                detalleVenta.Cantidad = Convert.ToInt32(tabla.Rows[0]["cantidad"]);
                detalleVenta.PrecioVenta = Convert.ToDecimal(tabla.Rows[0]["precioVenta"].ToString());
                detalleVenta.SubTotal = Convert.ToDecimal(tabla.Rows[0]["subTotal"].ToString());
                detalleVenta.Estado = tabla.Rows[0]["estado"].ToString();
            }
            return detalleVenta;
        }

        public void EditarDetalleVentaDal(DetalleVenta detalleVenta)
        {
            string consulta = "update detalleventa set idVenta =" + detalleVenta.IdVenta + "," +
                                                      "idProducto =" + detalleVenta.IdProducto + "," +
                                                      "cantidad =" + detalleVenta.Cantidad + "," +
                                                      "precioVenta =" + detalleVenta.PrecioVenta + "," +
                                                      "subtotal =" + detalleVenta.SubTotal + "," +
                                                      "estado ='" + detalleVenta.Estado + "' " +
                                    "where iddetalleventa =" + detalleVenta.IdDetalleVenta;

            Conexion.Ejecutar(consulta);
        }

        public void EliminarDetalleVentaDal(int id)
        {
            string consulta = "delete from detalleventa where iddetalleventa =" + id;
            Conexion.Ejecutar(consulta);
        }
    }
}
