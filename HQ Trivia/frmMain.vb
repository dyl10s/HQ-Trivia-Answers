Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Tesseract
Imports System.Text

Public Class frmMain

    Dim curPath As String = My.Computer.FileSystem.CurrentDirectory
    Dim textDataPath As String = curPath + "/seData.txt"

    Dim question As String = ""
    Dim ans1 As String = ""
    Dim ans2 As String = ""
    Dim ans3 As String = ""

    Dim captureForm As frmScreenshot = New frmScreenshot

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRun.Click

        question = ""
        ans1 = ""
        ans2 = ""
        ans3 = ""

        txtOutput.Clear()
        captureForm.saveImage(cbxBW.Checked)

        Dim testImagePath = AppDomain.CurrentDomain.BaseDirectory + "/test.png"
        Dim dataPath = AppDomain.CurrentDomain.BaseDirectory + "/tessData"

        Try

            Using tEngine = New TesseractEngine(dataPath, "eng", EngineMode.[Default])
                Using img = Pix.LoadFromFile(testImagePath)
                    Using page = tEngine.Process(img)

                        Dim text = page.GetIterator
                        text.Begin()

                        Dim level = New PageIteratorLevel()
                        Dim dataLines As New List(Of String)

                        Do
                            dataLines.Add(text.GetText(level.TextLine))
                        Loop Until text.Next(level.TextLine) = False

                        If dataLines.Last.Length <= 3 Then
                            dataLines.Remove(dataLines.Last)
                        End If

                        ans3 = dataLines.Last
                        dataLines.Remove(dataLines.Last)
                        ans2 = dataLines.Last
                        dataLines.Remove(dataLines.Last)
                        ans1 = dataLines.Last
                        dataLines.Remove(dataLines.Last)

                        For Each s As String In dataLines
                            If s.Last <> "?" Then
                                question += s.Remove(s.IndexOf(s.Last)) + " "
                            End If

                        Next

                        ans3 = ans3.Remove(ans3.IndexOf(ans3.Last))
                        ans2 = ans2.Remove(ans2.IndexOf(ans2.Last))
                        ans1 = ans1.Remove(ans1.IndexOf(ans1.Last))

                        question = question.Replace("ﬁ", "fi")
                        ans3 = ans3.Replace("ﬁ", "fi")
                        ans1 = ans1.Replace("ﬁ", "fi")
                        ans2 = ans2.Replace("ﬁ", "fi")

                        Console.WriteLine(question)
                        Console.WriteLine(ans1 + " " + ans2 + " " + ans3)

                    End Using
                End Using
            End Using

        Catch ex As Exception
        End Try

        Dim fr As New IO.StreamReader(textDataPath)
        Dim data As String = fr.ReadToEnd
        Dim lines As String() = data.Split(vbCrLf.ToCharArray)
        fr.Close()
        fr.Dispose()

        If cbxmethod1.Checked Then
            For i As Integer = 0 To lines.Length - 1
                If lines(i) <> "" AndAlso lines(i).Split(";")(2) = "1" Then
                    searchMethod(lines(i).Split(";")(1), lines(i).Split(";")(0) + ": ")
                End If
            Next
        End If

        If cbxmethod2.Checked Then
            For i As Integer = 0 To lines.Length - 1
                If lines(i) <> "" AndAlso lines(i).Split(";")(2) = "2" Then
                    findmethod(lines(i).Split(";")(1), lines(i).Split(";")(0) + ": ")
                End If
            Next
        End If


    End Sub

    Public Function HTTPrequest(url As String) As String

        Dim webStream As Stream
        Dim webResponse = ""
        Dim req As HttpWebRequest
        Dim res As HttpWebResponse

        Try
            req = CType(WebRequest.Create(url), HttpWebRequest)
            req.Method = "GET"
            res = CType(req.GetResponse(), HttpWebResponse) ' Send Request
            webStream = res.GetResponseStream() ' Get Response
            Dim webStreamReader As New StreamReader(webStream)
            While webStreamReader.Peek >= 0
                webResponse = webStreamReader.ReadToEnd()
            End While
        Catch ex As Exception

        End Try

        Return webResponse.ToString

    End Function

    Public Sub searchMethod(searchURL As String, lblText As String)

        Dim text As String = HTTPrequest(searchURL + question)

        'What has the first result

        Dim score1 = text.IndexOf(ans1.ToLower)
        Dim score2 = text.IndexOf(ans2.ToLower)
        Dim score3 = text.IndexOf(ans3.ToLower)

        Dim highscore As Integer = -1
        Dim ansNum = -1

        If question.ToLower.Contains(" not ") Then
            If (score1 <> -1 AndAlso (score1 < highscore Or highscore = -1)) Then

                highscore = score1
                ansNum = 1

            End If

            If (score2 <> -1 AndAlso (score2 < highscore Or highscore = -1)) Then

                highscore = score2
                ansNum = 2

            End If

            If (score3 <> -1 AndAlso (score3 < highscore Or highscore = -1)) Then

                highscore = score3
                ansNum = 3

            End If

        Else

            If (score1 <> -1 AndAlso (score1 > highscore Or highscore = -1)) Then

                highscore = score1
                ansNum = 1

            End If

            If (score2 <> -1 AndAlso (score2 > highscore Or highscore = -1)) Then

                highscore = score2
                ansNum = 2

            End If

            If (score3 <> -1 AndAlso (score3 > highscore Or highscore = -1)) Then

                highscore = score3
                ansNum = 3

            End If

        End If


        Select Case ansNum
            Case 1

                txtOutput.Text += lblText + ans1 & vbCrLf

            Case 2

                txtOutput.Text += lblText + ans2 & vbCrLf

            Case 3

                txtOutput.Text += lblText + ans3 & vbCrLf

            Case Else

                txtOutput.Text += lblText + "Fail" & vbCrLf

        End Select

        'What has the most results?

        score1 = text.Split(New String() {ans1.ToLower}, StringSplitOptions.None).Count - 1
        score2 = text.Split(New String() {ans2.ToLower}, StringSplitOptions.None).Count - 1
        score3 = text.Split(New String() {ans3.ToLower}, StringSplitOptions.None).Count - 1

        highscore = 0
        ansNum = -1

        If (score1 <> -1 AndAlso score1 > highscore) Then

            highscore = score1
            ansNum = 1

        End If

        If (score2 <> -1 AndAlso score2 > highscore) Then

            highscore = score2
            ansNum = 2

        End If

        If (score3 <> -1 AndAlso score3 > highscore) Then

            highscore = score3
            ansNum = 3

        End If

        If question.ToLower.Contains(" not ") Then

            If score1 < score2 AndAlso score1 < score3 Then

                txtOutput.Text += lblText + ans1 & vbCrLf
                Exit Sub

            End If

            If score2 < score3 AndAlso score2 < score1 Then

                txtOutput.Text += lblText + ans2 & vbCrLf
                Exit Sub

            End If

            If score3 < score2 AndAlso score3 < score1 Then

                txtOutput.Text += lblText + ans3 & vbCrLf
                Exit Sub

            End If

        End If

        Select Case ansNum
            Case 1

                txtOutput.Text += lblText + ans1 & vbCrLf

            Case 2

                txtOutput.Text += lblText + ans2 & vbCrLf

            Case 3

                txtOutput.Text += lblText + ans3 & vbCrLf

            Case Else

                txtOutput.Text += lblText + "Fail" & vbCrLf

        End Select

    End Sub

    Public Sub findmethod(searchUrl As String, lblText As String)

        Dim res1 As String = HTTPrequest(searchUrl + ans1)
        Dim res2 As String = HTTPrequest(searchUrl + ans2)
        Dim res3 As String = HTTPrequest(searchUrl + ans3)

        Dim Qwords As New List(Of String)
        Dim isNotQ As Boolean = False
        Qwords.Clear()

        Dim q As String = question

        q = q.ToLower
        q = q.Replace("?", "")
        q = q.Replace(",", "")
        q = q.Replace("&", "")

        For i As Integer = q.Split(" ").Count - 1 To 0 Step -1
            Dim s As String = q.Split(" ")(i)

            If s = "these" Then
                Qwords.Remove(q.Split(" ")(i + 1))
            End If

            If s = "are" Then
                Qwords.Remove(q.Split(" ")(i + 1))
            End If

            If s = "the" Then
                Qwords.Remove(q.Split(" ")(i + 1))
            End If

            If s = "which" Then
                Try
                    If i - 0 > 1 Then
                        If q.Split(" ")(i - 1) = "from" Then
                            For x As Integer = 1 To q.Split(" ").Count - 1 - i
                                Qwords.Remove(q.Split(" ")(i + x))
                            Next
                        End If
                    Else
                        Qwords.Remove(q.Split(" ")(i + 1))
                    End If
                Catch ex As Exception

                End Try
            End If

            If s = "" Or s = "from" Or s = "words" Or s = "would" Or s = "need" Or s = "most" Or s = "are" Or s = "you" Or s = "likely" Or s = "find" Or s = "type" Or s = "to" Or s = "animals" Or s = "for" Or s = "was" Or s = "a" Or s = "an" Or s = "the" Or s = "what" Or s = "how" Or s = "when" Or s = "of" Or s = "on" Or s = "is" Or s = "of" Or s = "which" Or s = "in" Or s = "these" Then
            Else
                If s = "not" Or s = "unable" Then
                    isNotQ = True
                Else
                    Qwords.Add(s)
                End If
            End If
        Next

        If q.Contains("dates back to the") Then
            Qwords.Clear()
            Dim qdate As String = q.Split(New String() {"dates back to the"}, StringSplitOptions.None)(1)
            If qdate.Length >= 5 Then
                qdate = qdate.Remove(4)
            End If
            Qwords.Add(qdate)
        End If

        Dim score1 As Integer = 0
        Dim score2 As Integer = 0
        Dim score3 As Integer = 0

        For Each s As String In Qwords
            score1 += res1.Split(New String() {s}, StringSplitOptions.None).Count - 1
            score2 += res2.Split(New String() {s}, StringSplitOptions.None).Count - 1
            score3 += res3.Split(New String() {s}, StringSplitOptions.None).Count - 1
        Next

        If isNotQ = False Then

            If score1 > score2 AndAlso score1 > score3 Then
                txtOutput.Text += lblText + ans1 & vbCrLf
            End If

            If score2 > score3 AndAlso score2 > score1 Then
                txtOutput.Text += lblText + ans2 & vbCrLf
            End If

            If score3 > score2 AndAlso score3 > score1 Then
                txtOutput.Text += lblText + ans3 & vbCrLf
            End If

        End If

        If isNotQ = True Then

            If score1 < score2 AndAlso score1 < score3 Then
                txtOutput.Text += lblText + ans1 & vbCrLf
            End If

            If score2 < score3 AndAlso score2 < score1 Then
                txtOutput.Text += lblText + ans2 & vbCrLf
            End If

            If score3 < score2 AndAlso score3 < score1 Then
                txtOutput.Text += lblText + ans3 & vbCrLf
            End If

        End If


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCapture.Click

        captureForm.Show()
        captureForm.BringToFront()

    End Sub

    Private Sub btnSearchEngines_Click(sender As Object, e As EventArgs) Handles btnSearchEngines.Click

        Dim frm As New frmSearchEngines
        frm.Show()
        frm.BringToFront()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not My.Computer.FileSystem.FileExists(textDataPath) Then
            Dim fw As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(textDataPath, False)
            fw.WriteLine("Google;https://www.google.com/search?q=;1")
            fw.WriteLine("Google;https://www.google.com/search?q=?q=;2")
            fw.Close()
            fw.Dispose()
        End If

    End Sub
End Class
