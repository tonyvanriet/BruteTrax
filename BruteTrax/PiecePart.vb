

Public Class PiecePart

    ''' <summary>
    ''' The location of this part relative to the piece origin.
    ''' </summary>
    Property PieceLocation As Coordinates

    Property IsFilling As Boolean = True

    Property FloorLocation As Coordinates

    Property Orientation As PieceOrientation


    Public Sub New(ByVal pieceLocation As Coordinates)
        Me.PieceLocation = pieceLocation
    End Sub

    Sub RaiseRemoveMe()
        RaiseEvent RemoveMe(Me)
    End Sub

    Event RemoveMe(ByVal part As PiecePart)

    Overridable Function PiecePartToString() As String
        Return "*"
    End Function

End Class



Public Class PiecePartCollection
    Inherits List(Of PiecePart)

End Class


Public Class RoadPiecePart
    Inherits PiecePart

    Property RoadDirection As RoadPartDirection

    Public Sub New(ByVal pieceLocation As Coordinates, roadDirection As RoadPartDirection)
        MyBase.New(pieceLocation)
        Me.IsFilling = True
        Me.RoadDirection = roadDirection
    End Sub

    Public Overrides Function PiecePartToString() As String
        Select Case Me.Orientation
            Case PieceOrientation.Rotate0, PieceOrientation.Rotate180
                Select Case Me.RoadDirection
                    Case RoadPartDirection.Horizontal
                        Return "-"
                    Case RoadPartDirection.Rotate45
                        Return "\"
                    Case RoadPartDirection.Vertical
                        Return "|"
                    Case RoadPartDirection.Rotate135
                        Return "/"
                End Select
            Case PieceOrientation.Rotate90, PieceOrientation.Rotate270
                Select Case Me.RoadDirection
                    Case RoadPartDirection.Horizontal
                        Return "|"
                    Case RoadPartDirection.Rotate45
                        Return "/"
                    Case RoadPartDirection.Vertical
                        Return "-"
                    Case RoadPartDirection.Rotate135
                        Return "\"
                End Select
        End Select
        Throw New InvalidOperationException
    End Function

End Class



Public Class ConnectionPiecePart
    Inherits PiecePart

    Public Sub New(ByVal pieceLocation As Coordinates, ByVal connectionDirection As PieceConnectionDirection)
        MyBase.New(pieceLocation)
        Me.IsFilling = True
        Me.ConnectionDirection = connectionDirection
    End Sub

    Property ConnectionDirection As PieceConnectionDirection

    ReadOnly Property AbsoluteConnectionDirection As PieceConnectionDirection
        Get
            Return Me.ConnectionDirection.Rotate(Me.Orientation)
        End Get
    End Property

End Class



Public Class DeadSpacePiecePart
    Inherits PiecePart

    Public Sub New(ByVal pieceLocation As Coordinates)
        MyBase.New(pieceLocation)
        Me.IsFilling = True
    End Sub

    Public Overrides Function PiecePartToString() As String
        Return "*"
    End Function

End Class



Public Class ConnectingPiecePartPair

    Private ConnectingPartPair As New List(Of ConnectionPiecePart)

    ReadOnly Property IsConnected() As Boolean
        Get
            If ConnectingPartPair.Count = 2 Then

                Dim firstPart = ConnectingPartPair(0)
                Dim secondPart = ConnectingPartPair(1)

                Return firstPart.AbsoluteConnectionDirection = secondPart.AbsoluteConnectionDirection.Rotate(PieceOrientation.Rotate180)

            Else
                Return False
            End If
        End Get
    End Property

    ReadOnly Property IsOpenConnection As Boolean
        Get
            Return ConnectingPartPair.Count = 1
        End Get
    End Property


    Function PlacePiecePart(placingConnectionPiecePart As ConnectionPiecePart) As PlacingResult

        If IsConnected Then
            Return False

        ElseIf IsOpenConnection Then
            ConnectingPartPair.Add(placingConnectionPiecePart)

            If IsConnected Then
                AddHandler placingConnectionPiecePart.RemoveMe, AddressOf RemoveConnectingPart
                Return PlacingResult.Placed
            Else
                ConnectingPartPair.Remove(placingConnectionPiecePart)
                Return PlacingResult.Collision
            End If

        Else
            ConnectingPartPair.Add(placingConnectionPiecePart)
            AddHandler placingConnectionPiecePart.RemoveMe, AddressOf RemoveConnectingPart
            Return PlacingResult.Placed

        End If

    End Function


    Private Sub RemoveConnectingPart(ByVal removingPart As PiecePart)
        RemoveHandler removingPart.RemoveMe, AddressOf RemoveConnectingPart
        ConnectingPartPair.Remove(removingPart)
    End Sub

    Function PiecePartToString() As String
        If IsConnected Then
            Return "X"
        Else
            Return "O"
        End If
    End Function

End Class


