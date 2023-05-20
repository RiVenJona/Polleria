<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneOrdenDelivery.aspx.cs" Inherits="WebPolleria.GeneOrdenDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/estilos/GenOrdenDelivery.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="General">
    <div id="General1" runat="server" class="General">
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
    <asp:Button ID="Btn1" runat="server" Text="Comprar" OnClick="Btn1_Click"  />
    <asp:Label ID="LbC1" runat="server" Text=" S/ 19.90"></asp:Label>
    </div>
    
    <div class="Platillos1">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/12Pollo.png" Height="80px" Width="150px" /> 
        <br />
    <asp:Label ID="LbP2" runat="server" Text="1/2 POLLO"></asp:Label>
        <br />
    <asp:Label ID="Label5" runat="server" Text="1/2 de pollo + papas crujientes + ensalada + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn2" runat="server" Text="Comprar" OnClick="Btn2_Click" />
    <asp:Label ID="LbC2" runat="server" Text=" S/ 37.90"></asp:Label>
    </div>

    <div class="Platillos1">
    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/1Pollo.png" Height="80px" Width="150px" />
        <br />
    <asp:Label ID="LbP3" runat="server" Text="POLLO A LA BRASA"></asp:Label>
        <br />
    <asp:Label ID="Label8" runat="server" Text="pollo entero + papas crujientes + ensalada + cremas" Width="150px"></asp:Label>
        <br />
    <asp:Button ID="Btn3" runat="server" Text="Comprar" OnClick="Btn3_Click" />
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
    <asp:Button ID="Btn4" runat="server" Text="Comprar" OnClick="Btn4_Click" />
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
    <asp:Button ID="Btn5" runat="server" Text="Comprar" OnClick="Btn5_Click" />
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
    <asp:Button ID="Btn6" runat="server" Text="Comprar" OnClick="Btn6_Click" />
    <asp:Label ID="LbC6" runat="server" Text=" S/ 32.90"></asp:Label>
    <br />
    </div>

    </div>
     </div>
    <div id="Carrito" class="Column2">
    <h4 Style=" text-align: center">
            Mi carrito
    </h4>
    <asp:Label ID="MensajeVacio" runat="server" Style=" text-align: center" CssClass="TextoSuperior" Text="El carrito se encuentra vacio, echa un vistazo a nuestros productos."></asp:Label>
    <br />
    <br />
    <br />
    <div id="Compras">
        <div id="Div1" runat="server">
        <asp:Label ID="LBD1" runat="server" Text="1/4 POLLO"></asp:Label>
        <asp:TextBox ID="Cant1" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="🢁" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="🢃" OnClick="Button2_Click" />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton1_Click" />
        <br />
        <asp:Label ID="Label21" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo1" runat="server" Text="19.90"></asp:Label>
        </div>
        <br />
        <div id="Div2" runat="server">
        <asp:Label ID="Label3" runat="server" Text="1/2 POLLO"></asp:Label>
        <asp:TextBox ID="Cant2" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="🢁" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="🢃" OnClick="Button4_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton2_Click" />
        <br />
        <asp:Label ID="Label20" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo2" runat="server" Text="37.90"></asp:Label>
</div> 
        <br />
        <div id="Div3" runat="server">
        <asp:Label ID="Label7" runat="server" Text="POLLO A LA BRASA"></asp:Label>
        <asp:TextBox ID="Cant3" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="🢁" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="🢃" OnClick="Button6_Click" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton3_Click" />
        <br />
        <asp:Label ID="Label18" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo3" runat="server" Text="71.90"></asp:Label>
       </div> 
       <br />
       <div id="Div4" runat="server">  
        <asp:Label ID="Label14" runat="server" Text="MOSTRITO BRASA"></asp:Label>
        <asp:TextBox ID="Cant4" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button7" runat="server" Text="🢁" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="🢃" OnClick="Button8_Click" />
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton4_Click" />
        <br />
        <asp:Label ID="Label17" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo4" runat="server" Text="16.90"></asp:Label>
</div> 
        <br />
        <div id="Div5" runat="server"> 
        <asp:Label ID="Label23" runat="server" Text="MOSTRO BRASA"></asp:Label>
        <asp:TextBox ID="Cant5" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button9" runat="server" Text="🢁" OnClick="Button9_Click" />
        <asp:Button ID="Button10" runat="server" Text="🢃" OnClick="Button10_Click" />
        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton5_Click" />
       <br />
        <asp:Label ID="Label24" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo5" runat="server" Text="26.90"></asp:Label>
        </div> 
         <br />
        <div id="Div6" runat="server"> 
        <asp:Label ID="Label27" runat="server" Text="PARRILLA PERSONAL"></asp:Label>
        <asp:TextBox ID="Cant6" runat="server" Height="20px" Width="15px">0</asp:TextBox>
        <asp:Button ID="Button11" runat="server" Text="🢁" OnClick="Button11_Click" />
        <asp:Button ID="Button12" runat="server" Text="🢃" OnClick="Button12_Click" />
        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Imagenes/basura.png" Height="20px" Width="20px" OnClick="ImageButton6_Click" />
        <br />
        <asp:Label ID="Label28" runat="server" Text="S/ "></asp:Label>
        <asp:Label ID="LbCo6" runat="server" Text="32.90"></asp:Label>
    </div> 
