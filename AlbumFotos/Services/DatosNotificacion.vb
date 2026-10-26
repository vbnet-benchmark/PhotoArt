''' <summary>
''' Datos no controlados por el usuario que se exponen a la plantilla de notificación como Model
''' (@Model.Nombre / @Model.NombreAlbum en el texto de la plantilla). Estos valores en sí mismos no
''' son el problema: el problema es que el TEXTO de la plantilla (ver PlantillaNotificacion) se
''' compila y ejecuta como código Razor en lugar de tratarse como texto estático.
''' </summary>
Public Class DatosNotificacion
    Public Property Nombre As String
    Public Property NombreAlbum As String
End Class
