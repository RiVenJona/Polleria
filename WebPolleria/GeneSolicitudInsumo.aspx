<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneSolicitudInsumo.aspx.cs" Inherits="WebPolleria.GeneOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenSoliInsumo.css" />
    <section>
        <div class="tituloCus">
            <asp:Label ID="Label4" runat="server" Text="Solicitud de Insumos" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
    </section>
    <div id="General" class="General">
        <br />
    <div>
    <asp:Label ID="Label1" runat="server" style="position:relative; float: left; top: 0px; left: 0px;margin-left:20px;" Text="Fecha: " class="Fuente1"></asp:Label>
    <asp:TextBox ID="TxtFecha" TextMode="Date"  style="position:relative; float: left; top: 0px; left: 0px;margin-left:10px;" runat="server"></asp:TextBox>

    <asp:TextBox ID="TxtEAlmacen" style="position:relative; float: right; top: 0px; left: 0px; margin-left:10px;margin-right:20px;" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server"  style="position:relative; float: right; top: 0px; left: 0px;" Text="Encargado de Almacen: " class="Fuente1"></asp:Label> 
    </div>
    <br />
    <fieldset >
            <legend class="Fuente1"> Busqueda</legend>
    <div class="Contenedor">
        <div class="columna">
   
         <fieldset >
            <legend class="Fuente1">Buscar Insumo</legend>
            <div>
                <asp:Label ID="Label3" runat="server" CssClass="Fuente1" Text="Descripcion"></asp:Label>
                <asp:DropDownList ID="DpInsumos" runat="server" style="margin-left: 18px" Width="135px" Height="25px">
                    <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnAñadir" runat="server" Text="Añadir" style="margin-left: 27px; width: 55px;" OnClick="BtnAñadir_Click"  />
            </div>
        </fieldset>
        </div>
        <div class="columna">
           <asp:Button ID="BtnPlanificacion" runat="server" CssClass="BotonPla" Text="Cargar Planificacion" OnClick="BtnPlanificacion_Click" Height="66px" Width="165px" style="margin-left: 50px"/>
        </div>
    </div>
    <br />
    <br />
    <div class="Detalle">
        <fieldset style="width: 675px">
            <legend class="Fuente1">Lista de Insumos</legend>
            <div style="width: 658px">
             <asp:GridView HorizontalAlign="Center" ID="GvOrden" runat="server" ShowHeaderWhenEmpty="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnRowCommand="EliminarFila" OnSelectedIndexChanged="GvOrden_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField  DataField="NumInsumo" HeaderText="ID"/>
                <asp:BoundField  DataField="Categoria" HeaderText="CATEGORÍA" />
                <asp:BoundField  DataField="DesIns" HeaderText="DESCRIPCIÓN" />
                <asp:BoundField  DataField="Cantidad" HeaderText="STOCK ACTUAL" />
                <asp:BoundField  DataField="StockMax" HeaderText="PLANIFICADO" />
                <asp:TemplateField HeaderText="PENDIENTE">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("StockMax")) - Convert.ToInt32(Eval("Cantidad")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField  DataField="Unidad" HeaderText="UNIDAD" />
                
                <asp:TemplateField HeaderText="ACCION" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                      <asp:Button runat="server" ID="btnEliminar" CssClass="Boton" Width="25px" Height="25px" Text="x" CommandName="ELIMINAR" CommandArgument="<%# Container.DataItemIndex %> "/>
                  </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>   
            </div>
        </fieldset>
         </div>
        <br />
            <br />
        <div class="Botones">
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" style="height: 26px" />
            <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" style="margin-left:50px"/>
           
                <br />
           
         </div>
    </fieldset> 
        <br />
    </div >
</asp:Content>
