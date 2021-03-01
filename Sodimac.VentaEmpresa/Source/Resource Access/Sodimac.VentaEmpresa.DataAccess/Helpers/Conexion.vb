Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class Conexion
    Public Shared cnsSql As String = "cnSodimac"
    Public Shared cnsSqlAsync As String = "cnSodimacAsync"
    Public Shared cnsSqlSeguridad As String = "cnSodimacSeguridad"

    '************* Nueva Conexion *************
    'Public Shared cnsSqls As ConnectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings("cnSodimac")
    ''cnsSqls = System.Configuration.ConfigurationManager.ConnectionStrings("cnSodimac")
    'Public Shared cnsSql As String = cnsSqls.ConnectionString

    ''**************  *************

    'Public Shared cnsSqlSeguridads As ConnectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings("cnSodimacSeguridad")
    ''cnsSqls = System.Configuration.ConfigurationManager.ConnectionStrings("cnSodimac")
    'Public Shared cnsSqlSeguridad As String = cnsSqlSeguridads.ConnectionString



End Class