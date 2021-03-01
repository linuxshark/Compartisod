Imports Sodimac.VentaEmpresa.DataContracts

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Sodimac.VentaEmpresa.BusinessLogic



'''<summary>
'''This is a test class for ClienteBusinessLogicTest and is intended
'''to contain all ClienteBusinessLogicTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ClienteBusinessLogicTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for CrearCarteraSecundariaClientes
    '''</summary>
    <TestMethod()> _
    Public Sub CrearCarteraSecundariaClientesTest()
        Dim oSiLog As Boolean = False ' TODO: Initialize to an appropriate value
        Dim oLog As New Log  ' TODO: Initialize to an appropriate value
        Dim target As ClienteBusinessLogic = New ClienteBusinessLogic(oSiLog, oLog) ' TODO: Initialize to an appropriate value
        Dim ventaCartera As New VentaCartera ' TODO: Initialize to an appropriate value
        ventaCartera.IdCliente = 6682
        ventaCartera.IdEmpleado = 70

        Dim paginacion As New Paginacion ' TODO: Initialize to an appropriate value
        paginacion.ListaSucursal = New ListaSucursal
        paginacion.ListaSucursal.Add(New Sucursal With {.IdSucursal = 5, .FechaAsignacion = Date.Now, .Porcentaje = 50})
        paginacion.ListaSucursal.Add(New Sucursal With {.IdSucursal = 5, .FechaAsignacion = Date.Now, .Porcentaje = 60})
        Dim expected As Integer = 1 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = target.CrearCarteraSecundariaClientes(ventaCartera, paginacion)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
