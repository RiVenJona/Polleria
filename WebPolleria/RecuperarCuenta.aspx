<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="WebPolleria.RecuperarCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-preguntas">
                <h3>RECUPERAR CUENTA DE TRABAJADOR</h3>
                <h5>Ingrese usuario del que desea recuperar contraseña</h5>
                <input type="text" placeholder="Usuario" name="txtUsuario" />
                <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
                <p><b>Si no lo recuerda, <a href="~/RecuPorCorreo.aspx"> ingrese aquí</a></b></p>
            </div>
            <div id="Preguntas" runat="server">
                <h3>Preguntas 1: Cuál es el nombre de su abuelo?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta1" id="txtPregunta1" runat="server"/>
                <h3>Preguntas 2: Cuál es el nombre de su colegio de primaria?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta2" id="txtPregunta2" runat="server"/>
                <h3>Preguntas 3: Cuál es el nombre de su mejor amigo?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta3" id="txtPregunta3" runat="server"/>
                <h3>Preguntas 4: En que año termino la secundaria?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta4" id="txtPregunta4" runat="server" />
                <h3>Preguntas 5: Cuantos primos tiene?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta5" id="txtPregunta5" runat="server"/>
                <br /><br /><br /><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
