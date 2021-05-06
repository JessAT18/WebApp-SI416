using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;

namespace PRESENTACION
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
            gvCategoria.DataSource = cat.buscar();
            gvCategoria.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdcategoria.Text = "";
            txtNombre.Text = "";
            lblResp.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Nombre = txtNombre.Text;
            if (cat.guardar()) { lblResp.Text = "Registro Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }
    }
}