using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOCompras
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOCompras()
        {

        }
        
        public DataTable obtenerTabla()
        {
            return ad.abrirTabla("DetalleCompra", "Select DetalleCompra.Legajo_Cliente, Compra.Legajo_Compra, Compra.Fecha, Compra.Cantidad, Compra.Legajo_Producto, Producto.Nombre, Producto.Descripción, Producto.Precio from Compra INNER JOIN CompraXCliente ON Compra.Legajo_Compra = CompraXCliente.Legajo_Compra INNER JOIN Producto ON Producto.Legajo_Producto = Compra.Legajo_Producto");
                 
        }

        public DataTable obtenerTablaCliente(Clientes cli) 
        {
            return ad.abrirTabla("CompraXCliente", $"Select CompraXCliente.Legajo_Cliente, Compra.Legajo_Compra, Compra.Fecha, Compra.Cantidad, Compra.Legajo_Producto, Producto.Nombre, Producto.Descripción, Producto.Precio from Compra INNER JOIN CompraXCliente ON Compra.Legajo_Compra = CompraXCliente.Legajo_Compra AND {cli.legajo_Cliente} = CompraXCliente.Legajo_Cliente INNER JOIN Producto ON Producto.Legajo_Producto = Compra.Legajo_Producto");
            
        }
        public DataTable obtenerTablaCompras(Clientes cli)
        {
            
            return ad.abrirTabla("Compras", $"Select Legajo_Compra, Fecha, Total from Compra Where Legajo_Cliente = {cli.legajo_Cliente}");
        }
        public DataTable obtenerTablaDetalleCompra(Compras compra)
        {
            return ad.abrirTabla("DetalleCompra", $"Select Legajo_Compra, Producto.Nombre,Producto.Marca,Producto.Categoria,DetalleCompra.PU,DetalleCompra.Cantidad,DetalleCompra.Subtotal from DetalleCompra INNER JOIN Producto On DetalleCompra.Legajo_Producto = Producto.Legajo_Producto where Legajo_Compra = {compra.legajo_Compra}");
        }

        
    }
}
