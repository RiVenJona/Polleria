<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="GenOrdenSalida.aspx.cs" Inherits="WebPolleria.GenOrdenSalida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenOrdenSalida.css" />
    <div class="page-container" style="padding:20px; padding-bottom:100px;">
    <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell Width="100%" HorizontalAlign="Left" ColumnSpan="2">
        <asp:Panel ID="Panel" runat="server" CssClass="panelExterior">
            <h3>SOLICITUDES DE INSUMO:</h3>
            <asp:Panel ID="Panel1" runat="server" CssClass="panelInterior">
                <asp:GridView ID="GvInsumo" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="10px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvInsumos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="numOrdenInsumo" HeaderText="IDPEDIDO" />
                        <asp:BoundField DataField="fecha" HeaderText="NOMBRE" />
                        <asp:CommandField HeaderText="SELECCIONAR" SelectText="SELECCIONAR"  ShowSelectButton="True" /> 
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
            <div style="margin-top:30px;">
            <asp:Label CssClass="label" runat="server" Text="Nro. Solicitud:"></asp:Label>
            <asp:TextBox Style="margin-left: 20px;" ID="txtNroSol" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </asp:Panel>
                </asp:TableCell>
    </asp:TableRow>    
            <asp:TableRow>
                <asp:TableCell Width="50%" Style="vertical-align: top;">
                    <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior" style="margin-right:15px;">
                        <h3>INSUMOS NO DISPONIBLES:</h3>
                        <asp:Panel ID="Panel3" runat="server" CssClass="panelInterior">
                            <asp:GridView ID="GvCompra" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="NumInsumo" HeaderText="ID INSUMO" />
                                    <asp:BoundField DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                                    <asp:BoundField DataField="Unidad" HeaderText="UNIDAD" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="CANT. SOLICITADA" />
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
                        <div style="margin-top:15px;">
                        <asp:Button CssClass="button" Style="background-color: #4CAF50;" ID="btnSolicitar" runat="server" OnClick="btnSolicitar_Click" Text="SOLICITAR" />
                        </div>                    
                    </asp:Panel>
                </asp:TableCell>
                <asp:TableCell Width="50%" Style="vertical-align: top;">
                    <asp:Panel ID="Panel4" runat="server" CssClass="panelExterior">
                        <h3>INSUMOS DISPONIBLES:</h3>
                        <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior">
                            <asp:GridView ID="GvSalida" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField DataField="NumInsumo" HeaderText="ID INSUMO" />
                                    <asp:BoundField DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                                    <asp:BoundField DataField="Unidad" HeaderText="UNIDAD" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="CANT. SOLICITADA" />
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
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 44px;margin-top: 10px;" ID="Button5" runat="server" Text="SALIR" />
        <asp:Button CssClass="button" style="background-color: #4CAF50; position:relative; float: right; margin-right: 44px; margin-top: 10px; top: 0px; left: 0px;" ID="btnGenerar" runat="server" Text="GENERAR" OnClick="btnGenerar_Click"/>

    </div>
</asp:Content>
