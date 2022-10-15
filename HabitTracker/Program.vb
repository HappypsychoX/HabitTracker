Imports System

Module Program
    Private db As Database
    Private myConsole As MyConsole

    Sub Main(args As String())
        db = New Database
        myConsole = New MyConsole

        MainMenu()
    End Sub

    Private Sub MainMenu()
        Select Case myConsole.MainMenuUserInput()
            Case 0
                Exit Sub
            Case 1
                ShowAllRecords()
            Case 2
                InsertRecord()
            Case 3
                DeleteRecord()
            Case 4
                UpdateRecord()
            Case Else
                myConsole.InvalidInputMessage()
        End Select
    End Sub

    Private Sub ShowAllRecords()
        Dim records As List(Of Habit) = db.ReadAll

        myConsole.ShowRecords(records)
        MainMenu()
    End Sub

    Private Sub InsertRecord()
        Dim input As String() = myConsole.InsertRecordInput()
        db.Create(input(0), input(1))

        myConsole.RecordAddedMessage()
        MainMenu()
    End Sub

    Private Sub DeleteRecord()
        Dim id As Integer = myConsole.DeleteRecordInput
        If id = 0 Then
            MainMenu()
        Else
            db.Delete(id)
            myConsole.RecordDeletedMessage()
            MainMenu()
        End If
    End Sub

    Private Sub UpdateRecord()
        Dim id As Integer = myConsole.UpdateRecordIdInput
        Dim record As Habit
        If db.RecordExists(id) Then
            record = db.Read(id)
            Dim input As String() = myConsole.UpdateRecordDataInput(record)
            record.RecordDate = input(0)
            record.Quantity = input(1)
            db.Update(id, record.RecordDate, record.Quantity)
        Else
            myConsole.NoRecordMessage()
        End If

        MainMenu()
    End Sub
End Module
