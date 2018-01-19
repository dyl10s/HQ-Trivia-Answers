Public Class clsSearchEngine

    Dim label As String = ""
    Dim url As String = ""
    Dim meathod As Integer

    Public Sub New(label As String, url As String, meathod As Integer)
        Me.label = label
        Me.url = url
        Me.meathod = meathod
    End Sub


    Public Overrides Function toString() As String

        Return label + ";" + url + ";" + meathod.ToString

    End Function

End Class
