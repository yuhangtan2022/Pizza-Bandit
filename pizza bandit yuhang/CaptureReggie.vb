Public Class CaptureReggie

    Private Sub CaptureReggie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\CaptureSound.wav", AudioPlayMode.Background)
    End Sub

    Private Sub tryagain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tryagain.Click
        Me.Hide()
    End Sub

    Private Sub quitbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitbutton.Click
        quit = True
        Me.Hide()
    End Sub
End Class