Public Class frmScreenshot
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel1.BackColor = Color.Pink
        Me.TransparencyKey = Color.Pink

    End Sub

    Public Sub saveImage(toBW As Boolean)

        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Me.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(Me.DesktopLocation.X, Me.DesktopLocation.Y + 30, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)

        If toBW = True Then
            For x As Integer = 0 To screenshot.Width - 1
                For y As Integer = 0 To screenshot.Height - 1
                    Dim colorscore = 0
                    colorscore += screenshot.GetPixel(x, y).R
                    colorscore += screenshot.GetPixel(x, y).G
                    colorscore += screenshot.GetPixel(x, y).B
                    'Console.WriteLine(colorscore)
                    If colorscore < 400 Then
                        screenshot.SetPixel(x, y, Color.Black)
                    Else
                        screenshot.SetPixel(x, y, Color.White)
                    End If
                Next
            Next
        End If

        screenshot.Save(AppDomain.CurrentDomain.BaseDirectory + "/test.png", Imaging.ImageFormat.Png)


    End Sub
End Class