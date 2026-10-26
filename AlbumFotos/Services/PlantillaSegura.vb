''' <summary>
''' Esquema de sustitución SEGURO para las plantillas de notificación: un conjunto cerrado y
''' enumerable de marcadores ("{{Nombre}}", "{{NombreAlbum}}") que se sustituyen de forma literal
''' (String.Replace) por los valores del destinatario. No hay evaluación de expresiones, no hay
''' bucles ni condicionales dentro de la plantilla, y ningún texto distinto de estos dos marcadores
''' puede tener ningún efecto: a diferencia de un motor de plantillas (RazorEngine), esto nunca
''' compila ni ejecuta el texto que escribe el administrador.
''' </summary>
Public Class PlantillaSegura

    Private Const MARCADOR_NOMBRE As String = "{{Nombre}}"
    Private Const MARCADOR_ALBUM As String = "{{NombreAlbum}}"

    Public Shared Function Sustituir(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String
        If plantilla Is Nothing Then
            Return String.Empty
        End If
        Dim resultado As String = plantilla
        resultado = resultado.Replace(MARCADOR_NOMBRE, datos.Nombre)
        resultado = resultado.Replace(MARCADOR_ALBUM, datos.NombreAlbum)
        Return resultado
    End Function

End Class
