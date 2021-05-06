using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class frmVenta : System.Web.UI.Page
    {
        DataTable dtb;
        DataTable carrito = new DataTable();
        DataTable detalleObj = new DataTable();

        public void CargarDetalle()
        {
            if (Session["pedido"] == null)
            {
                dtb = new DataTable("Carrito");
                dtb.Columns.Add("id_producto", System.Type.GetType("System.String"));
                dtb.Columns.Add("descripcion", System.Type.GetType("System.String"));
                dtb.Columns.Add("precio", System.Type.GetType("System.Double"));
                dtb.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                dtb.Columns.Add("preciov", System.Type.GetType("System.Double"));

                Session["pedido"] = dtb;
                Session["prueba"] = dtb;
            }
            else
            {
                Session["pedido"] = Session["prueba"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDetalle();
            txtFechaVenta.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void selectCliente()
        {
            Cliente cli = new Cliente();
            cli.Nombre = txtBuscarC.Text;
            gvCliente.DataSource = cli.buscar();
            gvCliente.DataBind();
        }
        protected void selectClienteEmp()
        {
            Cliente cli = new Cliente();
            cli.Empresa = txtBuscarC.Text;
            gvCliente.DataSource = cli.buscarEmpresa();
            gvCliente.DataBind();
        }
        protected void selectProducto()
        {
            Producto prod = new Producto();
            prod.Descripcion = txtBuscarP.Text;
            gvProducto.DataSource = prod.buscar();
            gvProducto.DataBind();
        }
        protected void selectVenta()
        {
            Venta prod = new Venta();
            gvVenta.DataSource = prod.buscar(txtBuscarV.Text);
            gvVenta.DataBind();
        }
        public void cargarcarrito()
        {
            gvDetalle.DataSource = Session["pedido"];
            gvDetalle.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtFechaVenta.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtCliente.Text = "";
            txtIdVenta.Text = "";
            txtIdCliente.Text = "";
            txtBuscarC.Text = "";
            txtBuscarP.Text = "";
            lblResp.Text = "";
            txtIdVenta.Text = "";
            lblTotal.Text = "";
            gvDetalle.DataBind();
            Session["pedido"] = null;
            Session["prueba"] = null;
        }
        protected decimal calcularTotal()
        {
            decimal monto = 0;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                monto = monto + Convert.ToDecimal(row.Cells[5].Text);
            }
            return monto;
        }
        protected void actualizarSubtotal()
        {
            int cantidad = 0;
            int precio = 0;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                precio = Convert.ToInt32(row.Cells[3].Text);
                row.Cells[5].Text = Convert.ToString(cantidad * precio);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            actualizarSubtotal();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
           
            Venta vent = new Venta();
            vent.Fecha = Convert.ToDateTime(txtFechaVenta.Text);
            vent.Monto = calcularTotal();
            vent.Idcliente = Convert.ToInt32(txtIdCliente.Text);
            if (vent.guardar()) { lblResp.Text = "Venta Registrada..!"; } else { lblResp.Text = "Error al Registrar"; }

            DetalleVenta dv;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                dv = new DetalleVenta();
                dv.Idproducto = Convert.ToInt32(row.Cells[1].Text);
                dv.Preciov = Convert.ToDecimal(row.Cells[5].Text);
                dv.Cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                dv.guardar();
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            actualizarSubtotal();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
            Venta vent = new Venta();
            vent.Idventa = Convert.ToInt32(txtIdVenta.Text);
            vent.Fecha = Convert.ToDateTime(txtFechaVenta.Text);
            vent.Monto = calcularTotal();
            vent.Idcliente = Convert.ToInt32(txtIdCliente.Text);
            if (vent.modificar()) { lblResp.Text = "Venta Modificada..!"; } else { lblResp.Text = "Error al Modificar"; }

            DetalleVenta dv1 = new DetalleVenta();
            dv1.Idventa = Convert.ToInt32(txtIdVenta.Text);
            dv1.eliminar();

            DetalleVenta dv;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                dv = new DetalleVenta();
                dv.Idproducto = Convert.ToInt32(row.Cells[1].Text);
                dv.Preciov = Convert.ToDecimal(row.Cells[5].Text);
                dv.Cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                dv.guardar();
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            DetalleVenta dv1 = new DetalleVenta();
            dv1.Idventa = Convert.ToInt32(txtIdVenta.Text);
            dv1.eliminar();

            Venta vent = new Venta();
            vent.Idventa = Convert.ToInt32(txtIdVenta.Text);
            if (vent.eliminar()) { lblResp.Text = "Venta Eliminada..!"; } else { lblResp.Text = "Error al Eliminar"; }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            miModalV.Show(); //inicia el modal Venta
            gvVenta.DataBind(); //deja limpio la tabla de registros
            lblError.Text = "";
        }
        protected void buscarCliente(object sender, EventArgs e)
        {
            miModalC.Show(); //inicia el modal Cliente
            gvCliente.DataBind(); //deja limpio la tabla de registros
        }
        protected void buscarProducto(object sender, EventArgs e)
        {
            miModalP.Show(); //inicia el modal Producto
            gvProducto.DataBind(); //deja limpio la tabla de registros
            lblError.Text = "";
        }
        protected void btnCerrarCli(object sender, EventArgs e)
        {
            miModalC.Hide(); //cierra el modal Cliente
        }
        protected void btnCerrarPro(object sender, EventArgs e)
        {
            miModalP.Hide(); //cierra el modal Cliente
        }
        protected void btnCerrarVent(object sender, EventArgs e)
        {
            miModalV.Hide(); //cierra el modal Cliente
        }
        protected void btnBuscarC(object sender, EventArgs e)
        {
            //busqueda dentro del modal cliente
            selectCliente();
            miModalC.Show();
        }
        protected void btnBuscarCE(object sender, EventArgs e)
        {
            //busqueda dentro del modal cliente
            selectClienteEmp();
            miModalC.Show();
        }
        protected void btnBuscarP(object sender, EventArgs e)
        {
            //busqueda dentro del modal producto
            selectProducto();
            miModalP.Show();
        }
        protected void btnBuscarV(object sender, EventArgs e)
        {
            //busqueda dentro del modal venta
            selectVenta();
            miModalV.Show();
        }
        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = gvCliente.SelectedRow.Cells[0].Text;
            txtCliente.Text = gvCliente.SelectedRow.Cells[1].Text + ' ' + gvCliente.SelectedRow.Cells[2].Text;
        }
        private bool existeProdEnDetalle(int idProd)
        {
            bool existe = false;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                if (Convert.ToInt32(row.Cells[1].Text) == idProd)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public void AgregarItem(string id_producto, string descripcion, double precio)
        {
            double preciov;
            int cantidad = 1;
            preciov = precio * cantidad;
            carrito = (DataTable)Session["pedido"];
            DataRow fila = carrito.NewRow();
            fila[0] = id_producto;
            fila[1] = descripcion;
            fila[2] = precio;
            fila[3] = (int)cantidad;
            fila[4] = preciov;
            carrito.Rows.Add(fila);
            Session["pedido"] = carrito;
            cargarcarrito();
        }
        protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = gvProducto.SelectedRow.Cells[0].Text;
            string des = gvProducto.SelectedRow.Cells[1].Text;
            double precio = Convert.ToDouble(gvProducto.SelectedRow.Cells[2].Text);
            
            if (existeProdEnDetalle(Convert.ToInt32(cod)) == true)
            {
                lblError.Text = "Ya se encuentra agregado";
                miModalP.Show();
            }
            else
            {
                AgregarItem(cod, des, precio);
                lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
                miModalP.Show();
            }
        }
        protected void gvVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdVenta.Text = gvVenta.SelectedRow.Cells[0].Text;
            DateTime dt = Convert.ToDateTime(gvVenta.SelectedRow.Cells[1].Text);
            txtFechaVenta.Text = String.Format("{0:yyyy-MM-dd}", dt);
            txtCliente.Text = gvVenta.SelectedRow.Cells[3].Text;
            Venta vent = new Venta();
            txtIdCliente.Text = vent.buscarClienteVenta(Convert.ToInt32(txtIdVenta.Text));

            DetalleVenta det = new DetalleVenta();
            DataTable detalle = new DataTable();
            detalle= det.buscar(Convert.ToInt32(txtIdVenta.Text));
            gvDetalle.DataSource = detalle;
            gvDetalle.DataBind();
            Session["prueba"] = detalle;
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvDetalle.SelectedRow.Cells[1].Text);
            var db = (DataTable)Session["pedido"];
            detalleObj = null;
            foreach (DataRow row in db.Rows)
            {
                if (detalleObj == null)
                {
                    detalleObj = new DataTable("Carrito");
                    detalleObj.Columns.Add("id_producto", System.Type.GetType("System.String"));
                    detalleObj.Columns.Add("descripcion", System.Type.GetType("System.String"));
                    detalleObj.Columns.Add("precio", System.Type.GetType("System.Double"));
                    detalleObj.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                    detalleObj.Columns.Add("preciov", System.Type.GetType("System.Double"));
                }
                int es = Convert.ToInt32(row["id_producto"].ToString());
                if (es != id)
                {
                    DataRow fila = detalleObj.NewRow();
                    fila[0] = Convert.ToInt32(row["id_producto"].ToString());
                    fila[1] = Convert.ToString(row["descripcion"].ToString());
                    fila[2] = Convert.ToDecimal(row["precio"].ToString());
                    fila[3] = Convert.ToInt32(row["cantidad"].ToString());                    
                    fila[4] = Convert.ToDecimal(row["preciov"].ToString());
                    detalleObj.Rows.Add(fila);
                }
            }
            Session["pedido"] = detalleObj;
            Session["prueba"] = detalleObj;
            gvDetalle.DataSource = detalleObj;
            gvDetalle.DataBind();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
        }
    }
}