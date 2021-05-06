using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }
        protected void mostrar()
        {
            Categoria cat = new Categoria();
            cat.Nombre = txtBuscar.Text;
            gvRegis.DataSource = cat.buscar();
            gvRegis.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Nombre = txtNombre.Text;
            if (cat.guardar()) { txtResp.Text = "Registro Guardado..!"; } else { txtResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId_categoria.Text = "";
            txtNombre.Text = "";
            txtBuscar.Text = "";
            txtResp.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvRegis_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId_categoria.Text = gvRegis.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvRegis.SelectedRow.Cells[1].Text; 
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            Categoria cat = new Categoria();
            cat.id_Categoria = Convert.ToInt32(txtId_categoria.Text);
           cat.Nombre = txtNombre.Text;
              if (cat.modificar()) { txtResp.Text = "Registro Modificado..!"; } else { txtResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.id_Categoria = Convert.ToInt32(txtId_categoria.Text);
            if (cat.eliminar()) { txtResp.Text = "Registro eliminado..!"; } else { txtResp.Text = "Error al eliminar; "; }
            this.mostrar();
        }
    }
}