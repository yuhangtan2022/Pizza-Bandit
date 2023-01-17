Imports WMPLib
Public Class GAMEOVER
    Dim player As WindowsMediaPlayer = New WindowsMediaPlayer
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        quit = True
        Me.Hide()
    End Sub

    Private Sub GAMEOVER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        player.URL = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\fidgetspinners.wav"
        player.controls.play()
    End Sub

    Private Sub GAMEOVER_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            player.controls.stop()
        End If
    End Sub
End Class