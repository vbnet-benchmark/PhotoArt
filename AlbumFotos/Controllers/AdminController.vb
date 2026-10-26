Imports RazorEngine

Public Class AdminController
    Inherits System.Web.Mvc.Controller
    Dim m As New AlbumFotos.PhotoArtEntities

    '
    ' GET: /Admin

    Function Index() As ActionResult
        Return View()
    End Function

    Function AdministrarUsuarios() As ActionResult
        ' m.Usuarios.
        'm.SaveChanges()

        Return View()
    End Function

    '
    ' GET: /Admin/ComponerNotificacion
    ' Formulario libre (textarea) donde el administrador escribe el asunto y el cuerpo de la
    ' plantilla de notificación que se enviará/previsualizará a través de las acciones siguientes.

    Function ComponerNotificacion() As ActionResult
        Return View()
    End Function

    ' ------------------------------------------------------------------
    ' Nivel DIRECTO (PLANTED-VB-HR-676 / -safe)
    ' ------------------------------------------------------------------

    <HttpPost()> _
    Function PrevisualizarNotificacion(ByVal miPlantilla As PlantillaNotificacion) As ActionResult
        Dim datos As New DatosNotificacion With {.Nombre = CType(Session.Item("Nick"), String), .NombreAlbum = "Mi Álbum"}
        ' PLANTED-VB-HR-676: CWE-1336 - compila y ejecuta directamente, sin ningún ayudante
        ' intermedio, el texto de plantilla que acaba de escribir el administrador en el formulario.
        Dim htmlRenderizado As String = RazorEngine.Razor.Parse(Of DatosNotificacion)(miPlantilla.CuerpoPlantilla, datos) ' SINK: PLANTED-VB-HR-676
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    <HttpPost()> _
    Function PrevisualizarNotificacionSegura(ByVal miPlantilla As PlantillaNotificacion) As ActionResult
        Dim datos As New DatosNotificacion With {.Nombre = CType(Session.Item("Nick"), String), .NombreAlbum = "Mi Álbum"}
        ' PLANTED-VB-HR-676-safe: gemelo seguro - sustitución literal de marcadores, nunca se compila
        ' ni se ejecuta el texto del administrador.
        Dim htmlRenderizado As String = PlantillaSegura.Sustituir(miPlantilla.CuerpoPlantilla, datos) ' SAFE_SINK: PLANTED-VB-HR-676-safe
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    ' ------------------------------------------------------------------
    ' Nivel INDIRECTO (PLANTED-VB-HR-677 / -safe) - un salto a través de un ayudante privado de la
    ' misma clase.
    ' ------------------------------------------------------------------

    <HttpPost()> _
    Function EnviarNotificacionSocio(ByVal miPlantilla As PlantillaNotificacion, ByVal nickDestino As String) As ActionResult
        Dim datos As New DatosNotificacion With {.Nombre = nickDestino, .NombreAlbum = "Álbum compartido"}
        Dim htmlRenderizado As String = RenderizarPlantillaNotificacion(miPlantilla.CuerpoPlantilla, datos)
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    <HttpPost()> _
    Function EnviarNotificacionSocioSegura(ByVal miPlantilla As PlantillaNotificacion, ByVal nickDestino As String) As ActionResult
        Dim datos As New DatosNotificacion With {.Nombre = nickDestino, .NombreAlbum = "Álbum compartido"}
        Dim htmlRenderizado As String = RenderizarPlantillaNotificacionSegura(miPlantilla.CuerpoPlantilla, datos)
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    ''' <summary>
    ''' PLANTED-VB-HR-677: CWE-1336 - la acción pública de más arriba delega en este ayudante privado
    ''' de la misma clase, que es quien realmente compila y ejecuta la plantilla del administrador.
    ''' </summary>
    Private Function RenderizarPlantillaNotificacion(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String
        Return RazorEngine.Razor.Parse(Of DatosNotificacion)(plantilla, datos) ' SINK: PLANTED-VB-HR-677
    End Function

    ''' <summary>
    ''' PLANTED-VB-HR-677-safe: gemelo seguro del ayudante privado anterior.
    ''' </summary>
    Private Function RenderizarPlantillaNotificacionSegura(ByVal plantilla As String, ByVal datos As DatosNotificacion) As String
        Return PlantillaSegura.Sustituir(plantilla, datos) ' SAFE_SINK: PLANTED-VB-HR-677-safe
    End Function

    ' ------------------------------------------------------------------
    ' Nivel INTERPROCEDURAL (PLANTED-VB-HR-678 / -safe) - el sumidero real vive dos saltos más abajo,
    ' en Services\PlantillaEngine.vb, a través de Services\NotificacionLogic.vb.
    ' ------------------------------------------------------------------

    <HttpPost()> _
    Function EnviarAvisoPersonalizado(ByVal miPlantilla As PlantillaNotificacion, ByVal nickDestino As String) As ActionResult
        Dim logicaNotificacion As New Notificacion_Logic
        Dim htmlRenderizado As String = logicaNotificacion.GenerarCuerpoNotificacion(miPlantilla.CuerpoPlantilla, nickDestino, "Álbum compartido")
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    <HttpPost()> _
    Function EnviarAvisoPersonalizadoSeguro(ByVal miPlantilla As PlantillaNotificacion, ByVal nickDestino As String) As ActionResult
        Dim logicaNotificacion As New Notificacion_Logic
        Dim htmlRenderizado As String = logicaNotificacion.GenerarCuerpoNotificacionSegura(miPlantilla.CuerpoPlantilla, nickDestino, "Álbum compartido")
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    ' ------------------------------------------------------------------
    ' Nivel TYPE/POLYMORPHISM-DEPENDENT (PLANTED-VB-HR-679 / -safe) - la implementación concreta que
    ' PlantillaRendererFactory devuelve depende únicamente del ajuste "MotorPlantillaAvanzado" de
    ' Web.config; no hay ninguna bifurcación visible en este punto de llamada.
    ' ------------------------------------------------------------------

    <HttpPost()> _
    Function EnviarNotificacionPersonalizada(ByVal miPlantilla As PlantillaNotificacion, ByVal nickDestino As String) As ActionResult
        Dim datos As New DatosNotificacion With {.Nombre = nickDestino, .NombreAlbum = "Álbum compartido"}
        Dim renderer As IPlantillaRenderer = PlantillaRendererFactory.ObtenerRenderer()
        Dim htmlRenderizado As String = renderer.Render(miPlantilla.CuerpoPlantilla, datos)
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("CuerpoRenderizado") = htmlRenderizado
        Return View("PrevisualizarNotificacion")
    End Function

    ' ------------------------------------------------------------------
    ' Nivel DIVERSIDAD (PLANTED-VB-HR-680 / -safe) - la misma plantilla del administrador se compila
    ' y renderiza una vez por cada destinatario dentro de un bucle por lotes.
    ' ------------------------------------------------------------------

    <HttpPost()> _
    Function EnviarNotificacionMasiva(ByVal miPlantilla As PlantillaNotificacion) As ActionResult
        Dim resultados As New List(Of String)
        For Each socio As Usuarios In m.Usuarios.Where(Function(u) u.rol = "socio" AndAlso u.baja = "no").ToList()
            Dim datos As New DatosNotificacion With {.Nombre = socio.nick, .NombreAlbum = "Álbum compartido"}
            ' PLANTED-VB-HR-680: CWE-1336 - dentro del bucle, la plantilla del administrador se
            ' vuelve a compilar y ejecutar una vez por cada socio activo.
            Dim htmlRenderizado As String = RazorEngine.Razor.Parse(Of DatosNotificacion)(miPlantilla.CuerpoPlantilla, datos) ' SINK: PLANTED-VB-HR-680
            resultados.Add(htmlRenderizado)
        Next
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("ResultadosRenderizados") = resultados
        Return View("PrevisualizarNotificacionMasiva")
    End Function

    <HttpPost()> _
    Function EnviarNotificacionMasivaSegura(ByVal miPlantilla As PlantillaNotificacion) As ActionResult
        Dim resultados As New List(Of String)
        For Each socio As Usuarios In m.Usuarios.Where(Function(u) u.rol = "socio" AndAlso u.baja = "no").ToList()
            Dim datos As New DatosNotificacion With {.Nombre = socio.nick, .NombreAlbum = "Álbum compartido"}
            ' PLANTED-VB-HR-680-safe: gemelo seguro - sustitución literal de marcadores en el bucle.
            Dim htmlRenderizado As String = PlantillaSegura.Sustituir(miPlantilla.CuerpoPlantilla, datos) ' SAFE_SINK: PLANTED-VB-HR-680-safe
            resultados.Add(htmlRenderizado)
        Next
        ViewData("Asunto") = miPlantilla.Asunto
        ViewData("ResultadosRenderizados") = resultados
        Return View("PrevisualizarNotificacionMasiva")
    End Function

End Class