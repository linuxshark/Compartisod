Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class ClienteVentaMetadata

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Private _idCliente As Integer

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property RazonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property
    Private _razonSocial As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(11, MinimumLength:=11, ErrorMessageResourceName:="LongitudExacta", ErrorMessageResourceType:=GetType(Validaciones))> _
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property RUC() As String
        Get
            Return _rUC
        End Get
        Set(ByVal value As String)
            _rUC = value
        End Set
    End Property
    Private _rUC As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreFantasia() As String
        Get
            Return _nombreFantasia
        End Get
        Set(ByVal value As String)
            _nombreFantasia = value
        End Set
    End Property
    Private _nombreFantasia As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreCuenta() As String
        Get
            Return _nombreCuenta
        End Get
        Set(ByVal value As String)
            _nombreCuenta = value
        End Set
    End Property
    Private _nombreCuenta As String

    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaAniversario() As Nullable(Of Date)
        Get
            Return _FechaAniversario
        End Get
        Set(ByVal value As Nullable(Of Date))

            _FechaAniversario = value

        End Set
    End Property
    Private _FechaAniversario As Nullable(Of Date)

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaActivacion() As Date
        Get
            Return _fechaActivacion
        End Get
        Set(ByVal value As Date)
            _fechaActivacion = value
        End Set
    End Property
    Private _fechaActivacion As Date

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdClienteSector() As Nullable(Of Integer)
        Get
            Return _idClienteSector
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_idClienteSector, value) Then
                _idClienteSector = value
            End If
        End Set
    End Property
    Private _idClienteSector As Nullable(Of Integer)

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdClienteTipo() As Nullable(Of Integer)
        Get
            Return _idClienteTipo
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _idClienteTipo = value
        End Set
    End Property
    Private _idClienteTipo As Nullable(Of Integer)

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdClienteCategoria() As Nullable(Of Integer)
        Get
            Return _idClienteCategoria
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _idClienteCategoria = value
        End Set
    End Property
    Private _idClienteCategoria As Nullable(Of Integer)

    <StringLength(200, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)

            _calle = value

        End Set
    End Property
    Private _calle As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdDepartamento() As Nullable(Of Integer)
        Get
            Return _idDepartamento
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idDepartamento = value

        End Set
    End Property
    Private _idDepartamento As Nullable(Of Integer)


    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdProvincia() As Nullable(Of Integer)
        Get
            Return _idProvincia
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idProvincia = value

        End Set
    End Property
    Private _idProvincia As Nullable(Of Integer)

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdDistrito() As Nullable(Of Integer)
        Get
            Return _idDistrito
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idDistrito = value

        End Set
    End Property
    Private _idDistrito As Nullable(Of Integer)

    <StringLength(12, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    <RegularExpression("([0-9]+|\*|\-|\+|\#)+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloCaracteresTelefono")> _
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)

            _telefono = value

        End Set
    End Property
    Private _telefono As String

    <StringLength(12, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    <RegularExpression("([0-9]+|\*|\-|\+|\#)+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloCaracteresTelefono")> _
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)

            _fax = value

        End Set
    End Property
    Private _fax As String

    <StringLength(50, MinimumLength:=0, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property ProcedenciaCapital() As String
        Get
            Return _ProcedenciaCapital
        End Get
        Set(ByVal value As String)
            _ProcedenciaCapital = value
        End Set
    End Property
    Private _ProcedenciaCapital As String

    '<RegularExpression("/^(www)((\.[A-Z0-9][A-Z0-9_-]*)+.(com|pe|ch|col|org|net|dk|at|us|tv|info|uk|co.uk|biz|se)$)(:(\d+))?\/?/i", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="EmailCustom")> _
    '<RegularExpression("^[_A-Z0-9-]+(\.[_A-Z0-9-]+)*@[A-Z0-9-]+(\.[A-Z0-9-]+)*(\.[A-Z]{2,4})$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="EmailCustom")> _
    <RegularExpression("^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="EmailCustom")> _
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)

            _email = value
        End Set
    End Property
    Private _email As String



End Class
