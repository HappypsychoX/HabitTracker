Imports System
Imports Microsoft.Data.Sqlite
Module Program
    Sub Main(args As String())
        CreateDatabase()
        GetUserInput()
        Exit Sub
    End Sub

    Private connectionString As String = "Data Source=habit-Tracker.db"

    Private Sub CreateDatabase()
        'Creating a connection passing the connection string as an argument
        'This will create the database For you, there's no need to manually create it.
        'And no need to use File.Create().
        Using connection As New SqliteConnection(connectionString)
            'Creating the command that wwill be sent to the database
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                'Declaring the command (in SQL syntax)
                tableCmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS yourHabit(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )"

                'Executing the command, which isn't a query, it's not asking to return data from the database.
                tableCmd.ExecuteNonQuery()
            End Using
            'We don't need to close the connection or the command. The 'using statement' does that for us.
        End Using
    End Sub
    ' Once we check if the database exists and create it (or not),
    'we will call the next method, which will handle the user's input. Your next step is to create this method
    Private Sub GetUserInput()
        WriteMenu()
        Select Case Console.ReadLine()
            Case "0"
                Exit Sub
            Case 1

        End Select
    End Sub

    Private Sub WriteMenu()
        Console.WriteLine("Main Menu")
        Console.WriteLine()
        Console.WriteLine("Type 0 to Close Application")
        Console.WriteLine("Type 1 to View All Records")
        Console.WriteLine("Type 2 to Insert Record")
        Console.WriteLine("Type 3 to Delete Record")
        Console.WriteLine("Type 4 to Update Record")
    End Sub
End Module
