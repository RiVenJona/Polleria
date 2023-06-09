﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CobrarOrdenPedido.aspx.cs" Inherits="WebPolleria.WebForm2" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/CobrarOrdenPedido.css" />
    <div class="page-container">
        <div class="tabs-container">
            <div class="tab-buttons">
                <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab1" Text="COBRAR PEDIDO" OnClick="BtnTab_Click" CommandArgument="0" />
                <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab2" Text="ESTADO DE PEDIDO" OnClick="BtnTab_Click" CommandArgument="1" />
            </div>
            <asp:MultiView runat="server" ID="MultiViewTabs">
                <asp:View runat="server" ID="ViewTab1">
                    <asp:Panel runat="server" CssClass="panelTipo" HorizontalAlign="Center">
                        <asp:RadioButtonList CssClass="rbllabel2" ID="RblTipoServ" runat="server" RepeatDirection="Horizontal" CellPadding="20" AutoPostBack="true" OnSelectedIndexChanged="RblTipoServ_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text=" SERVICIO PRESENCIAL" Value="1"></asp:ListItem>
                            <asp:ListItem Text=" SERVICIO DELIVERY" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell Width="40%" Style="vertical-align: top;">
                                <h3 id="h3pedido" runat="server">BUSCAR ORDEN DE PEDIDO:</h3>
                                <h3 id="h3delivery" visible="false" runat="server">BUSCAR ORDEN DE DELIVERY:</h3>
                                <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                                    <asp:Label CssClass="label" ID="Label4" runat="server" Text="Código de Orden:"></asp:Label>
                                    <asp:TextBox Style="margin-left: 20px;" Width="100px" ID="txtBuscar" runat="server"></asp:TextBox>
                                    <asp:Button CssClass="button" Style="background-color: #4CAF50; margin-left: 30px;" ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click"/>
                                </asp:Panel>

                                <h3>DATOS DEL CLIENTE:</h3>
                                <asp:Panel ID="Panel3" runat="server" CssClass="panel">
                                    <asp:Label CssClass="label" ID="Label7" runat="server" Text="DNI / RUC:"></asp:Label>
                                    <asp:TextBox Style="margin-left: 10px;" ID="txtDNI" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label CssClass="labelDC" ID="Label5" runat="server" Text="Nombres:"></asp:Label>
                                    <asp:TextBox ID="txtNombres" runat="server" Width="400px" Enabled="False"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label CssClass="labelDC" ID="Label6" runat="server" Text="Apellidos:"></asp:Label>
                                    <asp:TextBox ID="txtApellidos" runat="server" Width="400px" Enabled="False"></asp:TextBox>
                                </asp:Panel>
                            </asp:TableCell>
                            <asp:TableCell Width="60%" Style="vertical-align: top;">
                                <h3>DETALLE PEDIDO:</h3>
                                <asp:Panel ID="Panel2" runat="server" CssClass="panelExterior">
                                    <asp:Label CssClass="label" ID="Label1" runat="server" Text="N° Orden:"></asp:Label>
                                    <asp:TextBox Style="margin-left: 20px;" ID="txtNroOrden" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:TextBox Style="position: relative; float: right; margin-right: 0px; margin-left: 20px;" ID="txtTipoServ" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label2" runat="server" Text="Tipo de Servicio:"></asp:Label>
                                    <asp:Panel ID="Panel5" runat="server" CssClass="panelInterior">
                                        <asp:GridView ID="GvDetalle" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                            <Columns>
                                                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCIÓN" />
                                                <asp:BoundField DataField="cantidadProducto" HeaderText="CANTIDAD" />
                                                <asp:BoundField DataField="PrecioProducto" HeaderText="PRECIO UNIT." />
                                                <asp:BoundField DataField="total" HeaderText="TOTAL" />
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
                                        <asp:GridView ID="GvDetalleDelivery" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                            <Columns>
                                                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCIÓN" />
                                                <asp:BoundField DataField="cantidadProducto" HeaderText="CANTIDAD" />
                                                <asp:BoundField DataField="PrecioProducto" HeaderText="PRECIO UNIT." />
                                                <asp:BoundField DataField="total" HeaderText="TOTAL" />
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
                                    <div style="margin-top: 305px">
                                        <asp:Label CssClass="label" ID="Label21" runat="server" Text="Dir. Entrega:"></asp:Label>
                                        <asp:TextBox Style="margin-left: 20px;" ID="txtDireccion" Width="300px" runat="server" Enabled="False"></asp:TextBox>
                                        <asp:TextBox Style="position: relative; float: right; margin-right: 0px; margin-left: 20px;" ID="txtMonto" runat="server" Enabled="False"></asp:TextBox>
                                        <asp:Label Style="position: relative; float: right;" CssClass="label" ID="Label3" runat="server" Text="Monto S/:"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <h3>COMPROBANTE DE PAGO:</h3>
                    <asp:Panel ID="Panel4" runat="server" CssClass="panel" Height="240px">
                        <asp:Table runat="server" TableLayout="Fixed">
                            <asp:TableRow>
                                <asp:TableCell Width="600px" Style="vertical-align: top;">
                                    <asp:Label CssClass="label" ID="Label8" runat="server" Text="N° CDP:"></asp:Label>
                                    <asp:TextBox Style="margin-left: 10px;" ID="txtNroCDP" Width="100px" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:Label CssClass="label" Style="margin-left: 150px;" ID="Label9" runat="server" Text="Fecha:"></asp:Label>
                                    <asp:TextBox Style="margin-left: 10px;" ID="txtFecha" Width="100px" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label CssClass="label" ID="Label10" runat="server" Text="Método de Pago:"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:RadioButtonList CssClass="rbllabel" ID="RblMetodoPago" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="RblMetodoPago_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                    <br />
                                    <asp:Label CssClass="label" ID="Label11" runat="server" Text="Tipo CDP:"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:RadioButtonList CssClass="rbllabel" ID="RblCDP" runat="server" Width="300px">
                                    </asp:RadioButtonList>
                                </asp:TableCell>
                                <asp:TableCell Style="vertical-align: top;">
                                    <asp:Panel ID="pMetodoPago" runat="server" CssClass="panel" Width="400px" Height="166px">
                                        <asp:Label CssClass="label" ID="label12" runat="server" Text="Forma de pago:"></asp:Label>
                                        <asp:DropDownList CssClass="ddl" ID="ddlFormaPago" runat="server">
                                            <asp:ListItem Text="SELECCIONAR" Value="0" />
                                            <asp:ListItem Text="VISA" Value="1" />
                                            <asp:ListItem Text="MASTERCARD" Value="2" />
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Label CssClass="label" ID="Label13" runat="server" Text="Nro. Tarjeta:"></asp:Label>
                                        <asp:TextBox CssClass="txtbox2" ID="txtNroTarjeta" runat="server" TextMode="Number" onKeyDown="if(this.value.length==16 && event.keyCode!=8) return false;"></asp:TextBox>
                                        <br />
                                        <br />
                                        <asp:Label CssClass="label" ID="Label14" runat="server" Text="Fecha de Caducidad:"></asp:Label>
                                        <asp:DropDownList CssClass="ddl" ID="ddlMes" runat="server">
                                            <asp:ListItem Text="--" Value="0" />
                                        </asp:DropDownList>
                                        <asp:DropDownList CssClass="ddl" ID="ddlAno" runat="server">
                                            <asp:ListItem Text="----" Value="0" />
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Label CssClass="label" ID="Label15" runat="server" Text="Código de Seguridad:"></asp:Label>
                                        <asp:TextBox CssClass="txtbox2" Width="50px" Text="XXX" ID="txtCodSeg" TextMode="Number" runat="server"
                                            onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;"></asp:TextBox>
                                    </asp:Panel>
                                    <!--RBL METODOPAGO SEPARADOR-->
                                    <asp:Panel ID="pEfectivo" runat="server" CssClass="panel" Width="400px" Visible="false">
                                        <asp:Table runat="server" TableLayout="Fixed" CellPadding="0" Style="margin: 0px; padding: 0px;">
                                            <asp:TableRow>
                                                <asp:TableCell Width="180px" Style="vertical-align: top;">
                                                    <asp:Label CssClass="label" ID="label16" runat="server" Text="Pago          S/:"></asp:Label>
                                                    <asp:TextBox CssClass="txtbox3" ID="txtPago" runat="server" TextMode="Number" onKeyDown="if(this.value.length==9 && event.keyCode!=8) return false;"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:Button CssClass="button" Style="background-color: #4CAF50; margin-left: 30px;" ID="btnVer" runat="server" Text="VER" OnClick="btnVer_Click"/>
                                
                                                </asp:TableCell>
                                                <asp:TableCell Style="vertical-align: top;">
                                                    <asp:Label CssClass="label" ID="Label17" runat="server" Text="Op. Gravada   S/:"></asp:Label>
                                                    <asp:TextBox CssClass="txtbox3" ID="txtOpGrav" runat="server" Enabled="False" TextMode="Number" onKeyDown="if(this.value.length==9 && event.keyCode!=8) return false;"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="label" ID="Label18" runat="server" Text="I.G.V.        S/:"></asp:Label>
                                                    <asp:TextBox CssClass="txtbox3" Style="margin-left: 64px;" Enabled="False" ID="txtIGV" runat="server" TextMode="Number" onKeyDown="if(this.value.length==9 && event.keyCode!=8) return false;"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="label" ID="Label19" runat="server" Text="Importe       S/:"></asp:Label>
                                                    <asp:TextBox CssClass="txtbox3" Enabled="False" Style="margin-left: 42px;" Width="70px" ID="txtImporte" TextMode="Number" runat="server"
                                                        onKeyDown="if(this.value.length==9 && event.keyCode!=8) return false;"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="label" ID="Label20" runat="server" Text="Vuelto        S/:"></asp:Label>
                                                    <asp:TextBox CssClass="txtbox3" Enabled="False" ID="txtVuelto" Style="margin-left: 54px;" TextMode="Number" runat="server"
                                                        onKeyDown="if(this.value.length==9 && event.keyCode!=8) return false;"></asp:TextBox>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:Panel>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </asp:Panel>
                    <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 100px" ID="Button3" runat="server" OnClick="Button3_Click" Text="SALIR" />
                    <asp:Button CssClass="button" Style="background-color: #4CAF50; position: relative; float: right; margin-right: 100px" ID="btnEmitir" runat="server" OnClick="btnEmitir_Click" Text="EMITIR" />
                </asp:View>

                <!--segunda tab-->
                <asp:View runat="server" ID="ViewTab2" >
                        <h3>VER ESTADO DE PEDIDOS:</h3>
                        <asp:Panel ID="Panel6" runat="server" CssClass="panelExterior2">
                            <asp:Label CssClass="label" ID="Label22" runat="server" Text="Filtrar Orden:"></asp:Label>
                            <asp:TextBox Style="margin-left: 20px;" ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Button CssClass="button" Style="background-color: #4CAF50; margin-left: 30px;" ID="Button1" runat="server" Text="BUSCAR" />
                            <asp:Panel ID="Panel7" runat="server" CssClass="panelInterior" Width="1100px">
                                <asp:GridView ID="GvEstadoPedido" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay datos disponibles" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                    <Columns>
                                        <asp:BoundField DataField="NumOrdenPedido" HeaderText="IDPEDIDO" />
                                        <asp:BoundField DataField="cliente" HeaderText="NOMBRE" />
                                        <asp:BoundField DataField="clienteDNI" HeaderText="DNI" />
                                        <asp:BoundField DataField="totalOP" HeaderText="TOTAL S/" />
                                        <asp:BoundField DataField="dia" HeaderText="FECHA" />
                                        <asp:BoundField DataField="hora" HeaderText="HORA" />
                                        <asp:BoundField DataField="estado" HeaderText="ESTADO" />
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
                            <div style="margin-top:300px;">
                                <asp:Button CssClass="button" Style="background-color: #FF0000; position: absolute; float: left; margin-left: 100px" ID="Button5" runat="server" OnClick="Button3_Click" Text="SALIR" />
                                </div>
                        </asp:Panel>
                </asp:View>
            </asp:MultiView>
                </div>
        <br />
        <br />
        <br />


    </div>
</asp:Content>
