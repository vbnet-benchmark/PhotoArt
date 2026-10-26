''' <summary>
''' Modelo de formulario para que el administrador componga una notificación. "CuerpoPlantilla" es
''' texto libre (un &lt;textarea&gt;, nunca una lista desplegable) que el administrador puede llenar
''' con marcadores de posición (p. ej. "{{Nombre}}") pensando que es texto estático - en las acciones
''' vulnerables de AdminController se trata en cambio como código Razor y se compila y ejecuta.
''' </summary>
Public Class PlantillaNotificacion
    Public Property Asunto As String
    Public Property CuerpoPlantilla As String
End Class
