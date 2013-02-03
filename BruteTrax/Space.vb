Public Class Space

    Public Property FloorLocation As Coordinates

    Public WithEvents PlacedFillingPiecePart As PiecePart

    Public WithEvents PlacedConnectingPiecePartPair As ConnectingPiecePartPair


    Public ReadOnly Property IsFull As Boolean
        Get
            Return PlacedFillingPiecePart IsNot Nothing Or IsConnected
        End Get
    End Property


    Public ReadOnly Property IsConnected As Boolean
        Get
            Return PlacedConnectingPiecePartPair IsNot Nothing AndAlso PlacedConnectingPiecePartPair.IsConnected
        End Get
    End Property


    Public ReadOnly Property IsOpenConnectionLocation As Boolean
        Get
            Return PlacedConnectingPiecePartPair IsNot Nothing AndAlso PlacedConnectingPiecePartPair.IsOpenConnection
        End Get
    End Property


    Public Function PlacePiecePart(placingPiecePart As PiecePart) As PlacingResult

        If TypeOf placingPiecePart Is ConnectionPiecePart Then Return PlaceConnectingPiecePart(placingPiecePart)

        If placingPiecePart.IsFilling Then

            If Me.IsFull Then
                Return PlacingResult.Collision

            Else
                PlacedFillingPiecePart = placingPiecePart
                placingPiecePart.FloorLocation = Me.FloorLocation
                Return PlacingResult.Placed

            End If

        Else

            Throw New InvalidOperationException
            ' assuming all pieces are filling

        End If

    End Function


    Public Function PlaceConnectingPiecePart(placingConnectionPiecePart As ConnectionPiecePart) As PlacingResult
        If Me.IsFull Then Return PlacingResult.Collision
        If PlacedConnectingPiecePartPair Is Nothing Then PlacedConnectingPiecePartPair = New ConnectingPiecePartPair
        Return PlacedConnectingPiecePartPair.PlacePiecePart(placingConnectionPiecePart)
    End Function


    Private Sub PlacedFillingPiecePart_RemoveMe() Handles PlacedFillingPiecePart.RemoveMe
        PlacedFillingPiecePart.FloorLocation = Nothing
        PlacedFillingPiecePart = Nothing
    End Sub


    Function SpaceToString() As String
        If PlacedConnectingPiecePartPair IsNot Nothing Then
            Return PlacedConnectingPiecePartPair.PiecePartToString()
        ElseIf IsFull Then
            Return PlacedFillingPiecePart.PiecePartToString()
        Else
            Return " "
        End If
    End Function

End Class



Public Class SpaceCollection
    Inherits List(Of Space)


    Public Function MinFloorLocation() As Coordinates
        If Me.Count = 0 Then Throw New InvalidOperationException
        Dim returnLocation As Coordinates = Me(0).FloorLocation.Clone
        For Each s In Me
            If s.FloorLocation.X < returnLocation.X Then returnLocation.X = s.FloorLocation.X
            If s.FloorLocation.Y < returnLocation.Y Then returnLocation.Y = s.FloorLocation.Y
        Next
        Return returnLocation
    End Function


    Public Function MaxFloorLocation() As Coordinates
        If Me.Count = 0 Then Throw New InvalidOperationException
        Dim returnLocation As Coordinates = Me(0).FloorLocation.Clone
        For Each s In Me
            If s.FloorLocation.X > returnLocation.X Then returnLocation.X = s.FloorLocation.X
            If s.FloorLocation.Y > returnLocation.Y Then returnLocation.Y = s.FloorLocation.Y
        Next
        Return returnLocation
    End Function



    Public Function Dimensions() As Coordinates
        Dim min = MinFloorLocation()
        Dim max = MaxFloorLocation()
        Return New Coordinates(max.X - min.X, max.Y - min.Y)
    End Function


End Class