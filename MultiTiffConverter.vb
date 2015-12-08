
Imports MP.Utils.Common
Imports System.Windows.Media.Imaging

Namespace MultiTiffConverter

  Namespace App

    Public Class AppProperties
      Private Shared SETTING_FILE_NAME = "setting.properties"

      Public Shared KEY_ALLOW_TO_DELETE_ORIGINAL_IMAGE_FILES = "AllowToDeleteOriginalImageFiles"
      Public Shared KEY_IMAGE_FILES_ORDER = "ImageFilesOrder"
      Public Shared KEY_COMPRESSION_SCHEME = "CompressionScheme"
      Public Shared KEY_FILE_NAME_CREATION_MODE = "FileNameCreationMode"
      Public Shared KEY_DEFAULT_FILE_NAME = "DefaultFileName"

      Public Shared MANAGER = New PropertyManager(SETTING_FILE_NAME, DefaultSettingProperties(), True)

      Private Shared Function DefaultSettingProperties() As IDictionary(Of String, String)
        Dim dict As IDictionary(Of String, String) = New Dictionary(Of String, String)
        dict(KEY_ALLOW_TO_DELETE_ORIGINAL_IMAGE_FILES) = "False"
        dict(KEY_IMAGE_FILES_ORDER) = ImageFilesOrder.Auto.ToString
        dict(KEY_COMPRESSION_SCHEME) = CompressionScheme.Auto.ToString
        dict(KEY_FILE_NAME_CREATION_MODE) = FileNameCreationMode.DefaultName.ToString
        dict(KEY_DEFAULT_FILE_NAME) = "新しいファイル.tiff"
        Return dict
      End Function
    End Class

    Public Class AppPropertyManager
      Private Manager As PropertyManager = AppProperties.MANAGER
      Private Properties As IDictionary(Of String, String)

      Public Sub New()
        Me.Properties = Manager.ToDictionary()
      End Sub

      Public Function IsAllowedToDeleteOriginalImageFiles() As Boolean
        Return Properties(AppProperties.KEY_ALLOW_TO_DELETE_ORIGINAL_IMAGE_FILES) = True.ToString
      End Function

      Public Function GetImageFilesOrder() As ImageFilesOrder
        Dim mode As String = Properties(AppProperties.KEY_IMAGE_FILES_ORDER)
        Return MyEnum.GetId(GetType(ImageFilesOrder), mode, ImageFilesOrder.Auto)
      End Function

      Public Function GetCompressionScheme() As CompressionScheme
        Dim mode As String = Properties(AppProperties.KEY_COMPRESSION_SCHEME)
        Return MyEnum.GetId(GetType(CompressionScheme), mode, CompressionScheme.Auto)
      End Function

      Public Function GetFileNameCreationMode() As FileNameCreationMode
        Dim mode As String = Properties(AppProperties.KEY_FILE_NAME_CREATION_MODE)
        Return MyEnum.GetId(GetType(FileNameCreationMode), mode, FileNameCreationMode.DefaultName)
      End Function

      Public Function GetDefaultFileName() As String
        Return Properties(AppProperties.KEY_DEFAULT_FILE_NAME)
      End Function

      Public Sub AllowToDeleteOriginalImageFiles(allow As Boolean)
        Properties(AppProperties.KEY_ALLOW_TO_DELETE_ORIGINAL_IMAGE_FILES) = allow.ToString
      End Sub

      Public Sub SetImageFilesOrder(order As ImageFilesOrder)
        Dim str As String = MyEnum.GetName(GetType(ImageFilesOrder), order, ImageFilesOrder.Auto.ToString)
        Properties(AppProperties.KEY_IMAGE_FILES_ORDER) = str
      End Sub

      Public Sub SetCompressionScheme(scheme As CompressionScheme)
        Dim str As String = MyEnum.GetName(GetType(CompressionScheme), scheme, CompressionScheme.Auto.ToString)
        Properties(AppProperties.KEY_COMPRESSION_SCHEME) = str
      End Sub

      Public Sub SetFileNameCreationMode(way As FileNameCreationMode)
        Dim str As String = MyEnum.GetName(GetType(FileNameCreationMode), way, FileNameCreationMode.DefaultName)
        Properties(AppProperties.KEY_FILE_NAME_CREATION_MODE) = str
      End Sub

      Public Sub SetDefaultFileName(name As String)
        Properties(AppProperties.KEY_DEFAULT_FILE_NAME) = name
      End Sub

      Public Sub Flush()
        Manager.SetValues(Properties)
      End Sub

      Public Sub Reset()
        Properties = Manager.ToDictionary
      End Sub
    End Class

    Public Enum ImageFilesOrder As Integer
      Auto
      Name
      Manual
    End Enum

    Public Enum CompressionScheme As Integer
      Auto = TiffCompressOption.Default
      None = TiffCompressOption.None
      Ccitt3 = TiffCompressOption.Ccitt3
      Ccitt4 = TiffCompressOption.Ccitt4
      Lwz = TiffCompressOption.Lzw
      Rle = TiffCompressOption.Rle
      Zip = TiffCompressOption.Zip
    End Enum

    Public Enum FileNameCreationMode As Integer
      FirstPageName
      Manual
      DefaultName
    End Enum
  End Namespace
End Namespace
