<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPersona.aspx.cs" Inherits="capaPresentacion.frmPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>frmPersona</title>
</head>
<body>
    <h3>REGISTRO DE PERSONAS</h3>  
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>Ci</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtCi" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Nombre</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Apellidos</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Sexo</asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton ID="rb1" runat="server" GroupName="rbt" Checked="false"/>Masculino
                        <asp:RadioButton ID="rb2" runat="server" GroupName="rbt"/>Femenino
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Fecha Nacimiento</asp:TableCell>
                    <asp:TableCell><asp:TextBox type="date" ID="txtFecha" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Telefono</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/><br />
            <asp:Label ID="txtResp" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <label>Listado de Personas</label><br />
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
            <br />
            <br />
            <asp:GridView ID="gvRegis" runat="server" AutoGenerateColumns="false" OnPageIndexChanged="gvRegis_SelectedIndexChanged" OnSelectedIndexChanged="gvRegis_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ci" HeaderText="Ci"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos"/>
                    <asp:BoundField DataField="sexo" HeaderText="Sexo"/>
                    <asp:BoundField DataField="fecha_nacimiento" DataFormatString="{0:d}" HeaderText="Fecha Nacimiento"/>
                    <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Editar"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
