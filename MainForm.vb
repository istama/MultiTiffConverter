
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
    If imageFileNames.Count > 0 AndAlso
       PropertyManager.GetImageFilesOrder <> ImageFilesOrder.Manual AndAlso
       PropertyManager.GetFileNameCreationMode <> FileNameCreationMode.Manual Then
      Convert(GetOrderedFileNames)
    Else
      InitForm()
      InitSaveFileDialog()
      imageFileNames.ForEach(Sub(f) lboxImageFileNames.Items.Add(f))

      Loaded = True
    End If


  End Sub

  Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    If Not Loaded Then
      'ドラッグ＆ドロップで変換だけした場合はアプリを起ち上げない
      Me.Close()
    ElseIf GetDropedFileNames.Count > 0 AndAlso PropertyManager.GetImageFilesOrder <> ImageFilesOrder.Manual AndAlso PropertyManager.GetFileNameCreationMode = FileNameCreationMode.Manual Then
      'ドラッグ＆ドロップで変換したファイルの名前をダイアログで入力する場合
      Convert(GetOrderedFileNames)
      Me.Close()
    End If
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
    rBtnOrderToTime.Checked = order = ImageFilesOrder.Time
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
  Private Function GetOrderedFileNames() As List(Of String)
    Dim imageFileNames As List(Of String) = GetDropedFileNames()
    Dim order As ImageFilesOrder = PropertyManager.GetImageFilesOrder()

    If imageFileNames.Count = 0 OrElse order = ImageFilesOrder.Manual Then
      Return GetFileNamesInListBox()
    ElseIf order = ImageFilesOrder.Name
      imageFileNames.Sort()
      Return imageFileNames
    ElseIf order = ImageFilesOrder.Time
      Return SortFilesWithCreationTime(imageFileNames)
    Else
      Return imageFileNames
    End If
  End Function

  'ファイルを作成日時順に並び替える
  Private Function SortFilesWithCreationTime(fileNames As List(Of String)) As List(Of String)
    Dim nameWithTimeList As List(Of Tuple(Of String, Date)) =
      fileNames.ConvertAll(Function(f) Tuple.Create(f, File.GetCreationTime(f)))
    Dim query = nameWithTimeList.OrderBy(Function(t) t.Item2.ToFileTime())
    Return query.ToList.ConvertAll(Function(t) t.Item1)
  End Function

  'イメージファイルをマルチTiffファイルに変換する
  Private Sub Convert(imageFileNames As List(Of String))
    If imageFileNames.Count > 0 Then
      Try
        ConvertImageFileToMultiTiff(
        GetSaveCallback,
        imageFileNames,
        PropertyManager.GetCompressionScheme,
        PropertyManager.IsAllowedToDeleteOriginalImageFiles)
      Catch ex As Exception
        MsgBox.ShowError(ex)
      End Try
    Else
      MessageBox.Show("画像ファイルがありません。")
    End If
  End Sub

  Private Function GetSaveCallback() As SaveCallback
    Dim fileNameCreationMode As FileNameCreationMode = PropertyManager.GetFileNameCreationMode

    If fileNameCreationMode = FileNameCreationMode.FirstPageName Then
      Dim name As String = CutDirStr(GetOrderedFileNames.First)
      name = name.Substring(0, name.LastIndexOf(".")) & ".tiff"
      Return GetFuncForSaving(CreateNumberingFileNameIfAlreadyExists(name))
    ElseIf fileNameCreationMode = FileNameCreationMode.Manual
      Return GetFuncForSavingInDialog()
    Else
      Dim name As String = txtDefaultFileName.Text
      If name.Length = 0 Then
        name = "新しいファイル.tiff"
      End If
      Return GetFuncForSaving(CreateNumberingFileNameIfAlreadyExists(name))
    End If
  End Function

  Private Function CutDirStr(path As String) As String
    Dim idx As Integer = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar)
    Return _
      If(path.Length = idx - 1,
        "",
        If(idx < 0,
          path,
          path.Substring(idx + 1)))
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
    Dim deleteOriginalFile As Boolean = False
    Dim fileStreams As List(Of FileStream) = Nothing
    Try
      'イメージファイルへのストリームを作成する
      fileStreams = CreateImageFileStream(imageFileNames)
      'マルチTiffを作成する
      Dim tiffEncoder As TiffBitmapEncoder = CreateMultiTiffEncoder(fileStreams, compressionScheme)
      'Save("sample.tiff", tiffEncoder)
      'マルチTiffを保存 保存されればTrueを返す
      deleteOriginalFile = saveCallback(tiffEncoder) AndAlso deletesOriginalImageFile
    Finally
      If fileStreams IsNot Nothing Then
        fileStreams.ForEach(Sub(fs) fs.Close())
      End If
    End Try

    If deleteOriginalFile Then
      '元のイメージファイルを削除する
      imageFileNames.ForEach(Sub(f) File.Delete(f))
    End If
  End Sub

  Private Function CreateImageFileStream(imageFileNames As List(Of String)) As List(Of FileStream)
    Dim fsList As New List(Of FileStream)
    imageFileNames.ForEach(
      Sub(f)
        Try
          fsList.Add(New FileStream(f, FileMode.Open, FileAccess.Read))
        Catch ex As Exception
          fsList.ForEach(Sub(fs) fs.Close())
          Throw New Exception(f & " を開くことに失敗しました")
        End Try
      End Sub)
    Return fsList
  End Function

  'マルチTiffのエンコーダーを生成する
  Private Function CreateMultiTiffEncoder(imageFileStreams As List(Of FileStream), Optional compressScheme As CompressionScheme = TiffCompressOption.Default) As TiffBitmapEncoder
    'TiffBitmapEncoderを作成する
    Dim encoder As New TiffBitmapEncoder()
    '圧縮方法を変更する
    encoder.Compression = compressScheme

    CreateBitmapList(imageFileStreams).ForEach(
        Sub(bmp) encoder.Frames.Add(bmp))
    'For Each bmp As BitmapFrame In CreateBitmapList(imageFileStreams)
    '  encoder.Frames.Add(bmp)
    'Next

    Return encoder
  End Function

  'bitmapを生成する
  Private Function CreateBitmapList(imageFileStreams As List(Of FileStream)) As List(Of BitmapFrame)
    Dim bmpList As New List(Of BitmapFrame)
    imageFileStreams.ForEach(
        Sub(fs)
          'BitmapDecoderを作成する
          Dim decoder As BitmapDecoder =
            BitmapDecoder.Create(fs, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)

          'フレーム数を取得する
          For Each frame As BitmapFrame In decoder.Frames
            bmpList.Add(frame)
          Next

          'Dim bmp As BitmapFrame = Nothing
          'Try
          '  bmp = BitmapFrame.Create(fs)
          '  bmpList.Add(bmp)
          'Catch ex As Exception
          '  Throw New Exception(fs.Name & " のイメージの取得に失敗しました。")
          'End Try
        End Sub)

    Return bmpList
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

  Private Sub InitSaveFileDialog()
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

  Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
    Dim idx As Integer = lboxImageFileNames.SelectedIndex
    If idx > 0 Then
      Dim item As String = lboxImageFileNames.SelectedItem

      lboxImageFileNames.Items.RemoveAt(idx)
      lboxImageFileNames.Items.Insert(idx - 1, item)
      lboxImageFileNames.SelectedIndex = idx - 1
    End If
  End Sub

  Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
    Dim idx As Integer = lboxImageFileNames.SelectedIndex
    If idx >= 0 AndAlso idx < lboxImageFileNames.Items.Count - 1 Then
      Dim item As String = lboxImageFileNames.SelectedItem

      lboxImageFileNames.Items.RemoveAt(idx)
      lboxImageFileNames.Items.Insert(idx + 1, item)
      lboxImageFileNames.SelectedIndex = idx + 1
    End If
  End Sub

  Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    Dim idx As Integer = lboxImageFileNames.SelectedIndex
    If idx >= 0 Then
      lboxImageFileNames.Items.RemoveAt(idx)
      If idx < lboxImageFileNames.Items.Count Then
        lboxImageFileNames.SelectedIndex = idx
      ElseIf idx = lboxImageFileNames.Items.Count
        lboxImageFileNames.SelectedIndex = idx - 1
      End If
    End If
  End Sub

  Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
    '変換ボタンからマルチtiffを生成するときは、画像の順番はリストBoxを優先する
    Convert(GetFileNamesInListBox)
  End Sub

  Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles lboxImageFileNames.DragEnter
    'データ形式の確認
    If e.Data.GetDataPresent(DataFormats.FileDrop) = False Then
      Return
    End If

    'ドラッグしているファイル／フォルダの取得
    Dim FilePath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

    For idx As Integer = 0 To FilePath.Length - 1
      If Not System.IO.File.Exists(FilePath(idx)) Then
        Return
      End If
    Next idx

    'ドロップ可能な場合は、エフェクトを変える
    e.Effect = DragDropEffects.Copy

    ''
    ''ドラッグされている内容が文字列型に変換可能な場合
    'If e.Data.GetDataPresent(GetType(String)) Then
    '  'コピーを許可するようにドラッグ元に通知する
    '  e.Effect = DragDropEffects.Copy
    'End If

  End Sub

  Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles lboxImageFileNames.DragDrop
    'ドラッグしているファイル／フォルダの取得
    Dim FilePath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

    For Each path As String In FilePath
      lboxImageFileNames.Items.Add(path)
    Next

    ''
    'MessageBox.Show("Drop")
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

  Private Sub rBtnOrderToTime_CheckedChanged(sender As Object, e As EventArgs) Handles rBtnOrderToTime.CheckedChanged
    SetImageFileOrder(rBtnOrderToTime, ImageFilesOrder.Time)
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

  Private Function GetFileNamesInListBox() As List(Of String)
    Dim names As New List(Of String)
    For Each f As String In lboxImageFileNames.Items
      names.Add(f)
    Next
    Return names
  End Function


End Class

'Public Class ImageUtils

'  Public Shared Function GetImageCodecInfo(mimeType As String) As ImageCodecInfo
'    'GDI+ に組み込まれたイメージ エンコーダに関する情報をすべて取得
'    Dim encs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
'    Return encs.ToList.Find(Function(e) e.MimeType = mimeType)
'  End Function
'End Class
