Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class EmpleadoPerfilMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdPerfil() As Nullable(Of Integer)
        Get
            Return _IdPerfil
        End Get
        Set(ByVal value As Nullable(Of Integer))
            ' If Not Equals(_IdZona, value) Then
            _IdPerfil = value
            '   End If
        End Set
    End Property
    Private _IdPerfil As Integer
End Class
