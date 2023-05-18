<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneOrdenDelivery.aspx.cs" Inherits="WebPolleria.GeneOrdenDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" type="text/css" href="/estilos/GeneOrdenDelivery.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="General" class="General">
    <div id="Platillos" class="Column1">
    <div>
        <h4 Style=" text-align: center">
            NUESTROS PLATILLOS
        </h4>
    </div>
    <div id="Catalogo Productos" class="Platillos">
    <div class="Platillos1">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/14Pollo.png" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP1" runat="server" Text="1/4 POLLO"></asp:Label>
        <br />
    <asp:Label ID="Label2" runat="server" Text="1/4 de pollo + papas crujientes + ensalada + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn1" runat="server" Text="Comprar" OnClick="Btn1_Click" />
    <asp:Label ID="LbC1" runat="server" Text=" S/ 19.90"></asp:Label>
    </div>
    
    <div class="Platillos1">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/12Pollo.png" Height="80px" Width="150px" /> 
        <br />
    <asp:Label ID="LbP2" runat="server" Text="1/2 POLLO"></asp:Label>
        <br />
    <asp:Label ID="Label5" runat="server" Text="1/2 de pollo + papas crujientes + ensalada + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn2" runat="server" Text="Comprar" />
    <asp:Label ID="LbC2" runat="server" Text=" S/ 37.90"></asp:Label>
    </div>

    <div class="Platillos1">
    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/1Pollo.png" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP3" runat="server" Text="POLLO A LA BRASA"></asp:Label>
        <br />
    <asp:Label ID="Label8" runat="server" Text="pollo entero + papas crujientes + ensalada + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn3" runat="server" Text="Comprar" />
    <asp:Label ID="LbC3" runat="server" Text=" S/ 71.90"></asp:Label>
    <br />
    </div>
    
    <div class="Platillos1">
    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/mostrito.jpg" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP4" runat="server" Text="MOSTRITO BRASA"></asp:Label>
        <br />
    <asp:Label ID="Label13" runat="server" Text="1/8 de pollo + papas crujientes + arroz chaufa + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn4" runat="server" Text="Comprar" />
    <asp:Label ID="LbC4" runat="server" Text=" S/ 16.90"></asp:Label>
    <br />
    </div>

     <div class="Platillos1">
    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/mostro.jpg" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP5" runat="server" Text="MOSTRO BRASA"></asp:Label>
        <br />
    <asp:Label ID="Label16" runat="server" Text="1/4 de pollo + papas crujientes + arroz chaufa + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn5" runat="server" Text="Comprar" />
    <asp:Label ID="LbC5" runat="server" Text=" S/ 26.90"></asp:Label>
    <br />
    </div>

     <div class="Platillos1">
    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/parrilla.jpeg" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP6" runat="server" Text="PARRILLA PERSONAL"></asp:Label>
        <br />
    <asp:Label ID="Label19" runat="server" Text="1/8 de pollo + papas crujientes + 2 palos anticuchos + 1 porcion de mollejas + chorizo" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn6" runat="server" Text="Comprar" />
    <asp:Label ID="LbC6" runat="server" Text=" S/ 32.90"></asp:Label>
    <br />
    </div>

    </div>
     </div>
    <div id="Carrito" class="Column2">
    <h4 Style=" text-align: center">
            Mi carrito
    </h4>
    <asp:Label ID="MensajeVacio" runat="server" CssClass="TextoSuperior" Text="El carrito se encuentra vacio, echa un vistazo a nuestros productos."></asp:Label>
    <br />
    <asp:GridView HorizontalAlign="Center" ID="GvOrden" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                <asp:Label ID="LbProducto" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                    <asp:TextBox ID="txtCantGv" runat="server"  Width="38px" Enabled="false" Text=1></asp:TextBox>
                      <BR />
                    <asp:Button runat="server" ID="btnIncrementar" Text="↑" OnClick="btnIncrementar_Click" />
                    <asp:Button runat="server" ID="btnDisminuir" Text="↓" OnClick="btnDisminuir_Click" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/basura.png" Width="25px" Height="25px" CommandArgument='<%# Container.DataItemIndex %>' Text="x" OnClick="btnEliminar_Click"/>
                  </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <br />
    <div class="TextoInferior">
    <asp:Label ID="Label10" runat="server" Text="Costo de entrega "></asp:Label>
    <asp:Label ID="Label11" runat="server" Text="S/"></asp:Label>
    <asp:Label ID="CostoEntrega" runat="server" Text="0.00"></asp:Label>
    <br />
    <asp:Label ID="CostoTotal1" runat="server" Text="Total pedido"></asp:Label>
    <asp:Label ID="CostoTotal2" runat="server" Text="S/"></asp:Label>
    <asp:Label ID="CostoTotal3" runat="server" Text="0.00"></asp:Label>
    </div>
    </div>
    </div>
</asp:Content>