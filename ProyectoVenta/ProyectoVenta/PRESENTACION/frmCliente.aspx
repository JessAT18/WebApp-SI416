<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="PRESENTACION.frmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
        <a href="frmCategoria.aspx">Categorias</a>&nbsp;
        <a href="frmProducto.aspx">Productos</a>&nbsp;
        <a href="frmCliente.aspx">Clientes</a>&nbsp;
        <a href="frmVenta.aspx">Ventas</a>
        <h3>REGISTRO DE CLIENTES</h3>
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdcliente" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
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
                        <asp:TableCell>Empresa</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Telefono</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Direccion</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" style="height: 26px"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
               <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp; 
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>
             <br />
            <div>
                <label>Listado de Clientes</label><br />
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
                <asp:Button ID="btnBuscarEmpresa" runat="server" Text="Buscar por Empresa" OnClick="btnBuscarEmpresa_Click"/>
                <br />
                <br />
                <br />
                <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id_cliente" HeaderText="IdCliente"/>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="apellidos" HeaderText="Apellidos"/>
                        <asp:BoundField DataField="empresa" HeaderText="Empresa"/>
                        <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                        <asp:BoundField DataField="direccion" HeaderText="Direccion"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </center>
</body>
</html>
