
Imports MP.Details.IO

Namespace Utils

  Namespace Common
    Public Class MsgBox
      Public Shared Sub ShowWarn(msg As String)
        MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Sub
      Public Shared Sub ShowWarn(ex As Exception)
        Show(ex, "Warning", MessageBoxIcon.Warning)
      End Sub

      Public Shared Sub ShowError(msg As String)
        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Sub
      Public Shared Sub ShowError(ex As Exception)
        Show(ex, "Error", MessageBoxIcon.Warning)
      End Sub
      Private Shared Sub Show(ex As Exception, title As String, icon As MessageBoxIcon)
        MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, title, MessageBoxButtons.OK, icon)
      End Sub
    End Class

    Public Class PropertyManager
      Private FilePath As String
      Private DefProperties As IDictionary(Of String, String)
      Private Properties As IDictionary(Of String, String) = New Dictionary(Of String, String)

      Private EnableDefPropertyKeysOnly As Boolean

      Private hasRead As Boolean = False

      Public Sub New(filePath As String, def As IDictionary(Of String, String), enableDefPropertyKeysOnly As Boolean)
        Me.FilePath = filePath
        Me.DefProperties = def
        Me.EnableDefPropertyKeysOnly = enableDefPropertyKeysOnly
      End Sub

      Public Function GetValue(key As String) As String
        Load()

        If Properties.ContainsKey(key) Then
          Return Properties(key)
        Else
          Append(DefProperties)
          If Properties.ContainsKey(key) Then
            Return Properties(key)
          Else
            Return ""
          End If
        End If
      End Function

      Public Sub SetValue(key As String, value As String)
        Dim dict As Dictionary(Of String, String) = ToDictionary()
        dict.Add(key, value)
        PropertyAccessor.SetProp(FilePath, dict)
        Reload()
      End Sub

      Public Sub SetValues(dict As IDictionary(Of String, String))
        PropertyAccessor.SetProp(FilePath, dict)
        Reload()
      End Sub

      Private Sub Load()
        If Not hasRead Then
          Try
            Properties = PropertyAccessor.GetProp(FilePath)

            If EnableDefPropertyKeysOnly Then
              Dim nProp As IDictionary(Of String, String) = RemoveKeysThatDoseNotContainsToDefProperties(Properties)
              If nProp.Count() < Properties.Count() Then
                PropertyAccessor.SetProp(FilePath, nProp)
                Properties = nProp
              End If
            End If

            If Properties.Count < DefProperties.Count Then
              Append(DefProperties)
            End If
          Catch ex As System.IO.FileNotFoundException
            PropertyAccessor.SetProp(FilePath, DefProperties)
            Properties = DefProperties
          Catch ex As Exception
            MsgBox.ShowError(ex)
          End Try
          hasRead = True
        End If
      End Sub

      Private Sub Append(addedProp As IDictionary(Of String, String))
        PropertyAccessor.AppendOnlyPropThatDoesNotExists(FilePath, addedProp)
        Reload()
      End Sub

      Private Sub Reload()
        hasRead = False
        Load()
      End Sub

      Private Function RemoveKeysThatDoseNotContainsToDefProperties(prop As IDictionary(Of String, String)) As IDictionary(Of String, String)
        Dim nDict As New Dictionary(Of String, String)
        For Each k As String In prop.Keys
          If DefProperties.ContainsKey(k) Then
            nDict.Add(k, prop(k))
          End If
        Next
        Return nDict
      End Function

      Public Function ToDictionary() As IDictionary(Of String, String)
        Load()

        Dim dict As New Dictionary(Of String, String)
        Properties.Keys.ToList.ForEach(
          Sub(key) dict.Add(key, Properties(key)))

        Return dict
      End Function

    End Class

    Public Class MyEnum

      '使い方 GetNames(GetType(EnumType))
      Public Shared Function GetNames(type As System.Type) As List(Of String)
        Return [Enum].GetNames(type).ToList
      End Function

      Public Shared Function GetId(type As [Type], name As String, defaultId As Integer) As Integer
        For Each id As Integer In [Enum].GetValues(type)
          If [Enum].GetName(type, id) = name Then
            Return id
          End If
        Next
        Return defaultId
      End Function

      Public Shared Function GetName(type As [Type], id As Integer, defaultName As String) As String
        If Array.Exists(Of Integer)([Enum].GetValues(type), Function(i) i = id) Then
          Return [Enum].GetName(type, id)
        Else
          Return defaultName
        End If
        [Enum].GetName(type, id)
      End Function
    End Class
  End Namespace
End Namespace
