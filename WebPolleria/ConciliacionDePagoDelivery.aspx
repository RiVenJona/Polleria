 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConciliacionDePagoDelivery.aspx.cs" Inherits="WebPolleria.ConciliacionDePagoDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="estilos/Conciliacion.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="BgContainer">
        <section class="Titulo">
            <h3>Conciliacion de Pago Delivery</h3>
            <div class="datosCajera">
                <p>Cajera</p>
                <input type="text" placeholder="Nombre Cajera" disabled="disabled" id="Nombre" runat="server">
            </div>
        </section>
        <section class="ListaRepartidores">
            <fieldset >
                <legend>Lista de Repartidores</legend>
                    <asp:GridView ID="gvRepatidores" runat="server" AutoGenerateColumns="false" BorderStyle="Double" CellPadding="5" EmptyDataText="NO SE MUESTRAS NINGUN REGISTRO EN LA TABLA" 
                    HeaderStyle-CssClass="tabla1Cabeza" RowStyle-CssClass="tabla1Cuerpo" SelectedRowStyle-BackColor="Yellow" OnSelectedIndexChanged="gvRepatidores_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NroGOPD" HeaderText="ID_Orden" />
                        <asp:BoundField DataField="idRepartidor" HeaderText="ID_Repartidor" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="EstadoGOPD" HeaderText="Estado" />
                        <asp:CommandField HeaderText="Seleccionar" SelectText="✅" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </fieldset>
        </section>
        <section class="DetalleOrdenDelivery">
            <fieldset>
                <legend>Detalle Orden de Delivery</legend>
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="false" BorderStyle="Double" CellPadding="5" EmptyDataText="NO SE HA SELECCIONADO NINGUNA ORDEN" 
                    HeaderStyle-CssClass="tabla2Cabeza" RowStyle-CssClass="tabla2Cuerpo" SelectedRowStyle-BackColor="Yellow">
                    <Columns>
                        <asp:BoundField DataField="idDetallePedido" HeaderText="ID_Pedido" />
                        <asp:BoundField DataField="total" HeaderText="Monto Pedido" />
                        <asp:BoundField DataField="vuelto" HeaderText="Vuelto" />
                        <asp:BoundField DataField="recaudacion" HeaderText="Recaudacion" />
                        <asp:BoundField DataField="estadoPedido" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </fieldset>
        </section>
        <section class="Cash">
            <div class="cashDatos">
                <p>Monto Recibido</p>
            <input type="text" placeholder="Aqui Dinero" disabled="disabled" id="monto" runat="server">
            </div>
        </section>
        <section class="actionBtn">
            <asp:Button ID="Button1" runat="server" Text="Regresar" CssClass="btn1" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Generar Consolidacion de Pago"  CssClass="btn2" OnClick="Button2_Click"/>
        </section>
    </main>
</asp:Content>
