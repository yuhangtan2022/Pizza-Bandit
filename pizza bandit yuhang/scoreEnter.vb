Public Class scoreEnter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name = nb.Text
        My.Computer.FileSystem.WriteAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\score.txt", name & "," & score & Environment.NewLine, True)
        Me.Hide()
    End Sub

    Private Sub scoreEnter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sl.Text = score
    End Sub
End Class