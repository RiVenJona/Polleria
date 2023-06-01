<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionarOrdenDelivery.aspx.cs" Inherits="WebPolleria.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GestionarOrdenDelivery.css" />
    <div class="page-container">
    <br />
        <h3>ORDENES DE PEDIDO:</h3>
        <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior2">
            <asp:Label CssClass="label" Style="margin-left:60px;" ID="Label1" runat="server" Text="ID Orden Delivery:" ></asp:Label>
            <asp:TextBox CssClass="txtbox" ID="txtNroDelivery" runat="server" Enabled="false"></asp:TextBox>
            <asp:Panel ID="Panel3" runat="server" CssClass="panelInterior" Width="1100px">
                <asp:GridView ID="GvOrdenes" runat="server" AutoGenerateColumns="False" EmptyDataText="No tienes entregas pendientes" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="numOrdenPedidoDeli" HeaderText="ID PEDIDO DEL." />
                        <asp:BoundField DataField="total" HeaderText="MONTO"/>
                        <asp:BoundField DataField="vuelto" HeaderText="VUELTO"/>
                        <asp:BoundField DataField="recaudacion" HeaderText="RECAUDACIÓN"/>
                        <asp:BoundField DataField="estado" HeaderText="ESTADO"/>
                        <asp:CommandField HeaderText="DETALLE" SelectText="SELECCIONAR" ShowSelectButton="True" />
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
            <asp:Label CssClass="label" ID="Label2" runat="server" Text="Recaudación total:"></asp:Label>
            <asp:TextBox ID="txtRecaudacion" CssClass="txtbox" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </asp:Panel>
        <h3>DETALLE PEDIDO:</h3>
        <asp:Panel ID="Panel1" runat="server" CssClass="panelExterior2">
            <asp:Label CssClass="label" Style="margin-left:60px;" ID="Label3" runat="server" Text="ID Orden Pedido:" ></asp:Label>
            <asp:TextBox CssClass="txtbox" ID="txtNroOP" runat="server" Enabled="false"></asp:TextBox>
            <div CssClass="flex-container" style="margin-left:60px;">
            <asp:RadioButtonList CssClass="rbllabel2" ID="RblEstado" runat="server" CellPadding="10" AutoPostBack="true" OnSelectedIndexChanged="RblEstado_SelectedIndexChanged">
                <asp:ListItem Selected="True" Text="POR ENTREGAR" Value="1"></asp:ListItem>
                <asp:ListItem Text="ENTREGADO" Value="2"></asp:ListItem>
                <asp:ListItem Text="NO ENTREGADO" Value="3"></asp:ListItem>
                <asp:ListItem Text="CANCELADO" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                </div>
                            
        </asp:Panel>
    </div>
</asp:Content>
