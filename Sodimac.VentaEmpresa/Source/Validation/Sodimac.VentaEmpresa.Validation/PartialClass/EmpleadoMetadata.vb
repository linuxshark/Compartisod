Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class EmpleadoMetadata


    Private m_IdEmpleadoCargoActual As Integer
    Private m_IdEmpleadoPerfilActual As Integer
    Private m_IdSucursalActual As Integer
    Private m_CodigoOfisis As String
    Private m_DNI As String
    Private m_Nombres As String
    Private m_Apellidos As String
    Private m_NombresApellidos As String
    Private m_FechaNacimiento As Nullable(Of Date)
    Private m_FechaContrato As Nullable(Of Date)
    Private m_Telefono As String
    Private m_Email As String
    Private m_Direccion As String
    Private _FechaIngreso As Date
    Private _FechaActivacion As Date
    Private _Celular1 As String
    Private _Celular2 As String
    ''variables agregadas
    Private _PlanVentas As Decimal
    Private _IngresoBasicoMensual As Decimal
    'Private m_UsuarioIngreso As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdEmpleadoCargoActual() As Integer
        Get
            Return m_IdEmpleadoCargoActual
        End Get
        Set(value As Integer)
            m_IdEmpleadoCargoActual = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdSucursalActual() As Integer
        Get
            Return m_IdSucursalActual
        End Get
        Set(value As Integer)
            m_IdSucursalActual = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(13, MinimumLength:=7, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property CodigoOfisis() As String
        Get
            Return m_CodigoOfisis
        End Get
        Set(value As String)
            m_CodigoOfisis = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(8, MinimumLength:=8, ErrorMessageResourceName:="LongitudExacta", ErrorMessageResourceType:=GetType(Validaciones))> _
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property DNI() As String
        Get
            Return m_DNI
        End Get
        Set(value As String)
            m_DNI = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(40, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property Nombres() As String
        Get
            Return m_Nombres
        End Get
        Set(value As String)
            m_Nombres = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(40, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property Apellidos() As String
        Get
            Return m_Apellidos
        End Get
        Set(value As String)
            m_Apellidos = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaNacimiento() As Nullable(Of Date)
        Get
            Return m_FechaNacimiento
        End Get
        Set(value As Nullable(Of Date))
            m_FechaNacimiento = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaContrato() As Nullable(Of Date)
        Get
            Return m_FechaContrato
        End Get
        Set(value As Nullable(Of Date))
            m_FechaContrato = value
        End Set
    End Property

    <StringLength(12, MinimumLength:=6, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    <RegularExpression("([0-9]+|\*|\-|\+|\#)+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloCaracteresTelefono")> _
    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(value As String)
            m_Telefono = value
        End Set
    End Property

    <RegularExpression("^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="EmailCustom")> _
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
        End Set
    End Property

    <StringLength(200, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property Direccion() As String
        Get
            Return m_Direccion
        End Get
        Set(value As String)
            m_Direccion = value
        End Set
    End Property

    <StringLength(12, MinimumLength:=6, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    <RegularExpression("([0-9]+|\*|\-|\+|\#)+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloCaracteresTelefono")> _
    Public Property Celular1() As String
        Get
            Return _Celular1
        End Get
        Set(ByVal value As String)
            _Celular1 = value
        End Set
    End Property

    <StringLength(12, MinimumLength:=6, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    <RegularExpression("([0-9]+|\*|\-|\+|\#)+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloCaracteresTelefono")> _
    Public Property Celular2() As String
        Get
            Return _Celular2
        End Get
        Set(ByVal value As String)
            _Celular2 = value
        End Set
    End Property

    '<Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    ' Public Property UsuarioIngreso() As String
    '    Get
    '        Return m_UsuarioIngreso
    '    End Get
    '    Set(ByVal value As String)
    '        m_UsuarioIngreso = value
    '    End Set
    'End Property

    '<Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    'Public Property IdPerfil() As Nullable(Of Integer)
    '    Get
    '        Return _IdPerfil
    '    End Get
    '    Set(ByVal value As Nullable(Of Integer))
    '        _IdPerfil = value
    '    End Set
    'End Property
    'Private _IdPerfil As Integer
    '<Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    'Public Property IdZona() As Nullable(Of Integer)
    '    Get
    '        Return _IdZona
    '    End Get
    '    Set(ByVal value As Nullable(Of Integer))
    '        ' If Not Equals(_IdZona, value) Then
    '        _IdZona = value
    '        '   End If
    '    End Set
    'End Property
    'Private _IdZona As Integer

End Class
