using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.listarCategoria();
        }

        private void mostrar()
        {
            Producto pro = new Producto();
            pro.Descripcion = txtBuscar.Text;
            gvRegis.DataSource = pro.buscar();
            gvRegis.DataBind();
        }
        protected void listarCategoria()
        {
            Categoria cat = new Categoria();
            if (IsPostBack == false)
            {
                dd1.DataSource = cat.listarCategoria();
                dd1.DataValueField = "id_categoria";
                dd1.DataTextField = "nombre";
                dd1.DataBind();
                dd1.Items.Insert(0, new ListItem("Selecciona", "0"));
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId_producto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByValue("0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Producto pro = new Producto();

            pro.Descripcion = txtDescripcion.Text;
            pro.Precio = Convert.ToInt32(txtPrecio.Text);
            pro.Stock = Convert.ToInt32(txtStock.Text);
            pro.id_Categoria = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (pro.guardar()) { txtResp.Text = "Registro Guardado..!"; } else { txtResp.Text = "Error al Registrar"; }
            this.mostrar();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto pro = new Producto();
            pro.id_Producto = Convert.ToInt32(txtId_producto.Text);
            pro.Descripcion = txtDescripcion.Text;
            pro.Precio = Convert.ToDecimal(txtPrecio.Text);
            pro.Stock = Convert.ToInt32(txtStock.Text);
            pro.id_Categoria = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (pro.modificar()) { txtResp.Text = "Registro Modificado..!"; } else { txtResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto pro = new Producto();
            pro.id_Producto = Convert.ToInt32(txtId_producto.Text);
            if (pro.eliminar()) { txtResp.Text = "Registro eliminado..!"; } else { txtResp.Text = "Error al eliminar; "; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvRegis_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtId_producto.Text = gvRegis.SelectedRow.Cells[0].Text;
            txtDescripcion.Text = gvRegis.SelectedRow.Cells[1].Text;
            txtPrecio.Text = gvRegis.SelectedRow.Cells[2].Text;
            txtStock.Text = gvRegis.SelectedRow.Cells[3].Text;
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByText(gvRegis.SelectedRow.Cells[4].Text));
        }
    }
}