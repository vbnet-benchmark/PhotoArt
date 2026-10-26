Imports RazorEngine

''' <summary>
''' Implementación de IPlantillaRenderer respaldada por RazorEngine (motor "avanzado"). Esta clase
''' solo se instancia cuando PlantillaRendererFactory decide, en tiempo de ejecución, que el motor
''' avanzado está habilitado - ver PlantillaRendererFactory.ObtenerRenderer.
''' </summary>
Public Class RazorPlantillaRenderer
    Implements IPlantillaRenderer

    ''' <summary>
    ''' PLANTED-VB-HR-679: CWE-1336 - el despacho polimórfico (resuelto en PlantillaRendererFactory en
    ''' función de un indicador de configuración) puede entregar en tiempo de ejecución esta
    ''' implementación, que compila y ejecuta "plantilla" como una plantilla Razor real. En el punto de
    ''' llamada (AdminController.EnviarNotificacionPersonalizada) la variable solo se conoce como
    ''' IPlantillaRenderer y no hay ninguna bifurcación visible entre esta implementación y la segura.
    '''
    ''' Se genera una clave de plantilla nueva (Guid) en cada llamada para evitar que la caché interna
    ''' de RazorEngine devuelva una plantilla ya compilada con una clave reutilizada en lugar de
    ''' recompilar el texto recién recibido (ver la nota de caché en el documento de investigación).
    ''' </summary>
    Public Function Render(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String Implements IPlantillaRenderer.Render
        Dim claveUnica As String = "plantillaNotificacion_" & Guid.NewGuid().ToString("N")
        Return RazorEngine.Engine.Razor.RunCompile(Of DatosNotificacion)(plantilla, claveUnica, GetType(DatosNotificacion), datos) ' SINK: PLANTED-VB-HR-679
    End Function

End Class
