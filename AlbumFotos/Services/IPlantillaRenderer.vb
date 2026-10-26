''' <summary>
''' Contrato común para los distintos motores de renderizado de plantillas de notificación. Esta es
''' la única interfaz/jerarquía polimórfica de todo el proyecto PhotoArt (no existía ninguna
''' MustInherit/Interface previa en el código base; ver la encuesta en el documento de investigación
''' de planting, sección "Conditions/Edge Cases"). Se introduce específicamente para dar soporte al
''' nivel de dificultad "type/polymorphism-dependent" de esta ronda de planting de CWE-1336.
''' </summary>
Public Interface IPlantillaRenderer
    Function Render(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String
End Interface
