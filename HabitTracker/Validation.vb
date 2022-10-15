Module Validation
    Public Function InsertRecordInputIsValid(input() As String) As Boolean
        If Not input.Length = 2 Then
            Return False
        ElseIf Not IsDate(input(0)) Then
            Return False
        ElseIf Not IsNumeric(input(1)) Then
            Return False
        End If
        Return True
    End Function
End Module
