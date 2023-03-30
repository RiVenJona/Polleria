<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreSeguridad.aspx.cs" Inherits="WebPolleria.PreSeguridad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Preguntas" runat="server">
                <h4>Estas son las preguntas de seguridad que serviran en caso de que se requiera recuperar la contraseña:</h4>
                <p>(Solo se responden una sola vez, no se reciben respuestas vacias.)</p>
                <h3>Preguntas 1: Cuál es el nombre de su Abuelo?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta1" />
                <h3>Preguntas 2: Cuál es el nombre de su colegio de primaria?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta2" />
                <h3>Preguntas 3: Cuál es el nombre de su mejor amigo?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta3" />
                <h3>Preguntas 4: En que año termino la secundaria?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta4" />
                <h3>Preguntas 5: Cuantos primos tiene?</h3>
                <input class="inputPreguntas" type="text" name="txtPregunta5" />
                <br /><br /><br /><asp:Button ID="btnEnviar" runat="server" Text="Registrar" OnClick="btnEnviar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
