
Public Class Straight3Piece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 0), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 0), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(2, 0), PieceConnectionDirection.Right))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
    End Sub

End Class



Public Class Turn3Piece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 0), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 0), RoadPartDirection.Rotate135))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 1)))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 1), RoadPartDirection.Rotate135))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(2, 2), PieceConnectionDirection.Up))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class


Public Class Turn4Piece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 3), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 3), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 3), RoadPartDirection.Rotate45))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 2)))
        PieceParts.Add(New RoadPiecePart(New Coordinates(3, 2), RoadPartDirection.Rotate45))
        PieceParts.Add(New RoadPiecePart(New Coordinates(3, 1), RoadPartDirection.Vertical))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 0), PieceConnectionDirection.Down))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class



Public Class SwitchLeftPiece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 0), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 0), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 1), RoadPartDirection.Rotate135))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 0), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 0), PieceConnectionDirection.Right))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 1), PieceConnectionDirection.Right))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class


Public Class SwitchRightPiece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 1), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 0), RoadPartDirection.Rotate45))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 0), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 0), PieceConnectionDirection.Right))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 1), PieceConnectionDirection.Right))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class


Public Class BigTurnPiece
    Inherits Piece

    Public Sub New()

        ' outer entrance ramp
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 4), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 4), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 4), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(3, 4), RoadPartDirection.Horizontal))
        ' open space under the ramp
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 4)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(6, 4)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 4)))

        ' inner entrance ramp
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(2, 2), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(3, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(4, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(6, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(6, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(8, 1)))


        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class


Public Class EiffelTowerPiece
    Inherits Piece

    Public Sub New()

        ' outer entrance ramp
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 2), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(3, 2), PieceConnectionDirection.Right))

        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(0, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(0, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(0, 3)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 3)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 3)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 3)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(0, 4)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 4)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 4)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 4)))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
    End Sub

End Class



Public Class BigBenPiece
    Inherits Piece

    Public Sub New()

        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 1), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 1), RoadPartDirection.Horizontal))
        ' open space under ramps
        PieceParts.Add(New RoadPiecePart(New Coordinates(10, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(11, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(12, 1), PieceConnectionDirection.Right))

        ' crossing path underneath
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(6, 0), PieceConnectionDirection.Down))
        PieceParts.Add(New RoadPiecePart(New Coordinates(6, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(6, 2), PieceConnectionDirection.Up))

        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(5, 2)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(7, 2)))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
    End Sub

End Class



Public Class StraightCameraPiece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 2), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(2, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New RoadPiecePart(New Coordinates(3, 2), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(4, 2), PieceConnectionDirection.Right))

        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 1)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(3, 0)))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class





Public Class StraightGaragePiece
    Inherits Piece

    Public Sub New()
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(0, 1), PieceConnectionDirection.Left))
        PieceParts.Add(New RoadPiecePart(New Coordinates(1, 1), RoadPartDirection.Horizontal))
        PieceParts.Add(New ConnectionPiecePart(New Coordinates(2, 1), PieceConnectionDirection.Right))

        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(0, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(2, 0)))
        PieceParts.Add(New DeadSpacePiecePart(New Coordinates(1, 2)))

        UniqueOrientations.Add(PieceOrientation.Rotate0)
        UniqueOrientations.Add(PieceOrientation.Rotate90)
        UniqueOrientations.Add(PieceOrientation.Rotate180)
        UniqueOrientations.Add(PieceOrientation.Rotate270)
    End Sub

End Class



