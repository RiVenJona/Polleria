<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GOrdenDelivery(Daniel).aspx.cs" Inherits="WebPolleria.GOrdenDelivery_Daniel_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilos/GenOrdenDelivery(dan).css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="BgContainer">
    <div class="encabezadoDelivery">
        <h4 class="Titulo"><b>Lista Pedidos Delivery</b></h4>
        <asp:Button CssClass="btnRefresh" ID="btnRefresh" runat="server" Text="🔄️" OnClick="btnRefresh_Click" />
    </div>
    <fieldset>
        <legend>Pedidos por asignar</legend>
    <%-- TABLA 1 --%>
        <asp:GridView ID="gvListaPedidos" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField HeaderText="CODIGO" DataField="idOPD" />
                <asp:BoundField HeaderText="CLIENTE" DataField="nombreCliente" />
                <asp:BoundField HeaderText="PEDIDO" DataField="Creacion" />
                <asp:BoundField HeaderText="LISTO" DataField="estadoPedido" />
                <asp:TemplateField HeaderText="PICK">
                  <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACT">
                  <ItemTemplate>
                    <asp:Button CssClass="btnTablaPedido" ID="SelectButton" runat="server" Text="Ver"/>
                  </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </fieldset>
    <div class="containerText">
        <h5>Seleccionados:</h5>
        <asp:Label ID="txtSeleccionados" runat="server" Text="0" CssClass="txtCantidad"></asp:Label>
    </div>
    
    <fieldset>
        <legend>Persona quien envia</legend>
        <asp:GridView ID="gvRepEnable" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="REPARTIDOR" DataField="repartidor"/>
                <asp:ButtonField Text="Seleccionar" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    <asp:Button  runat="server" Text="Asignar" ID="btnAsignar" CssClass="btnAsignar"/>
</fieldset>
        </div>
</asp:Content>
