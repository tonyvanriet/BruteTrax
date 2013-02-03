

Public MustInherit Class PieceSet
    Inherits List(Of Piece)
End Class


' I think you generally want to put the awkward pieces first so they will be placed earlier in the recusion tree.
' it's easier to find a solution by filling in with the standard small pieces at the end.
' That's just intuition though. Not sure.


Public Class BasicSpeedTestPieceSet
    Inherits PieceSet

    Public Sub New()
        For i = 1 To 8
            Me.Add(New Straight3Piece)
            Me.Add(New Turn3Piece)
        Next
    End Sub

End Class


Public Class BasicSpeedTest2PieceSet
    Inherits PieceSet

    Public Sub New()
        For i = 1 To 8
            Me.Add(New Turn3Piece)
            Me.Add(New Straight3Piece)
        Next
    End Sub

End Class


Public Class BasicSpeedTest3PieceSet
    Inherits PieceSet

    Public Sub New()

        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)

    End Sub

End Class

Public Class BasicSpeedTest4PieceSet
    Inherits PieceSet

    Public Sub New()

        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)

    End Sub

End Class


Public Class BasicSpeedTest5PieceSet
    Inherits PieceSet

    Public Sub New()

        Me.Add(New Turn3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)

    End Sub

End Class



Public Class CompleteEarlyPieceSet
    Inherits PieceSet

    Public Sub New()
        Me.Add(New BigTurnPiece)
        Me.Add(New BigBenPiece)

        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)

        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)

        Me.Add(New EiffelTowerPiece)

        Me.Add(New StraightCameraPiece)

        Me.Add(New StraightGaragePiece)

        Me.Add(New Turn4Piece)
        Me.Add(New Turn4Piece)

        Me.Add(New SwitchLeftPiece)
        Me.Add(New SwitchLeftPiece)

        Me.Add(New SwitchRightPiece)
        Me.Add(New SwitchRightPiece)

        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)
        Me.Add(New Turn3Piece)

        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
        Me.Add(New Straight3Piece)
    End Sub



End Class
 