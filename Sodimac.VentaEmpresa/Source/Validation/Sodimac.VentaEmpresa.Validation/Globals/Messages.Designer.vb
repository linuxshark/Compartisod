﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18052
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Public Class Messages
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Sodimac.VentaEmpresa.Validation.Messages", GetType(Messages).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Se actualizó correctamente.
    '''</summary>
    Public Shared ReadOnly Property Actualizacion_Correcta() As String
        Get
            Return ResourceManager.GetString("Actualizacion_Correcta", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ocurrió un error mientras se realizaba la actualización.
    '''</summary>
    Public Shared ReadOnly Property Actualizacion_Incorrecta() As String
        Get
            Return ResourceManager.GetString("Actualizacion_Incorrecta", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Se autorizaron correctamente.
    '''</summary>
    Public Shared ReadOnly Property Autorizacion_Correcta() As String
        Get
            Return ResourceManager.GetString("Autorizacion_Correcta", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mensaje de Aviso.
    '''</summary>
    Public Shared ReadOnly Property Aviso() As String
        Get
            Return ResourceManager.GetString("Aviso", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to ¿ Desea actualizar el registro ?.
    '''</summary>
    Public Shared ReadOnly Property Confirmacion_Actualizar() As String
        Get
            Return ResourceManager.GetString("Confirmacion_Actualizar", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to ¿ Desea cancelar el registro ?.
    '''</summary>
    Public Shared ReadOnly Property Confirmacion_Cancelar() As String
        Get
            Return ResourceManager.GetString("Confirmacion_Cancelar", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to ¿ Desea eliminar el registro ?.
    '''</summary>
    Public Shared ReadOnly Property Confirmacion_Eliminar() As String
        Get
            Return ResourceManager.GetString("Confirmacion_Eliminar", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to ¿ Desea generar el registro ?.
    '''</summary>
    Public Shared ReadOnly Property Confirmacion_Registrar() As String
        Get
            Return ResourceManager.GetString("Confirmacion_Registrar", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mensaje de Confirmación.
    '''</summary>
    Public Shared ReadOnly Property Confirmacion_Titulo() As String
        Get
            Return ResourceManager.GetString("Confirmacion_Titulo", resourceCulture)
        End Get
    End Property
End Class
