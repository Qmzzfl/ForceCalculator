Module MainObject

    '两种队列尾号
    Public ForceTail = 0
    Public CoupleTail = 0

    Public ObjSelect As String

    '力偶方向 枚举类型
    Public Enum Direction
        Clockwise
        Anticlockwise
    End Enum

    '力 结构体
    Public Structure Force
        Dim ObjectName As String
        Dim ObjectValue As Double
        Dim Degree As Double
        Dim PointX As Double
        Dim PointY As Double
    End Structure

    '力偶 结构体
    Public Structure Couple
        Dim ObjectName As String
        Dim ObjectValue As Double
        Dim Dir As Direction
        Dim PointX As Double
        Dim PointY As Double
    End Structure

    '队列存储数组
    Public ForceObj(50) As Force
    Public CoupleObj(50) As Couple


    '结果变量
    Public ForceXValResult As Double
    Public ForceYValResult As Double
    Public ForceValResult As Double
    Public ForceDegResult As Double
    Public ForcePXResult As Double
    Public ForcePYResult As Double
    Public CoupleResult

    '计算力相关参数
    Function ForceCal() As Double
        Dim i As Integer
        For i = 0 To ForceTail + 1
            ForceXValResult += ForceObj(i).ObjectValue * Math.Cos(ForceObj(i).Degree)
            ForceYValResult += ForceObj(i).ObjectValue * Math.Sin(ForceObj(i).Degree)
        Next
        ForceValResult = Math.Sqrt(ForceXValResult * ForceXValResult + ForceYValResult * ForceYValResult)

        If ForceXValResult = 0 And ForcePYResult <> 0 Then
            ForceDegResult = 90
        ElseIf ForceXValResult > 0 And ForceYValResult > 0 Then
            ForceDegResult = Math.Atan(ForcePYResult / ForcePXResult)
        ElseIf ForceXValResult > 0 And ForceYValResult < 0 Then
            ForceDegResult = Math.Atan(ForcePYResult / ForcePXResult) + 360
        ElseIf ForceXValResult < 0 Then
            ForceDegResult = Math.Atan(ForcePYResult / ForcePXResult) + 180
        ElseIf ForceXValResult = 0 And ForceYValResult = 0 Then
            ForceDegResult = 0
        End If
        Return 0
    End Function

    '计算力偶相关参数
    Function CoupleCal() As Double
        Dim OrgCou, ForCou As Double
        Dim i As Integer
        For i = 0 To CoupleTail + 1
            If CoupleObj(i).Dir = Direction.Clockwise Then
                OrgCou -= CoupleObj(i).ObjectValue
            ElseIf CoupleObj(i).Dir = Direction.Anticlockwise Then
                OrgCou += CoupleObj(i).ObjectValue
            End If
        Next
        For i = 0 To ForceTail
            ForCou += ForceObj(i).ObjectValue * (ForceObj(i).PointX * Math.Sin(ForceObj(i).Degree) - ForceObj(i).PointY * Math.Cos(ForceObj(i).Degree))
        Next
        CoupleResult = OrgCou + ForCou
        Return 0
    End Function

    '最终简化结果参数
    Function FinalCal() As Double
        Dim Dis As Double
        If ForceValResult = 0 Then
            ForcePXResult = 0
            ForcePYResult = 0
            Return 0
            Exit Function
        End If
        Dis = CoupleResult / ForceValResult
        ForcePXResult = -Dis * Math.Sin(ForceDegResult)
        ForcePYResult = Dis * Math.Cos(ForceDegResult)
        Return 0
    End Function

End Module
