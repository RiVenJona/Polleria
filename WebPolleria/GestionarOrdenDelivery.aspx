<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionarOrdenDelivery.aspx.cs" Inherits="WebPolleria.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GestionarOrdenDelivery.css" />
    <div class="page-container">
    <br />
        <h3>ORDENES DE PEDIDO:</h3>
             <asp:Panel ID="Panel4" runat="server" CssClass="panelExterior2" Height="300px">
            <asp:Label CssClass="label" Style="margin-left:60px;" ID="Label4" runat="server" Text="ID Orden Delivery:" ></asp:Label>
            <asp:TextBox CssClass="txtbox" ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
            <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior" Width="1100px">
                <asp:GridView ID="GvOrdenesDel" runat="server" AutoGenerateColumns="False" EmptyDataText="No tienes entregas pendientes" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvOrdenesDel_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="numOrdenPedidoDeli" HeaderText="ID PEDIDO DEL." />
                        <asp:BoundField DataField="cliente" HeaderText="CLIENTE"/>
                        <asp:BoundField DataField="direccion" HeaderText="DIRECCION"/>
                        <asp:BoundField DataField="total" HeaderText="TOTAL"/>
                        <asp:BoundField DataField="vuelto" HeaderText="VUELTO"/>
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
            <div style="margin-top: 305px; margin-left: 60px;">
            </div>
        </asp:Panel>
       
        <h3>DETALLE PEDIDO:</h3>
        <asp:Panel ID="Panel1" runat="server" CssClass="panelExterior2" Height="30px" HorizontalAlign="Center">
            <asp:Label CssClass="label" Style="margin-left:60px;" ID="Label3" runat="server" Text="ID Orden Pedido:" ></asp:Label>
            <asp:TextBox CssClass="txtbox" ID="txtNroOP" runat="server" Enabled="false"></asp:TextBox>
            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" Style="margin-left:30px;">
                <asp:ListItem Selected="True" Text="POR ENTREGAR" Value="16"></asp:ListItem>
                <asp:ListItem Text="ENTREGADO" Value="17"></asp:ListItem>
                <asp:ListItem Text="NO ENTREGADO" Value="18"></asp:ListItem>
                <asp:ListItem Text="CANCELADO" Value="12"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button CssClass="button" Style="background-color: #4CAF50; margin-left: 30px" ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" Text="CAMBIAR" />
        
            </asp:Panel>
        <h3>RECAUDACIÓN:</h3>
            <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior2" Height="330px">
            <asp:Panel ID="Panel3" runat="server" CssClass="panelInterior" Width="1100px">
                <asp:GridView ID="GvOrdenes" runat="server" AutoGenerateColumns="False" EmptyDataText="No tienes entregas pendientes" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="numOrdenPedidoDeli" HeaderText="ID PEDIDO DEL." />
                        <asp:BoundField DataField="total" HeaderText="MONTO"/>
                        <asp:BoundField DataField="vuelto" HeaderText="VUELTO"/>
                        <asp:BoundField DataField="recaudacion" HeaderText="RECAUDACIÓN"/>
                        <asp:BoundField DataField="estado" HeaderText="ESTADO"/>
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
        <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 100px" ID="Button3" runat="server" Text="SALIR" />
                    <br />
    </div>
</asp:Content>
