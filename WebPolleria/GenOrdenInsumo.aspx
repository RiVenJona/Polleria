<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="GenOrdenInsumo.aspx.cs" Inherits="WebPolleria.GenOrdenInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div style="margin-top: 30px">
        <asp:Label ID="Label6" runat="server" Width="160px" Text="Nro. O. Insumo:"></asp:Label>
        <asp:TextBox ID="TxtNroIns" runat="server" Width="128px" Enabled="false"></asp:TextBox>
        <asp:TextBox style="position:relative; float: right; margin-right: 50px" ID="TxtJefe" runat="server" Width="118px"></asp:TextBox>
        <asp:Label style="position:relative; float: right;" ID="Label7" runat="server" Width="160px" Text="Jefe de Cocina:"></asp:Label>
    </div>
    <h4>BUSCAR INSUMO:</h4>    
    <asp:Panel ID="Panel1" runat="server" Height="70px" style="border: 1px solid black;">
        <br />
        <asp:Label ID="Label3" runat="server" Width="160px" Text="Nombre de insumo: "></asp:Label>
        <asp:TextBox ID="TxtInsumoDesc" runat="server"></asp:TextBox>
        <asp:Button style="margin-left: 50px" ID="btnBuscar" runat="server" Text="Buscar" Width="68px" OnClick="btnBuscar_Click"/>
        <br />
    </asp:Panel>
    <h4>DATOS INSUMO:</h4>  
    <asp:Panel ID="Panel2" runat="server" Height="240px" style="border: 1px solid black;">
        <br />
        <asp:GridView HorizontalAlign="Center" ID="GvDatos" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="460px" OnSelectedIndexChanged="GvDatos_SelectedIndexChanged">
            <Columns>

                <asp:BoundField  DataField="NumInsumo" HeaderText="ID" />
                <asp:BoundField  DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                <asp:BoundField  DataField="Categoria" HeaderText="CATEGORÍA" />
                <asp:BoundField  DataField="Unidad" HeaderText="UNIDAD" />
                <asp:BoundField  DataField="Cantidad" HeaderText="CANTIDAD" />
                <asp:CommandField HeaderText="SELECCIÓN" SelectText="Seleccionar" ShowSelectButton="True"/>           
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
        <br />
        <asp:Button style="float: right; margin-right: 50px" ID="btnAgregar" runat="server" Width="60px" Text="Agregar" />
        <br />
    </asp:Panel>
    <h4>DETALLE ORDEN DE INSUMO:</h4>  
    <asp:Panel ID="Panel3" runat="server" Height="240px" style="border: 1px solid black;">
        <br />
        <asp:GridView HorizontalAlign="Center" ID="GvOrden" runat="server" ShowHeaderWhenEmpty="true" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="460px" OnSelectedIndexChanged="GvOrden_SelectedIndexChanged">
            <Columns>
                <asp:BoundField  DataField="NumInsumo" HeaderText="ID" />
                <asp:BoundField  DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                <asp:BoundField  DataField="Categoria" HeaderText="CATEGORÍA" />
                <asp:BoundField  DataField="Unidad" HeaderText="UNIDAD" />
                <asp:TemplateField HeaderText="CANTIDAD">
                  <ItemTemplate>
                    <asp:TextBox ID="txtCantGv" runat="server"  Width="38px" Enabled="false" Text=1></asp:TextBox>
                      <BR />
                    <asp:Button runat="server" ID="btnIncrementar" Text="+" OnClick="btnIncrementar_Click" />
                    <asp:Button runat="server" ID="btnDisminuir" Text="-" OnClick="btnDisminuir_Click" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QUITAR">
                  <ItemTemplate>
                      <asp:Button runat="server" ID="btnEliminar" Width="25px" Height="25px" CommandArgument='<%# Container.DataItemIndex %>' Text="x" OnClick="btnEliminar_Click"/>
                  </ItemTemplate>
                </asp:TemplateField>
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
    <div>
        <br />
        <asp:Button style="position:absolute; float: left; margin-left: 50px" ID="btnSalir" runat="server" Width="60px" Text="Salir" />
        <asp:Button style="position:relative; float: right; margin-right: 50px" ID="btnGenerar" runat="server" Width="60px" Text="Generar" />
        <br />
    </div>
    </div>
</asp:Content>
