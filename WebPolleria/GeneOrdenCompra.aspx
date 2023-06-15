<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneOrdenCompra.aspx.cs" Inherits="WebPolleria.GeneOrdenCompra1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenOrdenCompra.css" />
    <div class="General">
        <br />
        <div class="tituloCus">
            <asp:Label ID="Label4" runat="server" Text="Orden de Compra" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
        <div>
    <asp:Label ID="Label1" runat="server" style="position:relative; float: left; top: 0px; left: 0px;margin-left:20px;" Text="Fecha: " class="Fuente1"></asp:Label>
    <asp:TextBox ID="TxtFecha" TextMode="Date"  style="position:relative; float: left; top: 0px; left: 0px;margin-left:10px;" runat="server"></asp:TextBox>
    
    <asp:TextBox ID="TxtEAlmacen" style="position:relative; float: right; top: 0px; left: 0px; margin-left:10px;margin-right:20px;" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server"  style="position:relative; float: right; top: 0px; left: 0px;" Text="Encargado de Almacen: " class="Fuente1"></asp:Label> 
    </div>
        <div id="Solicitudes" runat="server">
        <br />
            <h3 class="Seccion">Solicitudes</h3>
           <asp:GridView ID="GvSolicitudes" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" EmptyDataText="No hay solicitudes disponibles" OnSelectedIndexChanged="GvSolicitudes_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="NumSolInsumo" HeaderText="Id Solicitud" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="FechaSolicitudes" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" />
        <asp:CommandField HeaderText="SELECCIONAR" SelectText="SELECCIONAR" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333"/>
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>

        </div>
        <br />
        <div id="Insumos" runat="server">
            <h3 class="Seccion">Insumos Solicitados</h3>
            <asp:GridView ID="GvInsumo" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" EmptyDataText="No hay datos disponibles" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                                    <asp:BoundField DataField="NumInsumo" HeaderText="ID INSUMO"  ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Categoria" HeaderText="CATEGORIA"  ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="DesIns" HeaderText="DESCRIPCIÓN"  ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Cantidad" HeaderText="CANT. SOLICITADA" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Unidad" HeaderText="UNIDAD" ItemStyle-HorizontalAlign="Center" />
                                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        </div>
        <br />
        <div class="SeccionBotones">
            <asp:Button ID="BtnSalir" runat="server" CssClass="button" Text="Salir" OnClick="BtnSalir_Click" />
            <asp:Button ID="BtnGenerar" runat="server" CssClass="button" Style="margin-left:25px" Text="Generar" OnClick="BtnGenerar_Click" />
        </div>
        <br />
        <br />
    </div>
</asp:Content>
