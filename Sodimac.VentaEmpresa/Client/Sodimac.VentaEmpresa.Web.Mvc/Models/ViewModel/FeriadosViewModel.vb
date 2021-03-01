Imports Sodimac.VentaEmpresa.DataContracts

Namespace Models.ViewModel
    Public Class FeriadosViewModel
        Inherits Parameters

        Private _Feriados As Feriados
        Public Property Feriados() As Feriados
            Get
                Return _Feriados
            End Get
            Set(ByVal value As Feriados)
                _Feriados = value
            End Set
        End Property

        Private _ListaFeriados As List(Of Feriados)
        Public Property ListaFeriados() As List(Of Feriados)
            Get
                Return _ListaFeriados
            End Get
            Set(ByVal value As List(Of Feriados))
                _ListaFeriados = value
            End Set
        End Property

        Private _Paginacion As Paginacion
        Public Property Paginacion() As Paginacion
            Get
                Return _Paginacion
            End Get
            Set(ByVal value As Paginacion)
                _Paginacion = value
            End Set
        End Property

        Private _ListaMes As List(Of Mes)
        Public Property ListaMes() As List(Of Mes)
            Get
                Return _ListaMes
            End Get
            Set(ByVal value As List(Of Mes))
                _ListaMes = value
            End Set
        End Property

        Private _ListaEstado As List(Of Activo)
        Public Property ListaEstado() As List(Of Activo)
            Get
                Return _ListaEstado
            End Get
            Set(ByVal value As List(Of Activo))
                _ListaEstado = value
            End Set
        End Property

        Private _MesMulti As String
        Public Property MesMulti() As String
            Get
                Return _MesMulti
            End Get
            Set(ByVal value As String)
                _MesMulti = value
            End Set
        End Property

        Private _OpcionModalidad As Boolean
        Public Property OpcionModalidad() As Boolean
            Get
                Return _OpcionModalidad
            End Get
            Set(ByVal value As Boolean)
                _OpcionModalidad = value
            End Set
        End Property

        Private _Estado As String
        Public Property Estado() As String
            Get
                Return _Estado
            End Get
            Set(ByVal value As String)
                _Estado = value
            End Set
        End Property

    End Class
End Namespace