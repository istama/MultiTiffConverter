<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
  Inherits System.Windows.Forms.Form

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Windows フォーム デザイナーで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
  'Windows フォーム デザイナーを使用して変更できます。  
  'コード エディターを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.btnDown = New System.Windows.Forms.Button()
    Me.btnUp = New System.Windows.Forms.Button()
    Me.btnDelete = New System.Windows.Forms.Button()
    Me.btnConvert = New System.Windows.Forms.Button()
    Me.lboxImageFileNames = New System.Windows.Forms.ListBox()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.rBtnFileDestModeFirstPage = New System.Windows.Forms.RadioButton()
    Me.btnShowDirDialog = New System.Windows.Forms.Button()
    Me.txtDefaultFileDest = New System.Windows.Forms.TextBox()
    Me.rBtnFileDestModeDefault = New System.Windows.Forms.RadioButton()
    Me.rBtnFileDestModeManual = New System.Windows.Forms.RadioButton()
    Me.btnBack = New System.Windows.Forms.Button()
    Me.btnApply = New System.Windows.Forms.Button()
    Me.cboxCompressionScheme = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.txtDefaultFileName = New System.Windows.Forms.TextBox()
    Me.rBtnFileNameCreationModeDefault = New System.Windows.Forms.RadioButton()
    Me.rBtnFileNameCreationModeFirstPage = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.rBtnOrderToTime = New System.Windows.Forms.RadioButton()
    Me.rBtnOrderToManual = New System.Windows.Forms.RadioButton()
    Me.rBtnOrderToName = New System.Windows.Forms.RadioButton()
    Me.rBtnOrderToAuto = New System.Windows.Forms.RadioButton()
    Me.chkDeleteOriginalFiles = New System.Windows.Forms.CheckBox()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.AllowDrop = True
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(305, 475)
    Me.TabControl1.TabIndex = 1
    '
    'TabPage1
    '
    Me.TabPage1.AllowDrop = True
    Me.TabPage1.Controls.Add(Me.btnDown)
    Me.TabPage1.Controls.Add(Me.btnUp)
    Me.TabPage1.Controls.Add(Me.btnDelete)
    Me.TabPage1.Controls.Add(Me.btnConvert)
    Me.TabPage1.Controls.Add(Me.lboxImageFileNames)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(297, 449)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "画像ファイル変換"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'btnDown
    '
    Me.btnDown.Location = New System.Drawing.Point(102, 394)
    Me.btnDown.Name = "btnDown"
    Me.btnDown.Size = New System.Drawing.Size(91, 23)
    Me.btnDown.TabIndex = 6
    Me.btnDown.Text = "↓"
    Me.btnDown.UseVisualStyleBackColor = True
    '
    'btnUp
    '
    Me.btnUp.Location = New System.Drawing.Point(8, 394)
    Me.btnUp.Name = "btnUp"
    Me.btnUp.Size = New System.Drawing.Size(91, 23)
    Me.btnUp.TabIndex = 5
    Me.btnUp.Text = "↑"
    Me.btnUp.UseVisualStyleBackColor = True
    '
    'btnDelete
    '
    Me.btnDelete.Location = New System.Drawing.Point(196, 394)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.Size = New System.Drawing.Size(91, 23)
    Me.btnDelete.TabIndex = 4
    Me.btnDelete.Text = "削除"
    Me.btnDelete.UseVisualStyleBackColor = True
    '
    'btnConvert
    '
    Me.btnConvert.Location = New System.Drawing.Point(196, 421)
    Me.btnConvert.Name = "btnConvert"
    Me.btnConvert.Size = New System.Drawing.Size(92, 23)
    Me.btnConvert.TabIndex = 1
    Me.btnConvert.Text = "変換"
    Me.btnConvert.UseVisualStyleBackColor = True
    '
    'lboxImageFileNames
    '
    Me.lboxImageFileNames.AllowDrop = True
    Me.lboxImageFileNames.FormattingEnabled = True
    Me.lboxImageFileNames.HorizontalScrollbar = True
    Me.lboxImageFileNames.ItemHeight = 12
    Me.lboxImageFileNames.Location = New System.Drawing.Point(8, 22)
    Me.lboxImageFileNames.Name = "lboxImageFileNames"
    Me.lboxImageFileNames.Size = New System.Drawing.Size(280, 364)
    Me.lboxImageFileNames.TabIndex = 0
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.GroupBox3)
    Me.TabPage2.Controls.Add(Me.btnBack)
    Me.TabPage2.Controls.Add(Me.btnApply)
    Me.TabPage2.Controls.Add(Me.cboxCompressionScheme)
    Me.TabPage2.Controls.Add(Me.Label2)
    Me.TabPage2.Controls.Add(Me.GroupBox2)
    Me.TabPage2.Controls.Add(Me.GroupBox1)
    Me.TabPage2.Controls.Add(Me.chkDeleteOriginalFiles)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(297, 449)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "設定"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.rBtnFileDestModeFirstPage)
    Me.GroupBox3.Controls.Add(Me.btnShowDirDialog)
    Me.GroupBox3.Controls.Add(Me.txtDefaultFileDest)
    Me.GroupBox3.Controls.Add(Me.rBtnFileDestModeDefault)
    Me.GroupBox3.Controls.Add(Me.rBtnFileDestModeManual)
    Me.GroupBox3.Location = New System.Drawing.Point(17, 251)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(259, 118)
    Me.GroupBox3.TabIndex = 16
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "生成したファイルの保存先"
    '
    'rBtnFileDestModeFirstPage
    '
    Me.rBtnFileDestModeFirstPage.AutoSize = True
    Me.rBtnFileDestModeFirstPage.Checked = True
    Me.rBtnFileDestModeFirstPage.Location = New System.Drawing.Point(9, 21)
    Me.rBtnFileDestModeFirstPage.Name = "rBtnFileDestModeFirstPage"
    Me.rBtnFileDestModeFirstPage.Size = New System.Drawing.Size(162, 16)
    Me.rBtnFileDestModeFirstPage.TabIndex = 8
    Me.rBtnFileDestModeFirstPage.TabStop = True
    Me.rBtnFileDestModeFirstPage.Text = "１ページ目のファイルのフォルダ"
    Me.rBtnFileDestModeFirstPage.UseVisualStyleBackColor = True
    '
    'btnShowDirDialog
    '
    Me.btnShowDirDialog.Location = New System.Drawing.Point(188, 86)
    Me.btnShowDirDialog.Name = "btnShowDirDialog"
    Me.btnShowDirDialog.Size = New System.Drawing.Size(65, 23)
    Me.btnShowDirDialog.TabIndex = 7
    Me.btnShowDirDialog.Text = "フォルダ"
    Me.btnShowDirDialog.UseVisualStyleBackColor = True
    '
    'txtDefaultFileDest
    '
    Me.txtDefaultFileDest.Location = New System.Drawing.Point(23, 88)
    Me.txtDefaultFileDest.Name = "txtDefaultFileDest"
    Me.txtDefaultFileDest.ReadOnly = True
    Me.txtDefaultFileDest.Size = New System.Drawing.Size(159, 19)
    Me.txtDefaultFileDest.TabIndex = 6
    '
    'rBtnFileDestModeDefault
    '
    Me.rBtnFileDestModeDefault.AutoSize = True
    Me.rBtnFileDestModeDefault.Location = New System.Drawing.Point(9, 65)
    Me.rBtnFileDestModeDefault.Name = "rBtnFileDestModeDefault"
    Me.rBtnFileDestModeDefault.Size = New System.Drawing.Size(102, 16)
    Me.rBtnFileDestModeDefault.TabIndex = 5
    Me.rBtnFileDestModeDefault.Text = "デフォルトフォルダ"
    Me.rBtnFileDestModeDefault.UseVisualStyleBackColor = True
    '
    'rBtnFileDestModeManual
    '
    Me.rBtnFileDestModeManual.AutoSize = True
    Me.rBtnFileDestModeManual.Location = New System.Drawing.Point(9, 43)
    Me.rBtnFileDestModeManual.Name = "rBtnFileDestModeManual"
    Me.rBtnFileDestModeManual.Size = New System.Drawing.Size(151, 16)
    Me.rBtnFileDestModeManual.TabIndex = 4
    Me.rBtnFileDestModeManual.Text = "ダイアログを開いて選択する"
    Me.rBtnFileDestModeManual.UseVisualStyleBackColor = True
    '
    'btnBack
    '
    Me.btnBack.Location = New System.Drawing.Point(93, 411)
    Me.btnBack.Name = "btnBack"
    Me.btnBack.Size = New System.Drawing.Size(75, 23)
    Me.btnBack.TabIndex = 15
    Me.btnBack.Text = "元に戻す"
    Me.btnBack.UseVisualStyleBackColor = True
    '
    'btnApply
    '
    Me.btnApply.Location = New System.Drawing.Point(12, 411)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(75, 23)
    Me.btnApply.TabIndex = 14
    Me.btnApply.Text = "適用"
    Me.btnApply.UseVisualStyleBackColor = True
    '
    'cboxCompressionScheme
    '
    Me.cboxCompressionScheme.FormattingEnabled = True
    Me.cboxCompressionScheme.Location = New System.Drawing.Point(78, 380)
    Me.cboxCompressionScheme.Name = "cboxCompressionScheme"
    Me.cboxCompressionScheme.Size = New System.Drawing.Size(157, 20)
    Me.cboxCompressionScheme.TabIndex = 13
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(15, 384)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 12)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "圧縮形式"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.txtDefaultFileName)
    Me.GroupBox2.Controls.Add(Me.rBtnFileNameCreationModeDefault)
    Me.GroupBox2.Controls.Add(Me.rBtnFileNameCreationModeFirstPage)
    Me.GroupBox2.Location = New System.Drawing.Point(17, 168)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(259, 74)
    Me.GroupBox2.TabIndex = 11
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "生成後のファイル名"
    '
    'txtDefaultFileName
    '
    Me.txtDefaultFileName.Location = New System.Drawing.Point(112, 43)
    Me.txtDefaultFileName.Name = "txtDefaultFileName"
    Me.txtDefaultFileName.Size = New System.Drawing.Size(125, 19)
    Me.txtDefaultFileName.TabIndex = 6
    '
    'rBtnFileNameCreationModeDefault
    '
    Me.rBtnFileNameCreationModeDefault.AutoSize = True
    Me.rBtnFileNameCreationModeDefault.Location = New System.Drawing.Point(9, 44)
    Me.rBtnFileNameCreationModeDefault.Name = "rBtnFileNameCreationModeDefault"
    Me.rBtnFileNameCreationModeDefault.Size = New System.Drawing.Size(79, 16)
    Me.rBtnFileNameCreationModeDefault.TabIndex = 5
    Me.rBtnFileNameCreationModeDefault.TabStop = True
    Me.rBtnFileNameCreationModeDefault.Text = "デフォルト名"
    Me.rBtnFileNameCreationModeDefault.UseVisualStyleBackColor = True
    '
    'rBtnFileNameCreationModeFirstPage
    '
    Me.rBtnFileNameCreationModeFirstPage.AutoSize = True
    Me.rBtnFileNameCreationModeFirstPage.Checked = True
    Me.rBtnFileNameCreationModeFirstPage.Location = New System.Drawing.Point(9, 20)
    Me.rBtnFileNameCreationModeFirstPage.Name = "rBtnFileNameCreationModeFirstPage"
    Me.rBtnFileNameCreationModeFirstPage.Size = New System.Drawing.Size(129, 16)
    Me.rBtnFileNameCreationModeFirstPage.TabIndex = 3
    Me.rBtnFileNameCreationModeFirstPage.TabStop = True
    Me.rBtnFileNameCreationModeFirstPage.Text = "１ページ目のファイル名"
    Me.rBtnFileNameCreationModeFirstPage.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToTime)
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToManual)
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToName)
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToAuto)
    Me.GroupBox1.Location = New System.Drawing.Point(17, 41)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(259, 118)
    Me.GroupBox1.TabIndex = 10
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "マルチTiff内での画像ファイルの順番"
    '
    'rBtnOrderToTime
    '
    Me.rBtnOrderToTime.AutoSize = True
    Me.rBtnOrderToTime.Location = New System.Drawing.Point(9, 69)
    Me.rBtnOrderToTime.Name = "rBtnOrderToTime"
    Me.rBtnOrderToTime.Size = New System.Drawing.Size(127, 16)
    Me.rBtnOrderToTime.TabIndex = 3
    Me.rBtnOrderToTime.TabStop = True
    Me.rBtnOrderToTime.Text = "ファイルの作成日時順"
    Me.rBtnOrderToTime.UseVisualStyleBackColor = True
    '
    'rBtnOrderToManual
    '
    Me.rBtnOrderToManual.AutoSize = True
    Me.rBtnOrderToManual.Location = New System.Drawing.Point(9, 93)
    Me.rBtnOrderToManual.Name = "rBtnOrderToManual"
    Me.rBtnOrderToManual.Size = New System.Drawing.Size(173, 16)
    Me.rBtnOrderToManual.TabIndex = 2
    Me.rBtnOrderToManual.TabStop = True
    Me.rBtnOrderToManual.Text = "ダイアログを開いて手動で並べる"
    Me.rBtnOrderToManual.UseVisualStyleBackColor = True
    '
    'rBtnOrderToName
    '
    Me.rBtnOrderToName.AutoSize = True
    Me.rBtnOrderToName.Location = New System.Drawing.Point(9, 45)
    Me.rBtnOrderToName.Name = "rBtnOrderToName"
    Me.rBtnOrderToName.Size = New System.Drawing.Size(103, 16)
    Me.rBtnOrderToName.TabIndex = 1
    Me.rBtnOrderToName.TabStop = True
    Me.rBtnOrderToName.Text = "ファイル名の順番"
    Me.rBtnOrderToName.UseVisualStyleBackColor = True
    '
    'rBtnOrderToAuto
    '
    Me.rBtnOrderToAuto.AutoSize = True
    Me.rBtnOrderToAuto.Checked = True
    Me.rBtnOrderToAuto.Location = New System.Drawing.Point(9, 21)
    Me.rBtnOrderToAuto.Name = "rBtnOrderToAuto"
    Me.rBtnOrderToAuto.Size = New System.Drawing.Size(47, 16)
    Me.rBtnOrderToAuto.TabIndex = 0
    Me.rBtnOrderToAuto.TabStop = True
    Me.rBtnOrderToAuto.Text = "自動"
    Me.rBtnOrderToAuto.UseVisualStyleBackColor = True
    '
    'chkDeleteOriginalFiles
    '
    Me.chkDeleteOriginalFiles.AutoSize = True
    Me.chkDeleteOriginalFiles.Location = New System.Drawing.Point(17, 15)
    Me.chkDeleteOriginalFiles.Name = "chkDeleteOriginalFiles"
    Me.chkDeleteOriginalFiles.Size = New System.Drawing.Size(247, 16)
    Me.chkDeleteOriginalFiles.TabIndex = 9
    Me.chkDeleteOriginalFiles.Text = "マルチTiff生成後に元の画像ファイルを削除する"
    Me.chkDeleteOriginalFiles.UseVisualStyleBackColor = True
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(304, 475)
    Me.Controls.Add(Me.TabControl1)
    Me.MaximizeBox = False
    Me.Name = "MainForm"
    Me.Text = "マルチTiff変換"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TabControl1 As TabControl
  Friend WithEvents TabPage1 As TabPage
  Friend WithEvents btnConvert As Button
  Friend WithEvents lboxImageFileNames As ListBox
  Friend WithEvents TabPage2 As TabPage
  Friend WithEvents btnBack As Button
  Friend WithEvents btnApply As Button
  Friend WithEvents cboxCompressionScheme As ComboBox
  Friend WithEvents Label2 As Label
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents txtDefaultFileName As TextBox
  Friend WithEvents rBtnFileNameCreationModeDefault As RadioButton
  Friend WithEvents rBtnFileDestModeManual As RadioButton
  Friend WithEvents rBtnFileNameCreationModeFirstPage As RadioButton
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents rBtnOrderToManual As RadioButton
  Friend WithEvents rBtnOrderToName As RadioButton
  Friend WithEvents rBtnOrderToAuto As RadioButton
  Friend WithEvents chkDeleteOriginalFiles As CheckBox
  Friend WithEvents btnDown As Button
  Friend WithEvents btnUp As Button
  Friend WithEvents btnDelete As Button
  Friend WithEvents rBtnOrderToTime As RadioButton
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents txtDefaultFileDest As TextBox
  Friend WithEvents rBtnFileDestModeDefault As RadioButton
  Friend WithEvents btnShowDirDialog As Button
  Friend WithEvents rBtnFileDestModeFirstPage As RadioButton
End Class
