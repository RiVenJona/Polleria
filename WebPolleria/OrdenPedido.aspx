<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrdenPedido.aspx.cs" Inherits="WebPolleria.OrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link rel="stylesheet" type="text/css" href="/estilos/ordenPedido.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="BgContainer">
    <section>
        <div class="tituloCus">
            <h3>Orden de Pedido</h3>
        </div>
    </section>
    <section>
        <div class="ResponsablePedido">
            <div class="inputItem">
                <p>Responsable de O. Pedido</p>
                <input type="text">
            </div>
            <div class="inputItem">
                <p>Codigo O.Pedido</p>
                <input type="text">
            </div>
        </div>
    </section>
    <section class="containerBusqueda">
        <fieldset class="BusquedaCliente">
            <legend>Busqueda</legend>
            <div class="busqueda">
                <p>Mesa Asignada:</p>
                <input type="text">
                <button>Buscar</button>
            </div>
        </fieldset>
    </section>
    <section>
        <div class="DetallesInputsPedido">
            <p>Codigo O.Pedido:</p>
            <input type="text">
        </div>
    </section>
    <section class="TipoPedidoBox">
        <fieldset class="TipodePedido">
            <legend>Detalle Cliente de Pedido</legend>
            <div class="DetallesInputs">
                <p>Nombre:</p>
                <input type="text">
            </div>
        </fieldset>
    </section>
    <!-- <section class="BoxDetalle">
        <fieldset class="DetalleOrden">
            <legend>Datos del Cliente</legend>
            <div class="DatosPersonales">
                <div class="DetallesInputs">
                    <p>Nombre:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Apellido:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>DNI:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Nro.Telefono:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Fecha:</p>
                    <input type="date">
                </div>
            </div>
            <div class="espacioxd"></div>
            <div class="DatosEnvio">
                <div class="DetallesInputs">
                    <p>Direccion:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Referencia:</p>
                    <input type="text">
                </div>
            </div>
        </fieldset>
    </section> -->
    <section>
        <fieldset class="ListaTickets">
            <legend>Pedidos</legend>
            <div>
                <asp:GridView CssClass="gridView" HorizontalAlign="Center" ID="gvCatalogo" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GvDatos_SelectedIndexChanged">
            <Columns>

                <asp:BoundField  DataField="idProducto" HeaderText="ID" />
                <asp:BoundField  DataField="desProducto" HeaderText="PRODUCTO" />
                <asp:BoundField  DataField="PrecioProducto" HeaderText="PRECIO" />
                <asp:CommandField HeaderText="SELECCIÓN" SelectText="X" ShowSelectButton="True"/>           
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
                <div class="AgregarCosas">
                    <div class="CosaBuscador">
                        <div class="CosaBuscadorHijo">
                            <p>Descripcion del Producto</p>
                            <input type="text">
                            <button>Buscar</button>
                        </div>
                    </div>
                    <div style="display:flex; align-items:center; justify-content:center;">
                        <asp:GridView ID="gvPedido" EmptyDataText="vacio" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idProducto" HeaderText="CODIGO"/>
                                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCION"/>
                                <asp:TemplateField HeaderText="CANTIDAD">
                                  <ItemTemplate>
                                    <asp:TextBox ID="txtCantGv" runat="server"  Width="38px" Enabled="false" Text=1></asp:TextBox>
                                      <BR />
                                    <asp:Button runat="server" ID="btnIncrementar" Text="+" OnClick="btnIncrementar_Click" />
                                    <asp:Button runat="server" ID="btnDisminuir" Text="-" OnClick="btnDisminuir_Click" />
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrecioProducto" HeaderText="PRECIO"/>
                                <asp:ButtonField Text="X" />
                            </Columns>
                            <EmptyDataRowStyle BorderStyle="Dotted" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="monto">
                    <div class="casillas">
                        <p>Monto Total</p>
                        <input type="text">
                    </div>
                </div>
        </fieldset>
    </section>
    <section class="BotonesFinales">
        <button class="generalBtn">Regresar</button>
        <button class="generalBtn">Generar</button>
    </section>
        </div>
</asp:Content>
