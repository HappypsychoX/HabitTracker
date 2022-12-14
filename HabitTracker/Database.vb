Imports Microsoft.Data.Sqlite

Public Class Database

    Private ReadOnly connectionString As String = "Data Source=habit-Tracker.db"

    Public Sub New()
        InitializeDatabase()
    End Sub

    Public Sub Create(recordDate As String, quantity As Integer)
        Using connection As New SqliteConnection(connectionString)
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText =
                    "INSERT INTO yourHabit (Date, Quantity)
                VALUES ($date, $quantity)"
                tableCmd.Parameters.AddWithValue("$date", recordDate)
                tableCmd.Parameters.AddWithValue("$quantity", quantity)
                tableCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Reads all records from database
    ''' </summary>
    ''' <returns>List of type Habit</returns>
    Public Function ReadAll() As List(Of Habit)
        Dim records As New List(Of Habit)
        Using connection As New SqliteConnection(connectionString)
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText = "SELECT * FROM yourHabit"

                Dim reader As SqliteDataReader = tableCmd.ExecuteReader()
                While (reader.Read())
                    Dim idReader As Integer = reader.GetInt32(0)
                    Dim dateReader As String = reader.GetString(1)
                    Dim quantityReader As Integer = reader.GetInt32(2)
                    records.Add(New Habit(idReader, dateReader, quantityReader))
                End While
            End Using
        End Using
        Return records
    End Function

    Public Function Read(id As Integer) As Habit
        Dim result As Habit
        Using connection As New SqliteConnection(connectionString)
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText = "SELECT * FROM yourHabit WHERE Id = $id"
                tableCmd.Parameters.AddWithValue("$id", id)

                Dim reader As SqliteDataReader = tableCmd.ExecuteReader()
                'Dim idReader As Integer = reader.GetInt32(0)
                While (reader.Read())
                    Dim dateReader As String = reader.GetString(1)
                    Dim quantityReader As Integer = reader.GetInt32(2)

                    result = New Habit(id, dateReader, quantityReader)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Sub Update(id As Integer, recordDate As String, quantity As Integer)
        Using connection As New SqliteConnection(connectionString)
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText =
                        "UPDATE yourHabit
                        SET Date = $date,
                            Quantity = $quantity
                        WHERE Id = $id"
                tableCmd.Parameters.AddWithValue("$date", recordDate)
                tableCmd.Parameters.AddWithValue("$quantity", quantity)
                tableCmd.Parameters.AddWithValue("$id", id)
                tableCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(id As Integer)
        Using connection As New SqliteConnection(connectionString)
            'Creating the command that wwill be sent to the database
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                'Declaring the command (in SQL syntax)
                tableCmd.CommandText = "DELETE FROM yourHabit WHERE Id = $id"
                tableCmd.Parameters.AddWithValue("$id", id)
                tableCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function RecordExists(id As Integer) As Boolean
        Dim result As Integer
        Using connection As New SqliteConnection(connectionString)
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText = "SELECT EXISTS(SELECT 1 FROM yourHabit WHERE Id = $id)"
                tableCmd.Parameters.AddWithValue("$id", id)
                result = tableCmd.ExecuteScalar()
            End Using
        End Using
        If result = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Creates a database if none exists. Also creates as table called yourHabit if none exists
    ''' </summary>
    Private Sub InitializeDatabase()
        Using connection As New SqliteConnection(connectionString)
            'Creating the command that wwill be sent to the database
            Using tableCmd = connection.CreateCommand()
                connection.Open()
                tableCmd.CommandText =
                        "CREATE TABLE IF NOT EXISTS yourHabit(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )"
                tableCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
