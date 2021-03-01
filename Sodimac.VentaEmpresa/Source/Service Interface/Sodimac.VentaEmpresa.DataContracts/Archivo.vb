Imports System
Imports System.ComponentModel.DataAnnotations
Partial Public Class Archivo

    Private idArchivos As Integer
    Private gUID_ As String
    Private contentType_ As String
    Private path_ As String
    Private name_ As String
    Private originalName_ As String
    Private size_ As Long
    Private data_ As Byte()
    Private fechaRegistro_ As System.DateTime
    Private activo_ As Boolean
    Private idObjetoRel_ As Integer
    Private idUsuarioRegistro_ As String
    Private objeto_ As Object

    Private IdJefeRRVV_ As Empleado
    Private Descripcion_ As String
    Private AprobadoPor_ As String
    Private IdUsuario_ As Usuario
    Private IdPeriodoComision_ As Integer


    Public Property IdArchivo As Integer
        Get
            Return idArchivos
        End Get
        Set(value As Integer)
            idArchivos = value
        End Set
    End Property

    Public Property IdPeriodoComision As Integer
        Get
            Return IdPeriodoComision_
        End Get
        Set(value As Integer)
            IdPeriodoComision_ = value
        End Set
    End Property

    Public Property IdJefeRRVV As Empleado
        Get
            Return IdJefeRRVV_
        End Get
        Set(value As Empleado)
            IdJefeRRVV_ = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return Descripcion_
        End Get
        Set(value As String)
            Descripcion_ = value
        End Set
    End Property

    Public Property AprobadoPor As String
        Get
            Return AprobadoPor_
        End Get
        Set(value As String)
            AprobadoPor_ = value
        End Set
    End Property

    Public Property IdUsuario As Usuario
        Get
            Return IdUsuario_
        End Get
        Set(value As Usuario)
            IdUsuario_ = value
        End Set
    End Property

    Public Property GUID As String
        Get
            Return gUID_
        End Get
        Set(value As String)
            gUID_ = value
        End Set
    End Property

    Public Property ContentType As String
        Get
            Return contentType_
        End Get
        Set(value As String)
            contentType_ = value
        End Set
    End Property

    Public Property Path As String
        Get
            Return path_
        End Get
        Set(value As String)
            path_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property

    Public Property OriginalName As String
        Get
            Return originalName_
        End Get
        Set(value As String)
            originalName_ = value
        End Set
    End Property

    Public Property Size As Long
        Get
            Return size_
        End Get
        Set(value As Long)
            size_ = value
        End Set
    End Property

    Public Property Data As Byte()
        Get
            Return data_
        End Get
        Set(value As Byte())
            data_ = value
        End Set
    End Property

    Public Property FechaRegistro As System.DateTime
        Get
            Return fechaRegistro_
        End Get
        Set(value As System.DateTime)
            fechaRegistro_ = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return activo_
        End Get
        Set(value As Boolean)
            activo_ = value
        End Set
    End Property

    Public Property IdObjetoRel As Integer
        Get
            Return idObjetoRel_
        End Get
        Set(value As Integer)
            idObjetoRel_ = value
        End Set
    End Property

    Public Property IdUsuarioRegistro As String
        Get
            Return idUsuarioRegistro_
        End Get
        Set(value As String)
            idUsuarioRegistro_ = value
        End Set
    End Property

    Public Property Objeto As Object
        Get
            Return objeto_
        End Get
        Set(value As Object)
            objeto_ = value
        End Set
    End Property
End Class
