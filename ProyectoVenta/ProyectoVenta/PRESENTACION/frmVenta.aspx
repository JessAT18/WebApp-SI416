<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVenta.aspx.cs" Inherits="PRESENTACION.frmVenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .modalBackground{
            background-color: black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 !important;
            z-index:20;
        }
        .modalPopup{
            padding:20px 0px 24px 10px;
            position: relative;
            width:550px;
            height:300px;
            background-color:white;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <center>
        <a href="frmCategoria.aspx">Categorias</a>&nbsp;
        <a href="frmProducto.aspx">Productos</a>&nbsp;
        <a href="frmCliente.aspx">Clientes</a>&nbsp;
        <a href="frmVenta.aspx">Ventas</a>
        <h3>REGISTRO DE VENTAS</h3>
        
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdVenta" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdCliente" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>FechaVenta</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtFechaVenta" type="date" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Cliente</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtCliente" runat="server"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><a href="#" runat="server" onserverclick="buscarCliente">Buscar Cliente</a></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><a href="#" runat="server" onserverclick="buscarProducto">Agregar Producto</a></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <%--Tabla detalle Venta--%>
                <div>
                    <asp:GridView ID="gvDetalle" Width="500px" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDetalle_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Quitar"/>
                            <asp:BoundField DataField="id_producto" HeaderText="Codigo"/>
                            <asp:BoundField DataField="descripcion" ItemStyle-Width="150" HeaderText="Descripcion"/>
                            <asp:BoundField DataField="precio" HeaderText="Precio"/>
                            <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidad" Width="90px" runat="server">1</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="preciov" ItemStyle-HorizontalAlign="Right" HeaderText="SubTotal"/>
                        </Columns>
                    </asp:GridView>
                    <asp:Table runat="server" Width="500px">
                        <asp:TableRow>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px" HorizontalAlign="Right">
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>             

                </div>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>

            <%--Modales Cliente Producto--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--Inicio modal buscar cliente--%>
            <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalC" runat="server" TargetControlID="lblCliente" PopupControlID="modalCliente" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            
            <div id="modalCliente" class="modalPopup">
                 <div id="Header" class="header" >
                     Busqueda de Clientes
                     <br />
                     <br />
                 </div>
                 <div id="main" class="main">
                    <asp:TextBox ID="txtBuscarC" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarCli" runat="server" Text="Buscar por Nombre" OnClick="btnBuscarC"/>
                    <asp:Button ID="btnBuscarCliEmpresa" runat="server" Text="Buscar por Empresa" OnClick="btnBuscarCE"/>
                    <br />
                    <br />
                    <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_cliente" HeaderText="Id"/>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                            <asp:BoundField DataField="apellidos" HeaderText="Apellidos"/>
                            <asp:BoundField DataField="empresa" HeaderText="Empresa"/>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                            <asp:BoundField DataField="direccion" HeaderText="Direccion"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>

                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarC" runat="server" text="Cerrar" OnClick="btnCerrarCli" />
                 </div>
            </div>
            <%--Fin modal buscar cliente--%>

            <%--Inicio modal buscar producto--%>
             <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalP" runat="server" TargetControlID="lblProducto" PopupControlID="modalProducto" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            <div id="modalProducto" class="modalPopup">
                 <div id="Header2" class="header" >
                     Seleccione uno o varios productos
                     <br />
                     <br />
                 </div>
                 <div id="main2" class="main">
                    <asp:TextBox ID="txtBuscarP" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarProd" runat="server" Text="Buscar por Descripcion" OnClick="btnBuscarP"/><br />
                     <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvProducto_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_producto" HeaderText="Id"/>
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion"/>
                            <asp:BoundField DataField="precio" HeaderText="Precio"/>
                            <asp:BoundField DataField="stock" HeaderText="Stock"/>
                            <asp:BoundField DataField="nomb_categoria" HeaderText="Categoria"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>
                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarP" runat="server" text="Cerrar" OnClick="btnCerrarPro" />
                 </div>
            </div>
            <%--Fin modal buscar producto--%>   
            
            <%--Inicio modal buscar venta--%>
            <asp:Label ID="lblVenta" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalV" runat="server" TargetControlID="lblVenta" PopupControlID="modalVenta" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            
            <div id="modalVenta" class="modalPopup">
                 <div id="Header3" class="header" >
                     Busqueda de Venta
                     <br />
                     <br />
                 </div>
                 <div id="main3" class="main">
                    <asp:TextBox ID="txtBuscarV" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarVent" runat="server" Text="Buscar por Nombre de Cliente" OnClick="btnBuscarV"/>
                    <br />
                    <br />
                    <asp:GridView ID="gvVenta" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvVenta_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_venta" HeaderText="IdVenta"/>
                            <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="FechaVenta"/>
                            <asp:BoundField DataField="monto" HeaderText="Total"/>
                            <asp:BoundField DataField="cliente" HeaderText="Cliente"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>

                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarV" runat="server" text="Cerrar" OnClick="btnCerrarVent" />
                 </div>
            </div>
            <%--Fin modal buscar venta--%>
        </form> 
    </center>
</body>
</html>
