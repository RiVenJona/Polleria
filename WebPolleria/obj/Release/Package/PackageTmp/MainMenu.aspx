<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="WebPolleria.MainMenu" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/estilos/Master.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex;justify-content:center;align-items:center;color:gray;font-weight:bold;flex-direction:column;">
        <h2>BIENVENIDO</h2>
        <h2 id="rolBi" runat="server"></h2>
    </div>
</asp:Content>
