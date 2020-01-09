Imports MySql.Data.MySqlClient
Module Delete
    Friend Sub DeleteData()
        Form1.RichTextBox1.Text = ""
        If (Form1.TextBox1.Text = "") Then
            Form1.RichTextBox1.Text = "You do not have an ID!"
            'MsgBox("You do not have an ID!")
        Else
            Dim accept As DialogResult = MessageBox.Show("Confirm delete?", "Title", MessageBoxButtons.YesNo)
            If (accept = 6) Then
                ids = CInt(Form1.TextBox1.Text)
                names = Form1.TextBox2.Text
                marks = CDbl(Form1.TextBox3.Text)
                departs = CInt(Form1.TextBox4.Text)
                Try
                    'PREPARE THE CONNECTION TO DB
                    dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
                    'STATEMENT
                    strQuery1 = "SELECT * FROM `student` where id=" + Form1.TextBox1.Text
                    strQuery2 = "INSERT INTO `delete`  (id,name,mark,depart) values(@id_,@name_,@mark_,@depart_)"
                    strQuery3 = "DELETE FROM `student` WHERE id=" + Form1.TextBox1.Text

                    SQLCmd = New MySqlCommand(strQuery1, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY
                    dbCon.Open()
                    DR = SQLCmd.ExecuteReader
                    While DR.Read
                        ids = CInt(DR.Item("id"))
                        names = DR.Item("name")
                        marks = CDbl(DR.Item("mark"))
                        departs = CInt(DR.Item("depart"))
                    End While
                    'DONE, WE CLOSE EVERYTHING
                    DR.Close()
                    dbCon.Close()
                    'MsgBox("1 sucessfully!")

                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery2, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY
                    SQLCmd.CommandType = CommandType.Text
                    SQLCmd.Parameters.AddWithValue("@id_", ids)
                    SQLCmd.Parameters.AddWithValue("@name_", names)
                    SQLCmd.Parameters.AddWithValue("@mark_", marks)
                    SQLCmd.Parameters.AddWithValue("@depart_", departs)
                    SQLCmd.ExecuteNonQuery()
                    'MsgBox("Data sucessfully inserted!")
                    dbCon.Close()

                    'MsgBox("2 sucessfully!")

                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery3, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY

                    SQLCmd.ExecuteReader()
                    dbCon.Close()

                    names = "deleted"
                    marks = 0
                    departs = 0

                    strQuery3 = "INSERT INTO logging (id,name,mark,depart) values(@id_,@name_,@mark_,@depart_)"

                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery3, dbCon)
                    'OPEN THE DB AND KICKOFF THE QUERY
                    SQLCmd.CommandType = CommandType.Text
                    SQLCmd.Parameters.AddWithValue("@id_", ids)
                    SQLCmd.Parameters.AddWithValue("@name_", names)
                    SQLCmd.Parameters.AddWithValue("@mark_", marks)
                    SQLCmd.Parameters.AddWithValue("@depart_", departs)
                    SQLCmd.ExecuteNonQuery()
                    Form1.RichTextBox1.Text = "Data sucessfully deleted!"
                    'MsgBox("Data sucessfully inserted!")
                    dbCon.Close()
                Catch ex As Exception
                    Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
                    'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
                End Try
                Form1.TextBox2.Enabled = False
                Form1.TextBox3.Enabled = False
                Form1.TextBox4.Enabled = False

                Form1.Button1.Enabled = True
                Form1.Button2.Enabled = False
                Form1.Button3.Enabled = False
                Form1.Button4.Enabled = False
                Form1.Button5.Enabled = True
                Form1.Button6.Enabled = True
                Form1.Button7.Enabled = True
            End If
        End If
    End Sub
End Module
