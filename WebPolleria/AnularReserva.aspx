<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AnularReserva.aspx.cs" Inherits="WebPolleria.AnularReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="height: 385px; margin-top: 72px">
            <asp:Label ID="Label1" runat="server" Text="N° O. Reserva"></asp:Label>
            <asp:TextBox ID="TxtNro" runat="server" Style="margin-left: 35px" Width="152px"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" Style="margin-left: 91px" Width="92px" OnClick="Button1_Click" />

            <br />
            Estado O. Reserva&nbsp;
            <asp:TextBox ID="TxtEstado" runat="server" Width="156px" BackColor="#999999" Enabled="False" OnTextChanged="TxtEstado_TextChanged"></asp:TextBox>

            <asp:GridView ID="GrdReserva" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="819px" AutoGenerateColumns="False" Height="190px" Style="margin-top: 36px" HorizontalAlign="Center" OnSelectedIndexChanged="GrdReserva_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="NumOrdenRe" HeaderText="N°Reserva" />
                    <asp:BoundField DataField="FechaProgra" HeaderText="Fecha" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="IdMesa" HeaderText="Mesa" />
                    <asp:BoundField DataField="Espacio" HeaderText="Cant.Personas" />
                </Columns>
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>

            <asp:Button ID="Button3" runat="server" Text="Salir" /> 

            <asp:Button ID="BtnAnular" runat="server" Text="Anular" OnClick="BtnAnular_Click" />

        </div>

</asp:Content>
