<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AnularReserva.aspx.cs" Inherits="WebPolleria.AnularReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/AnularReserva.css" />
        <div class="divp">
            <div class="div1">
            <div class="div2">
            <asp:Label ID="Label1" runat="server" Text="N° O. Reserva"></asp:Label>
            <asp:TextBox ID="TxtNro" runat="server" Style="margin-left: 35px" Width="152px"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="Button1_Click" />
             <br />
            Estado O. Reserva&nbsp;
            <asp:TextBox ID="TxtEstado" runat="server" Width="156px" Enabled="False" OnTextChanged="TxtEstado_TextChanged"></asp:TextBox>
            </div >
                </div >
            <div class="div1">
            <div id="Detalle" runat="server" class="div2">
                 <h4>Detalle de orden:</h4>
                 <asp:GridView ID="GrdReserva" runat="server" CssClass="gridview" Width="819px" AutoGenerateColumns="False" Height="190px" Style="margin-top: 36px" OnSelectedIndexChanged="GrdReserva_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="NumOrdenRe" HeaderText="N°Reserva" />
                    <asp:BoundField DataField="FechaProgra" HeaderText="Fecha" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="IdMesa" HeaderText="Mesa" />
                    <asp:BoundField DataField="Espacio" HeaderText="Cant.Personas" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            </div>
                </div>  
            <div class="div1">
            <div class="div2">
            <asp:Button ID="btnReiniciar" runat="server" Text="Reiniciar" CssClass="button" OnClick="btnReiniciar_Click" /> 
            &nbsp
            <asp:Button ID="BtnAnular" runat="server" Text="Anular" CssClass="button" OnClick="BtnAnular_Click" />
                </div>
                </div>
        </div>

</asp:Content>
