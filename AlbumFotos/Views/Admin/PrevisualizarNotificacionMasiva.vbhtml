@Code
    ViewData("Title") = "PrevisualizarNotificacionMasiva"
End Code

<h2>Vista previa de la notificación masiva</h2>
<p><b>Asunto:</b> @ViewData("Asunto")</p>
@For Each cuerpo In CType(ViewData("ResultadosRenderizados"), List(Of String))
    @<div style="border-bottom: 1px solid #ccc; margin-bottom: 10px;">
        @Html.Raw(cuerpo)
    </div>
Next
