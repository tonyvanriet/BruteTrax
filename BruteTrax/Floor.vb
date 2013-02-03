Public Class Floor


    Property Spaces As New SpaceCollection


    ''' <summary>
    ''' Places the piece in the given orientation such that the 0,0 piece part is at the given floor location.
    ''' Returns Collision if any piece part is being placed in a space that is already full.
    ''' Does not check for connectivity.
    ''' </summary>
    Public Function PlacePiece(placingPiece As Piece, pieceOrientation As PieceOrientation,
                               anchorFloorLocation As Coordinates, anchorPiecePart As PiecePart) As PlacingResult
        Debug.Assert(placingPiece.IsPlaced = False)

        For Each placingPiecePart In placingPiece.PieceParts

            Dim piecePartPlacingResult = PlacePiecePart(placingPiecePart, pieceOrientation, anchorFloorLocation, anchorPiecePart.PieceLocation)

            If piecePartPlacingResult <> PlacingResult.Placed Then Return piecePartPlacingResult
        Next

        placingPiece.IsPlaced = True
        Return PlacingResult.Placed

    End Function


    Public Function PlacePiecePart(placingPiecePart As PiecePart, pieceOrientation As PieceOrientation,
                                   anchorFloorLocation As Coordinates, anchorPiecePartPieceLocation As Coordinates) As PlacingResult

        Dim rotatedPartLocation = placingPiecePart.PieceLocation.Rotated(pieceOrientation, anchorPiecePartPieceLocation)

        Dim floorLocation = anchorFloorLocation.Offset(rotatedPartLocation)

        Dim placingSpace As Space = GetOrCreateSpace(floorLocation)

        placingPiecePart.Orientation = pieceOrientation

        Return placingSpace.PlacePiecePart(placingPiecePart)

    End Function



    Sub RemovePiece(removingPiece As Piece)

        For Each removingPiecePart In removingPiece.PieceParts
            RemovePiecePart(removingPiecePart)
        Next

        removingPiece.IsPlaced = False

        ClearEmptySpaces()

    End Sub


    Sub RemovePiecePart(removingPiecePart As PiecePart)
        removingPiecePart.RaiseRemoveMe()
    End Sub


    Public Function GetSpace(location As Coordinates) As Space
        For Each s As Space In Spaces
            If s.FloorLocation = location Then
                Return s
            End If
        Next
        Return Nothing
    End Function


    Public Function GetOrCreateSpace(location As Coordinates) As Space
        Dim s = GetSpace(location)
        If s IsNot Nothing Then Return s
        Dim newEmptySpace = New Space With {.FloorLocation = location}
        Spaces.Add(newEmptySpace)
        Return newEmptySpace
    End Function


    Function GetOpenConnectionLocation() As Coordinates
        For Each s In Spaces
            If s.IsOpenConnectionLocation Then
                Return s.FloorLocation
            End If
        Next
        Return Nothing
    End Function


    Function TrackToString() As String

        Dim s As New System.Text.StringBuilder

        Dim originOffset As Coordinates = Spaces.MinFloorLocation

        Dim dimensions As Coordinates = Spaces.Dimensions

        For j = dimensions.Y To 0 Step -1
            s.Append(" ")

            For i = 0 To dimensions.X

                Dim printingLocation As Coordinates = New Coordinates(i, j)
                Dim printingSpace As Space = GetSpace(printingLocation + originOffset)
                If printingSpace Is Nothing Then
                    s.Append(" ")
                Else
                    s.Append(printingSpace.SpaceToString())
                End If
            Next

            s.AppendLine()
        Next

        Return s.ToString

    End Function


    Private Sub ClearEmptySpaces()
        Dim spacesToRemove = New SpaceCollection
        For Each existingSpace In Spaces
            If existingSpace.IsFull = False And existingSpace.IsOpenConnectionLocation = False Then spacesToRemove.Add(existingSpace)
        Next
        For Each spaceToRemove In spacesToRemove
            Spaces.Remove(spaceToRemove)
        Next
    End Sub


End Class


Public Enum PlacingResult
    Placed
    Collision
    Disconnected
End Enum