<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegReserva.aspx.cs" Inherits="WebPolleria.RegReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="DNI"></asp:Label>
        <asp:TextBox ID="TxtBDni" runat="server" style="margin-left: 15px" Width="102px"></asp:TextBox>
        <asp:Button ID="BtnDni" runat="server" Text="Buscar Cliente" OnClick="BtnDni_Click" />
    <asp:TextBox style="position:relative; float: right; margin-right: 50px" ID="TxtRecepcionista" runat="server" Width="118px"></asp:TextBox>
        <asp:Label style="position:relative; float: right;" ID="Label3" runat="server" Width="160px" Text="Recepcionista:"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Fecha de reserva"></asp:Label>
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="Date" Height="16px" Width="141px"></asp:TextBox>
        <asp:Button ID="BtnDispo" runat="server" Text="Buscar Disponibilidad" OnClick="BtnDispo_Click" />
        <br />
        <asp:Panel ID="PanelMesas" runat="server"  HorizontalAlign="Center" Height="290px" Width="335px" style="border: 1px solid black;">
         <h4>Datos de Reserva:</h4>
         <asp:Label ID="Label12" runat="server" Text="Horarios" Width="170px"></asp:Label>
         <asp:Label ID="Label11" runat="server" Text="Mesas" ></asp:Label>
         <br />
    <asp:DropDownList ID="DpDown1" runat="server" Height="16px" Width="140px" OnSelectedIndexChanged="DpDown1_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True">
    </asp:DropDownList>
        <asp:DropDownList ID="DpDown2" runat="server" Height="16px" style="margin-left: 32px" Width="129px" OnSelectedIndexChanged="DpDown2_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
        <br />
         <asp:Image ID="ImagenMesa" runat="server" Height="179px" Width="282px" style="margin-left: 14px" />
    </asp:Panel>
        <br />
        <asp:Panel ID="PanelClientes" runat="server"  HorizontalAlign="Center" Width="349px"  style="border: 1px solid black;" Height="233px">
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
    </asp:Panel>
        
        <asp:Button ID="RegCliente" runat="server" style="margin-left: 36px" Text="Registrar Cliente" Width="125px" OnClick="RegCliente_Click" />
        <br />
        <br />
        <asp:Button ID="BtnSalir" runat="server" Text="Salir" />
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" style="margin-left: 177px" Width="122px" OnClick="BtnRegistrar_Click" Height="26px" />
        <br />
        <br />
</asp:Content>
