Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts
Public Class ServicioClienteController
    Public Shared Function ConsultarClienteCategoria() As ListaClienteCategoria
        Return New ClienteCategoriaBusinessLogic().ConsultarClienteCategoria()
    End Function

    Public Shared Function ConsultarClienteSector() As ListaClienteSector
        Return New ClienteSectorBusinessLogic().ConsultarClienteSector()
    End Function

    Public Shared Function ConsultarEstado() As ListaProcesoEstado
        Return New ClienteBusinessLogic().ConsultarEstado()
    End Function


    Public Shared Function ConsultarClienteTipo() As ListaClienteTipo
        Return New ClienteTipoBusinessLogic().ConsultarClienteTipo()
    End Function

    Public Shared Function CrearCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Return New ClienteBusinessLogic().CrearCliente(oClienteVenta)
    End Function

    Public Shared Function ModificarCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Return New ClienteBusinessLogic().ModificarCliente(oClienteVenta)
    End Function

    Public Shared Function ConsultarClienteID(ByVal IdCliente As Int32) As ClienteVenta
        Return New ClienteBusinessLogic().ConsultarClienteID(IdCliente)
    End Function
    Public Shared Function ListaContactoTipo() As ListaContactoTipo
        Return New ClienteBusinessLogic().ListaContactoTipo()
    End Function
    Public Shared Function ListaContactoClase() As ListaContactoClase
        Return New ClienteBusinessLogic().ListaContactoClase()
    End Function

    Public Shared Function ListaClienteModoPago() As ListaClienteModoPagoCombo
        Return New ClienteBusinessLogic().ListaClienteModoPago
    End Function

    Public Shared Function ModificarClienteContacto(ByVal oClienteContacto As ClienteContacto) As Int32
        Return New ClienteBusinessLogic().ModificarClienteContacto(oClienteContacto)
    End Function

    Public Shared Function ActualizarClienteEstado(ByVal IdCliente As Integer, ByRef IdEstado As Integer, ByVal Activo As Boolean, ByVal Usuario As String) As Int32
        Return New ClienteBusinessLogic().ActualizarClienteEstado(IdCliente, IdEstado, Activo, Usuario)
    End Function

    Public Shared Function CrearClienteAdjunto(ByVal oClienteAdjunto As ClienteAdjunto)
        Return New ClienteBusinessLogic().CrearClienteAdjunto(oClienteAdjunto)
    End Function

    Public Shared Function ConsultarClienteAdjunto(ByRef oPaginacion As Paginacion) As Paginacion
        Return New ClienteBusinessLogic().ConsultarClienteAdjunto(oPaginacion)
    End Function

    Public Shared Function ConsultarClienteAdjuntoId(IdAdj As Integer) As ClienteAdjunto
        Return New ClienteBusinessLogic().ConsultarClienteAdjuntoId(IdAdj)
    End Function

    Public Shared Function EliminarClienteAdjunto(IdAdj As Integer) As Integer
        Return New ClienteBusinessLogic().EliminarClienteAdjunto(IdAdj)
    End Function

    Public Shared Function ObtenerClienteContactoPorId(IdContacto As Integer) As ClienteContacto
        Return New ClienteBusinessLogic().ObtenerClienteContactoPorId(IdContacto)
    End Function

    Public Shared Function ListaClienteTipo() As ListaClienteTipo
        Return New ClienteBusinessLogic().ListaClienteTipo
    End Function

    Public Shared Function ListarGrupo() As ListaGrupo
        Return New ClienteBusinessLogic().ListarGrupo()
    End Function

    Public Shared Function ListaTipoDocumentoCliente() As ListaTipodocumento
        Return New ClienteBusinessLogic().ListaTipoDocumentoCliente
    End Function
End Class