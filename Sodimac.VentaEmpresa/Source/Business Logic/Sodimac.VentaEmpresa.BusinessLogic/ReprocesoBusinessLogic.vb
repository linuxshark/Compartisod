
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess
Imports System.Transactions
Imports System.Configuration
Imports Sodimac.VentaEmpresa.Common.Constantes
Public Class ReprocesoBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Function ListarReprocesoBoletas(oBoletas As ProcesoCarga) As ListaProcesoCarga
        Dim oLista As New ListaProcesoCarga
        oLista = New ReprocesoDataAccess().ListarReprocesoBoletas(oBoletas)
        Return oLista
    End Function
    Public Function RegistraBoletas(lstCliente As ListaProcesoCarga) As Integer
        Return New ReprocesoDataAccess().RegistraBoletas(lstCliente)
    End Function
    Public Function RegistrarRBoletas(oEmpleado As ProcesoCarga) As Integer
        Return New ReprocesoDataAccess().RegistrarRBoletas(oEmpleado)
    End Function
    Public Function EliminarRBoletas(oEmpleado As ProcesoCarga) As Integer
        Return New ReprocesoDataAccess().EliminarRBoletas(oEmpleado)
    End Function
End Class
