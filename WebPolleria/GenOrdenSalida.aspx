<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="GenOrdenSalida.aspx.cs" Inherits="WebPolleria.GenOrdenSalida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenOrdenSalida.css" />
    <div class="page-container" style="padding:20px; padding-bottom:100px;">
        <asp:Panel ID="Panel" runat="server" CssClass="panelExterior">
            <h3>SOLICITUDES DE INSUMO:</h3>
            <asp:Label CssClass="label" runat="server" Text="Nro. Solicitud de la Semana Actual:"></asp:Label>
            <asp:TextBox Style="margin-left: 20px;" ID="txtNroSol" runat="server" Enabled="false"></asp:TextBox>
            <asp:Panel ID="Panel1" runat="server" CssClass="panelInterior">
                <asp:GridView ID="GvInsumo" runat="server" AutoGenerateColumns="False" EmptyDataText="NO HAY SOLICITUDES PENDIENTES PARA EL DÍA DE HOY." BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="10px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="IdInsumo" HeaderText="ID INSUMO" />
                        <asp:BoundField DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                        <asp:BoundField DataField="Unidad" HeaderText="UNIDAD" />
                        <asp:BoundField DataField="Cantidad" HeaderText="CANTIDAD" />
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
    <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 44px;margin-top: 10px;" ID="btnSalir" runat="server" Text="SALIR" OnClick="btnSalir_Click"/>
    <asp:Button CssClass="button" style="background-color: #4CAF50; position:relative; float: right; margin-right: 44px; margin-top: 10px; top: 0px; left: 0px;" ID="btnGenerar" runat="server" Text="EGRESAR" OnClick="btnGenerar_Click"/>
    </div>
</asp:Content>
