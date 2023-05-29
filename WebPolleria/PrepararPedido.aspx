<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PrepararPedido.aspx.cs" Inherits="WebPolleria.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/CobrarOrdenPedido.css" />
    <div class="page-container">
        <h3>VER ESTADO DE PEDIDOS:</h3>
        <asp:Panel ID="Panel6" runat="server" CssClass="panelExterior2">
            <asp:DropDownList ID="ddlTipo" runat="server">
                <asp:ListItem Text="PRESENCIAL" Value="1" Selected="True" />
                <asp:ListItem Text="DELIVERY" Value="2" />
            </asp:DropDownList>
            <asp:Panel ID="Panel7" runat="server" CssClass="panelInterior" Width="1100px">
                <asp:GridView ID="GvEsperando" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvEsperando_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="idTicket" HeaderText="IDTICKET" />
                        <asp:BoundField DataField="numOrdenPedido" HeaderText="IDORDEN" />
                        <asp:CommandField HeaderText="SELECCIONAR" SelectText="SELECCIONAR" ShowSelectButton="True"/>
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
        <br>
        <asp:Panel ID="Panel1" runat="server" CssClass="panelExterior2">
            <asp:Panel ID="Panel2" runat="server" CssClass="panelInterior" Width="1100px">
                <asp:GridView ID="GvDetalle" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvEsperando_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="desProductoTicket" HeaderText="DETALLE" />
                        <asp:BoundField DataField="cantidadProductoTicket" HeaderText="CANTIDAD" />
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
                            <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 100px" ID="Button3" runat="server" OnClick="Button3_Click" Text="SALIR" />
                    <asp:Button CssClass="button" Style="background-color: #4CAF50; position: relative; float: right; margin-right: 100px" ID="btnEmitir" runat="server" OnClick="btnPreparado_Click" Text="LISTO" />
    </div>
</asp:Content>
