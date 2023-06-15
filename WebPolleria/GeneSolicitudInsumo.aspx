<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneSolicitudInsumo.aspx.cs" Inherits="WebPolleria.GeneOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Mensage {
            width: 358px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenSoliInsumo.css" />
    <section>
        <div class="tituloCus">
            <asp:Label ID="Label4" runat="server" Text="Solicitud de Insumos" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
    </section>
    <div class="General">
        <div id="Planificacion" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" style="position:relative; float: left; top: 0px; left: 0px;margin-left:20px;" Text="Fecha de solicitud: " class="Fuente1"></asp:Label>
    <asp:TextBox ID="TxtFecha" TextMode="Date"  style="position:relative; float: left; top: 0px; left: 0px;margin-left:10px;" runat="server"></asp:TextBox>
    
    <asp:TextBox ID="TxtEAlmacen" style="position:relative; float: right; top: 0px; left: 0px; margin-left:10px;margin-right:20px;" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" CssClass="Fuente1"  style="position:relative; float: right; top: 0px; left: 0px;" Text="Jefe de Cocina: " class="Fuente1"></asp:Label> 
    </div>
    <br />
    <div class="tab-buttons">
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab1" Text="LUNES" OnClick="BtnTab_Click" CommandArgument="0" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab2" Text="MARTES" OnClick="BtnTab_Click" CommandArgument="1" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab3" Text="MIERCOLES" OnClick="BtnTab_Click" CommandArgument="2" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab4" Text="JUEVES" OnClick="BtnTab_Click" CommandArgument="3" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab5" Text="VIERNES" OnClick="BtnTab_Click" CommandArgument="4" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab6" Text="SABADO" OnClick="BtnTab_Click" CommandArgument="5" />
        <asp:LinkButton CssClass="tab-button" runat="server" ID="BtnTab7" Text="DOMINGO" OnClick="BtnTab_Click" CommandArgument="6" />
    </div>
     <asp:MultiView runat="server" ID="MultiViewTabs">
     <asp:View runat="server" ID="ViewTab1">
         <div class="Contenedor">
         <div>
         <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label3" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp1" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar1" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar1_Click"/>
         <br />
         <asp:Label ID="Label5" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="txtCantidad1" runat="server"></asp:TextBox>
           </fieldset>
             </div>
             <br />
         <div>
         <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv1" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
             </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab2">
<div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label6" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp2" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar2" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar2_Click"/>
         <br />
         <asp:Label ID="Label7" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad2" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv2" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab3">
         <div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label8" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp3" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar3" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar3_Click"/>
         <br />
         <asp:Label ID="Label9" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad3" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv3" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab4">
         <div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label10" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp4" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar4" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar4_Click"/>
         <br />
         <asp:Label ID="Label11" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad4" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv4" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab5">
<div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label12" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp5" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar5" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar5_Click"/>
         <br />
         <asp:Label ID="Label13" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad5" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv5" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab6">
         <div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label14" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp6" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar6" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar6_Click"/>
         <br />
         <asp:Label ID="Label15" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad6" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv6" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>

     <asp:View runat="server" ID="ViewTab7">
         <div class="Contenedor">
         <div>
             <fieldset>
             <legend class="Fuente1">Agregar Platos</legend>
         <asp:Label ID="Label16" runat="server" style="margin-left: 18px" class="Fuente1" Text="Productos de la carta:"></asp:Label>
         <asp:DropDownList ID="Dp7" runat="server" style="margin-left: 18px">
              <asp:ListItem Selected="True" Text="SELECCIONAR PRODUCTO" Value="0"></asp:ListItem>
                <asp:ListItem Text="1 POLLO A LA BRASA" Value="1"></asp:ListItem>
                <asp:ListItem Text="1/2 POLLO A LA BRASA" Value="2"></asp:ListItem>
                <asp:ListItem Text="1/4 POLLO A LA BRASA" Value="3"></asp:ListItem>
                <asp:ListItem Text="1/8 POLLO A LA BRASA" Value="4"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 1LT" Value="5"></asp:ListItem>
                <asp:ListItem Text="INKA KOLA 3LT" Value="6"></asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnAgregar7" runat="server" style="margin-left: 18px" Text="Agregar" OnClick="BtnAgregar7_Click"/>
         <br />
         <asp:Label ID="Label17" runat="server" style="margin-left: 18px" class="Fuente1" Text="Cantidad Planeada:"></asp:Label>
         <asp:TextBox ID="TxtCantidad7" runat="server"></asp:TextBox>
                 </fieldset>
          </div>
             <br />
         <div>
             <fieldset>
             <legend class="Fuente1">Lista de Planificacion</legend>
         <asp:GridView ID="Grv7" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
             <Columns>
                 <asp:BoundField DataField="idProducto" HeaderText="NumProducto" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="desProducto" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="cantidadProducto" HeaderText="Planificacion" ItemStyle-HorizontalAlign="Center" />
                 <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                         <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %> " CommandName="ELIMINAR" CssClass="Boton" Height="25px" Text="x" Width="25px" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
         </asp:GridView>
                 </fieldset>
             </div>
         </div>
     </asp:View>
     </asp:MultiView>
    <br />

        <div class="Contenedor">
        <div id="Botones">
    <asp:Button ID="BtnSalir" runat="server" Text="Salir" OnClick="BtnSalir_Click" style="height: 26px" />
    <asp:Button ID="BtnGenerar" runat="server" style="margin-left: 18px" Text="Generar" OnClick="BtnGenerar_Click"/>
            </div>
            </div>
        <br />
        </div>
    </div>
    <div class="Contenedor">
    <div class="Contenedor1">
    <div id="Mensage" runat="server">
        <h4>¿Quisiera cancelar la solicitud ya generada?</h4>
        <div class="Contenedor">
        <div>
        <asp:Button ID="BtnSalir1" runat="server" Text="Salir" OnClick="BtnSalir1_Click" />
        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" style="margin-left: 18px" OnClick="BtnCancelar_Click"/>
            </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
