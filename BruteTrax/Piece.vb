Imports System.Runtime.CompilerServices


Public Class Piece

    Property PieceParts As New PiecePartCollection

    Property UniqueOrientations As New List(Of PieceOrientation)

    Property IsPlaced As Boolean = False

    Function GetConnectionPieceParts() As List(Of PiecePart)
        Dim connectionPieceParts As New List(Of PiecePart)
        For Each part In PieceParts
            If TypeOf part Is ConnectionPiecePart Then connectionPieceParts.Add(part)
        Next
        Return connectionPieceParts
    End Function

    Function PieceTypeToString() As String
        Return Me.GetType.ToString
    End Function

End Class



Public Class PieceCollection
    Inherits List(Of Piece)


    Public ReadOnly Property UnplacedPieces() As PieceCollection
        Get
            Dim pieces As New PieceCollection
            For Each p In Me
                If p.IsPlaced = False Then
                    pieces.Add(p)
                End If
            Next
            Return pieces
        End Get
    End Property


    Public ReadOnly Property UniqueUnplacedPieces() As PieceCollection
        Get
            Dim pieces As New PieceCollection
            For Each p In Me.UnplacedPieces
                If pieces.ContainsPieceType(p.GetType) = False Then
                    pieces.Add(p)
                End If
            Next
            Return pieces
        End Get
    End Property


    Private Function ContainsPieceType(pieceType As Type) As Boolean
        For Each p In Me
            If pieceType = p.GetType Then Return True
        Next
        Return False
    End Function

End Class


Public Enum PieceOrientation
    Rotate0
    Rotate90
    Rotate180
    Rotate270
End Enum


Public Enum PieceConnectionDirection
    Left
    Up
    Right
    Down
End Enum


Public Module Extensions

    <Extension()>
    Public Function Rotate(connectionDirection As PieceConnectionDirection, orientation As PieceOrientation) As PieceConnectionDirection
        Select Case connectionDirection
            Case PieceConnectionDirection.Left
                Select Case orientation
                    Case PieceOrientation.Rotate0
                        Return PieceConnectionDirection.Left
                    Case PieceOrientation.Rotate90
                        Return PieceConnectionDirection.Up
                    Case PieceOrientation.Rotate180
                        Return PieceConnectionDirection.Right
                    Case PieceOrientation.Rotate270
                        Return PieceConnectionDirection.Down
                End Select
            Case PieceConnectionDirection.Up
                Select Case orientation
                    Case PieceOrientation.Rotate0
                        Return PieceConnectionDirection.Up
                    Case PieceOrientation.Rotate90
                        Return PieceConnectionDirection.Right
                    Case PieceOrientation.Rotate180
                        Return PieceConnectionDirection.Down
                    Case PieceOrientation.Rotate270
                        Return PieceConnectionDirection.Left
                End Select
            Case PieceConnectionDirection.Right
                Select Case orientation
                    Case PieceOrientation.Rotate0
                        Return PieceConnectionDirection.Right
                    Case PieceOrientation.Rotate90
                        Return PieceConnectionDirection.Down
                    Case PieceOrientation.Rotate180
                        Return PieceConnectionDirection.Left
                    Case PieceOrientation.Rotate270
                        Return PieceConnectionDirection.Up
                End Select
            Case PieceConnectionDirection.Down
                Select Case orientation
                    Case PieceOrientation.Rotate0
                        Return PieceConnectionDirection.Down
                    Case PieceOrientation.Rotate90
                        Return PieceConnectionDirection.Left
                    Case PieceOrientation.Rotate180
                        Return PieceConnectionDirection.Up
                    Case PieceOrientation.Rotate270
                        Return PieceConnectionDirection.Right
                End Select
        End Select
        Throw New InvalidOperationException
    End Function

End Module



Public Enum RoadPartDirection
    Horizontal
    Rotate45
    Vertical
    Rotate135
End Enum




