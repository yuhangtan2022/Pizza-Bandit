Imports WMPLib
Public Class welcome
    Dim player1 As WindowsMediaPlayer = New WindowsMediaPlayer
    Dim rainingPizzas(6) As PictureBox
    Dim firstFootForward As Boolean
    Dim firstfoootforward As Boolean
    Dim mouthOpen As Boolean
    Dim switchoff As Boolean
    Dim moorepizza As Boolean
    Dim trapnum As Integer
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub reggieface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reggieface.Click

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rp6.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        For rindex = 0 To 6
            MoveDown(rainingPizzas(rindex), 3)
        Next rindex
    End Sub
    Private Sub welcome_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        player1.URL = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pizzaSong.wav"
        player1.controls.play()
        trapnum = 0
        rainingPizzas(0) = rp0
        rainingPizzas(1) = rp1
        rainingPizzas(2) = rp2
        rainingPizzas(3) = rp3
        rainingPizzas(4) = rp4
        rainingPizzas(5) = rp5
        rainingPizzas(6) = rp6
        Timer2.Start()
        Timer1.Start()
    End Sub
    Private Sub MoveDown(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Top > 300 Then
            guy.Top = 0 - guy.Height
        Else
            guy.Top = guy.Top + speed
        End If
    End Sub
    Private Sub animateleft()
        If firstFootForward = True Then
            rs2.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt2.png")
            firstFootForward = False
        Else
            rs2.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animateright()
        If firstfoootforward = True Then
            rs1.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt2.png")
            firstfoootforward = False
        Else
            rs1.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt1.png")
            firstfoootforward = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        animateleft()
        animateright()
        mouthclose()
        morepizzas()
        trapAnimate()
    End Sub
    Private Sub mouthclose()
        If mouthOpen = True Then
            reggieface.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ReggieEating.png")
            mouthOpen = False
        Else
            reggieface.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Reggie\Lives.png")
            mouthOpen = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        exitgame = True
        Me.Hide()
    End Sub


    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pizzaFreezer.Click
        If switchoff = True Then
            pizzaFreezer.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\switchBIG.png")
            Timer1.Start()
            Timer2.Start()
            switchoff = False
        Else
            pizzaFreezer.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\switchOFF.png")
            Timer1.Stop()
            Timer2.Stop()
            switchoff = True
        End If
    End Sub
    Private Sub morepizzas()
        If moorepizza = True Then
            morepizza.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\switchOFF.png")
            moorepizza = False
        Else
            morepizza.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\switchBIG.png")
            moorepizza = True
        End If
    End Sub
    Private Sub trapAnimate()
        Select Case trapnum
            Case 0
                trapnum = 1
                bestcage.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\RRTrapped0.bmp")
            Case 1
                trapnum = 2
                bestcage.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\RRTrapped1.bmp")
            Case 2
                trapnum = 3
                bestcage.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\RRTrapped2.bmp")
            Case 3
                trapnum = 4
                bestcage.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\RRTrapped3.bmp")
            Case 4
                trapnum = 0
                bestcage.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\RRTrapped4.bmp")
        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        instruction.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        scoreForm.ShowDialog()
    End Sub

    Private Sub welcome_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            player1.controls.stop()

        End If
    End Sub
End Class