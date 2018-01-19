Public Class frmSearchEngines

    Dim searchEngines As New List(Of clsSearchEngine)

    Dim curPath As String = My.Computer.FileSystem.CurrentDirectory
    Dim dataPath As String = curPath + "/seData.txt"

    Private Sub frmSearchEngines_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadData()

    End Sub

    Private Sub loadData()

        searchEngines.Clear()
        lbMeathod1.Items.Clear()
        lbMeathod2.Items.Clear()

        Dim fr = New IO.StreamReader(dataPath)
        Dim dataString As String = fr.ReadToEnd
        Dim dataLines As String() = dataString.Split(vbCrLf.ToCharArray)

        For i As Integer = 0 To dataLines.Length - 1
            If dataLines(i) <> "" AndAlso dataLines IsNot Nothing Then

                Dim line As String = dataLines(i)
                If line.Split(";")(2) = 1 Then

                    lbMeathod1.Items.Add(line.Split(";")(0))
                    searchEngines.Add(New clsSearchEngine(line.Split(";")(0), line.Split(";")(1), 1))

                ElseIf line.Split(";")(2) = 2 Then

                    lbMeathod2.Items.Add(line.Split(";")(0))
                    searchEngines.Add(New clsSearchEngine(line.Split(";")(0), line.Split(";")(1), 2))

                End If

            End If
        Next

        fr.Close()
        fr.Dispose()

    End Sub

    Private Sub lbMeathod2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbMeathod2.SelectedIndexChanged

        lbMeathod1.ClearSelected()

    End Sub

    Private Sub lbMeathod1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbMeathod1.SelectedIndexChanged

        lbMeathod2.ClearSelected()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim label As String = InputBox("What is the search engines name?")
        Dim url As String = InputBox("What is the search url you wish to use:")
        Dim meathod As String = InputBox("What meathod would you like to use (1 or 2)")

        Dim meathodInt As Integer = Integer.Parse(meathod)

        If meathodInt = 1 Or meathodInt = 2 Then
            addSearchEngine(label, url, meathodInt)
        Else
            MsgBox("Invalid meathod was entered")
        End If


    End Sub

    Public Sub addSearchEngine(label As String, url As String, meathod As String)

        Dim fw As IO.StreamWriter

        Dim newSE As New clsSearchEngine(label, url, meathod)

        fw = New IO.StreamWriter(dataPath, True)
        fw.WriteLine(vbCrLf + newSE.toString)
        fw.Close()
        fw.Dispose()

        loadData()


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim deletedEngine As New clsSearchEngine("", "", 0)
        Dim selectedText As String = ""
        Dim meathodNum As String = ""

        If lbMeathod1.SelectedItem <> Nothing Then
            selectedText = lbMeathod1.SelectedItem.ToString
            meathodNum = "1"
        End If

        If lbMeathod2.SelectedItem <> Nothing Then
            selectedText = lbMeathod2.SelectedItem.ToString
            meathodNum = "2"
        End If


        For Each se In searchEngines
            If se.toString.Split(";")(0) = selectedText AndAlso se.toString.Split(";")(2) = meathodNum Then
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
        Dim meathodNum As String = ""

        If lbMeathod1.SelectedItem <> Nothing Then
            selectedText = lbMeathod1.SelectedItem.ToString
            meathodNum = "1"
        End If

        If lbMeathod2.SelectedItem <> Nothing Then
            selectedText = lbMeathod2.SelectedItem.ToString
            meathodNum = "2"
        End If

        For Each se As clsSearchEngine In searchEngines
            If se.toString.Split(";")(0) = selectedText AndAlso se.toString.Split(";")(2) = meathodNum Then
                editedEngine = se
            End If
        Next

        Dim startingLabel As String = editedEngine.toString.Split(";")(0)
        Dim startingURL As String = editedEngine.toString.Split(";")(1)
        Dim startingMeathod As String = editedEngine.toString.Split(";")(2)


        Dim changedLabel As String = InputBox("What would you like to change the label to?", "HQ Trivia", startingLabel)
        Dim changedURL As String = InputBox("What would you like to change the URL to?", "HQ Trivia", startingURL)
        Dim changedMeathod As String = InputBox("What would you like to change the meathod to?", "HQ Trivia", startingMeathod)

        Dim fr As New IO.StreamReader(dataPath)
        Dim dataText As String = fr.ReadToEnd
        fr.Close()
        fr.Dispose()

        Dim fw As New IO.StreamWriter(dataPath, False)
        dataText = dataText.Replace(startingLabel + ";" + startingURL + ";" + startingMeathod, changedLabel + ";" + changedURL + ";" + changedMeathod)
        fw.Write(dataText)
        fw.Close()
        fw.Dispose()

        loadData()

    End Sub
End Class