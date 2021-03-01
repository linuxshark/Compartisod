Imports Sodimac.VentaEmpresa.Web.Mvc

Imports System.Web.Mvc

Imports Microsoft.VisualStudio.TestTools.UnitTesting.Web

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc



'''<summary>
'''This is a test class for ProcesoControllerTest and is intended
'''to contain all ProcesoControllerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProcesoControllerTest


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
    '''A test for ProcesoController Constructor
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ProcesoControllerConstructorTest()
        Dim target As ProcesoController = New ProcesoController()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ActualizarComisionesManual
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ActualizarComisionesManualTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim IdCarga As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ActualizarComisionesManual(IdCarga)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ActualizarEstadoCarga
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ActualizarEstadoCargaTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim IDCarga As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim IdEstado As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ActualizarEstadoCarga(IDCarga, IdEstado)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for AdjuntarDataMensualAsync
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub AdjuntarDataMensualAsyncTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim oViewModelProceso As ProcesoViewModel = Nothing ' TODO: Initialize to an appropriate value
        target.AdjuntarDataMensualAsync(oViewModelProceso)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for AdjuntarDataMensualCompleted
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub AdjuntarDataMensualCompletedTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim oViewModelProceso As ProcesoViewModel = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.AdjuntarDataMensualCompleted(oViewModelProceso)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for BorrarFilasVacias
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub BorrarFilasVaciasTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for CalcularValores
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub CalcularValoresTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for CierrePeriodo
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub CierrePeriodoTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.CierrePeriodo
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsClienteValido
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub EsClienteValidoTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsEntero
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub EsEnteroTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim pNumero As String = "304" ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.EsEntero(pNumero)
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsMonedaValida
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub EsMonedaValidaTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsProductoValido
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub EsProductoValidoTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsTipoDocumentoValido
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub EsTipoDocumentoValidoTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for Finalize
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub FinalizeTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ImportarArchivos
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ImportarArchivosTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ImportarArchivos
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for Index
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub IndexTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.Index
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for LeerArchivoExcel
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/"), _
     DeploymentItem("Sodimac.VentaEmpresa.Web.Mvc.dll")> _
    Public Sub LeerArchivoExcelTest()
        'Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
        Assert.Inconclusive("Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSy" & _
                "mbols.Assembly' failed")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ObtenerResultadoReproceso
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ObtenerResultadoReprocesoTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ObtenerResultadoReproceso
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for PV_Errores
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub PV_ErroresTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.PV_Errores
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for PV_Historial
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub PV_HistorialTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim sort As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim page As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim sortdir As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.PV_Historial(sort, page, sortdir)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for QuitarEstadohistorialCarga
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub QuitarEstadohistorialCargaTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim IDCarga As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim IdEstadoA As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.QuitarEstadohistorialCarga(IDCarga, IdEstadoA)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ReprocesoVentas
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ReprocesoVentasTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ReprocesoVentas
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ReprocesoVentas_
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ReprocesoVentas_Test()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim IdZona As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim IdSucursal As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim FechaInicio As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim FechaFin As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.ReprocesoVentas_(IdZona, IdSucursal, FechaInicio, FechaFin)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for UpdVentasCotizacion
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub UpdVentasCotizacionTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.UpdVentasCotizacion
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ValidarFecha
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ValidarFechaTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim pFecha As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.ValidarFecha(pFecha)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for ValidarNumero
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub ValidarNumeroTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim pNumero As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.ValidarNumero(pNumero)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for VerDetalleHistorial
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub VerDetalleHistorialTest()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim IDCarga As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As ActionResult = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ActionResult
        actual = target.VerDetalleHistorial(IDCarga)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for EsEntero
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("E:\Sodimac\SFSodimacVentaEmpresa\Sodimac.VentaEmpresa\Sodimac.VentaEmpresa\Client\Sodimac.VentaEmpresa.Web.Mvc", "/"), _
     UrlToTest("http://localhost:61531/")> _
    Public Sub EsEnteroTest1()
        Dim target As ProcesoController = New ProcesoController() ' TODO: Initialize to an appropriate value
        Dim pNumero As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.EsEntero(pNumero)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
