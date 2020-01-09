Imports MySql.Data.MySqlClient
Module History
    Friend Sub GetHistory()
        Form1.RichTextBox1.Text = ""
        Try
            'PREPARE THE CONNECTION TO DB
            dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
            'STATEMENT
            strQuery1 = "SELECT * FROM `logging` WHERE `ID`=" + Form1.TextBox1.Text + " order by `time`"
            SQLCmd = New MySqlCommand(strQuery1, dbCon)
            'OPEN THE DB AND KICKOFF THE QUERY
            dbCon.Open()
            DR = SQLCmd.ExecuteReader
            While DR.Read
                Form1.RichTextBox1.Text = Form1.RichTextBox1.Text & DR.Item("name") & Space(10) & DR.Item("mark") & Space(10) & DR.Item("depart") & Space(10) & DR.Item("time") & vbCrLf
            End While
            'DONE, WE CLOSE EVERYTHING
            DR.Close()
            dbCon.Close()
        Catch ex As Exception
            Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
            'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
End Module
