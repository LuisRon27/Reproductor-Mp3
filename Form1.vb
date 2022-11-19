Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        End

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        WindowState = FormWindowState.Minimized


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If ListBox1.Items.Count <> 0 Then

            If Reproductor.playState = WMPLib.WMPPlayState.wmppsPlaying Then

                Reproductor.Ctlcontrols.pause()
                PictureBox3.Image = Pic_play.Image

            ElseIf Reproductor.playState = WMPLib.WMPPlayState.wmppsPaused Then
                Reproductor.Ctlcontrols.play()
                PictureBox3.Image = Pic_paused.Image

            End If

        End If




    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Try

            ListBox1.SelectedIndex += 1
            Reproductor.URL = ListBox1.SelectedItem

        Catch ex As Exception

            ListBox1.SelectedIndex = 0

        End Try


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        Try

            If ListBox1.SelectedIndex <> 0 Then
                ListBox1.SelectedIndex -= 1
            End If

            Reproductor.URL = ListBox1.SelectedItem

        Catch ex As Exception



        End Try

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll


        Reproductor.Ctlcontrols.currentPosition = TrackBar1.Value


    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        OpenFileDialog1.ShowDialog()



    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        For Each track As String In OpenFileDialog1.FileNames

            ListBox1.Items.Add(track)
            Dim NOMBRE
            NOMBRE = track
            NOMBRE = NOMBRE.REMOVE(0, NOMBRE.LastindexOf("\") + 1)
            NOMBRE = NOMBRE.substring(0, NOMBRE.lastindexOf("."))
            ListBox2.Items.Add(NOMBRE)
            TextBox2.AutoCompleteCustomSource.Add(NOMBRE)


        Next

        If Windows.Forms.DialogResult.OK Then
            ListBox1.SetSelected(0, True)

        End If

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged


        Try

            ListBox1.SelectedIndex = ListBox2.SelectedIndex
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Try

            ListBox2.SelectedIndex = ListBox1.SelectedIndex
            Reproductor.URL = ListBox1.SelectedItem
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try

            Dim dur As Integer
            dur = Reproductor.currentMedia.duration
            Label4.Text = ListBox1.SelectedIndex + 1 & " de " & ListBox1.Items.Count
            Label1.Text = Reproductor.Ctlcontrols.currentPositionString
            Label2.Text = Reproductor.currentMedia.durationString
            TrackBar1.Maximum = Val(dur)
            TrackBar1.Value = Reproductor.Ctlcontrols.currentPosition

            Try

                If Reproductor.playState = WMPLib.WMPPlayState.wmppsStopped Then

                    If ListBox1.SelectedIndex <> ListBox1.Items.Count - 1 Then
                        ListBox1.SelectedIndex += 1

                    End If


                End If



            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Button1.Click

        P_reproductor.BringToFront()


    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, Button2.Click
        p_list.BringToFront()

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll

        Reproductor.settings.balance = TrackBar2.Value

    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Reproductor.settings.volume = TrackBar3.Value
        Label10.Text = TrackBar3.Value

    End Sub
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown

        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

        Try


            If ListBox2.Items.Count <> 0 Then
                Dim returnvalue As Boolean
                Dim comparisontype As StringComparison
                For i = ListBox2.Items.Count - 1 To 0 Step -1
                    returnvalue = LCase(ListBox2.Items(i)).Startswith(LCase(TextBox2.Text), comparisontype)
                    If returnvalue = True Then
                        ListBox2.ClearSelected()
                        TextBox2.Focus()
                        ListBox2.SetSelected(i, True)
                        Exit Sub
                    End If


                Next


            End If



        Catch ex As Exception

        End Try








    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then

            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
            Application.DoEvents()

        End If

    End Sub
End Class
