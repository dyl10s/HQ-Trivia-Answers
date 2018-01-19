<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.lblM4 = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.cbxBW = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxMeathod1 = New System.Windows.Forms.CheckBox()
        Me.cbxMeathod2 = New System.Windows.Forms.CheckBox()
        Me.btnSearchEngines = New System.Windows.Forms.Button()
        Me.ttBW = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(12, 12)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(175, 41)
        Me.btnRun.TabIndex = 6
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(208, 12)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(175, 41)
        Me.btnCapture.TabIndex = 7
        Me.btnCapture.Text = "Open Capture"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'lblM4
        '
        Me.lblM4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM4.Location = New System.Drawing.Point(12, 88)
        Me.lblM4.Name = "lblM4"
        Me.lblM4.Size = New System.Drawing.Size(223, 25)
        Me.lblM4.TabIndex = 30
        Me.lblM4.Text = "Output"
        Me.lblM4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(12, 116)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(223, 235)
        Me.txtOutput.TabIndex = 31
        '
        'cbxBW
        '
        Me.cbxBW.Location = New System.Drawing.Point(246, 130)
        Me.cbxBW.Name = "cbxBW"
        Me.cbxBW.Size = New System.Drawing.Size(137, 43)
        Me.cbxBW.TabIndex = 32
        Me.cbxBW.Text = "Convert image to black and white ."
        Me.cbxBW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ttBW.SetToolTip(Me.cbxBW, "This converts the image captured to black and white." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This can cause longer respo" &
        "nse times but greatly improves" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the accuracy in converting the image to text.")
        Me.cbxBW.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(246, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 25)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Settings"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxMeathod1
        '
        Me.cbxMeathod1.Location = New System.Drawing.Point(246, 179)
        Me.cbxMeathod1.Name = "cbxMeathod1"
        Me.cbxMeathod1.Size = New System.Drawing.Size(137, 41)
        Me.cbxMeathod1.TabIndex = 34
        Me.cbxMeathod1.Text = "[Meathod 1] Search for question with answers"
        Me.cbxMeathod1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ttBW.SetToolTip(Me.cbxMeathod1, resources.GetString("cbxMeathod1.ToolTip"))
        Me.cbxMeathod1.UseVisualStyleBackColor = True
        '
        'cbxMeathod2
        '
        Me.cbxMeathod2.Location = New System.Drawing.Point(246, 226)
        Me.cbxMeathod2.Name = "cbxMeathod2"
        Me.cbxMeathod2.Size = New System.Drawing.Size(137, 41)
        Me.cbxMeathod2.TabIndex = 35
        Me.cbxMeathod2.Text = "[Meathod 2} Search for answer with question"
        Me.cbxMeathod2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ttBW.SetToolTip(Me.cbxMeathod2, "This does 3 searches for each answer and attempts to extract" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "key words from the " &
        "question to look for. This takes a longer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "amount of time then meathod 1 because" &
        " it has to preform 3 searches.")
        Me.cbxMeathod2.UseVisualStyleBackColor = True
        '
        'btnSearchEngines
        '
        Me.btnSearchEngines.Location = New System.Drawing.Point(246, 308)
        Me.btnSearchEngines.Name = "btnSearchEngines"
        Me.btnSearchEngines.Size = New System.Drawing.Size(139, 43)
        Me.btnSearchEngines.TabIndex = 36
        Me.btnSearchEngines.Text = "Edit search engines"
        Me.btnSearchEngines.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 364)
        Me.Controls.Add(Me.btnSearchEngines)
        Me.Controls.Add(Me.cbxMeathod2)
        Me.Controls.Add(Me.cbxMeathod1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxBW)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblM4)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.btnRun)
        Me.Name = "frmMain"
        Me.Text = "HQ Trivia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRun As Button
    Friend WithEvents btnCapture As Button
    Friend WithEvents lblM4 As Label
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents cbxBW As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxMeathod1 As CheckBox
    Friend WithEvents cbxMeathod2 As CheckBox
    Friend WithEvents btnSearchEngines As Button
    Friend WithEvents ttBW As ToolTip
End Class
