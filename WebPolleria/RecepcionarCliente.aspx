<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecepcionarCliente.aspx.cs" Inherits="WebPolleria.RecepcionarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/Recepcion.css"/>
    <div class="Global">
         <div class="DivRecepcionista">
             <br />
 <asp:TextBox ID="TxtRecepcionista" style="position:relative; float: right; top: 0px; left: 0px;" runat="server"></asp:TextBox>
 <asp:Label ID="Label1" runat="server" CssClass="Fuente1" style="position:relative; float: right; top: 0px; left: 0px;" Text="Recepcionista:"></asp:Label>  
        </div>
    <br />
     <div class="Global1">
    <asp:Panel ID="General1" runat="server">      
        <div>
    <asp:Button Class="tab-button" ID="BtnRep" runat="server" Text="RecepcionCliente" OnClick="Button1_Click1" />
    <asp:Button Class="tab-button" ID="BtnReser" runat="server" Text="ReservasActicas" OnClick="Button2_Click" />
        </div>
    <asp:Panel ID="General2" runat="server">
    <asp:Panel ID="RecepcionCliente" runat="server">
    <div id="Recepcion" runat="server"> 
        <fieldset style="width: 1224px">
        <legend Class="Fuente1">Mesas Disponibles</legend>
        <div  id="Div2" runat="server">
    <div  id="DetRecepcion" runat="server"  Class="divDet1">
         <asp:Label ID="Label7" runat="server" Class="Fuente1" Text="Mesa Asignada: "></asp:Label>
         <asp:TextBox ID="TxtMesa" runat="server" Enabled="False"></asp:TextBox>
       </div>  
    </div>
            </fieldset>
        </div>
    
    <div id="Div4" runat="server" > 
        <fieldset style="width: 1226px">
        <legend Class="Fuente1">Datos Cliente</legend>
            <div  id="Div5" runat="server"  Class="divDet1">
            <asp:Label ID="Label2" runat="server" Class="Fuente1" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Class="Fuente1" Text="Apellidos: "></asp:Label>
            <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Class="Fuente1" Text="DNI/RUC: "></asp:Label>
            <asp:TextBox ID="TxtDni" runat="server"></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Class="Fuente1" Text="(Opcional en caso de no usar poner 0*)"></asp:Label>
                </div>
        </fieldset>
        </div>
    <div id="Div1" runat="server" > 
        <fieldset style="width: 1226px">
        <legend Class="Fuente1">Datos del mozo</legend>
            <div  id="Div6" runat="server"  Class="divDet1">
            <asp:Label ID="Label8" runat="server" Class="Fuente1" Text="Mozo Responsable"></asp:Label>
            <asp:TextBox ID="TxtMozo" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtMozoId" runat="server"></asp:TextBox>
                </div>
        </fieldset>
        </div>
    </asp:Panel>
      
    <asp:Panel ID="ReservaActivas" runat="server">
    <div id="Reserva" runat="server" >
        <fieldset style="width: 550px">
        <div id="Busqueda" runat="server">
            <asp:RadioButton ID="RdDNI" runat="server" Class="Fuente1" Text="DNI" OnCheckedChanged="RdDNI_CheckedChanged" AutoPostBack="True" />
        <asp:TextBox ID="TxtNro" Class="Fuente" runat="server"></asp:TextBox>
            <asp:Button ID="BtnBuscarRes" runat="server" Class="button" OnClick="BtnBuscarRes_Click" Text="Buscar Reserva" />
            <br/>
            <asp:RadioButton ID="RdNombre" runat="server" AutoPostBack="True" Class="Fuente1" OnCheckedChanged="RdNombre_CheckedChanged" Text="Nombre" />
            <asp:TextBox ID="TxtNombre1" runat="server"></asp:TextBox>
            <asp:Label ID="Label13" runat="server" Text="" Width="10px"></asp:Label>
            <asp:TextBox ID="TxtApellido1" runat="server" style="width: 128px"></asp:TextBox>
            <asp:Button ID="BtnBuscarRes1" runat="server" Class="button" OnClick="BtnBuscarRes12_Click" Text="Buscar Reserva" />
        </div>
            <div id="Detalle"  runat="server" Class="divDet1">
           <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/CalendarioSim.png" Height="29px" Width="36px" />
                <asp:Label ID="Label12" runat="server" Text="" Width="36px"></asp:Label>
           <asp:Label ID="LbCalendario" runat="server" Class="Fuente1" Text="Fecha de Reserva"></asp:Label>
                <asp:Label ID="LbNombre" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="LbApellidos" runat="server" Text="Label"></asp:Label>
           <br />
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/RelojSim.png" Height="29px" Width="36px"/>
                <asp:Label ID="Label6" runat="server" Text="" Width="36px"></asp:Label>
           <asp:Label ID="LbHorario" runat="server" Class="Fuente1" Text="Horario"></asp:Label>
           <br />
           <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/MesasSim.png" Height="29px" Width="36px"/>
                <asp:Label ID="Label9" runat="server" Text="" Width="36px"></asp:Label>
           <asp:Label ID="Label5" runat="server" Class="Fuente1" Text="Mesa: "></asp:Label>
           <asp:Label ID="LbMesa" runat="server" Class="Fuente1" Text="Mesa Asignada"></asp:Label>
           <br />
           <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/IdentificacionSim.png" Height="29px" Width="36px" />
                <asp:Label ID="Label10" runat="server" Text="" Width="36px"></asp:Label>
           <asp:Label ID="LbIdentificacion" runat="server" Class="Fuente1" Text="Identificacion"></asp:Label>
                <br />
           <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Mozo.png" Height="29px" Width="36px" />
                <asp:Label ID="Label11" runat="server" Text="" Width="36px"></asp:Label>
           <asp:Label ID="Label15" runat="server" Class="Fuente1" Text="Mozo Asignado: "></asp:Label>
           <asp:Label ID="LbMozo" runat="server" Class="Fuente1" Text="Mozo"></asp:Label>
                <asp:Label ID="LbMozoId" runat="server" Text=""></asp:Label>
            </div>
            </fieldset>
         </div>
        </asp:Panel>
         </asp:Panel>
        </asp:Panel>

        <div Class="divCabe">
        <div id="Div3" runat="server" Class="divDet">
        <asp:Button ID="BtnAsignar" runat="server" Class="button" Text="Ocupar Mesa" OnClick="BtnAsignar_Click"  />
            <asp:Button ID="BtnAsignar1" runat="server" Class="button" Text="Ocupar Mesa" OnClick="BtnAsignar1_Click"  />
        <asp:Button ID="BtnSalir" runat="server" Class="button1" Text="Salir" OnClick="BtnSalir_Click"  />
    </div>
       </div>
          </div>
        </div>
      
</asp:Content>
