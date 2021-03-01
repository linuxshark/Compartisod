Imports Sodimac.VentaEmpresa.DataContracts
Namespace Models.ViewModel

    Public Class ProveedorViewModel
        Inherits Parameters

        Private _Proveedor As Proveedor
        Public Property Proveedor() As Proveedor
            Get
                Return _Proveedor
            End Get
            Set(ByVal value As Proveedor)
                _Proveedor = value
            End Set
        End Property

        Private _Producto As Producto
        Public Property Producto() As Producto
            Get
                Return _Producto
            End Get
            Set(ByVal value As Producto)
                _Producto = value
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

        Private _ListaProveedor As List(Of Proveedor)
        Public Property ListaProveedor() As List(Of Proveedor)
            Get
                Return _ListaProveedor
            End Get
            Set(ByVal value As List(Of Proveedor))
                _ListaProveedor = value
            End Set
        End Property

        Private _ListaEmpresa As List(Of Empresa)
        Public Property ListaEmpresa() As List(Of Empresa)
            Get
                Return _ListaEmpresa
            End Get
            Set(ByVal value As List(Of Empresa))
                _ListaEmpresa = value
            End Set
        End Property

        Private _ListaEstado As List(Of EstadoProveedor)
        
        Public Property ListaEstado() As List(Of EstadoProveedor)
            Get
                Return _ListaEstado
            End Get
            Set(ByVal value As List(Of EstadoProveedor))
                _ListaEstado = value
            End Set
        End Property


        Private _EmpresaDescripcion As String
        Public Property EmpresaDescripcion() As String
            Get
                Return _EmpresaDescripcion
            End Get
            Set(ByVal value As String)
                _EmpresaDescripcion = value
            End Set
        End Property

        Private _ListaProducto As List(Of Producto)
        Public Property ListaProducto() As List(Of Producto)
            Get
                Return _ListaProducto
            End Get
            Set(value As List(Of Producto))
                _ListaProducto = value
            End Set
        End Property

    End Class

End Namespace
