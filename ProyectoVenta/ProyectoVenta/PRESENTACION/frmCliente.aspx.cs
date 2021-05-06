using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class frmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        protected void mostrar()
        {
            Cliente cli = new Cliente();
            cli.Nombre = txtBuscar.Text;
            gvCliente.DataSource = cli.buscar();
            gvCliente.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdcliente.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEmpresa.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            lblResp.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Nombre = txtNombre.Text;
            cli.Apellidos = txtApellidos.Text;
            cli.Empresa = txtEmpresa.Text;
            cli.Telefono = txtTelefono.Text;
            cli.Direccion = txtDireccion.Text;
            if (cli.guardar()) { lblResp.Text = "Cliente Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Idcliente = Convert.ToInt32(txtIdcliente.Text);
            cli.Nombre = txtNombre.Text;
            cli.Apellidos = txtApellidos.Text;
            cli.Empresa = txtEmpresa.Text;
            cli.Telefono = txtTelefono.Text;
            cli.Direccion = txtDireccion.Text;
            if (cli.modificar()) { lblResp.Text = "Registro Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Idcliente = Convert.ToInt32(txtIdcliente.Text);
            if (cli.eliminar()) { lblResp.Text = "Registro Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdcliente.Text = gvCliente.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvCliente.SelectedRow.Cells[1].Text;
            txtApellidos.Text = gvCliente.SelectedRow.Cells[2].Text;
            txtEmpresa.Text = gvCliente.SelectedRow.Cells[3].Text;
            txtTelefono.Text = gvCliente.SelectedRow.Cells[4].Text;
            txtDireccion.Text = gvCliente.SelectedRow.Cells[5].Text;
        }

        protected void btnBuscarEmpresa_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Empresa = txtBuscar.Text;
            gvCliente.DataSource = cli.buscarEmpresa();
            gvCliente.DataBind();
        }
    }
}