<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="GenOrdenInsumo.aspx.cs" Inherits="WebPolleria.GenOrdenInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenOrdenInsumo.css" />
    <div class="page-container">
                <br />
    <div>
    <asp:Panel ID="Panel4" runat="server" CssClass="panel">
        <asp:Label CssClass="label" ID="Label6" runat="server" Width="160px" Text="Nueva S. Insumo:" ></asp:Label>
        <asp:TextBox ID="TxtNroIns" runat="server" Width="128px" Enabled="false"></asp:TextBox>
        <asp:TextBox style="position:relative; float: right; margin-right: 50px" ID="TxtJefe" runat="server" Width="118px"></asp:TextBox>
        <asp:Label CssClass="label" style="position:relative; float: right;" ID="Label7" runat="server" Width="160px" Text="Jefe de Cocina:"></asp:Label>
    </asp:Panel>
    </div>
        <br />
        <div style="text-align: center;">
        <h3>BUSCAR INSUMO:</h3>
        </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="panel">
        <br />
        <asp:Label CssClass="label" ID="Label3" runat="server" Width="160px" Text="Nombre de insumo: "></asp:Label>
        <asp:TextBox ID="TxtInsumoDesc" runat="server"></asp:TextBox>
        <asp:Button CssClass="button" style="background-color: #4CAF50; margin-left: 50px" ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click"/>
        <br />
    </asp:Panel>
        <br />
        <div style="text-align: center;">
        <h3>DATOS INSUMO:</h3>
        </div>
    <asp:Panel ID="Panel2" runat="server" CssClass="panelGv">
        <asp:Panel ID="Panel6" runat="server" CssClass="panelInterior">
        <div>
        <asp:GridView CssClass="gridView" HorizontalAlign="Center" ID="GvDatos" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvDatos_SelectedIndexChanged">
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
            </div>
       </asp:Panel> 
    </asp:Panel>
        <div style="text-align: center;">
            <h3>DETALLE SOLICITUD DE INSUMO:</h3>
        </div>
    <asp:Panel ID="Panel3" runat="server" CssClass="panelGv">
        <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior">
        <asp:GridView CssClass="gridView2" HorizontalAlign="Center" ID="GvOrden" runat="server" ShowHeaderWhenEmpty="true" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="GvOrden_SelectedIndexChanged">
            <Columns>
                <asp:BoundField  DataField="NumInsumo" HeaderText="ID"/>
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
    </asp:Panel>
    <div>
        <br />
        <asp:Button CssClass="button" style="background-color: #FF0000; position:absolute; float: left; margin-left: 200px" ID="btnSalir" runat="server" Text="SALIR" OnClick="btnSalir_Click"/>
        <asp:Button CssClass="button" style="background-color: #4CAF50; position:relative; float: right; margin-right: 200px; top: 0px; left: 0px;" ID="btnGenerar" runat="server" Text="GENERAR" OnClick="btnGenerar_Click"/>
        <br />
    </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>
