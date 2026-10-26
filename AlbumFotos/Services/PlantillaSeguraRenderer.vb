''' <summary>
''' Implementación SEGURA de IPlantillaRenderer: nunca compila ni ejecuta "plantilla", se limita a la
''' sustitución literal de marcadores de PlantillaSegura. Es la que entrega PlantillaRendererFactory
''' cuando el indicador de configuración del motor avanzado está deshabilitado.
''' </summary>
Public Class PlantillaSeguraRenderer
    Implements IPlantillaRenderer

    ''' <summary>
    ''' PLANTED-VB-HR-679-safe: gemelo seguro del despacho polimórfico - misma interfaz, mismo punto de
    ''' llamada, pero esta implementación nunca invoca a RazorEngine.
    ''' </summary>
    Public Function Render(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String Implements IPlantillaRenderer.Render
        Return PlantillaSegura.Sustituir(plantilla, datos) ' SAFE_SINK: PLANTED-VB-HR-679-safe
    End Function

End Class
