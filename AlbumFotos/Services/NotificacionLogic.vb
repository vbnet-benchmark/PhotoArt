''' <summary>
''' Lógica de negocio para la generación del cuerpo de una notificación a un socio. Primer salto de
''' la cadena interprocedural: recibe el texto de plantilla que escribió el administrador y lo pasa a
''' PlantillaEngine, que es quien realmente invoca el motor de plantillas.
''' </summary>
Public Class Notificacion_Logic

    Dim motorPlantillas As New PlantillaEngine

    ''' <summary>
    ''' Primer salto de PLANTED-VB-HR-678 (CWE-1336, interprocedural): el valor de "plantilla" procede,
    ''' sin ninguna comprobación, del texto compuesto por el administrador (ver
    ''' AdminController.EnviarAvisoPersonalizado) y se reenvía tal cual a PlantillaEngine.Renderizar.
    ''' </summary>
    Public Function GenerarCuerpoNotificacion(ByVal plantilla As String, ByVal nombreSocio As String, ByVal nombreAlbum As String) As String
        Dim datos As New DatosNotificacion With {.Nombre = nombreSocio, .NombreAlbum = nombreAlbum}
        Return motorPlantillas.Renderizar(plantilla, datos)
    End Function

    ''' <summary>
    ''' Primer salto del gemelo seguro PLANTED-VB-HR-678-safe.
    ''' </summary>
    Public Function GenerarCuerpoNotificacionSegura(ByVal plantilla As String, ByVal nombreSocio As String, ByVal nombreAlbum As String) As String
        Dim datos As New DatosNotificacion With {.Nombre = nombreSocio, .NombreAlbum = nombreAlbum}
        Return motorPlantillas.RenderizarSeguro(plantilla, datos)
    End Function

End Class
