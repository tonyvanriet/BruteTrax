Imports BruteTrax


Module Module1

    Sub Main()

        Dim room As New Room
        room.IsLoggingEnabled = True

        Dim pieceSet = New BasicSpeedTest7PieceSet
        ' Dim pieceSet = New CompleteEarlyPieceSet
        room.AddPieces(pieceSet)

        Dim sw As New Stopwatch
        sw.Start()

        room.FindCompleteTrack()

        Console.WriteLine(String.Format("Tried all possible piece locations in {0}s", sw.ElapsedMilliseconds / 1000))

        Console.ReadLine()

    End Sub

End Module
