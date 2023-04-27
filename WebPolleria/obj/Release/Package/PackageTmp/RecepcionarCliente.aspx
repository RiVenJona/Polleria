<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecepcionarCliente.aspx.cs" Inherits="WebPolleria.RecepcionarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10px">
        <h3>RESERVAS:</h3>
        <asp:Label ID="Label11" runat="server" Text="N. O. Reserva:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtNro" runat="server" Width="152px"></asp:TextBox>
        <asp:Button ID="BtnBuscarRes" runat="server" Text="Buscar Reserva" Style="margin-left: 48px" Width="110px" OnClick="BtnBuscarRes_Click"/>
    </div>
    <div style="margin-top: 10px">
        <h3>RECEPCIÓN:</h3>
        <asp:Label ID="Label1" runat="server" Text="DNI:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtDNI" runat="server" Width="496px"></asp:TextBox>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label9" runat="server" Text="Nombres:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" Width="496px"></asp:TextBox>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label10" runat="server" Text="Apellidos:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server" Width="496px"></asp:TextBox>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label2" runat="server" Text="Hora Reserva:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtHoraRes" runat="server" Width="152px" Style="margin-right: 48px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Telefono:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtTel" runat="server" Width="152px"></asp:TextBox>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label4" runat="server" Text="Correo Reservante:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtCorreoRes" runat="server" Width="496px"></asp:TextBox>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label6" runat="server" Text="Mesa Asignada:" Width="130px"></asp:Label>
        <asp:TextBox ID="TxtMesa" runat="server" Width="152px"></asp:TextBox>
    </div>

    <div style="margin-top: 10px">
        <asp:Label ID="Label7" runat="server" Text="Mesa:" Width="130px"></asp:Label>
        <asp:DropDownList ID="DropDownListMesas" runat="server" Width="160px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="25px" AutoPostBack="True">
        </asp:DropDownList>
        </div>
    <div style="margin-top: 10px">
        <asp:Label ID="Label8" runat="server" Text="Horario:" Width="130px"></asp:Label>
        <asp:DropDownList ID="DropDownListHorarios" runat="server" Width="160px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="25px">
        </asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Buscar Mesa Disponible" Style="margin-top: 30px" Width="200px" OnClick="Button1_Click"/>
    </div>
    <div style="margin-top: 10px">
        <asp:Button ID="BtnSalir" runat="server" Text="Salir" Width="86px" />
        <asp:Button ID="BtnAsignar" runat="server" Text="Asignar Mesa" />
    </div>
</asp:Content>
