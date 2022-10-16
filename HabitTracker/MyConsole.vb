Public Class MyConsole
    Public Sub New()
        Startup()
    End Sub

    Public Function MainMenuUserInput() As String
        ShowMainMenu()
        Return Console.ReadLine
    End Function

    Public Sub ShowRecords(records As List(Of Habit))
        ShowTitle("Show All Records")

        For Each element As Habit In records
            Console.WriteLine(element.Id & " " & element.RecordDate & " " & element.Quantity)
        Next

        Console.WriteLine("There are " & records.Count & " records in the database.")
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
    End Sub

    Public Function InsertRecordInput() As String()
        ShowTitle("Insert New Record")
Start:
        Console.WriteLine("Please enter date followed by quantity  EG: 12/30/20 5")
        Dim result() As String = Split(Console.ReadLine)
        If InsertRecordInputIsValid(result) Then
            Return result
        Else
            InvalidInputMessage()
            GoTo Start
        End If
    End Function

    Public Function DeleteRecordInput() As Integer
        ShowTitle("Delete Record")
Start:
        Console.WriteLine("Please enter the ID to delete or enter 0 to exit to Main Menu.")
        Dim id As Integer = Console.ReadLine

        If IsNumeric(id) Then
            Return id
        Else
            InvalidInputMessage()
            GoTo Start
        End If
    End Function

    Public Function UpdateRecordIdInput() As Integer
        ShowTitle("Update Record")
Start:
        Console.WriteLine("Please type the Id to update")
        Dim result As String = Console.ReadLine

        If IsNumeric(result) Then
            Return Int(result)
        Else
            InvalidInputMessage()
            GoTo Start
        End If
    End Function

    Public Function UpdateRecordDataInput(currentRecord As Habit) As String()
        Console.WriteLine("Current values:")
        Console.WriteLine("Date: " & currentRecord.RecordDate & " Quantity: " & currentRecord.Quantity)
Start:
        Console.WriteLine("Please enter date followed by quantity  EG: 12/30/20 5")
        Dim result() As String = Split(Console.ReadLine)
        If InsertRecordInputIsValid(result) Then
            Return result
        Else
            InvalidInputMessage()
            GoTo Start
        End If
    End Function

#Region "Public Console Write Methods"
    Public Sub InvalidInputMessage()
        Console.WriteLine("Invalid input please try again.")
    End Sub

    Public Sub RecordAddedMessage()
        Console.WriteLine("Record Added Successfully.")
    End Sub

    Public Sub RecordDeletedMessage()
        Console.WriteLine("Record Deleted Successfully.")
    End Sub

    Public Sub UpdateRecordMessage()
        Console.WriteLine("Record Updated Successfully.")
    End Sub

    Public Sub NoRecordMessage()
        Console.WriteLine("No Records Found.")
    End Sub
#End Region

#Region "Private Console Write Methods"
    Private Sub Startup()
        Console.WriteLine("////////////////////////////")
        Console.WriteLine("/ Habit Tracker            /")
        Console.WriteLine("/ By HappypsychoX          /")
        Console.WriteLine("/ October 2022             /")
        Console.WriteLine("////////////////////////////")
    End Sub

    Private Sub ShowMainMenu()
        ShowTitle("Main Menu")

        Console.WriteLine("Type Close to Close Application")
        Console.WriteLine("Type 1 to View All Records")
        Console.WriteLine("Type 2 to Insert Record")
        Console.WriteLine("Type 3 to Delete Record")
        Console.WriteLine("Type 4 to Update Record")
    End Sub

    Private Sub ShowTitle(title As String)
        Console.WriteLine()
        Console.WriteLine("////////////////////////////")
        Console.WriteLine("/                          /")
        Console.WriteLine(FormattedTitleString(title))
        Console.WriteLine("/                          /")
        Console.WriteLine("////////////////////////////")
        Console.WriteLine()
    End Sub
#End Region

#Region "Helper Methods"
    Private Function FormattedTitleString(title As String) As String
        Dim result As String = "/ " & title
        Dim numSpaces As Integer = 25 - title.Length

        result = result & Space(numSpaces) & "/"

        Return result
    End Function
#End Region
End Class