</div> 
    <br />
   <br />
    <br />
    <div class="TextoInferior">
    <asp:Label ID="Label10" runat="server" Text="Costo de entrega "></asp:Label>
    <asp:Label ID="Label11" runat="server" Text="S/"></asp:Label>
    <asp:Label ID="CostoEntrega" runat="server" Text="0.00"></asp:Label>
    <br />
    <asp:Label ID="CostoTotal1" runat="server" Text="Total pedido"></asp:Label>
    <asp:Label ID="CostoTotal2" runat="server" Text="S/"></asp:Label>
    <asp:Label ID="CostoTotal3" runat="server" Text="0.00"></asp:Label>
        <br />
        <asp:Button ID="Button13" runat="server" Text="Realizar Compra" OnClick="Button13_Click" />
    </div>
    </div>
    </div>
    


    <div id="General2" runat="server" class="General1">
    <div>
        <br />
 <br />
        <asp:Button ID="Button14" runat="server" Text="🔙 Regresar" OnClick="Button14_Click" />
    <h3 Style=" text-align: center"  class="Header">
            FINALIZAR PEDIDO
     </h3>
    </div>
    <div id="Datos" style="width: 460px" class="Datos">
    <h5 Style=" text-align: center">
            ¿A quien le entregamos el pedido?
     </h5>
        <br />
        <div class="Datos1">
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Celular"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
</div>
    </div>
    <br />
    <br />
    <div id="Referencia" style="width: 460px" class="Datos">
    <h5 Style=" text-align: center">
            ¿Donde debemos entregarlo?
     </h5>
        <br />
        <div class="Datos1">
        <asp:Label ID="Label9" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 12px"></asp:TextBox>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Referencia"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
            </div>
    </div>
    <br />
    <br />
    <div id="Comprobante" style="width: 460px" class="Datos">
    <h5 Style=" text-align: center">
            Tipo de comprobante
     </h5>
        <br />
        <div class="Datos1">
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Boleta Electronica" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
        <asp:Label ID="Label25" runat="server" Width="50px"></asp:Label>
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Factura Electronica" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
        <br />
        <asp:Label ID="Label15" runat="server" Text="DNI O RUC"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox6" runat="server" Width="201px" style="margin-left: 58px"></asp:TextBox>
        <br />
        <asp:Label ID="Label22" runat="server" Text="Nombre y Apellidos o Razon Social"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox7" runat="server" Height="16px" Width="198px" style="margin-left: 57px"></asp:TextBox>
        <br />
            </div>
    </div>
    <div id="Monto1" style="width: 460px" class="Datos">
    <h5 Style=" text-align: center">
            ¿Como te gustaria pagar?
     </h5>
        <br />
        <div class="Datos1">
        <asp:RadioButton ID="RadioButton3" runat="server" Text="Boleta Electronica" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged"  />
        <asp:Label ID="Label26" runat="server" Width="150px"></asp:Label>    
        <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/Dinero.png" Height="28px" Width="48px" />
        <br />
            <asp:Label ID="Label29" runat="server" Text="Monto con el que va a pagar"></asp:Label>
            <asp:Label ID="Label30" runat="server" Width="25px"></asp:Label>
            <asp:Label ID="Label31" runat="server" Text="S/"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" Height="20px" Width="39px"></asp:TextBox>
        </div>
        <div class="Datos1">
        <asp:RadioButton ID="RadioButton4" runat="server" Text="Pago en Linea" AutoPostBack="True" OnCheckedChanged="RadioButton4_CheckedChanged"  />
        <asp:Label ID="Label32" runat="server" Width="150px"></asp:Label>    
        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/visa.png" Height="47px" Width="81px" />
        </div>
    </div>
    <div class="Datos1">
        <asp:Button ID="Button15" runat="server" Text="Realizar Pedido" style="margin-left: 59px" OnClick="Button15_Click" />
    </div>
    </div>
        <div id="General3" runat="server" class="General1">
        <h3 Style=" text-align: center" class="Header">
            Pago con tarjeta de credito o debito
        </h3>
            <div class="Datos">
            <br />
                <asp:Label ID="Label33" runat="server" Text="Numero de pedido:     "></asp:Label>
                <asp:Label ID="Label34" runat="server" Text="1485"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label35" runat="server" Text="Total a Pagar:        "></asp:Label>
                <asp:Label ID="Label36" runat="server" Text="S/"></asp:Label>
                <asp:Label ID="LbTotal" runat="server" Text="0.00"></asp:Label>
                <br />
            </div>
            <br />
            <br />
            <div class="Datos">
                <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/visa.png" Height="55px" Width="93px" style="margin-left: 166px"/>
                <br />
                <asp:TextBox ID="TextBox9" runat="server" style="margin-left: 115px" Width="163px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox10" runat="server" Height="19px" style="margin-left: 117px" Width="162px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox11" runat="server" Height="22px" style="margin-left: 116px" Width="163px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button16" runat="server" Text="Pagar" style="margin-left: 159px" Width="69px" />
            </div>
            <br />
                <br />
        </div>
            </div>
</asp:Content>