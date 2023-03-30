<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegReserva.aspx.cs" Inherits="WebPolleria.RegReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="DNI"></asp:Label>
        <asp:TextBox ID="TxtBDni" runat="server" style="margin-left: 15px" Width="102px"></asp:TextBox>
        <asp:Button ID="BtnDni" runat="server" Text="Buscar Cliente" OnClick="BtnDni_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Fecha de reserva"></asp:Label>
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="Date" Height="16px" Width="141px"></asp:TextBox>
        <asp:Button ID="BtnDispo" runat="server" Text="Buscar Disponibilidad" OnClick="BtnDispo_Click" />
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Horarios" Width="170px"></asp:Label>
         <asp:Label ID="Label11" runat="server" Text="Mesas" ></asp:Label>
         <br />
    <asp:DropDownList ID="DpDown1" runat="server" Height="16px" Width="140px" OnSelectedIndexChanged="DpDown1_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True">
    </asp:DropDownList>
        <asp:DropDownList ID="DpDown2" runat="server" Height="16px" style="margin-left: 32px" Width="129px" OnSelectedIndexChanged="DpDown2_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
        <br />
        <asp:Image ID="ImagenMesa" runat="server" Height="179px" Width="282px" style="margin-left: 14px" />
        <br />
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
        <asp:Button ID="RegCliente" runat="server" style="margin-left: 36px" Text="Registrar Cliente" Width="125px" OnClick="RegCliente_Click" />
        <br />
        <br />
        <asp:Button ID="BtnSalir" runat="server" Text="Salir" />
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" style="margin-left: 177px" Width="122px" OnClick="BtnRegistrar_Click" />
        <br />
        <br />
</asp:Content>
