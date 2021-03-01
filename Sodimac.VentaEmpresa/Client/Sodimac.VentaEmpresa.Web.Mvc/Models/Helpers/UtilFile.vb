Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Common
Imports System.IO

Public Class UtilFile

    Private Shared oFileAttach As FileAttached

    Public Shared Function ServerPath(relativePath As String) As String
        Return System.Web.HttpContext.Current.Server.MapPath(relativePath)
    End Function

    Public Shared Function GetFileFromFileAttached(oFileAttached As FileAttached) As Archivo
        oFileAttached.Archivo = New Archivo()
        Dim Data(0 To oFileAttached.File.ContentLength - 1) As Byte
        'oFileAttached.File.InputStream.Read(Data, Constantes.ValorCero, oFileAttached.File.ContentLength)
        oFileAttached.Archivo.ContentType = oFileAttached.File.ContentType
        oFileAttached.Archivo.Path = Constantes.ValorDefecto
        oFileAttached.Archivo.OriginalName = oFileAttached.File.FileName
        oFileAttached.Archivo.Size = oFileAttached.File.ContentLength
        oFileAttached.Archivo.Data = Data
        oFileAttached.Archivo.FechaRegistro = DateTime.Now
        oFileAttached.Archivo.Activo = True

        Return oFileAttached.Archivo

    End Function

    Public Shared Function SaveFileFromFileAttached(oFileAttached As FileAttached, oArchivo As Archivo, Server As HttpServerUtilityBase, Code As Integer) As FileTile
        oFileAttached.FileTile = New FileTile()
        oFileAttached.Archivo = New Archivo()
        oFileAttached.Archivo.OriginalName = oFileAttached.File.FileName
        Dim FileSavedRelativePath As String = Constantes.ValorDefecto
        Dim FileSavedAbsolutePath As String = Constantes.ValorDefecto

        Dim FileSavedExtension As String = oFileAttached.GetExtension()
        Dim FileSavedCompleteExtension As String = oFileAttached.GetCompleteExtension()

        If oFileAttached.IsImage() Then

            FileSavedRelativePath = GetNameFile(GetCodeForFile(Code)) + FileSavedCompleteExtension

            If FileSavedRelativePath.LastIndexOf("\") <> -1 Then
                Dim fin As Integer = FileSavedRelativePath.LastIndexOf("\") + 1
                FileSavedRelativePath = FileSavedRelativePath.Substring(fin)
            End If

            FileSavedAbsolutePath = Server.MapPath(oFileAttached.FileFolderUrl) + FileSavedRelativePath
            oFileAttached.File.SaveAs(FileSavedAbsolutePath)

            If Not File.Exists(String.Concat(Server.MapPath("~/"), oFileAttached.FileTile.PathFileImage)) Then
                oFileAttached.FileTile.PathFileImage = "Content/images/filetypes/512px/_blank.png"
                oFileAttached.FileTile.PathFile = oFileAttached.FileTile.PathFileImage
                oFileAttached.FileTile.FileName = FileSavedRelativePath
                oFileAttached.FileTile.FileNameDescription = oArchivo.Name
                oFileAttached.FileTile.SizeDescription = GetSizeDescription(oArchivo.Size)
                oFileAttached.FileTile.ContentDescription = oArchivo.ContentType
                oFileAttached.FileTile.IsImage = True
            End If

        Else
            FileSavedRelativePath = GetNameFile(GetCodeForFile(Code)) + FileSavedCompleteExtension
            If FileSavedRelativePath.LastIndexOf("\") <> -1 Then
                Dim fin As Integer = FileSavedRelativePath.LastIndexOf("\") + 1
                FileSavedRelativePath = FileSavedRelativePath.Substring(fin)
            End If

            FileSavedAbsolutePath = Server.MapPath(oFileAttached.FileFolderUrl) + FileSavedRelativePath
            oFileAttached.File.SaveAs(FileSavedAbsolutePath)
            oFileAttached.FileTile.PathFileImage = "Content/images/filetypes/512px/" & FileSavedExtension & ".png"
            If Not File.Exists(String.Concat(Server.MapPath("~/"), oFileAttached.FileTile.PathFileImage)) Then
                oFileAttached.FileTile.PathFileImage = "Content/images/filetypes/512px/_blank.png"
            End If
            oFileAttached.FileTile.PathFile = oFileAttached.FileFolderUrl.Replace("~/", "") + FileSavedRelativePath
            oFileAttached.FileTile.FileName = FileSavedRelativePath
            oFileAttached.FileTile.FileNameDescription = oArchivo.Name
            oFileAttached.FileTile.SizeDescription = GetSizeDescription(oArchivo.Size)
            oFileAttached.FileTile.ContentDescription = oArchivo.ContentType
            oFileAttached.FileTile.IsImage = False
        End If

        DeleteAllFiles_UntilDate(Server)
        Return oFileAttached.FileTile

    End Function

    Public Shared Function SaveFileFromFile(oArchivo As Archivo, Server As HttpServerUtilityBase, Code As Integer) As FileTile
        Dim oFileStream As FileStream
        oFileAttach = New FileAttached()
        oFileAttach.FileTile = New FileTile()
        oFileAttach.Archivo = oArchivo
        Dim FileSavedRelativePath As String = Constantes.ValorDefecto
        Dim FileSavedAbsolutePath As String = Constantes.ValorDefecto
        Dim FileSavedExtension As String = oFileAttach.GetExtension()
        Dim FileSavedCompleteExtension As String = oFileAttach.GetCompleteExtension()

        If oFileAttach.IsImage() Then
            FileSavedRelativePath = GetNameFile(GetCodeForFile(Code)) + FileSavedCompleteExtension
            FileSavedAbsolutePath = Server.MapPath(oFileAttach.FileFolderUrl) + FileSavedRelativePath
            oFileStream = New FileStream(FileSavedAbsolutePath, FileMode.Create)
            oFileStream.Write(oFileAttach.Archivo.Data, 0, oFileAttach.Archivo.Data.Length)
            oFileStream.Close()
            oFileAttach.FileTile.PathFileImage = oFileAttach.FileFolderUrl.Replace("~/", "") + FileSavedRelativePath
            oFileAttach.FileTile.PathFile = oFileAttach.FileTile.PathFileImage
            oFileAttach.FileTile.FileName = FileSavedRelativePath
            oFileAttach.FileTile.FileNameDescription = oFileAttach.Archivo.Name
            oFileAttach.FileTile.SizeDescription = GetSizeDescription(oFileAttach.Archivo.Size)
            oFileAttach.FileTile.ContentDescription = oFileAttach.Archivo.ContentType
            oFileAttach.FileTile.IsImage = True

        Else
            FileSavedRelativePath = GetNameFile(GetCodeForFile(Code)) + FileSavedCompleteExtension
            If FileSavedRelativePath.LastIndexOf("\") <> -1 Then
                Dim fin As Integer = FileSavedRelativePath.LastIndexOf("\") + 1
                FileSavedRelativePath = FileSavedRelativePath.SubString(fin)

            End If
            FileSavedAbsolutePath = Server.MapPath(oFileAttach.FileFolderUrl) + FileSavedRelativePath
            oFileStream = New FileStream(FileSavedAbsolutePath, FileMode.Create)
            oFileStream.Write(oFileAttach.Archivo.Data, 0, oFileAttach.Archivo.Data.Length)
            oFileStream.Close()
            oFileAttach.FileTile.PathFileImage = "Content/images/filetypes/512px/" & FileSavedExtension & ".png"
            If Not File.Exists(String.Concat(Server.MapPath("/"), oFileAttach.FileTile.PathFileImage)) Then
                oFileAttach.FileTile.PathFileImage = "Content/images/filetypes/512px/_blank.png"
            End If
            oFileAttach.FileTile.PathFile = oFileAttach.FileFolderUrl.Replace("~/", "") + FileSavedRelativePath
        End If
        oFileAttach.FileTile.FileName = FileSavedRelativePath
        oFileAttach.FileTile.FileNameDescription = oFileAttach.Archivo.Name
        oFileAttach.FileTile.SizeDescription = GetSizeDescription(oFileAttach.Archivo.Size)
        oFileAttach.FileTile.ContentDescription = oFileAttach.Archivo.ContentType
        oFileAttach.FileTile.IsImage = False

        DeleteAllFiles_UntilDate(Server)
        Return oFileAttach.FileTile

    End Function

    Public Class FileAttached
        Private file_ As HttpPostedFileBase
        Private archivo_ As Archivo
        Private fileTile_ As FileTile
        Private fileFolderUrl_ As String
        Private isLoadDetail_ As Boolean
        Private fileAceptExtension_ As Boolean
        Private fileAceptSize_ As Boolean
        Private fileCount_ As Integer
        Private fileMaxSizeAllowKB_ As Integer
        Private fileMaxSizeAllowKBTotal2_ As Integer
        Private fileMaxAmount_ As Integer
        Private fileMaxAmountFill_ As Integer
        Private imageWidth_ As Integer
        Private imageHeight_ As Integer
        Private fileTypesAllow_Documents_ As String
        Private fileTypesAllow_Documents_Active_ As Boolean
        Private fileTypesAllow_Images_ As String
        Private fileTypesAllow_Images_Active_ As Boolean
        Private fileTypesAllow_Media_ As String
        Private fileTypesAllow_Media_Active_ As Boolean
        Private fileTypesAllow_Package_ As String
        Private fileTypesAllow_Package_Active_ As Boolean
        Private fileTypesAllow_Others_ As String
        Private Property fileTypesAllow_Others_Active_ As Boolean

        Public Property File() As HttpPostedFileBase
            Get
                Return File_
            End Get
            Set(value As HttpPostedFileBase)
                file_ = value
            End Set

        End Property

        Public Property Archivo() As Archivo
            Get
                Return archivo_
            End Get
            Set(value As Archivo)
                archivo_ = value
            End Set

        End Property

        Public Property FileTile() As FileTile
            Get
                Return fileTile_
            End Get
            Set(value As FileTile)
                fileTile_ = value
            End Set

        End Property

        Public Property FileFolderUrl() As String
            Get
                Return fileFolderUrl_
            End Get
            Set(value As String)
                fileFolderUrl_ = value
            End Set

        End Property

        Public Property IsLoadDetail() As Boolean
            Get
                Return isLoadDetail_
            End Get
            Set(value As Boolean)
                isLoadDetail_ = value
            End Set

        End Property

        Public Property FileAceptExtension() As Boolean
            Get
                Return fileAceptExtension_
            End Get
            Set(value As Boolean)
                fileAceptExtension_ = value
            End Set

        End Property

        Public Property FileAceptSize() As Boolean
            Get
                Return FileAceptSize_
            End Get
            Set(value As Boolean)
                fileAceptSize_ = value
            End Set

        End Property

        Public Property FileMaxSizeAllowKB() As Integer
            Get
                Return FileMaxSizeAllowKB_
            End Get
            Set(value As Integer)
                fileMaxSizeAllowKB_ = value
            End Set

        End Property
        Public Property FileMaxSizeAllowKBTotal2() As Integer
            Get
                Return FileMaxSizeAllowKBTotal2_
            End Get
            Set(value As Integer)
                fileMaxSizeAllowKBTotal2_ = value
            End Set

        End Property

        Public Property FileCount() As Integer
            Get
                Return FileCount_
            End Get
            Set(value As Integer)
                fileCount_ = value
            End Set

        End Property

        Public Property FileMaxAmount() As Integer
            Get
                Return FileMaxAmount_
            End Get
            Set(value As Integer)
                fileMaxAmount_ = value
            End Set

        End Property

        Public Property FileMaxAmountFill() As Integer
            Get
                Return FileMaxAmountFill_
            End Get
            Set(value As Integer)
                fileMaxAmountFill_ = value
            End Set

        End Property

        Public Property ImageWidth() As Integer
            Get
                Return ImageWidth_
            End Get
            Set(value As Integer)
                imageWidth_ = value
            End Set

        End Property

        Public Property ImageHeight() As Integer
            Get
                Return ImageHeight_
            End Get
            Set(value As Integer)
                imageHeight_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Documents() As String
            Get
                Return FileTypesAllow_Documents_
            End Get
            Set(value As String)
                fileTypesAllow_Documents_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Documents_Active() As Boolean
            Get
                Return FileTypesAllow_Documents_Active_
            End Get
            Set(value As Boolean)
                fileTypesAllow_Documents_Active_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Images() As String
            Get
                Return FileTypesAllow_Images_
            End Get
            Set(value As String)
                fileTypesAllow_Images_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Images_Active() As Boolean
            Get
                Return FileTypesAllow_Images_Active_
            End Get
            Set(value As Boolean)
                fileTypesAllow_Images_Active_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Media() As String
            Get
                Return FileTypesAllow_Media_
            End Get
            Set(value As String)
                fileTypesAllow_Media_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Media_Active() As Boolean
            Get
                Return FileTypesAllow_Media_Active_
            End Get
            Set(value As Boolean)
                fileTypesAllow_Media_Active_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Package() As String
            Get
                Return FileTypesAllow_Package_
            End Get
            Set(value As String)
                fileTypesAllow_Package_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Package_Active() As Boolean
            Get
                Return FileTypesAllow_Package_Active_
            End Get
            Set(value As Boolean)
                fileTypesAllow_Package_Active_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Others() As String
            Get
                Return FileTypesAllow_Others_
            End Get
            Set(value As String)
                fileTypesAllow_Others_ = value
            End Set

        End Property

        Public Property FileTypesAllow_Others_Active() As Boolean
            Get
                Return FileTypesAllow_Others_Active_
            End Get
            Set(value As Boolean)
                FileTypesAllow_Others_Active_ = value
            End Set

        End Property

        Public Sub New()
            'Dim integer As Integer
            'Me.fileFolderUrl = Komatsu.SGM.Validation.Settings.Settings.FileFolderUrl
            'Me.fileTypesAllow_Documents = Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Documents
            'Me.fileTypesAllow_Documents_Active = Boolean.Parse(Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Documents_Active.ToString())
            'Me.fileTypesAllow_Images = Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Images
            'Me.fileTypesAllow_Images_Active = Boolean.Parse(Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Images_Active.ToString())
            'Me.fileTypesAllow_Media = Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Media
            'Me.fileTypesAllow_Media_Active = Boolean.Parse(Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Media_Active.ToString())
            'Me.fileTypesAllow_Package = Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Package
            'Me.fileTypesAllow_Package_Active = Boolean.Parse(Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Package_Active.ToString())
            'Me.fileTypesAllow_Others = Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Others
            'Me.FileTypesAllow_Others_Active = Boolean.Parse(Komatsu.SGM.Validation.Settings.Settings.FileTypesAllow_Others_Active.ToString())
            'If Int32.TryParse(Komatsu.SGM.Validation.Settings.Settings.FileMaxAmount, Integereger) = True Then
            '    Me.fileMaxAmount = Int32.Parse(Komatsu.SGM.Validation.Settings.Settings.FileMaxAmount)

            'End If
            'If Int32.TryParse(Komatsu.SGM.Validation.Settings.Settings.ImageWidth, Integereger) = True Then
            '    Me.imageWidth = Int32.Parse(Komatsu.SGM.Validation.Settings.Settings.ImageWidth)

            'End If
            'If Int32.TryParse(Komatsu.SGM.Validation.Settings.Settings.ImageHeight, Integereger) = True Then
            '    Me.imageHeight = Int32.Parse(Komatsu.SGM.Validation.Settings.Settings.ImageHeight)

            'End If
            'If Int32.TryParse(Komatsu.SGM.Validation.Settings.Settings.FileMaxSizeAllowKB, Integereger) = True Then
            '    Me.fileMaxSizeAllowKB = Int32.Parse(Komatsu.SGM.Validation.Settings.Settings.FileMaxSizeAllowKB)

            'End If
            'If Int32.TryParse(Komatsu.SGM.Validation.Settings.Settings.FileMaxSizeAllowKBTotal2, Integereger) = True Then
            '    Me.fileMaxSizeAllowKBTotal2 = Int32.Parse(Komatsu.SGM.Validation.Settings.Settings.FileMaxSizeAllowKBTotal2)

            'End If

        End Sub

        Public Function GetExtension() As String
            Dim DotLocation As Integer = archivo.OriginalName.LastIndexOf(".")
            If DotLocation = -1 Then
                Return String.Empty
            Else
                Return archivo.OriginalName.SubString(DotLocation + 1, archivo.OriginalName.Length - DotLocation - 1).ToLower()

            End If
        End Function

        Public Function GetCompleteExtension() As String
            Dim DotLocation As Integer = archivo.OriginalName.LastIndexOf(".")
            If DotLocation = -1 Then
                Return String.Empty
            Else
                Return archivo.OriginalName.SubString(DotLocation, archivo.OriginalName.Length - DotLocation).ToLower()

            End If
        End Function

        Public Function IsDocument() As Boolean
            If String.Empty.CompareTo(GetExtension()) = 0 Then
                Return False
            Else
                If Me.fileTypesAllow_Documents.Contains(GetExtension().ToLower()) OrElse Me.fileTypesAllow_Documents.Contains(GetExtension().ToUpper()) Then
                    Return True
                Else
                    Return False

                End If
            End If

        End Function

        Public Function IsImage() As Boolean
            If String.Empty.CompareTo(GetExtension()) = 0 Then
                Return False
            Else
                If Me.fileTypesAllow_Images.Contains(GetExtension().ToLower()) OrElse Me.fileTypesAllow_Images.Contains(GetExtension().ToUpper()) Then
                    Return True
                Else
                    Return False

                End If
            End If

        End Function

        Public Function IsMedia() As Boolean
            If String.Empty.CompareTo(GetExtension()) = 0 Then
                Return False
            Else
                If Me.fileTypesAllow_Media.Contains(GetExtension().ToLower()) OrElse Me.fileTypesAllow_Media.Contains(GetExtension().ToUpper()) Then
                    Return True
                Else
                    Return False

                End If
            End If

        End Function

        Public Function IsPackage() As Boolean
            If String.Empty.CompareTo(GetExtension()) = 0 Then
                Return False
            Else
                If Me.fileTypesAllow_Package.Contains(GetExtension().ToLower()) OrElse Me.fileTypesAllow_Package.Contains(GetExtension().ToUpper()) Then
                    Return True
                Else
                    Return False

                End If
            End If

        End Function

        Public Function IsOther() As Boolean
            If String.Empty.CompareTo(GetExtension()) = 0 Then
                Return False
            Else
                If Me.fileTypesAllow_Others.Contains(GetExtension().ToLower()) OrElse Me.fileTypesAllow_Others.Contains(GetExtension().ToUpper()) Then
                    Return True
                Else
                    Return False

                End If
            End If

        End Function

    End Class

    Public Class FileTile
        Public IdFileTile As Integer
        Public IdObjetoRel As Integer
        Public PathFileImage As String
        Public PathFile As String
        Public FileName As String
        Public FileNameDescription As String
        Public SizeDescription As String
        Public ContentDescription As String
        Public IsImage As Boolean
    End Class

    Public Shared Function GetNameFile(Code As String) As String
        Return "File-" & Code & "-" & String.Format("{0:0000}", DateTime.Now.Year) + String.Format("{0:00}", DateTime.Now.Month) + String.Format("{0:00}", DateTime.Now.Day) & "-" & String.Format("{0:00}", DateTime.Now.Hour) & "." & String.Format("{0:00}", DateTime.Now.Minute) & "." & String.Format("{0:00}", DateTime.Now.Second) & "." & String.Format("{0:000}", DateTime.Now.Millisecond) & "." & String.Format("{0:0000000000}", DateTime.Now.Ticks) & "." & String.Format("{0:00000}", New Random().Next(0, 10000))
    End Function

    Public Shared Function GetCodeForFile(Code As Integer) As String
        Dim Prefix As String = "000000"
        Dim generatedCode As String = Prefix + Code.ToString()
        generatedCode = generatedCode.SubString(generatedCode.Length - Prefix.Length, Prefix.Length)
        Return generatedCode
    End Function

    Public Shared Function GetSizeDescription(Size As Long) As String
        Dim SizeCalc As Decimal = (Size / 1024)
        Dim Description As String = Constantes.ValorDefecto
        Description = SizeCalc & " KBs"
        Return Description
    End Function

    Public Shared Sub DeleteAllFiles_UntilDate(Server As HttpServerUtilityBase)
        Try
            Dim DateFileIntSaved As Integer
            Dim DateFileIntNow As Integer = Int32.Parse(String.Format("{0:yyyyMMdd}", DateTime.Now))
            Dim oDirectory As New DirectoryInfo(Server.MapPath(oFileAttach.FileFolderUrl))
            For Each oFileInfo As FileInfo In oDirectory.GetFiles()
                DateFileIntSaved = Int32.Parse(oFileInfo.Name.SubString(Constantes.ValorDoce, Constantes.ValorOcho))
                If DateFileIntSaved < DateFileIntNow Then
                    oFileInfo.Delete()
                End If
            Next
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub

    Public Shared Function GetFileExtension(oHttpPostedFileBase As HttpPostedFileBase) As Object
        oFileAttach = New FileAttached()
        oFileAttach.Archivo = New Archivo()
        oFileAttach.Archivo.OriginalName = oHttpPostedFileBase.FileName
        Return oFileAttach.GetExtension()
    End Function

End Class
