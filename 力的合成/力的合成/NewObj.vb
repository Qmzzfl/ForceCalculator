Public Class NewObj
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label8.Text = "N"
            ComboBox1.Enabled = False
            ComboBox1.Text = ""
            TextBox3.Enabled = True
        Else
            Label8.Text = "N*m"
            ComboBox1.Enabled = True
            TextBox3.Enabled = False
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Label8.Text = "N*m"
            ComboBox1.Enabled = True
            TextBox3.Enabled = False
            TextBox3.Text = ""
        Else
            Label8.Text = "N"
            ComboBox1.Enabled = False
            ComboBox1.Text = ""
            TextBox3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            If TextBox3.Text = "" And ComboBox1.Text = "" Then
                MsgBox("请输入相关信息", 1, "注意")
                Exit Sub
            End If
        End If
        Dim i As Integer
        If RadioButton1.Checked = True Then
            For i = 0 To ForceTail
                If ForceObj(i).ObjectName = TextBox1.Text Then
                    MsgBox("该力已存在！"， 1, "提示")
                    Exit Sub
                End If
            Next
            ForceObj(ForceTail).ObjectName = TextBox1.Text
            ForceObj(ForceTail).ObjectValue = TextBox2.Text
            ForceObj(ForceTail).Degree = CDbl(TextBox3.Text) * Math.PI / CDbl(180)
            ForceObj(ForceTail).PointX = TextBox4.Text
            ForceObj(ForceTail).PointY = TextBox5.Text
            MainWindow.ListBox1.Items.Add(TextBox1.Text)
            ForceTail += 1
        ElseIf RadioButton2.Checked = True Then
            For i = 0 To CoupleTail
                If CoupleObj(i).ObjectName = TextBox1.Text Then
                    MsgBox("该力偶已存在！"， 1, "提示")
                    Exit Sub
                End If
            Next
            CoupleObj(CoupleTail).ObjectName = TextBox1.Text
            CoupleObj(CoupleTail).ObjectValue = TextBox2.Text
            If TextBox5.Text = "顺时针" Then
                CoupleObj(CoupleTail).Dir = Direction.Clockwise
            ElseIf TextBox5.Text = "逆时针" Then
                CoupleObj(CoupleTail).Dir = Direction.Anticlockwise
            End If
            CoupleObj(CoupleTail).PointX = TextBox4.Text
            CoupleObj(CoupleTail).PointY = TextBox5.Text
            MainWindow.ListBox1.Items.Add(TextBox1.Text)
            CoupleTail += 1
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
