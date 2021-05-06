using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class frmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.selectCategoria();
        }
        protected void mostrar()
        {
            Producto prod = new Producto();
            prod.Descripcion = txtBuscar.Text;
            gvProducto.DataSource = prod.buscar();
            gvProducto.DataBind();
        }
        protected void selectCategoria()
        {
            Categoria cat = new Categoria();
            if (IsPostBack == false)
            {
                dd1.DataSource = cat.selectCategoria();
                dd1.DataValueField = "id_categoria";
                dd1.DataTextField = "nombre";
                dd1.DataBind();
                dd1.Items.Insert(0, new ListItem("Selecciona", "0"));
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdproducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByValue("0"));
            lblResp.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Descripcion = txtDescripcion.Text;
            prod.Precio = Convert.ToDecimal(txtPrecio.Text);
            prod.Stock = Convert.ToInt32(txtStock.Text);
            prod.Idcategoria = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (prod.guardar()) { lblResp.Text = "Registro Guardado..!"; } else { lblResp.Text = "Error al guardar"; }
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Idproducto = Convert.ToInt32(txtIdproducto.Text);
            prod.Descripcion = txtDescripcion.Text;
            prod.Precio = Convert.ToDecimal(txtPrecio.Text);
            prod.Stock = Convert.ToInt32(txtStock.Text);
            prod.Idcategoria = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (prod.modificar()) { lblResp.Text = "Registro Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Idproducto = Convert.ToInt32(txtIdproducto.Text);
            if (prod.eliminar()) { lblResp.Text = "Registro Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdproducto.Text = gvProducto.SelectedRow.Cells[0].Text;
            txtDescripcion.Text = gvProducto.SelectedRow.Cells[1].Text;
            txtPrecio.Text = gvProducto.SelectedRow.Cells[2].Text;
            txtStock.Text = gvProducto.SelectedRow.Cells[3].Text;
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByText(gvProducto.SelectedRow.Cells[4].Text));
        }
    }
}