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
    <div class="General"> 
        <br />
    <asp:Label ID="Label9" runat="server" style="position:relative; float: left; top: 0px; left: 0px;" Text="Fecha: " ></asp:Label>
    <asp:TextBox ID="TxtFecha" TextMode="Date"  style="position:relative; float: left; top: 0px; left: 0px;margin-left:10px;" runat="server"></asp:TextBox>

    <asp:TextBox ID="TxtEAlmacen" style="position:relative; float: right; top: 0px; left: 0px; margin-left:10px;" runat="server"></asp:TextBox>
    <asp:Label ID="Label10" runat="server"  style="position:relative; float: right; top: 0px; left: 0px;" Text="Encargado de Almacen: " ></asp:Label> 
        <br />
    <div class="General1">
    <fieldset style="width: 491px" >
    <legend>Datos Insumo</legend>
        <br />
    <asp:Label ID="Label8" runat="server" Text="Codigo Insumo: "></asp:Label>
    <asp:TextBox ID="TxtCod" runat="server" style="margin-left:15px;"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" style="margin-left: 36px" Text="Buscar" OnClick="BtnBuscar_Click" />
        <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Descripcion Insumo:"></asp:Label>
    <asp:TextBox ID="TxtDes" runat="server" style="margin-left:15px;"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Categoria: "></asp:Label>
    <asp:DropDownList ID="DpCategoria" runat="server" style="margin-left:15px;" AutoPostBack="true" OnSelectedIndexChanged="DpCategoria_SelectedIndexChanged">
         <asp:ListItem Selected="True" Text="SELECCIONAR CATEGORIA" Value="0"></asp:ListItem>
                <asp:ListItem Text="CARNE" Value="1"></asp:ListItem>
                <asp:ListItem Text="VEGETAL" Value="2"></asp:ListItem>
                <asp:ListItem Text="FRUTA" Value="3"></asp:ListItem>
                <asp:ListItem Text="ABARROTES" Value="4"></asp:ListItem>
        <asp:ListItem Text="OTROS" Value="5"></asp:ListItem>
    </asp:DropDownList>
        <br />
        <br />
        </fieldset>
    <br />
    <br />
    <fieldset style="width: 309px" >
    <legend>Planificacion</legend>
        <br />
    <asp:Label ID="Label3" runat="server" Text="Unidad: " ></asp:Label>
    <asp:DropDownList ID="DpUnidad" runat="server" style="margin-left:15px;">
        <asp:ListItem Selected="True" Text="SELECCIONAR UNIDAD" Value="-"></asp:ListItem>
                <asp:ListItem Text="KG." Value="kg."></asp:ListItem>
                <asp:ListItem Text="UNID." Value="unid."></asp:ListItem>
               <asp:ListItem Text="GRAMOS" Value="gr."></asp:ListItem>
                <asp:ListItem Text="LITROS" Value="lt."></asp:ListItem>  
    </asp:DropDownList>
        <br />
        <br />
    <asp:Label ID="Label4" runat="server" Text="Stock Actual: "></asp:Label>
    <asp:TextBox ID="TxtSActual" runat="server" style="margin-left:15px;"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Stock Minimo"></asp:Label>
    <asp:TextBox ID="TxtSMin" runat="server" style="margin-left:15px;"></asp:TextBox>
        <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Stock Maximo"></asp:Label>
    <asp:TextBox ID="TxtSMax" runat="server" style="margin-left:15px;"></asp:TextBox>
        <br />
        <br />
    </fieldset>
    <br />
    <br />
    <div>
    <asp:Button ID="BtnSalir" runat="server" Text="Salir" OnClick="BtnSalir_Click" style="margin-left: 20px" />
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" style="margin-left: 20px" />    
    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" style="margin-left: 21px" />
        </div>
        </div>
        </div>
</asp:Content>
