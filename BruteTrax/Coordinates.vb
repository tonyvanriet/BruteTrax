Public Class Coordinates

    Property X As Integer
    Property Y As Integer

    Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub


    ''' <summary>
    ''' Returns translated coordinates after rotating by the given amount clockwise around the anchor location
    ''' </summary>
    Function Rotated(ByVal o As PieceOrientation, anchorLocation As Coordinates) As Coordinates
        Dim offsetCoordinates As New Coordinates(Me.X - anchorLocation.X, Me.Y - anchorLocation.Y)
        Dim offsetRotatedCoordinates = offsetCoordinates.Rotated(o)
        'Return New Coordinates(offsetRotatedCoordinates.X + anchorLocation.X, offsetRotatedCoordinates.Y + anchorLocation.Y)
        Return offsetRotatedCoordinates
    End Function


    ''' <summary>
    ''' Returns translated coordinates after rotating by the given amount clockwise around the origin (0,0).
    ''' </summary>
    Function Rotated(ByVal o As PieceOrientation) As Coordinates

        Select Case o
            Case PieceOrientation.Rotate0
                Return Me
            Case PieceOrientation.Rotate90
                Return New Coordinates(X:=Me.Y, Y:=Me.X * -1)
            Case PieceOrientation.Rotate180
                Return New Coordinates(X:=Me.X * -1, Y:=Me.Y * -1)
            Case PieceOrientation.Rotate270
                Return New Coordinates(X:=Me.Y * -1, Y:=Me.X)
        End Select

        Throw New InvalidOperationException

    End Function


    Function Offset(offsetCoordinates As Coordinates) As Coordinates
        Return New Coordinates(X:=Me.X + offsetCoordinates.X, Y:=Me.Y + offsetCoordinates.Y)
    End Function


    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse TypeOf obj Is Coordinates = False Then Return False
        Dim comparisonCoordinates As Coordinates = obj
        If comparisonCoordinates.X = Me.X And comparisonCoordinates.Y = Me.Y Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Operator =(ByVal c1 As Coordinates, ByVal c2 As Coordinates) As Boolean
        If c1 Is Nothing Or c2 Is Nothing Then Throw New InvalidOperationException
        Return c1.Equals(c2)
    End Operator

    Public Shared Operator <>(ByVal c1 As Coordinates, ByVal c2 As Coordinates) As Boolean
        If c1 Is Nothing Or c2 Is Nothing Then Throw New InvalidOperationException
        Return Not c1 = c2
    End Operator


    Public Shared Operator +(ByVal c1 As Coordinates, ByVal c2 As Coordinates) As Coordinates
        If c1 Is Nothing Or c2 Is Nothing Then Throw New InvalidOperationException
        Return New Coordinates(c1.X + c2.X, c1.Y + c2.Y)
    End Operator

    Public Shared Operator -(ByVal c1 As Coordinates, ByVal c2 As Coordinates) As Coordinates
        If c1 Is Nothing Or c2 Is Nothing Then Throw New InvalidOperationException
        Return New Coordinates(c1.X - c2.X, c1.Y - c2.Y)
    End Operator


    Public Overrides Function ToString() As String
        Return "(" & Me.X & "," & Me.Y & ")"
    End Function


    Function Clone() As Coordinates
        Return New Coordinates(Me.X, Me.Y)
    End Function

End Class



Public Class ConnectionLocations
    Public Property OuterConnectionLocation As Coordinates
    Public Property InnerConnectionLocation As Coordinates
End Class