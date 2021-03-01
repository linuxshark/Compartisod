﻿Imports System.Web.Mvc

Imports Sodimac.VentaEmpresa.Web.Mvc

Imports Microsoft.VisualStudio.TestTools.UnitTesting.Web

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc



'''<summary>
'''This is a test class for ClienteControllerTest and is intended
'''to contain all ClienteControllerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ClienteControllerTest


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


    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for NuevaCarteraCliente_
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub NuevaCarteraCliente_Test()
        Dim target As ClienteController = New ClienteController() ' TODO: Initialize to an appropriate value
        Dim oClientesViewModel As ClientesViewModel = Nothing ' TODO: Initialize to an appropriate value
        oClientesViewModel.VentaCartera.IdCliente = 6682
        oClientesViewModel.VentaCartera.IdEmpleado = oClientesViewModel.Empleado.IdEmpleado
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.NuevaCarteraCliente_(oClientesViewModel)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
