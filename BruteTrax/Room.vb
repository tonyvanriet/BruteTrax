
Public Class Room

    Private Property Floor As New Floor
    Private Property AllPieces As New PieceCollection

    Public Sub AddPiece(piece As Piece)
        AllPieces.Add(piece)
    End Sub

    Public Sub AddPieces(pieces As IEnumerable(Of Piece))
        For Each p In pieces
            AddPiece(p)
        Next
    End Sub


    Public Sub SetFirstPiece(firstPiece As Piece)
        If AllPieces.Contains(firstPiece) = False Then Throw New Exception("FirstPiece hasn't been added")
        _FirstPiece = firstPiece
    End Sub

    Private _FirstPiece As Piece = Nothing


    Public IsLoggingEnabled As Boolean = True


    ''' <summary>
    ''' As you place more pieces, the recursion level goes up.
    ''' </summary>
    Public ReadOnly Property CurrentLevelOfRecursion As Integer
        Get
            Return AllPieces.Count - AllPieces.UnplacedPieces.Count
        End Get
    End Property


    Public Sub FindCompleteTrack()
        If AllPieces.Count = 0 Then Throw New Exception("No pieces")

        ShallowestLevelCompletedSinceLastFailurePrint = AllPieces.Count

        ' Place first piece
        If _FirstPiece Is Nothing Then _FirstPiece = AllPieces(0)
        Floor.PlacePiece(_FirstPiece, PieceOrientation.Rotate0, anchorFloorLocation:=New Coordinates(0, 0), anchorPiecePart:=_FirstPiece.PieceParts(0))

        WriteLine("First piece: " & _FirstPiece.GetType.ToString)
        WriteLine("AllPieces:")
        For Each p In AllPieces
            WriteLine(vbTab & p.GetType.ToString)
        Next

        ' Let er rip
        WriteLine(Now.TimeOfDay.ToString & ": starting")

        PlaceAllRemainingPiecesRecursively()

        WriteLine(Now.TimeOfDay.ToString & ": finished")
    End Sub


    Private Sub PlaceAllRemainingPiecesRecursively()

        Dim openConnectionLocation As Coordinates = Floor.GetOpenConnectionLocation

        If openConnectionLocation Is Nothing Then
            ' no open ends
            Dim s As New System.Text.StringBuilder
            s.Append(String.Format(Now.TimeOfDay.ToString & ": Found closed track with {0} pieces left.", AllPieces.UnplacedPieces.Count))
            If AllPieces.UnplacedPieces.Count <= 2 Then
                s.Append(vbCrLf & vbCrLf & Floor.TrackToString())
                s.AppendLine()
                s.AppendLine("Unplaced pieces")
                For Each unplacedPiece In AllPieces.UnplacedPieces
                    s.AppendLine(unplacedPiece.PieceTypeToString)
                Next
                s.AppendLine()
            End If

            WriteLine(s.ToString)


        Else

            ' for each unplaced piece
            For Each nextPiece In AllPieces.UniqueUnplacedPieces

                ' for each connection part of next piece
                For Each nextConnectionPart In nextPiece.GetConnectionPieceParts

                    ' for each orientation of the piece, anchored at the connection part
                    For Each orientation In nextPiece.UniqueOrientations

                        ' place the piece
                        Dim result = Floor.PlacePiece(nextPiece, orientation, openConnectionLocation, nextConnectionPart)

                        If result = PlacingResult.Placed And Floor.GetSpace(openConnectionLocation).IsConnected Then

                            PlaceAllRemainingPiecesRecursively()

                        End If

                        ' returned from searching that piece placement, remove the piece and move back up the tree
                        Floor.RemovePiece(nextPiece)

                    Next

                Next

            Next

        End If


        'If AllPieces.UnplacedPieces.Count = 0 And Now > _LastFailurePrintTime.AddMinutes(10) Then
        ' Every so often, print out the failing track with all pieces placed
        If CurrentLevelOfRecursion <= _ShallowestLevelCompletedSinceLastFailurePrint + 1 And Now > _LastFailurePrintTime.AddMinutes(1) Then

            _LastFailurePrintTime = Now
            _ShallowestLevelCompletedSinceLastFailurePrint = AllPieces.Count

            Dim s As New System.Text.StringBuilder
            s.Append(String.Format(Now.TimeOfDay.ToString & ": Can't find closed track, {0} pieces left.", AllPieces.UnplacedPieces.Count))
            s.Append(vbCrLf & vbCrLf & Floor.TrackToString())
            s.AppendLine()

            WriteLine(s.ToString)

        Else
            _ShallowestLevelCompletedSinceLastFailurePrint = Math.Min(_ShallowestLevelCompletedSinceLastFailurePrint, CurrentLevelOfRecursion)

        End If

    End Sub


#Region " Printing Output "

    Private Property ShallowestLevelCompletedSinceLastFailurePrint As Integer
    Private Property LastFailurePrintTime As Date = Now



    Private Sub WriteLine(Optional ByVal value As String = Nothing)
        If Not IsLoggingEnabled Then Exit Sub
        Console.WriteLine(value)
        WriteLineToFileLog(value)
    End Sub


    Private Sub WriteLineToFileLog(ByVal value As String)
        If Not IsLoggingEnabled Then Exit Sub
        ' My.Application.Log.WriteEntry(value)
    End Sub


#End Region


End Class
