<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrdenPedido.aspx.cs" Inherits="WebPolleria.OrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link rel="stylesheet" type="text/css" href="/estilos/ordenPedido.css" />
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

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
                <input runat="server" id="nombreMozo" name="nombreMozo" type="text">
            </div>
            <div class="inputItem">
                <p>Fecha Pedido</p>
                <input type="date">
            </div>
        </div>
    </section>
    <section class="containerBusqueda">
        <fieldset class="BusquedaCliente">
            <legend>Busqueda</legend>
            <div class="busqueda">
                <p>Mesa Asignada:</p>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
            </div>
        </fieldset>
    </section>
    <section class="TipoPedidoBox">
        <fieldset class="TipodePedido">
            <legend>Detalle Cliente de Pedido</legend>
            <div class="DetallesInputs">
                <p>Nombre:</p>
                <input disabled runat="server" id="nombreCliente" name="nombreCliente" type="text">
            </div>
        </fieldset>
    </section>
    <section>
        <fieldset class="ListaTickets">
            <div class="ListaTickets2">
                <div  id="TicketsUsuario" runat="server"></div>
            </div>
           <script>
               $(function () {
                   $(".accordion").click(function () {
                       var panel = $(this).next(".panel");
                       panel.slideToggle("fast");
                       $(".panel").not(panel).slideUp("fast"); // Cierra los paneles que no se estén abriendo
                   });

                   $("#TicketsUsuario").accordion({
                       collapsible: true,
                       active: false
                   });
               });
           </script>
                <style>
        
    </style>
            <legend>Pedidos</legend>
            
            <div>
                <fieldset style="margin-bottom:10px; border-radius:15px;">
                <legend>Nuevo Ticket a Generar</legend>
                    <div class="CosaBuscador">
                        <div class="CosaBuscadorHijo">
                            <p>Descripcion del Producto</p>
                            <input  type="text" name="txtBuscarProducto" id="txtBuscarProducto">
                            <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
                        </div>
                    </div>
                <asp:GridView ItemStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="3" CssClass="gridView" HorizontalAlign="Center" ID="gvCatalogo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GvDatos_SelectedIndexChanged" ForeColor="Black" GridLines="Vertical" Height="218px" Width="700px" OnPageIndexChanging="gvCatalogo_PageIndexChanging">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>

                <asp:BoundField  DataField="idProducto" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField  DataField="desProducto" HeaderText="PRODUCTO" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField  DataField="PrecioProducto" HeaderText="PRECIO" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="IMAGEN">
            <ItemTemplate >
                <asp:Image ItemStyle-HorizontalAlign="Center" ID="Image1" runat="server" ImageUrl='<%# Eval("idProducto", "~/Imagenes/{0}.jpg") %>' 
                    Width="100" Height="100" />
            </ItemTemplate>
        </asp:TemplateField>
                <asp:CommandField HeaderText="SELECCIÓN" SelectText="AGREGAR" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"/>           
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                    <div class="AgregarCosas">
                    
                    <div style="display:flex; align-items:center; justify-content:center;">
                        <fieldset>
                        <legend>Carrito Del Nuevo Ticket</legend>
                        <asp:GridView  ItemStyle-HorizontalAlign="Center" ID="gvPedido" EmptyDataText="Carrito vacio" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="16px" Width="700px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idProducto" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCION" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                    <asp:TextBox ItemStyle-HorizontalAlign="Center" ID="txtCantGv" runat="server"  Width="38px" Enabled="false" Text=1></asp:TextBox>
                                      <BR />
                                    <asp:Button runat="server" ID="btnIncrementar" Text="+" OnClick="btnIncrementar_Click" />
                                    <asp:Button runat="server" ID="btnDisminuir" Text="-" OnClick="btnDisminuir_Click" />
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrecioProducto" HeaderText="PRECIO" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="QUITAR" ItemStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Button  runat="server" ID="btnEliminar" Width="25px" Height="25px" CommandArgument='<%# Container.DataItemIndex %>' Text="x" OnClick="btnEliminar_Click"/>
                                  </ItemTemplate>
                                </asp:TemplateField>
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
                        </fieldset>
                    </div>
                </div>
                    <div class="monto">
                    <div class="casillas">
                        <p>Total del Nuevo Ticket</p>
                        <input disabled runat="server" name="txtTotal" id="txtTotal" type="text">
                    </div>
                        <asp:Button ID="Button4" runat="server" Text="Generar" OnClick="Button3_Click" />
                </div>
                </fieldset>
            </div>
                <div class="monto">
                    <div class="casillas">
                        <p>Total Orden de Pedido</p>
                        <input disabled runat="server" name="txtTotalOP" id="txtTotalOP" type="text">
                    </div>
                </div>
        </fieldset>
    </section>
    <section class="BotonesFinales">
        <button class="generalBtn">Regresar</button>
        <asp:Button ID="Button3" runat="server" Text="Generar" OnClick="Button3_Click" />
    </section>
        </div>
</asp:Content>
