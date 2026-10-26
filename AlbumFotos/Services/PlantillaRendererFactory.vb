Imports System.Configuration

''' <summary>
''' Resuelve, en tiempo de ejecución, qué implementación de IPlantillaRenderer se debe usar. La
''' decisión se basa únicamente en el indicador de configuración "MotorPlantillaAvanzado" de
''' Web.config - no hay ningún control de interfaz de usuario (desplegable, lista, etc.) involucrado
''' en esta decisión, solo un ajuste de configuración del servidor.
''' </summary>
Public Class PlantillaRendererFactory

    Public Shared Function ObtenerRenderer() As IPlantillaRenderer
        Dim motorAvanzadoHabilitado As String = ConfigurationManager.AppSettings("MotorPlantillaAvanzado")
        If String.Equals(motorAvanzadoHabilitado, "true", StringComparison.OrdinalIgnoreCase) Then
            Return New RazorPlantillaRenderer
        Else
            Return New PlantillaSeguraRenderer
        End If
    End Function

End Class
