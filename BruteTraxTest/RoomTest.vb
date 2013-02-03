Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BruteTrax

<TestClass()> Public Class RoomTest

    <TestMethod()> Public Sub FindCompleteTrackTest()

        Dim r As New Room
        r.IsLoggingEnabled = False
        r.AddPieces(New BasicSpeedTestPieceSet)
        r.FindCompleteTrack()

    End Sub

End Class