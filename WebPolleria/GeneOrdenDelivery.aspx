<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeneOrdenDelivery.aspx.cs" Inherits="WebPolleria.GeneOrdenDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/GenOrdenDelivery.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="General">
    <div id="General1" runat="server">
        <br />
    <asp:GridView ItemStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="3" CssClass="gridView" HorizontalAlign="Center" ID="gvCatalogo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GvDatos_SelectedIndexChanged" ForeColor="Black" GridLines="Vertical" Height="218px" Width="700px" OnPageIndexChanging="gvCatalogo_PageIndexChanging">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>

                <asp:BoundField  DataField="idProducto" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField  DataField="desProducto" HeaderText="PRODUCTO" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField  DataField="PrecioProducto" HeaderText="PRECIO" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="IMAGEN">
            <ItemTemplate >
                <asp:Image ItemStyle-HorizontalAlign="Center" ID="Image1" runat="server" ImageUrl='<%# Eval("idProducto", "~/Imagenes/{0}.jpg") %>' 
                    Width="100" Height="100" />
            </ItemTemplate>
        </asp:TemplateField>
                <asp:CommandField HeaderText="SELECCIÓN" SelectText="AGREGAR" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"/>           
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <br />
        <asp:GridView  ItemStyle-HorizontalAlign="Center" ID="gvPedido" EmptyDataText="Carrito vacio" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="16px" Width="700px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idProducto" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="desProducto" HeaderText="DESCRIPCION" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                    <asp:TextBox ItemStyle-HorizontalAlign="Center" ID="txtCantGv" runat="server"  Width="38px" Enabled="false" Text=1></asp:TextBox>
                                      <BR />
                                    <asp:Button runat="server" ID="btnIncrementar" Text="+" OnClick="btnIncrementar_Click" />
                                    <asp:Button runat="server" ID="btnDisminuir" Text="-" OnClick="btnDisminuir_Click" />
                                  </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrecioProducto" HeaderText="PRECIO" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="QUITAR" ItemStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:Button  runat="server" ID="btnEliminar" Width="25px" Height="25px" CommandArgument='<%# Container.DataItemIndex %>' Text="x" OnClick="btnEliminar_Click"/>
                                  </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle BorderStyle="Dotted" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
        <br />
        <br />
        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" OnClick="BtnRegistrar_Click" />
    </div>
</asp:Content>