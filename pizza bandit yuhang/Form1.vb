Imports WMPLib
Public Class MainForm
    Dim firstFootForward As Boolean
    Dim direction As Integer
    Dim vroads(3) As PictureBox
    Dim hroads(1) As PictureBox
    Dim cages(3) As PictureBox
    Dim cagesdirection(3) As Integer
    Dim cagestates(3) As Integer
    Dim cagenum As Integer
    Dim pizza(41) As PictureBox
    Dim pizzanum As Integer
    Dim sswitch(4) As PictureBox
    Dim ticks(3) As Integer
    Dim OldStates(3) As Integer
    Dim lives(2) As PictureBox
    Dim captime As Integer
    Dim livesnum As Integer
    Dim ticksnum As Integer
    Dim bpizza(4) As PictureBox
    Dim cageSpeed As Integer
    Public player As WindowsMediaPlayer = New WindowsMediaPlayer
    Public Shared CaptureReggie As New CaptureReggie
    Public Shared mainmenu As New welcome
    Public Shared youWin As New winForm
    Const INHOME As Integer = 0
    Const LEAVING As Integer = 1
    Const REGULAR As Integer = 2
    Const DISABLED As Integer = 3
    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        For index = 0 To 3
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.W Or e.KeyCode = Keys.S Then
                If touching(Reggie, vroads(index)) Then
                    direction = e.KeyCode
                End If
            End If
        Next index
        For index = 0 To 1
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.A Or e.KeyCode = Keys.D Then
                If touching(Reggie, hroads(index)) Then
                    direction = e.KeyCode
                End If
            End If
        Next index
        If direction = Keys.W Then
            direction = Keys.Up
        ElseIf direction = Keys.S Then
            direction = Keys.Down
        ElseIf direction = Keys.A Then
            direction = Keys.Left
        ElseIf direction = Keys.D Then
            direction = Keys.Right
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PizzaCounter.Text = pizzanum
        livenum.Text = livesnum
        scoreNum.Text = score
        MoveReggie()
        AnimateReggie()
        checkbeatlevel()
        switches()
        ebp()
        For cindex = 0 To 3
            If cagestates(cindex) = REGULAR Then
                MoveCages(cindex)
                If AtIntersection(cindex) Then
                    ChaseReggie(cindex)
                End If
                If touching(Reggie, cages(cindex)) Then
                    If captime < 3 Then
                        score -= 5
                        Timer1.Stop()
                        player.controls.pause()
                        CaptureReggie.ShowDialog()
                        lives(captime).Visible = False
                        captime += 1
                        livesnum -= 1
                        ResetLevel()
                        Timer1.Start()
                        player.controls.play()
                    Else
                        Timer1.Stop()
                        player.controls.pause()
                        scoreEnter.ShowDialog()
                        GAMEOVER.ShowDialog()
                        ResetLevel()
                        Timer1.Start()
                        player.controls.play()
                    End If
                End If
            ElseIf cagestates(cindex) = DISABLED Then
                ticks(cindex) += 1
                If ticks(cindex) > ticksnum Then
                    ticksnum = 0
                    cagestates(cindex) = OldStates(cindex)
                    Select Case OldStates(cindex)
                        Case INHOME
                            cages(cindex).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage2L.png")
                        Case LEAVING
                            cages(cindex).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage1L.png")
                        Case REGULAR
                            cages(cindex).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage0L.png")
                    End Select
                End If
            Else
                MoveInToGame()
            End If
        Next cindex
        If exitgame = True Then
            Me.Close()
        End If
        If quit = True Then
            quit = False
            Timer1.Stop()
            player.controls.pause()
            welcome.ShowDialog()
            bigpizza()
            score = 0
            For zindex = 0 To 41
                pizza(zindex).Visible = True
            Next zindex
            For lindex = 0 To 2
                lives(lindex).Visible = True
            Next lindex
            livesnum = 3
            captime = 0
            switchSet()
            pizzanum = 0
            Timer1.Start()
            player.controls.play()
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        quit = False
        exitgame = False
        welcome.ShowDialog()
        vroads(0) = vroad0
        vroads(1) = vroad1
        vroads(2) = vroad2
        vroads(3) = vroad3
        hroads(0) = hroad0
        hroads(1) = hroad1
        sswitch(0) = sw0
        sswitch(1) = sw2
        sswitch(2) = sw6
        lives(0) = live2
        lives(1) = live1
        lives(2) = live0
        ticksnum = 0
        livesnum = 3
        captime = 0
        pizzanum = 0
        score = 0
        ResetLevel()
        switchSet()
        player.controls.pause()
        player.URL = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\backMusic.wav"
        Timer1.Start()
    End Sub
    Private Sub MoveUp(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Bottom < 0 Then
            guy.Top = 780
        Else
            guy.Top = guy.Top - speed
        End If
    End Sub
    Private Sub MoveDown(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Top > 780 Then
            guy.Top = 0 - guy.Height
        Else
            guy.Top = guy.Top + speed
        End If
    End Sub
    Private Sub MoveLeft(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Right < 0 Then
            guy.Left = 1200
        Else
            guy.Left = guy.Left - speed
        End If
    End Sub
    Private Sub MoveRight(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Left > 1200 Then
            guy.Left = 0 - guy.Width
        Else
            guy.Left = guy.Left + speed
        End If
    End Sub
    Private Sub Animateup()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrup2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrup1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animatedown()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrdn2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrdn1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animateleft()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animateright()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt1.png")
            firstFootForward = True
        End If
    End Sub
    Private Function touching(ByVal object1 As PictureBox, ByVal object2 As PictureBox)
        If object1.Right > object2.Left And object1.Left < object2.Right Then
            If object1.Top < object2.Bottom And object1.Bottom > object2.Top Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Function AtIntersection(ByVal cindex As Integer)
        For index = 0 To 3
            If touching(cages(cindex), vroads(index)) And touching(cages(cindex), hroad0) Then
                Return True
            ElseIf touching(cages(cindex), vroads(index)) And touching(cages(cindex), hroad1) Then
                Return True
            End If
        Next index
        Return False
    End Function
    Private Sub MoveReggie()
        Dim index As Integer
        For index = 0 To 3
            If touching(Reggie, vroads(index)) Then
                If direction = Keys.Up Then
                    MoveUp(Reggie, 10)
                    Reggie.Left = vroads(index).Left
                End If
                If direction = Keys.Down Then
                    MoveDown(Reggie, 10)
                    Reggie.Left = vroads(index).Left
                End If
            End If
        Next index
        For index = 0 To 1
            If touching(Reggie, hroads(index)) Then
                If direction = Keys.Left Then
                    MoveLeft(Reggie, 10)
                    Reggie.Top = hroads(index).Top
                End If
                If direction = Keys.Right Then
                    MoveRight(Reggie, 10)
                    Reggie.Top = hroads(index).Top
                End If
            End If
        Next index
    End Sub
    Private Sub AnimateReggie()
        If direction = Keys.Up Then
            Animateup()
        ElseIf direction = Keys.Down Then
            animatedown()
        ElseIf direction = Keys.Left Then
            animateleft()
        ElseIf direction = Keys.Right Then
            animateright()
        End If
    End Sub
    Private Sub MoveCages(ByVal cindex As Integer)
        Dim index As Integer
        For index = 0 To 3
            If touching(cages(cindex), vroads(index)) Then
                If cagesdirection(cindex) = Keys.Up Then
                    MoveUp(cages(cindex), cageSpeed)
                    cages(cindex).Left = vroads(index).Left
                End If
                If cagesdirection(cindex) = Keys.Down Then
                    MoveDown(cages(cindex), cageSpeed)
                    cages(cindex).Left = vroads(index).Left
                End If
            End If
        Next index
        For index = 0 To 1
            If touching(cages(cindex), hroads(index)) Then
                If cagesdirection(cindex) = Keys.Left Then
                    MoveLeft(cages(cindex), cageSpeed)
                    cages(cindex).Top = hroads(index).Top
                End If
                If cagesdirection(cindex) = Keys.Right Then
                    MoveRight(cages(cindex), cageSpeed)
                    cages(cindex).Top = hroads(index).Top
                End If
            End If

        Next index
    End Sub
    Private Sub ChaseReggie(ByVal cindex As Integer)
        Dim xDistance As Integer
        Dim yDistance As Integer
        xDistance = Math.Abs(Reggie.Left - cages(cindex).Left)
        yDistance = Math.Abs(Reggie.Top - cages(cindex).Top)
        If xDistance > yDistance Then
            If Reggie.Left > cages(cindex).Left Then
                cagesdirection(cindex) = Keys.Right
            Else
                cagesdirection(cindex) = Keys.Left
            End If
        Else
            If cages(cindex).Top < Reggie.Top Then
                cagesdirection(cindex) = Keys.Down
            Else
                cagesdirection(cindex) = Keys.Up
            End If
        End If
    End Sub
    Private Sub CagesSet()
        cageSpeed = 5
        cagenum = 0
        cagestates(0) = INHOME
        cagestates(1) = INHOME
        cagestates(2) = INHOME
        cagestates(3) = INHOME
        cage0.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage2L.png")
        cage1.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage2R.png")
        cage2.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage2L.png")
        cage3.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage2R.png")
        cages(0) = cage0
        cages(1) = cage1
        cages(2) = cage2
        cages(3) = cage3
        cagesdirection(0) = Keys.Left
        cagesdirection(1) = Keys.Right
        cagesdirection(2) = Keys.Left
        cagesdirection(3) = Keys.Right
        cages(0).Left = 484
        cages(0).Top = 388
        cages(1).Left = 564
        cages(1).Top = 388
        cages(2).Left = 484
        cages(2).Top = 456
        cages(3).Left = 564
        cages(3).Top = 456
    End Sub
    Private Sub ResetLevel()
        CagesSet()
        ReggieSet()
        pizzaSet()
    End Sub
    Private Sub MoveInToGame()
        If cagestates(cagenum) = INHOME Then
            cagestates(cagenum) = LEAVING
            cages(cagenum).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage1L.png")
            cages(cagenum).Left = 529
            cages(cagenum).Top = 415
        ElseIf cagestates(cagenum) = LEAVING Then
            MoveUp(cages(cagenum), 2)
            If touching(cages(cagenum), hroad0) Then
                cagestates(cagenum) = REGULAR
                cages(cagenum).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCage0L.png")
                cagenum = cagenum + 1
            End If
        End If
    End Sub
    Private Sub ReggieSet()
        Reggie.Left = 539
        Reggie.Top = 621
        firstFootForward = True
        Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt2.png")
    End Sub
    Private Sub pizzaSet()
        pizza(0) = PictureBox1
        pizza(1) = PictureBox2
        pizza(2) = PictureBox3
        pizza(3) = PictureBox4
        pizza(4) = PictureBox5
        pizza(5) = PictureBox6
        pizza(6) = PictureBox7
        pizza(7) = PictureBox8
        pizza(8) = PictureBox9
        pizza(9) = PictureBox10
        pizza(10) = PictureBox11
        pizza(11) = PictureBox12
        pizza(12) = PictureBox13
        pizza(13) = PictureBox14
        pizza(14) = PictureBox15
        pizza(15) = PictureBox16
        pizza(16) = PictureBox17
        pizza(17) = PictureBox18
        pizza(18) = PictureBox19
        pizza(19) = PictureBox20
        pizza(20) = PictureBox21
        pizza(21) = PictureBox22
        pizza(22) = PictureBox23
        pizza(23) = PictureBox24
        pizza(24) = PictureBox25
        pizza(25) = PictureBox26
        pizza(26) = PictureBox27
        pizza(27) = PictureBox28
        pizza(28) = PictureBox29
        pizza(29) = PictureBox30
        pizza(30) = PictureBox31
        pizza(31) = PictureBox32
        pizza(32) = PictureBox33
        pizza(33) = PictureBox34
        pizza(34) = PictureBox35
        pizza(35) = PictureBox36
        pizza(36) = PictureBox37
        pizza(37) = PictureBox38
        pizza(38) = PictureBox39
        pizza(39) = PictureBox40
        pizza(40) = PictureBox41
        pizza(41) = PictureBox42
        bpizza(0) = bp0
        bpizza(1) = bp1
        bpizza(2) = bp2
        bpizza(3) = bp3
        bpizza(4) = bp4
    End Sub
    Private Sub checkbeatlevel()
        For pindex = 0 To 41
            If touching(Reggie, pizza(pindex)) And pizza(pindex).Visible = True Then
                pizza(pindex).Visible = False
                pizzanum += 1
                score += 1
                If pizzanum = 42 Then
                    Timer1.Stop()
                    player.controls.pause()
                    scoreEnter.ShowDialog()
                    winForm.ShowDialog()
                    ResetLevel()
                    For zindex = 0 To 41
                        pizza(zindex).Visible = True
                    Next zindex
                    switchSet()
                    bigpizza()
                    score = 0
                    pizzanum = 0
                    Timer1.Start()
                    player.controls.play()
                End If
            End If
        Next pindex
    End Sub
    Private Sub switches()
        For sindex = 0 To 2
            If touching(Reggie, sswitch(sindex)) And sswitch(sindex).Visible = True Then
                score += 1
                sswitch(sindex).Visible = False
                ticksnum += 100
                For cindex = 0 To 3
                    If cagestates(cindex) = REGULAR Or cagestates(cindex) = INHOME Or cagestates(cindex) = LEAVING Then
                        OldStates(cindex) = cagestates(cindex)
                        cagestates(cindex) = DISABLED
                        cages(cindex).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\cages\RoboCageScaredL.png")
                        ticks(cindex) = 0
                    End If
                Next cindex
            End If
        Next sindex
    End Sub
    Private Sub switchSet()
        Randomize()
        Dim swVroad As Integer
        Dim yValue As Integer
        For ssindex = 0 To 2
            swVroad = CInt(Math.Floor(4 * Rnd()))
            yValue = CInt(Math.Floor(781 * Rnd()))
            sswitch(ssindex).Top = yValue
            sswitch(ssindex).Left = vroads(swVroad).Left + 10
            sswitch(ssindex).Visible = True
        Next ssindex
    End Sub

    Private Sub PictureBox43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox43.Click
        Timer1.Enabled = Not Timer1.Enabled
        If Timer1.Enabled = False Then
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
        Else
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Timer1.Start()
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        ResetLevel()
        bigpizza()
        score = 0
        For zindex = 0 To 41
            pizza(zindex).Visible = True
        Next zindex
        For lindex = 0 To 2
            lives(lindex).Visible = True
        Next lindex
        livesnum = 3
        captime = 0
        switchSet()
        pizzanum = 0
        Timer1.Start()
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        quit = True
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Timer1.Start()
    End Sub
    Private Sub bigpizza()
        Randomize()
        Dim swVroad As Integer
        Dim yValue As Integer
        For bindex = 0 To 4
            swVroad = CInt(Math.Floor(4 * Rnd()))
            yValue = CInt(Math.Floor(781 * Rnd()))
            bpizza(bindex).Top = yValue
            bpizza(bindex).Left = vroads(swVroad).Left + 10
            bpizza(bindex).Visible = True
        Next bindex
    End Sub
    Private Sub ebp()
        For bpindex = 0 To 4
            If touching(Reggie, bpizza(bpindex)) And bpizza(bpindex).Visible Then
                bpizza(bpindex).Visible = False
                score += 5
            End If
        Next bpindex
    End Sub

    Private Sub MainForm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            player.controls.stop()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        cageSpeed += 1
    End Sub
End Class
