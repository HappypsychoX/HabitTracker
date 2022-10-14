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
