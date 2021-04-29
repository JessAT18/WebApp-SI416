using capaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capaPresentacion
{
    public partial class frmPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }
        protected void mostrar()
        {
            Persona person = new Persona();
            person.Nombre = txtBuscar.Text;
            gvRegis.DataSource = person.buscar();
            gvRegis.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Persona person = new Persona();
            person.Ci = Convert.ToInt32(txtCi.Text);
            person.Nombre = txtNombre.Text;
            person.Apellidos = txtApellidos.Text;
            person.Sexo = rb1.Checked ? "M" : "F";
            person.Fecha_nacimiento = Convert.ToDateTime(txtFecha.Text);
            person.Telefono = txtTelefono.Text;
            txtResp.Text = person.guardar() ? "Registro Guardado!" : "Error al registrar";
            this.mostrar();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvRegis_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb1.Checked = false;
            rb2.Checked = false;
            txtCi.Text = gvRegis.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvRegis.SelectedRow.Cells[1].Text;
            txtApellidos.Text = gvRegis.SelectedRow.Cells[2].Text;
            if (gvRegis.SelectedRow.Cells[3].Text == "M") { rb1.Checked = true; } else { rb2.Checked = true; }
            DateTime dt = Convert.ToDateTime(gvRegis.SelectedRow.Cells[4].Text);
            txtFecha.Text = String.Format("{0:yyyy-MM-dd}", dt);
            txtTelefono.Text = gvRegis.SelectedRow.Cells[5].Text;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Persona person = new Persona();
            person.Ci = Convert.ToInt32(txtCi.Text);
            person.Nombre = txtNombre.Text;
            person.Apellidos = txtApellidos.Text;
            if (rb1.Checked) { person.Sexo = "M"; } else { person.Sexo = "F"; }
            person.Fecha_nacimiento = Convert.ToDateTime(txtFecha.Text);
            person.Telefono = txtTelefono.Text;
            if (person.modificar()) { txtResp.Text = "Registro Modificado..!"; } else { txtResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCi.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            rb1.Checked = false;
            rb2.Checked = false;
            txtFecha.Text = "";
            txtTelefono.Text = "";
            txtResp.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Persona person = new Persona();
            person.Ci = Convert.ToInt32(txtCi.Text);
            if (person.eliminar()) { txtResp.Text = "Registro Eliminado..!"; } else { txtResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }
    }
}