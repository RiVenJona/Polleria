<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegReserva.aspx.cs" Inherits="WebPolleria.RegReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/RegisReserva.css" />
<div class="divp">
    <div class="div1">
    <div class="div2">
        <div>
    <asp:Label ID="Label2" runat="server" Text="DNI"></asp:Label>
        <asp:TextBox ID="TxtBDni" runat="server" style="margin-left: 15px" Width="102px"></asp:TextBox>
             </div>
         <div>
            <asp:Button CssClass="btnes" ID="BtnDni" runat="server" Text="Buscar Cliente" OnClick="BtnDni_Click" />
        </div>
</div>
    <div class="div1">
    <div class="div2">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Fecha de reserva"></asp:Label>
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="Date" Height="16px" Width="141px" CssClass="inputs"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Recepcionista:"></asp:Label>
            <asp:TextBox CssClass="inputs" ID="TxtRecepcionista" runat="server" Width="118px"></asp:TextBox>
        
             </div>
        <asp:Button CssClass="btnes" ID="BtnDispo" runat="server" Text="Buscar Disponibilidad" OnClick="BtnDispo_Click" />
        </div> 
        </div>
        </div>
    <div class="div1">
        <div  id="RegMesas" runat="server" class="div3" >
         <h4>Datos de Reserva:</h4>
         <asp:Label ID="Label12" runat="server" Text="Horarios" Width="170px"></asp:Label>
         <asp:Label ID="Label11" runat="server" Text="Mesas" ></asp:Label>
         <br />
         <asp:DropDownList ID="DpDown1" runat="server" Height="24px" Width="140px" OnSelectedIndexChanged="DpDown1_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True" style="margin-left: 7px">
         </asp:DropDownList>
         <asp:DropDownList  ID="DpDown2" runat="server" Height="24px" style="margin-left: 32px" Width="129px" OnSelectedIndexChanged="DpDown2_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList>
         <br />
          <br />
         <asp:Image ID="ImagenMesa" runat="server" Height="179px" Width="282px" style="margin-left: 14px" />
        </div>
        <br />
        
        <div  id="Clientes" runat="server" class="div3">
        <h4>Datos de clientes:</h4>
        <asp:Label ID="Label5" runat="server" Text="Nombre:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Apellidos:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Dni:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtDni" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Telefono:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Correo:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Direccion:" Height="16px" Width="140px"></asp:Label>
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
        </div>
             
        </div>  
        <div class="div2"> 
        <asp:Button  CssClass="btnes" ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click"/>
        <asp:Button  CssClass="btnes" ID="RegCliente" runat="server" style="margin-left: 10px" Text="Registrar Cliente" Width="125px" OnClick="RegCliente_Click" />
        <asp:Button CssClass="btnes" ID="BtnSalir" runat="server" Text="Salir" />
            </div> 
          </div>    
          <br />
        <br />
</asp:Content>