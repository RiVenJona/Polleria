<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CobrarOrdenPedido.aspx.cs" Inherits="WebPolleria.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/CobrarOrdenPedido.css" />
    <div class="page-container">
        <br />
        <h3>BUSCAR ORDEN DE PEDIDO:</h3>
        <asp:Panel ID="Panel1" runat="server" CssClass="panel">
            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Código O. Pedido:"></asp:Label>
            <asp:TextBox Style="margin-left: 20px;" ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button CssClass="button" Style="background-color: #4CAF50; margin-left: 20px;" ID="Button2" runat="server" Text="BUSCAR" />
        </asp:Panel>
        <h3>DETALLE PEDIDO:</h3>
        <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior">
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="N° O. Pedido:"></asp:Label>
            <asp:TextBox Style="margin-left: 20px;" ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            <asp:TextBox Style="position: relative; float: right; margin-right: 0px; margin-left: 20px;" ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
            <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label2" runat="server" Text="Tipo de Servicio:"></asp:Label>
            <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior">
                <asp:GridView ID="GvDetalle" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="des" HeaderText="DESCRIPCIÓN" />
                        <asp:BoundField DataField="cant" HeaderText="CANTIDAD" />
                        <asp:BoundField DataField="tot" HeaderText="TOTAL" />
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
            <div style="margin-top: 360px">
                <asp:TextBox Style="position: relative; float: right; margin-right: 0px; margin-left: 20px;" ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label3" runat="server" Text="Monto:"></asp:Label>
            </div>
        </asp:Panel>
        <h3>DATOS CLIENTE:</h3>
        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label CssClass="labelDC" ID="Label5" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" Width="400px" Enabled="False"></asp:TextBox>
            <asp:TextBox Style="position: relative; float: right; margin-right: 100px; margin-left: 20px;" ID="TextBox7" runat="server"></asp:TextBox>
            <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label7" runat="server" Text="DNI / RUC:"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="labelDC" ID="Label6" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" Width="400px" Enabled="False"></asp:TextBox>
        </asp:Panel>
        <h3>DETALLE CDP:</h3>
        <asp:Panel ID="Panel4" runat="server" CssClass="panel">
            <asp:Label CssClass="labelDC" ID="Label8" runat="server" Text="N° CDP:"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" Enabled="False"></asp:TextBox>
            <asp:TextBox Style="position: relative; float: right; margin-right: 100px; margin-left: 20px;" ID="txtFecha" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
            <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label9" runat="server" Text="Fecha:"></asp:Label>
            <br />
            <br />
            <asp:Label CssClass="label" ID="Label10" runat="server" Text="Método de Pago:"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList CssClass="rbllabel" ID="RblMetodoPago" runat="server" Width="300px">
            </asp:RadioButtonList>
            <br />
            <asp:Label CssClass="label" ID="Label11" runat="server" Text="Tipo CDP:"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList CssClass="rbllabel" ID="RblCDP" runat="server" Width="300px">
            </asp:RadioButtonList>
        </asp:Panel>
            <br />
        <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 150px" ID="Button3" runat="server" OnClick="Button3_Click" Text="SALIR" />
            <asp:Button CssClass="button" Style="background-color: #4CAF50; position: relative; float: right; margin-right: 150px" ID="Button4" runat="server" OnClick="Button4_Click" Text="GENERAR" />

        <br />
        <br />
        <br />

    </div>
</asp:Content>
