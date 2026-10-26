Imports RazorEngine

''' <summary>
''' Motor de renderizado de plantillas de notificación. Es el segundo salto de la cadena
''' interprocedural que parte de Notificacion_Logic: Notificacion_Logic nunca llama a RazorEngine
''' directamente, delega en esta clase.
''' </summary>
Public Class PlantillaEngine

    ''' <summary>
    ''' PLANTED-VB-HR-678: CWE-1336 - compila y ejecuta como plantilla Razor un texto que llega aquí
    ''' procedente, en última instancia, del administrador (ver Notificacion_Logic.GenerarCuerpoNotificacion
    ''' y AdminController.EnviarAvisoPersonalizado). Cualquier bloque "@{ ... }" o expresión "@(...)"
    ''' que el administrador incluya en "plantillaTexto" se ejecuta con los privilegios del proceso.
    ''' </summary>
    Public Function Renderizar(ByVal plantillaTexto As String, ByVal datos As DatosNotificacion) As String
        Return RazorEngine.Razor.Parse(Of DatosNotificacion)(plantillaTexto, datos) ' SINK: PLANTED-VB-HR-678
    End Function

    ''' <summary>
    ''' PLANTED-VB-HR-678-safe: gemelo seguro - nunca compila ni ejecuta "plantillaTexto"; se limita a
    ''' sustituir de forma literal el conjunto cerrado de marcadores conocidos.
    ''' </summary>
    Public Function RenderizarSeguro(ByVal plantillaTexto As String, ByVal datos As DatosNotificacion) As String
        Return PlantillaSegura.Sustituir(plantillaTexto, datos) ' SAFE_SINK: PLANTED-VB-HR-678-safe
    End Function

End Class
