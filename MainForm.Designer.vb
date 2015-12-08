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
    Me.btnConvert = New System.Windows.Forms.Button()
    Me.lboxImageFileNames = New System.Windows.Forms.ListBox()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.btnBack = New System.Windows.Forms.Button()
    Me.btnApply = New System.Windows.Forms.Button()
    Me.cboxCompressionScheme = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.txtDefaultFileName = New System.Windows.Forms.TextBox()
    Me.rBtnFileNameCreationModeDefault = New System.Windows.Forms.RadioButton()
    Me.rBtnFileNameCreationModeManual = New System.Windows.Forms.RadioButton()
    Me.rBtnFileNameCreationModeFirstPage = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.rBtnOrderToManual = New System.Windows.Forms.RadioButton()
    Me.rBtnOrderToName = New System.Windows.Forms.RadioButton()
    Me.rBtnOrderToAuto = New System.Windows.Forms.RadioButton()
    Me.chkDeleteOriginalFiles = New System.Windows.Forms.CheckBox()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
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
    Me.TabControl1.Size = New System.Drawing.Size(305, 426)
    Me.TabControl1.TabIndex = 1
    '
    'TabPage1
    '
    Me.TabPage1.AllowDrop = True
    Me.TabPage1.Controls.Add(Me.btnConvert)
    Me.TabPage1.Controls.Add(Me.lboxImageFileNames)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(297, 400)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "画像ファイル変換"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'btnConvert
    '
    Me.btnConvert.Location = New System.Drawing.Point(184, 370)
    Me.btnConvert.Name = "btnConvert"
    Me.btnConvert.Size = New System.Drawing.Size(104, 23)
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
    Me.lboxImageFileNames.Size = New System.Drawing.Size(280, 340)
    Me.lboxImageFileNames.TabIndex = 0
    '
    'TabPage2
    '
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
    Me.TabPage2.Size = New System.Drawing.Size(297, 400)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "設定"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'btnBack
    '
    Me.btnBack.Location = New System.Drawing.Point(93, 320)
    Me.btnBack.Name = "btnBack"
    Me.btnBack.Size = New System.Drawing.Size(75, 23)
    Me.btnBack.TabIndex = 15
    Me.btnBack.Text = "元に戻す"
    Me.btnBack.UseVisualStyleBackColor = True
    '
    'btnApply
    '
    Me.btnApply.Location = New System.Drawing.Point(12, 320)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(75, 23)
    Me.btnApply.TabIndex = 14
    Me.btnApply.Text = "適用"
    Me.btnApply.UseVisualStyleBackColor = True
    '
    'cboxCompressionScheme
    '
    Me.cboxCompressionScheme.FormattingEnabled = True
    Me.cboxCompressionScheme.Location = New System.Drawing.Point(19, 280)
    Me.cboxCompressionScheme.Name = "cboxCompressionScheme"
    Me.cboxCompressionScheme.Size = New System.Drawing.Size(157, 20)
    Me.cboxCompressionScheme.TabIndex = 13
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(17, 264)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 12)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "圧縮形式"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.txtDefaultFileName)
    Me.GroupBox2.Controls.Add(Me.rBtnFileNameCreationModeDefault)
    Me.GroupBox2.Controls.Add(Me.rBtnFileNameCreationModeManual)
    Me.GroupBox2.Controls.Add(Me.rBtnFileNameCreationModeFirstPage)
    Me.GroupBox2.Location = New System.Drawing.Point(17, 153)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(259, 96)
    Me.GroupBox2.TabIndex = 11
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "生成後のファイル名"
    '
    'txtDefaultFileName
    '
    Me.txtDefaultFileName.Location = New System.Drawing.Point(112, 67)
    Me.txtDefaultFileName.Name = "txtDefaultFileName"
    Me.txtDefaultFileName.Size = New System.Drawing.Size(125, 19)
    Me.txtDefaultFileName.TabIndex = 6
    '
    'rBtnFileNameCreationModeDefault
    '
    Me.rBtnFileNameCreationModeDefault.AutoSize = True
    Me.rBtnFileNameCreationModeDefault.Location = New System.Drawing.Point(9, 68)
    Me.rBtnFileNameCreationModeDefault.Name = "rBtnFileNameCreationModeDefault"
    Me.rBtnFileNameCreationModeDefault.Size = New System.Drawing.Size(79, 16)
    Me.rBtnFileNameCreationModeDefault.TabIndex = 5
    Me.rBtnFileNameCreationModeDefault.TabStop = True
    Me.rBtnFileNameCreationModeDefault.Text = "デフォルト名"
    Me.rBtnFileNameCreationModeDefault.UseVisualStyleBackColor = True
    '
    'rBtnFileNameCreationModeManual
    '
    Me.rBtnFileNameCreationModeManual.AutoSize = True
    Me.rBtnFileNameCreationModeManual.Location = New System.Drawing.Point(9, 44)
    Me.rBtnFileNameCreationModeManual.Name = "rBtnFileNameCreationModeManual"
    Me.rBtnFileNameCreationModeManual.Size = New System.Drawing.Size(151, 16)
    Me.rBtnFileNameCreationModeManual.TabIndex = 4
    Me.rBtnFileNameCreationModeManual.TabStop = True
    Me.rBtnFileNameCreationModeManual.Text = "ダイアログを開いて入力する"
    Me.rBtnFileNameCreationModeManual.UseVisualStyleBackColor = True
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
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToManual)
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToName)
    Me.GroupBox1.Controls.Add(Me.rBtnOrderToAuto)
    Me.GroupBox1.Location = New System.Drawing.Point(17, 41)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(259, 96)
    Me.GroupBox1.TabIndex = 10
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "マルチTiff内での画像ファイルの順番"
    '
    'rBtnOrderToManual
    '
    Me.rBtnOrderToManual.AutoSize = True
    Me.rBtnOrderToManual.Location = New System.Drawing.Point(9, 69)
    Me.rBtnOrderToManual.Name = "rBtnOrderToManual"
    Me.rBtnOrderToManual.Size = New System.Drawing.Size(173, 16)
    Me.rBtnOrderToManual.TabIndex = 2
    Me.rBtnOrderToManual.TabStop = True
    Me.rBtnOrderToManual.Text = "ダイアログを開いて手動で決める"
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
    Me.ClientSize = New System.Drawing.Size(304, 424)
    Me.Controls.Add(Me.TabControl1)
    Me.Name = "MainForm"
    Me.Text = "MainForm2"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
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
  Friend WithEvents rBtnFileNameCreationModeManual As RadioButton
  Friend WithEvents rBtnFileNameCreationModeFirstPage As RadioButton
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents rBtnOrderToManual As RadioButton
  Friend WithEvents rBtnOrderToName As RadioButton
  Friend WithEvents rBtnOrderToAuto As RadioButton
  Friend WithEvents chkDeleteOriginalFiles As CheckBox
End Class
