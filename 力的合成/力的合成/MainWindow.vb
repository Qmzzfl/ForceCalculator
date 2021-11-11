Public Class MainWindow
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 50
            ForceObj(i).ObjectValue = 0
            ForceObj(i).PointX = 0
            ForceObj(i).PointY = 0
            ForceObj(i).Degree = 0
            CoupleObj(i).ObjectValue = 0
            CoupleObj(i).ObjectValue = 0
            CoupleObj(i).PointX = 0
            CoupleObj(i).PointY = 0
        Next
        'ForceTail += 1
        'ForceObj(0).ObjectName = 1
        'ForceObj(0).ObjectValue = 10
        'ForceObj(0).Degree = CDbl(0) * Math.PI / CDbl(180)
        'ForceObj(0).PointX = 0
        'ForceObj(0).PointY = 0
        'Me.ListBox1.Items.Add(1)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NewObj.Show()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedItem <> vbNull Then
            ObjSelect = ListBox1.SelectedItem.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ObjSelect = ListBox1.SelectedItem.ToString
        ListBox1.Items.Remove(ObjSelect)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ForceCal()
        CoupleCal()
        FinalCal()
        Label2.Text = Math.Round(ForceXValResult, 3).ToString
        Label3.Text = ForceYValResult.ToString
        Label4.Text = ForceValResult.ToString
        Label5.Text = ForceDegResult.ToString
        Label6.Text = ForcePXResult
        Label7.Text = ForcePYResult
    End Sub


End Class
