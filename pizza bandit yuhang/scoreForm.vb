Public Class scoreForm
    Private Sub scoreForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Computer.FileSystem.WriteAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\score.txt", Environment.NewLine, False)
        loadGrid()
    End Sub
    Private Sub loadGrid()
        DataGridView1.Rows.Clear()
        Using scoreReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\score.txt")
            scoreReader.TextFieldType = FileIO.FieldType.Delimited
            scoreReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not scoreReader.EndOfData
                currentRow = scoreReader.ReadFields()
                DataGridView1.Rows.Add(currentRow)
            End While
        End Using
    End Sub
End Class