Public Interface IComisionDataAccess

    'Function ListaNombrePeriodo() As DataContracts.ListaNombrePeriodo

    'Function ListaComisionPeriodo(oComisionPeriodo As DataContracts.ComisionPeriodo, PageSize As Integer, PageNumber As Integer, SortBy As String, SortType As String, TotalRows As Integer) As DataContracts.ListaComisionPeriodo

    Function ListaComisionPeriodo(oPaginacion As DataContracts.Paginacion) As DataContracts.Paginacion

End Interface
