
Imports System.Drawing.Imaging
Imports System.Windows.Media.Imaging
Imports System.IO
Imports MP.Utils.Common
Imports MP.MultiTiffConverter.App

Public Class MainForm
  Private Loaded As Boolean = False

  Private PropertyManager As AppPropertyManager
  Private SaveFileDialog As SaveFileDialog

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    PropertyManager = New AppPropertyManager

    Dim imageFileNames As List(Of String) = GetDropedFileNames()
    If imageFileNames.Count = 0 OrElse PropertyManager.GetImageFilesOrder = ImageFilesOrder.Manual Then
      InitForm()
      InitSvaeFileDialog()
      imageFileNames.ForEach(Sub(f) lboxImageFileNames.Items.Add(f))
    Else
      Convert(GetOrderdFileNames)
      Me.Close()
    End If

    Loaded = True
  End Sub

  Private Sub InitForm()
    InitChkAllowToDeleteOriginalImageFiles()
    InitRBtnImageFilesOrder()
    InitRBtnFileNameCreationMode()
    InitTxtDefaultName()
    InitCBoxComressionScheme()
  End Sub

  Private Sub InitChkAllowToDeleteOriginalImageFiles()
    chkDeleteOriginalFiles.Checked = PropertyManager.IsAllowedToDeleteOriginalImageFiles()
  End Sub

  Private Sub InitRBtnImageFilesOrder()
    Dim order As ImageFilesOrder = PropertyManager.GetImageFilesOrder()

    rBtnOrderToAuto.Checked = order = ImageFilesOrder.Auto
    rBtnOrderToName.Checked = order = ImageFilesOrder.Name
    rBtnOrderToManual.Checked = order = ImageFilesOrder.Manual
  End Sub

  Private Sub InitRBtnFileNameCreationMode()
    Dim mode As FileNameCreationMode = PropertyManager.GetFileNameCreationMode

    rBtnFileNameCreationModeFirstPage.Checked = mode = FileNameCreationMode.FirstPageName
    rBtnFileNameCreationModeManual.Checked = mode = FileNameCreationMode.Manual
    rBtnFileNameCreationModeDefault.Checked = mode = FileNameCreationMode.DefaultName
  End Sub

  Private Sub InitTxtDefaultName()
    txtDefaultFileName.Text = PropertyManager.GetDefaultFileName
  End Sub

  Private Sub InitCBoxComressionScheme()
    With cboxCompressionScheme
      .Text = ""
      .Items.Clear()
      .DropDownStyle = ComboBoxStyle.DropDownList
      .BeginUpdate()    'EndUpdate()が呼び出されるまで描画しない
      Dim schemeNames As List(Of String) = MyEnum.GetNames(GetType(CompressionScheme))
      For Each name As String In schemeNames
        .Items.Add(name)
      Next
      .EndUpdate()      'ここで描画され、ちらつきが発生しない
      Dim scheme As String = MyEnum.GetName(GetType(CompressionScheme), PropertyManager.GetCompressionScheme(), CompressionScheme.Auto.ToString)
      .SelectedIndex = schemeNames.IndexOf(scheme)
    End With
  End Sub

  'アイコンにドロップされたファイルの名前を取得
  Private Function GetDropedFileNames() As List(Of String)
    Return System.Environment.GetCommandLineArgs().Skip(1).ToList
  End Function

  '並び替えたファイル名のリストを取得する
  Private Function GetOrderdFileNames() As List(Of String)
    Dim imageFileNames As List(Of String) = GetDropedFileNames()
    Dim order As ImageFilesOrder = PropertyManager.GetImageFilesOrder()

    If imageFileNames.Count = 0 OrElse order = ImageFilesOrder.Manual Then
      Dim fileNames As New List(Of String)
      For Each txt As String In lboxImageFileNames.Items
        fileNames.Add(txt)
      Next
      Return fileNames
    ElseIf order = ImageFilesOrder.Name
      imageFileNames.Sort()
      Return imageFileNames
    Else
      Return imageFileNames
    End If
  End Function

  'イメージファイルをマルチTiffファイルに変換する
  Private Sub Convert(imageFileNames As List(Of String))
    'CreateMultiTiff("sample.Tiff", imageFileNames.ToArray, PropertyManager.GetCompressionScheme)
    ConvertImageFileToMultiTiff(
      GetSaveCallback,
      imageFileNames,
      PropertyManager.GetCompressionScheme,
      PropertyManager.IsAllowedToDeleteOriginalImageFiles)
  End Sub

  Private Function GetSaveCallback() As SaveCallback
    Dim fileNameCreationMode As FileNameCreationMode = PropertyManager.GetFileNameCreationMode
    If fileNameCreationMode = FileNameCreationMode.FirstPageName Then
      Dim name As String = GetOrderdFileNames.First
      name = name.Substring(0, name.LastIndexOf(".")) & ".tiff"
      Return GetFuncForSaving(CreateNumberingFileNameIfAlreadyExists(name))
    ElseIf fileNameCreationMode = FileNameCreationMode.Manual
      Return GetFuncForSavingInDialog()
    Else
      Dim name As String = txtDefaultFileName.Text
      If name.Length = 0 Then
        name = MP.Details.Sys.App.GetCurrentDirectory & "\新しいファイル.tiff"
      End If
      Return GetFuncForSaving(CreateNumberingFileNameIfAlreadyExists(name))
    End If
  End Function

  Private Function CreateNumberingFileNameIfAlreadyExists(name As String) As String
    If File.Exists(name) Then
      Dim dotIdx As Integer = name.LastIndexOf(".")
      Dim prefix As String
      Dim sufix As String
      If dotIdx > 0 Then
        prefix = name.Substring(0, dotIdx)
        sufix = name.Substring(dotIdx)
      Else
        prefix = name
        sufix = ""
      End If

      Dim numbering As Integer = 1
      Dim numberingName As String = prefix & "(" & numbering.ToString & ")" & sufix
      While File.Exists(numberingName)
        numbering += 1
        numberingName = prefix & "(" & numbering.ToString & ")" & sufix
      End While

      Return numberingName
    Else
      Return name
    End If
  End Function

  'イメージファイルをマルチTiffファイルに変換する
  Private Sub ConvertImageFileToMultiTiff(saveCallback As SaveCallback, imageFileNames As List(Of String), compressionScheme As CompressionScheme, deletesOriginalImageFile As Boolean)
    Try
      'マルチTiffを作成する
      Dim tiffEncoder As TiffBitmapEncoder = CreateMultiTiffEncoder(imageFileNames, compressionScheme)
      'Save("sample.tiff", tiffEncoder)
      'マルチTiffを保存 保存されればTrueを返す
      If saveCallback(tiffEncoder) AndAlso deletesOriginalImageFile Then
        '  '元のイメージファイルを削除する
        'imageFileNames.ForEach(Sub(f) File.Delete(f))
      End If
    Catch ex As Exception
      MsgBox.ShowError(ex)
    End Try
  End Sub

  'マルチTiffのエンコーダーを生成する
  Private Function CreateMultiTiffEncoder(imageFileNames As List(Of String), Optional compressScheme As CompressionScheme = TiffCompressOption.Default) As TiffBitmapEncoder
    'TiffBitmapEncoderを作成する
    Dim encoder As New TiffBitmapEncoder()
    '圧縮方法を変更する
    encoder.Compression = compressScheme

    'CreateBitmapList(imageFileNames).
    '  ForEach(Sub(bmp) encoder.Frames.Add(bmp))
    For Each bmp As BitmapFrame In CreateBitmapList(imageFileNames)
      encoder.Frames.Add(bmp)
    Next

    Return encoder
  End Function

  'bitmapを生成する
  Private Function CreateBitmapList(imageFileNames As List(Of String)) As List(Of BitmapFrame)
    Return _
      imageFileNames.ConvertAll(
        Function(f)
          Try
            Dim bmp As BitmapFrame = Nothing
            'BitmapはFileStreamで開かないとファイルがロックされ他プロセスからアクセスできなくなる
            'Using fs As FileStream = New FileStream(f, FileMode.Open, FileAccess.Read)
            '  bmp = BitmapFrame.Create(fs)
            'End Using
            Dim fs As FileStream = Nothing
            Try
              fs = New FileStream(f, FileMode.Open, FileAccess.Read)
              bmp = BitmapFrame.Create(fs)
            Catch ex As Exception
              If fs IsNot Nothing Then
                fs.Close()
              End If
            End Try
            Return bmp
            'Return BitmapFrame.Create(New Uri(f, UriKind.RelativeOrAbsolute))
          Catch ex As IOException
            Throw ex
          Catch ex As Exception
            Throw New Exception(f & " のイメージの取得に失敗しました。")
          End Try
        End Function)
  End Function

  Delegate Function SaveCallback(encoder As TiffBitmapEncoder) As Boolean

  Private Function GetFuncForSaving(filePath As String) As SaveCallback
    Return Function(encoder) Save(filePath, encoder)
  End Function

  Private Function GetFuncForSavingInDialog() As SaveCallback
    Return Function(encoder) SaveInDialog(encoder)
  End Function

  'マルチTiffファイルを保存する
  Private Function Save(savePath As String, encoder As TiffBitmapEncoder) As Boolean
    If encoder.Frames.Count > 0 Then
      If Overwrites(savePath) Then
        'MessageBox.Show(savePath)
        Using outputFileStream As FileStream = New FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None)
          encoder.Save(outputFileStream)
        End Using
        Return True
      Else
        Return False
      End If
    Else
      Throw New Exception("マルチTiff化する画像が指定されていません。")
    End If
  End Function

  '同名のファイルが既にあるとき上書きするか訊く
  Private Function Overwrites(savePath As String) As Boolean
    Return _
      Not File.Exists(savePath) OrElse
      MessageBox.Show(
        "指定されたファイルはすでに存在しますが、上書きしますか？", "確認",
        MessageBoxButtons.YesNo, MessageBoxIcon.Information) =
        DialogResult.Yes
  End Function

  Private Sub InitSvaeFileDialog()
    SaveFileDialog = New SaveFileDialog()

    'はじめのファイル名を指定する
    SaveFileDialog.FileName = "新しいファイル.tiff"
    'はじめに表示されるフォルダを指定する
    'SaveFileDialog.InitialDirectory = MP.Details.Sys.App.GetCurrentDirectory
    '[ファイルの種類]に表示される選択肢を指定する
    SaveFileDialog.Filter = "tiffファイル(*.tiff)|*.tiff|すべてのファイル(*.*)|*.*"
    SaveFileDialog.FilterIndex = 0
    'タイトルを設定する
    SaveFileDialog.Title = "保存先のファイルを選択してください"
    'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
    SaveFileDialog.RestoreDirectory = True
    '既に存在するファイル名を指定したとき警告する
    'デフォルトでTrueなので指定する必要はない
    SaveFileDialog.OverwritePrompt = True
    '存在しないパスが指定されたとき警告を表示する
    'デフォルトでTrueなので指定する必要はない
    SaveFileDialog.CheckPathExists = True
  End Sub

  Public Function SaveInDialog(encoder As TiffBitmapEncoder) As Boolean
    'ダイアログを表示する
    If SaveFileDialog.ShowDialog() = DialogResult.OK Then
      Using stream As System.IO.Stream = SaveFileDialog.OpenFile()
        encoder.Save(stream)
      End Using
      Return True
    Else
      Return False
    End If
  End Function

  'Public Sub CreateMultiTiff(ByVal savePath As String,
  '                                ByVal imageFiles As String(),
  '                                ByVal compressOption As TiffCompressOption)
  '  'TiffBitmapEncoderを作成する
  '  Dim encoder As New TiffBitmapEncoder()
  '  '圧縮方法を変更する
  '  encoder.Compression = compressOption

  '  'For Each f As String In imageFiles
  '  '  '画像ファイルからBitmapFrameを作成する
  '  '  Dim bmpFrame As BitmapFrame =
  '  '        BitmapFrame.Create(New Uri(f, UriKind.RelativeOrAbsolute))
  '  '  'フレームに追加する
  '  '  encoder.Frames.Add(bmpFrame)
  '  'Next

  '  Dim bitmaps As List(Of BitmapFrame) = CreateBitmapList(imageFiles.ToList)
  '  'CreateBitmapList(imageFileNames).
  '  '  ForEach(Sub(bmp) encoder.Frames.Add(bmp))
  '  For Each bmp As BitmapFrame In bitmaps
  '    encoder.Frames.Add(bmp)
  '  Next

  '  '書き込むファイルを開く
  '  Dim outputFileStrm As New FileStream(savePath,
  '      FileMode.Create, FileAccess.Write, FileShare.None)
  '  '保存する
  '  encoder.Save(outputFileStrm)
  '  '閉じる
  '  outputFileStrm.Close()
  'End Sub

  Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
    Convert(GetOrderdFileNames)
  End Sub

  Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles lboxImageFileNames.DragEnter

    'ドラッグされている内容が文字列型に変換可能な場合
    If e.Data.GetDataPresent(GetType(String)) Then
      'コピーを許可するようにドラッグ元に通知する
      e.Effect = DragDropEffects.Copy
    End If

  End Sub

  Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles lboxImageFileNames.DragDrop
    MessageBox.Show("Drop")
    'ListBox1.Items.Add(DirectCast(sender, String))
  End Sub

  Private Sub chkDeleteOriginalFiles_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeleteOriginalFiles.CheckedChanged
    PropertyManager.AllowToDeleteOriginalImageFiles(chkDeleteOriginalFiles.Checked)
  End Sub

  Private Sub rBtnOrderToAuto_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnOrderToAuto.CheckedChanged
    SetImageFileOrder(rBtnOrderToAuto, ImageFilesOrder.Auto)
  End Sub

  Private Sub rBtnOrderToName_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnOrderToName.CheckedChanged
    SetImageFileOrder(rBtnOrderToName, ImageFilesOrder.Name)
  End Sub

  Private Sub rBtnOrderToManual_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnOrderToManual.CheckedChanged
    SetImageFileOrder(rBtnOrderToManual, ImageFilesOrder.Manual)
  End Sub

  Private Sub SetImageFileOrder(rBtn As RadioButton, order As ImageFilesOrder)
    If Loaded AndAlso rBtn.Checked Then
      PropertyManager.SetImageFilesOrder(order)
    End If
  End Sub

  Private Sub rBtnFileNameCreationModeFirstPage_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnFileNameCreationModeFirstPage.CheckedChanged
    SetFileNameCreationMode(sender, FileNameCreationMode.FirstPageName)
  End Sub

  Private Sub rBtnFileNameCreationModeManual_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnFileNameCreationModeManual.CheckedChanged
    SetFileNameCreationMode(sender, FileNameCreationMode.Manual)
  End Sub

  Private Sub rBtnFileNameCreationModeDefault_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnFileNameCreationModeDefault.CheckedChanged
    SetFileNameCreationMode(sender, FileNameCreationMode.DefaultName)
  End Sub

  Private Sub SetFileNameCreationMode(rBtn As RadioButton, naming As FileNameCreationMode)
    If Loaded AndAlso rBtn.Checked Then
      PropertyManager.SetFileNameCreationMode(naming)
    End If

    If rBtnFileNameCreationModeDefault.Checked Then
      txtDefaultFileName.Enabled = True
    Else
      txtDefaultFileName.Enabled = False
    End If
  End Sub

  Private Sub cboxCompressionScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxCompressionScheme.SelectedIndexChanged
    Dim selectedItem As String = cboxCompressionScheme.SelectedItem
    PropertyManager.SetCompressionScheme(MyEnum.GetId(GetType(CompressionScheme), selectedItem, CompressionScheme.Auto))
  End Sub

  Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
    PropertyManager.SetDefaultFileName(txtDefaultFileName.Text)
    PropertyManager.Flush()
  End Sub

  Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    PropertyManager.Reset()
    InitForm()
  End Sub


End Class

'Public Class ImageUtils

'  Public Shared Function GetImageCodecInfo(mimeType As String) As ImageCodecInfo
'    'GDI+ に組み込まれたイメージ エンコーダに関する情報をすべて取得
'    Dim encs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
'    Return encs.ToList.Find(Function(e) e.MimeType = mimeType)
'  End Function
'End Class
