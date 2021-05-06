<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCategoria.aspx.cs" Inherits="PRESENTACION.frmCategoria" %>

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
        <h3>REGISTRO DE CATEGORIAS</h3>
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdcategoria" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Nombre</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <label>Listado de Categorias</label><br />
                <asp:TextBox ID="txtBuscar" runat="server" Width="90px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
                <br />
                <br />
                <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="id_categoria" HeaderText="IdCategoria"/>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </center>
</body>
</html>
