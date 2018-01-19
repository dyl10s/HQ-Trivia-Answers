<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchEngines
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbMeathod1 = New System.Windows.Forms.ListBox()
        Me.lbMeathod2 = New System.Windows.Forms.ListBox()
        Me.lblM4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbMeathod1
        '
        Me.lbMeathod1.FormattingEnabled = True
        Me.lbMeathod1.Location = New System.Drawing.Point(12, 114)
        Me.lbMeathod1.Name = "lbMeathod1"
        Me.lbMeathod1.Size = New System.Drawing.Size(120, 173)
        Me.lbMeathod1.TabIndex = 0
        '
        'lbMeathod2
        '
        Me.lbMeathod2.FormattingEnabled = True
        Me.lbMeathod2.Location = New System.Drawing.Point(152, 114)
        Me.lbMeathod2.Name = "lbMeathod2"
        Me.lbMeathod2.Size = New System.Drawing.Size(120, 173)
        Me.lbMeathod2.TabIndex = 1
        '
        'lblM4
        '
        Me.lblM4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM4.Location = New System.Drawing.Point(12, 86)
        Me.lblM4.Name = "lblM4"
        Me.lblM4.Size = New System.Drawing.Size(120, 25)
        Me.lblM4.TabIndex = 31
        Me.lblM4.Text = "Meathod 1"
        Me.lblM4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(152, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Meathod 2"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 53)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(105, 13)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 53)
        Me.btnEdit.TabIndex = 34
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(197, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 53)
        Me.btnDelete.TabIndex = 35
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmSearchEngines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 301)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblM4)
        Me.Controls.Add(Me.lbMeathod2)
        Me.Controls.Add(Me.lbMeathod1)
        Me.Name = "frmSearchEngines"
        Me.Text = "Search Engines"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbMeathod1 As ListBox
    Friend WithEvents lbMeathod2 As ListBox
    Friend WithEvents lblM4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
End Class
