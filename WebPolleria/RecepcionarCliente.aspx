<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecepcionarCliente.aspx.cs" Inherits="WebPolleria.RecepcionarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/Recepcion.css" />
     <div Class="divGlobal">
    <div id="Reserva" runat="server" Class="divCabe1">
    <div>
         <h3 id="CabReserv" runat="server" Class="Fuente1" >Reservas Activas <asp:Button ID="Button1" runat="server" Class="button3" Text="🡙" OnClick="Button1_Click1" Width="21px"/> </h3>
        <div id="Busqueda" runat="server">
            <asp:Label ID="Label11" runat="server" Class="Fuente" Text="DNI"></asp:Label>
        <asp:TextBox ID="TxtNro" Class="Fuente" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscarRes" runat="server" Class="button" Text="Buscar Reserva" OnClick="BtnBuscarRes_Click"/>
        </div>
        <asp:Panel ID="Panel1" runat="server">
       <div id="DetalleReserva" runat="server" Class="divDet1">
           <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/CalendarioSim.png" Height="29px" Width="36px" />
           <asp:TextBox ID="TxtCalendario" runat="server" Class="Fuente" style="margin-left: 19px"></asp:TextBox>
           <br />
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/RelojSim.png" Height="29px" Width="36px"/>
           <asp:TextBox ID="TxtHoraRes" runat="server" Class="Fuente" style="margin-left: 19px"></asp:TextBox>
           <br />
           <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/MesasSim.png" Height="29px" Width="36px"/>
       <asp:TextBox ID="TxtMesa" runat="server" Class="Fuente" style="margin-left: 19px"></asp:TextBox>   
           <br />
           <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/IdentificacionSim.png" Height="29px" Width="36px" />
           <asp:TextBox ID="TxtDni" runat="server"  Class="Fuente" style="margin-left: 19px"></asp:TextBox>
       </div>
         </asp:Panel>
       </div>
         </div>
    <div id="Recepcion" runat="server" Class="divCabe1"> 
        <h3  id="CabRecepcion" runat="server" Class="Fuente1">Recepción <asp:Button ID="Button2" runat="server" Class="button3" Text="🡙" OnClick="Button2_Click" />
            </h3>
        <div  id="Div2" runat="server">
    <div  id="DetRecepcion" runat="server"  Class="divDet1">
         <asp:Label ID="Label7" runat="server" Class="Fuente" Text="Mesa:"></asp:Label>
        <asp:DropDownList ID="DropDownListMesas" runat="server" Class="Fuente" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="25px">
        </asp:DropDownList>
        <div>
        <asp:Label ID="Label8" runat="server" Class="Fuente" Text="Horario:"></asp:Label>
        <asp:TextBox ID="TxtHorario" runat="server" Class="Fuente"></asp:TextBox>        
        </div>
       </div>  
    </div>
        </div>
        <div Class="divCabe">
        <div id="Div3" runat="server" Class="divDet">
        <asp:Button ID="BtnDisponibilidad" runat="server" Class="button2" Text="Buscar Mesa Disponible"  OnClick="Button1_Click"/>
        <asp:Button ID="BtnAsignar" runat="server" Class="button" Text="Ocupar Mesa"  />
        <asp:Button ID="BtnSalir" runat="server" Class="button1" Text="Salir" OnClick="BtnSalir_Click"  />
    </div>
            </div>
         </div>
</asp:Content>
