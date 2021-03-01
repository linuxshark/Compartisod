Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Common

Public Class UtilWebGrid
    Public Shared Function ContadorRegistrosWebGrid(pageIndex As Integer, pageSize As Integer, rowCount As Integer) As String
        Dim strContador As String
        Dim registroInicio As Integer, registroFin As Integer
        Dim pageCount As Integer
        If pageIndex > 0 Then
            pageIndex -= 1
        End If
        If pageIndex = -1 Then
            pageIndex = 0
        End If
        Dim temp As Decimal = Convert.ToDecimal(rowCount) / Convert.ToDecimal(pageSize)
        If temp > Convert.ToInt32(rowCount \ pageSize) Then
            pageCount = Convert.ToInt32(rowCount \ pageSize) + 1
        Else
            pageCount = Convert.ToInt32(rowCount \ pageSize)
        End If

        registroInicio = (pageIndex * pageSize) + 1

        If rowCount <= 0 Then
            strContador = ""
        ElseIf rowCount = 1 Then
            strContador = " Un registro encontrado."
        Else
            registroInicio = (pageIndex * pageSize) + 1

            If pageIndex + 1 < pageCount Then
                registroFin = (pageIndex + 1) * pageSize
            Else
                registroFin = rowCount
            End If

            strContador = " [" & rowCount.ToString() & "] registros encontrados, mostrando del [" & registroInicio.ToString() & "] al [" & registroFin.ToString() & "]"
        End If
        Return strContador
    End Function

    Public Shared Function Paginacion_PorDefecto() As Paginacion
        Dim oPaginacion As New Paginacion
        oPaginacion.PageNumber = Constantes.FirstPage
        oPaginacion.PageSize = Constantes.RowsPerPage
        oPaginacion.SortBy = Constantes.ValorDefecto
        oPaginacion.SortType = Constantes.ValorDefecto
        oPaginacion.TotalRows = Constantes.ValorCero
        Return oPaginacion
    End Function
End Class

