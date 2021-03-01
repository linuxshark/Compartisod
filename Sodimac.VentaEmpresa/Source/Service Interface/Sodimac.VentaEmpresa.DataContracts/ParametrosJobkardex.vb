Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ParametrosJobkardex")> _
Public Class ParametrosJobkardex

    Private schedulenameField As String
    Private freqtypeField As Integer
    Private freqintervalField As Integer
    Private activestartdateField As System.DateTime
    Private activeenddateField As Integer
    Private activestarttimeField As System.TimeSpan
    Private activeendtimeField As Integer


    <WcfSerialization.DataMember(Name:="schedulename", IsRequired:=False, Order:=0)> _
    Public Property schedulename() As String
        Get
            Return schedulenameField
        End Get
        Set(value As String)
            schedulenameField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="freqtype", IsRequired:=False, Order:=1)> _
    Public Property freqtype() As Integer
        Get
            Return freqtypeField
        End Get
        Set(value As Integer)
            freqtypeField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="freqinterval", IsRequired:=False, Order:=2)> _
    Public Property freqinterval() As Integer
        Get
            Return freqintervalField
        End Get
        Set(value As Integer)
            freqintervalField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="activestartdate", IsRequired:=False, Order:=3)> _
    Public Property activestartdate() As System.DateTime
        Get
            Return activestartdateField
        End Get
        Set(value As System.DateTime)
            activestartdateField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="activeenddate", IsRequired:=False, Order:=4)> _
    Public Property activeenddate() As Integer
        Get
            Return activeenddateField
        End Get
        Set(value As Integer)
            activeenddateField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="activestarttime", IsRequired:=False, Order:=5)> _
    Public Property activestarttime() As System.TimeSpan
        Get
            Return activestarttimeField
        End Get
        Set(value As System.TimeSpan)
            activestarttimeField = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="activeendtime", IsRequired:=False, Order:=6)> _
    Public Property activeendtime() As Integer
        Get
            Return activeendtimeField
        End Get
        Set(value As Integer)
            activeendtimeField = value
        End Set
    End Property

End Class
