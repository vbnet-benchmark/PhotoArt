@Code
    ViewData("Title") = "ComponerNotificacion"
End Code

<h2>Componer notificación para socios</h2>
<p>
    Escribe el asunto y el cuerpo de la notificación. Puedes usar los marcadores
    <code>{{Nombre}}</code> y <code>{{NombreAlbum}}</code> dentro del cuerpo.
</p>

<h3>Previsualizar (motor avanzado)</h3>
<form method="post" action="/Admin/PrevisualizarNotificacion">
    <p>Asunto: <input type="text" name="Asunto" /></p>
    <p>Cuerpo:<br />
        <textarea name="CuerpoPlantilla" rows="6" cols="60"></textarea>
    </p>
    <input type="submit" value="Previsualizar" />
</form>

<h3>Enviar a un socio (ayudante interno)</h3>
<form method="post" action="/Admin/EnviarNotificacionSocio">
    <p>Nick destinatario: <input type="text" name="nickDestino" /></p>
    <p>Asunto: <input type="text" name="Asunto" /></p>
    <p>Cuerpo:<br />
        <textarea name="CuerpoPlantilla" rows="6" cols="60"></textarea>
    </p>
    <input type="submit" value="Enviar" />
</form>

<h3>Enviar aviso personalizado (lógica de notificación)</h3>
<form method="post" action="/Admin/EnviarAvisoPersonalizado">
    <p>Nick destinatario: <input type="text" name="nickDestino" /></p>
    <p>Asunto: <input type="text" name="Asunto" /></p>
    <p>Cuerpo:<br />
        <textarea name="CuerpoPlantilla" rows="6" cols="60"></textarea>
    </p>
    <input type="submit" value="Enviar" />
</form>

<h3>Enviar notificación personalizada (motor configurable)</h3>
<form method="post" action="/Admin/EnviarNotificacionPersonalizada">
    <p>Nick destinatario: <input type="text" name="nickDestino" /></p>
    <p>Asunto: <input type="text" name="Asunto" /></p>
    <p>Cuerpo:<br />
        <textarea name="CuerpoPlantilla" rows="6" cols="60"></textarea>
    </p>
    <input type="submit" value="Enviar" />
</form>

<h3>Enviar notificación masiva a todos los socios</h3>
<form method="post" action="/Admin/EnviarNotificacionMasiva">
    <p>Asunto: <input type="text" name="Asunto" /></p>
    <p>Cuerpo:<br />
        <textarea name="CuerpoPlantilla" rows="6" cols="60"></textarea>
    </p>
    <input type="submit" value="Enviar a todos" />
</form>
