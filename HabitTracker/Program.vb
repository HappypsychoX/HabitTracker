Imports System

Module Program
    Private db As Database

    Sub Main(args As String())
        db = New Database
        MainMenu()
    End Sub

    Private Sub MainMenu()
        ShowMainMenu()
        Select Case Console.ReadLine()
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
        End Select
    End Sub

    ''' <summary>
    ''' Creates a title section to display the item from the main menu.
    ''' </summary>
    ''' <param name="title">The title to be displayed</param>
    Private Sub ShowTitle(title As String)
        Console.WriteLine()
        Console.WriteLine("////////////////////////////")
        Console.WriteLine("/")
        Console.WriteLine("/ " & title)
        Console.WriteLine("/")
        Console.WriteLine("////////////////////////////")
        Console.WriteLine()
    End Sub

    Private Sub ShowMainMenu()
        Console.ForegroundColor = ConsoleColor.DarkGreen
        ShowTitle("Main Menu")
        Console.WriteLine("Type 0 to Close Application")
        Console.WriteLine("Type 1 to View All Records")
        Console.WriteLine("Type 2 to Insert Record")
        Console.WriteLine("Type 3 to Delete Record")
        Console.WriteLine("Type 4 to Update Record")
        Console.ResetColor()
    End Sub

    Private Sub ShowAllRecords()
        Console.ForegroundColor = ConsoleColor.DarkGreen
        ShowTitle("Show All Records")
        Dim records As List(Of Habit) = db.ReadAll
        For Each element As Habit In records
            Console.WriteLine(element.Id & " " & element.RecordDate & " " & element.Quantity)
        Next

        Console.WriteLine("There are " & records.Count & " records in the database.")
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
        MainMenu()
    End Sub

    Private Sub InsertRecord()
        Console.ForegroundColor = ConsoleColor.DarkGreen
        ShowTitle("Insert New Record")

        Console.WriteLine("Please enter quantity")
        Dim qty As Integer = Console.ReadLine
        Dim record As Habit = New Habit(0, Today.ToString("d"), qty)
        db.Create(record.RecordDate, record.Quantity)
        Console.WriteLine("Record Added")

        MainMenu()
    End Sub

    Private Sub DeleteRecord()
        Console.ForegroundColor = ConsoleColor.DarkGreen
        ShowTitle("Delete Record")

        Console.WriteLine("Please enter the ID to delete")
        Dim id As Integer = Console.ReadLine
        db.Delete(id)
        Console.ResetColor()
        MainMenu()
    End Sub

    Private Sub UpdateRecord()
        Console.Clear()
        Console.WriteLine("Update Record")
        Console.WriteLine("Please type the Id to update")
        Dim id As Integer = Console.ReadLine
        Console.WriteLine("Please type the new date")
        Dim recordDate As String = Console.ReadLine
        Console.WriteLine("Please type the quantity")
        Dim quantity As Integer = Console.ReadLine

        db.Update(id, recordDate, quantity)

        MainMenu()
    End Sub

End Module

Public Class Habit
    Private _id As Integer
    Private _recordDate As String
    Private _quantity As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property RecordDate As String
        Get
            Return _recordDate
        End Get
        Set(value As String)
            _recordDate = value
        End Set
    End Property

    Public Property Quantity As Integer
        Get
            Return _quantity
        End Get
        Set(value As Integer)
            _quantity = value
        End Set
    End Property

    Public Sub New(id As Integer, recordDate As String, quantity As Integer)
        _id = id
        _recordDate = recordDate
        _quantity = quantity
    End Sub
End Class
