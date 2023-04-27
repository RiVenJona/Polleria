<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrdenPedido.aspx.cs" Inherits="WebPolleria.OrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link rel="stylesheet" type="text/css" href="/estilos/ordenPedido.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section>
        <div class="tituloCus">
            <h3>Orden de Pedido</h3>
        </div>
    </section>
    <section>
        <div class="ResponsablePedido">
            <div class="inputItem">
                <p>Responsable de O. Pedido</p>
                <input type="text">
            </div>
            <div class="inputItem">
                <p>Codigo O.Pedido</p>
                <input type="text">
            </div>
        </div>
    </section>
    <section class="containerBusqueda">
        <fieldset class="BusquedaCliente">
            <legend>Busqueda de Cliente</legend>
            <div class="busqueda">
                <p>Codigo O.Pedido:</p>
                <input type="text">
                <button>Buscar</button>
            </div>
        </fieldset>
    </section>
    <section class="TipoPedidoBox">
        <fieldset class="TipodePedido">
            <legend>Tipo de Orden</legend>
            <div class="optionRadio">
                <p>Servicio Delivery</p>
                <input type="radio" name="group1" id="InDeli">
            </div>
            <div class="espacioxd"></div>
            <div class="optionRadio">
                <p>Servicio Presencial</p>
                <input type="radio" name="group1" id="InPres">
            </div>
        </fieldset>
    </section>
    <section class="BoxDetalle">
        <fieldset class="DetalleOrden">
            <legend>Datos del Cliente</legend>
            <div class="DatosPersonales">
                <div class="DetallesInputs">
                    <p>Nombre:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Apellido:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>DNI:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Nro.Telefono:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Fecha:</p>
                    <input type="date">
                </div>
            </div>
            <div class="espacioxd"></div>
            <div class="DatosEnvio">
                <div class="DetallesInputs">
                    <p>Direccion:</p>
                    <input type="text">
                </div>
                <div class="DetallesInputs">
                    <p>Referencia:</p>
                    <input type="text">
                </div>
            </div>
        </fieldset>
    </section>
    <section>
        <fieldset class="ListaTickets">
            <legend>Pedidos</legend>
            <div>
                <p>Insertar Tabla Mas na</p>
            </div>
                <div class="AgregarCosas">
                    <div class="CosaBuscador">
                        <div class="CosaBuscadorHijo">
                            <p>Descripcion del Producto</p>
                            <input type="text">
                            <button>Buscar</button>
                        </div>
                    </div>
                    <div>
                        <p>Cosas Encontradas</p>
                    </div>
                </div>
                <div class="monto">
                    <div class="casillas">
                        <p>Monto Total</p>
                        <input type="text">
                    </div>
                </div>
        </fieldset>
    </section>
    <section class="BotonesFinales">
        <button class="generalBtn">Regresar</button>
        <button class="generalBtn">Generar</button>
    </section>

</asp:Content>
