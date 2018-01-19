Public Class clsSearchEngine

    Dim label As String = ""
    Dim url As String = ""
    Dim method As Integer

    Public Sub New(label As String, url As String, method As Integer)
        Me.label = label
        Me.url = url
        Me.method = method
    End Sub


    Public Overrides Function toString() As String

        Return label + ";" + url + ";" + method.ToString

    End Function

End Class
