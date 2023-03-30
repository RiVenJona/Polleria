<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPass.aspx.cs" Inherits="WebPolleria.CambiarPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/estilos/Login.css" />
</head>
<body>
    <form id="form1" runat="server" class="formCambio">
        <div class="containerpass">
           <%-- <input type="password" name="txtContraA" placeholder="Ingrese Antigua contraseña" />
            <input type="password" name="txtContraN" placeholder="Ingrese Nueva contraseña" />--%>
            <h3 class="txtCambiarPass">PROCEDA A CAMBIAR LA CONTRASEÑA POR DEFECTO POR FAVOR</h3>
            <input type="password" id="myInput" name="txtNuevapass" oninput="inputChanged()" placeholder="Nueva Contraseña" onkeypress="return evitarEspacios(event)" oncopy="return false"/>
            <script>
                function evitarEspacios(event) {
                    var tecla = event.keyCode || event.which;
                    if (tecla == 32) {
                        event.preventDefault();
                        return false;
                    }
                    return true;
                }
                function inputChanged() {
                    var inputValue = document.getElementById("myInput").value;
                    let regex1 = /[A-Z]/;
                    let regex2 = /\d+/;
                    let regex3 = /[.,;:!?+-]/;

                    var test1 = regex1.test(inputValue);
                    var test2 = regex2.test(inputValue);
                    var test3 = regex3.test(inputValue);
                    var div1 = document.getElementById("b1");
                    var div2 = document.getElementById("b2");
                    var div3 = document.getElementById("b3");

                    if (test2 || test1 || test3) {
                        div1.style.background = "red";
                        div2.style.background = "white";
                        div3.style.background = "white";
                        if (test1 && test2) {
                            div1.style.background = "yellow";
                            div2.style.background = "yellow";
                            div3.style.background = "white";
                            if (test1 && test2 && test3) {
                                div1.style.background = "green";
                                div2.style.background = "green";
                                div3.style.background = "green";
                            }
                        }
                    }
                    
                    else {
                        div1.style.background = "white";
                        div2.style.background = "white";
                        div3.style.background = "white";
                    }
                }
            </script>
            <div class="barracompleta">
                <div class="barraseguridad1" id="b1"></div>
                <div class="barraseguridad2" id="b2"></div>
                <div class="barraseguridad3" id="b3"></div>
                    </div>
                <style>
                    .containerpass{
                        display:flex;
                        flex-direction:column;
                        justify-content:center;
                    }
                    .barracompleta{
                        display:flex;
                        margin-top: 10px;
                        justify-content:center;
                    }
                    .barraseguridad1{
                        background: white;
                        width: 40px;
                        height: 10px;
                        border-top-left-radius: 15px;
                        border-bottom-left-radius: 15px;
                        margin-right:2px;
                        border: 0.5px solid grey;
                    }
                    .barraseguridad2{
                        background: white;
                        width: 40px;
                        height: 10px;
                        border: 0.5px solid grey;
                    }
                    .barraseguridad3{
                        background: white;
                        width: 40px;
                        height: 10px;
                        border-top-right-radius: 15px;
                        border-bottom-right-radius: 15px;
                        margin-left:2px;
                        border: 0.5px solid grey;
                    }
                </style>
            <asp:Button ID="btnCambiarPass" runat="server" Text="Cambiar" OnClick="btnCambiarPass_Click" CssClass="btnCambiar"/>
            </div>
    </form>
</body>
</html>
