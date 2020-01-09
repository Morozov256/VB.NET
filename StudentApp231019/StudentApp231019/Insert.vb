Imports MySql.Data.MySqlClient
Module Insert
    Friend dbCon As MySqlConnection
    Friend strQuery1 = ""
    Friend strQuery2 = ""
    Friend strQuery3 = ""
    Friend ID = 0
    Friend SQLCmd As MySqlCommand
    Friend DR As MySqlDataReader
    Friend ids As Integer
    Friend names As String
    Friend marks As Double
    Friend departs As Integer
    Friend Sub InsertData()
        Form1.RichTextBox1.Text = ""
        If (Form1.TextBox1.Text = "") Then
            If (Form1.TextBox2.Text = "" Or Form1.TextBox3.Text = "" Or Form1.TextBox4.Text = "") Then
                Form1.RichTextBox1.Text = "Enter all data!"
                'MsgBox("Enter all data!")
            Else
                names = Form1.TextBox2.Text
                marks = CDbl(Form1.TextBox3.Text)
                departs = CInt(Form1.TextBox4.Text)
                Try
                    'PREPARE THE CONNECTION TO DB
                    dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
                    'STATEMENT
                    strQuery1 = "INSERT INTO student (name,mark,depart) values(@name_,@mark_,@depart_);SELECT LAST_INSERT_ID();"
                    strQuery2 = "select max(id)as res FROM `student`"
                    strQuery3 = "INSERT INTO logging (id,name,mark,depart) values(@id_,@name_,@mark_,@depart_)"

                    'Open the connection
                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery1, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY
                    SQLCmd.CommandType = CommandType.Text
                    SQLCmd.Parameters.AddWithValue("@name_", names)
                    SQLCmd.Parameters.AddWithValue("@mark_", marks)
                    SQLCmd.Parameters.AddWithValue("@depart_", departs)
                    SQLCmd.ExecuteNonQuery()
                    dbCon.Close()

                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery2, dbCon)
                    DR = SQLCmd.ExecuteReader
                    While DR.Read
                        ids = DR.Item("res")
                    End While
                    Form1.TextBox1.Text = ids
                    DR.Close()
                    dbCon.Close()

                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery3, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY
                    SQLCmd.CommandType = CommandType.Text
                    SQLCmd.Parameters.AddWithValue("@id_", ids)
                    SQLCmd.Parameters.AddWithValue("@name_", names)
                    SQLCmd.Parameters.AddWithValue("@mark_", marks)
                    SQLCmd.Parameters.AddWithValue("@depart_", departs)
                    SQLCmd.ExecuteNonQuery()
                    Form1.RichTextBox1.Text = "Data sucessfully inserted!"
                    'MsgBox("Data sucessfully inserted!")
                    dbCon.Close()

                Catch ex As Exception
                    Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
                    'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
                End Try
                Form1.TextBox2.Enabled = False
                Form1.TextBox3.Enabled = False
                Form1.TextBox4.Enabled = False
            End If
            Form1.Button1.Enabled = False
            Form1.Button2.Enabled = True
            Form1.Button3.Enabled = True
            Form1.Button4.Enabled = True
            Form1.Button5.Enabled = False
            Form1.Button6.Enabled = False
            Form1.Button7.Enabled = True
        Else
            Form1.TextBox1.Text = ""
            Form1.TextBox2.Text = ""
            Form1.TextBox2.Enabled = True
            Form1.TextBox3.Text = ""
            Form1.TextBox3.Enabled = True
            Form1.TextBox4.Text = ""
            Form1.TextBox4.Enabled = True
            Form1.TextBox5.Text = ""
            Form1.Button1.Enabled = False
            Form1.Button2.Enabled = True
            Form1.Button3.Enabled = False
            Form1.Button4.Enabled = False
            Form1.Button5.Enabled = False
            Form1.Button6.Enabled = False
            Form1.Button7.Enabled = False

            Form1.RichTextBox1.Text = "Insert data of new student!" & vbCrLf
        End If

    End Sub
End Module
