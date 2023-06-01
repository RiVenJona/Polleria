<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarInsumos.aspx.cs" Inherits="WebPolleria.AgregarInsumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/DatosInsumos.css" />
    <section>
        <div class="tituloCus">
            <asp:Label ID="Label7" runat="server" Text="Datos Maestros de Insumos" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
    </section>
    <br />
    <fieldset style="width: 491px" >
    <legend>Datos Insumo</legend>
        <br />
    <asp:Label ID="Label8" runat="server" Text="Codigo Insumo: "></asp:Label>
    <asp:TextBox ID="TxtCod" runat="server"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" style="margin-left: 36px" Text="Buscar" OnClick="BtnBuscar_Click" />
        <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Descripcion Insumo:"></asp:Label>
    <asp:TextBox ID="TxtDes" runat="server"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Categoria: "></asp:Label>
    <asp:DropDownList ID="DpCategoria" runat="server"></asp:DropDownList>
        <br />
        </fieldset>
    <br />
    <br />
    <fieldset style="width: 309px" >
    <legend>Planificacion</legend>
        <br />
    <asp:Label ID="Label3" runat="server" Text="Unidad: "></asp:Label>
    <asp:DropDownList ID="DpUnidad" runat="server"></asp:DropDownList>
        <br />
        <br />
    <asp:Label ID="Label4" runat="server" Text="Stock Actual: "></asp:Label>
    <asp:TextBox ID="TxtSActual" runat="server"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Stock Maximo"></asp:Label>
    <asp:TextBox ID="TxtSMax" runat="server"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Stock Minimo"></asp:Label>
    <asp:TextBox ID="TxtSMin" runat="server"></asp:TextBox>
    </fieldset>
    <br />
    <br />
    <asp:Button ID="BtnSalir" runat="server" Text="Salir" OnClick="BtnSalir_Click" />
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" style="margin-left: 20px" />    
    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" style="margin-left: 21px" />
</asp:Content>