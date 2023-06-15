<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DevolucionDelivery.aspx.cs" Inherits="WebPolleria.WebForm5" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GestionarOrdenDelivery.css" />
    <div class="page-container">
    <br />
    <h3>PEDIDOS DELIVERY DEVUELTOS:</h3>
        <asp:Panel ID="Panel4" runat="server" CssClass="panelExterior2" Height="250px">
            <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior" Width="1100px" Height="200px">
                <asp:GridView ID="GvPedidos" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay ordenes pendientes" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvPedidos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="numOrdenPedidoDeli" HeaderText="ID PEDIDO DEL." />
                        <asp:BoundField DataField="fechaPreparacion" HeaderText="FECHA PREPARACION"/>
                        <asp:BoundField DataField="estado" HeaderText="DIRECCION"/>
                        <asp:CommandField HeaderText="DETALLE" SelectText="SELECCIONAR"  ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </asp:Panel>
        </asp:Panel>
    <h3>DETALLE PEDIDOS DELIVERY:</h3>
    <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior2" Height="250px">
        <asp:Label CssClass="label" Style="margin-left:60px;" ID="Label4" runat="server" Text="ID Orden Delivery:" ></asp:Label>
        <asp:TextBox CssClass="txtbox" ID="txtOPD" runat="server" Enabled="False"></asp:TextBox>
        <asp:Panel ID="Panel1" runat="server" CssClass="panelInterior" Width="1100px" Height="200px">
        <asp:GridView ID="GvDetalle" runat="server" AutoGenerateColumns="False" EmptyDataText="No tienes entregas pendientes" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="idProducto" HeaderText="ID PRODUCTO" />
                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCIÓN"/>
                <asp:BoundField DataField="cantidadProducto" HeaderText="CANTIDAD"/> 
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        </asp:Panel>
        <div style="margin-top: 305px; margin-left: 60px;">
        </div>
    </asp:Panel>
        <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 100px" ID="Button3" runat="server" OnClick="btnSalir_Click" Text="SALIR" />
        <asp:Button CssClass="button" Style="background-color: #4CAF50; position: relative; float: right; margin-right: 100px" ID="btnEmitir" runat="server" OnClick="btnLiberar_Click" Text="LIBERAR" />
    <br />
    <br />
    <br />
    </div>
</asp:Content>
