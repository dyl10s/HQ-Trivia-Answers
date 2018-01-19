Public Class frmSearchEngines

    Dim searchEngines As New List(Of clsSearchEngine)

    Dim curPath As String = My.Computer.FileSystem.CurrentDirectory
    Dim dataPath As String = curPath + "/seData.txt"

    Private Sub frmSearchEngines_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadData()

    End Sub

    Private Sub loadData()

        searchEngines.Clear()
        lbmethod1.Items.Clear()
        lbmethod2.Items.Clear()

        Dim fr = New IO.StreamReader(dataPath)
        Dim dataString As String = fr.ReadToEnd
        Dim dataLines As String() = dataString.Split(vbCrLf.ToCharArray)

        For i As Integer = 0 To dataLines.Length - 1
            If dataLines(i) <> "" AndAlso dataLines IsNot Nothing Then

                Dim line As String = dataLines(i)
                If line.Split(";")(2) = 1 Then

                    lbmethod1.Items.Add(line.Split(";")(0))
                    searchEngines.Add(New clsSearchEngine(line.Split(";")(0), line.Split(";")(1), 1))

                ElseIf line.Split(";")(2) = 2 Then

                    lbmethod2.Items.Add(line.Split(";")(0))
                    searchEngines.Add(New clsSearchEngine(line.Split(";")(0), line.Split(";")(1), 2))

                End If

            End If
        Next

        fr.Close()
        fr.Dispose()

    End Sub

    Private Sub lbmethod2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbmethod2.SelectedIndexChanged

        lbmethod1.ClearSelected()

    End Sub

    Private Sub lbmethod1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbmethod1.SelectedIndexChanged

        lbmethod2.ClearSelected()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim label As String = InputBox("What is the search engines name?")
        Dim url As String = InputBox("What is the search url you wish to use:")
        Dim method As String = InputBox("What method would you like to use (1 or 2)")

        Dim methodInt As Integer = Integer.Parse(method)

        If methodInt = 1 Or methodInt = 2 Then
            addSearchEngine(label, url, methodInt)
        Else
            MsgBox("Invalid method was entered")
        End If


    End Sub

    Public Sub addSearchEngine(label As String, url As String, method As String)

        Dim fw As IO.StreamWriter

        Dim newSE As New clsSearchEngine(label, url, method)

        fw = New IO.StreamWriter(dataPath, True)
        fw.WriteLine(vbCrLf + newSE.toString)
        fw.Close()
        fw.Dispose()

        loadData()


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim deletedEngine As New clsSearchEngine("", "", 0)
        Dim selectedText As String = ""
        Dim methodNum As String = ""

        If lbmethod1.SelectedItem <> Nothing Then
            selectedText = lbmethod1.SelectedItem.ToString
            methodNum = "1"
        End If

        If lbmethod2.SelectedItem <> Nothing Then
            selectedText = lbmethod2.SelectedItem.ToString
            methodNum = "2"
        End If


        For Each se In searchEngines
            If se.toString.Split(";")(0) = selectedText AndAlso se.toString.Split(";")(2) = methodNum Then
                deletedEngine = se
            End If
        Next

        If MsgBox("Are you sure you want to delete this?", vbYesNo) = MsgBoxResult.Yes Then

            Dim fr As New IO.StreamReader(dataPath)
            Dim dataString As String = fr.ReadToEnd
            dataString = dataString.Remove(dataString.IndexOf(deletedEngine.toString), deletedEngine.toString.Length)
            fr.Close()
            fr.Dispose()

            Dim fw As New IO.StreamWriter(dataPath, False)
            fw.Write(dataString.Trim(vbCrLf.ToCharArray))
            fw.Close()
            fw.Dispose()

            loadData()

        End If




    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim editedEngine As New clsSearchEngine("", "", 0)
        Dim selectedText As String = ""
        Dim methodNum As String = ""

        If lbmethod1.SelectedItem <> Nothing Then
            selectedText = lbmethod1.SelectedItem.ToString
            methodNum = "1"
        End If

        If lbmethod2.SelectedItem <> Nothing Then
            selectedText = lbmethod2.SelectedItem.ToString
            methodNum = "2"
        End If

        For Each se As clsSearchEngine In searchEngines
            If se.toString.Split(";")(0) = selectedText AndAlso se.toString.Split(";")(2) = methodNum Then
                editedEngine = se
            End If
        Next

        Dim startingLabel As String = editedEngine.toString.Split(";")(0)
        Dim startingURL As String = editedEngine.toString.Split(";")(1)
        Dim startingmethod As String = editedEngine.toString.Split(";")(2)


        Dim changedLabel As String = InputBox("What would you like to change the label to?", "HQ Trivia", startingLabel)
        Dim changedURL As String = InputBox("What would you like to change the URL to?", "HQ Trivia", startingURL)
        Dim changedmethod As String = InputBox("What would you like to change the method to?", "HQ Trivia", startingmethod)

        Dim fr As New IO.StreamReader(dataPath)
        Dim dataText As String = fr.ReadToEnd
        fr.Close()
        fr.Dispose()

        Dim fw As New IO.StreamWriter(dataPath, False)
        dataText = dataText.Replace(startingLabel + ";" + startingURL + ";" + startingmethod, changedLabel + ";" + changedURL + ";" + changedmethod)
        fw.Write(dataText)
        fw.Close()
        fw.Dispose()

        loadData()

    End Sub
End Class