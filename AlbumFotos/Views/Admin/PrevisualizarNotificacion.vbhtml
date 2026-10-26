@Code
    ViewData("Title") = "PrevisualizarNotificacion"
End Code

<h2>Vista previa de la notificación</h2>
<p><b>Asunto:</b> @ViewData("Asunto")</p>
<div>
    @Html.Raw(ViewData("CuerpoRenderizado"))
</div>
