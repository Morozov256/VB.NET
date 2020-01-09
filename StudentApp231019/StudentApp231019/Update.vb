Imports MySql.Data.MySqlClient
Module Update
    Friend Sub UpdateData()
        Form1.RichTextBox1.Text = ""
        If (Form1.TextBox2.Enabled = False) Then
            Form1.TextBox2.Enabled = True
            Form1.TextBox3.Enabled = True
            Form1.TextBox4.Enabled = True
            Form1.Button2.Enabled = False
            Form1.Button4.Enabled = False
            Form1.Button7.Enabled = False
            Form1.RichTextBox1.Text = "You can change data!"

            'MsgBox("You can change data!")
        Else
            If (Form1.TextBox2.Text = "" Or Form1.TextBox3.Text = "" Or Form1.TextBox4.Text = "") Then
                Form1.RichTextBox1.Text = "Enter all data!"
                'MsgBox("Enter all data!")
            Else
                If (ids = CInt(Form1.TextBox1.Text) And
                    names = Form1.TextBox2.Text And
                    marks = CDbl(Form1.TextBox3.Text) And
                    departs = CInt(Form1.TextBox4.Text)) Then
                    Form1.RichTextBox1.Text = "Data was not change!"
                    'MsgBox("Data was not change!")
                    Form1.TextBox2.Enabled = False
                    Form1.TextBox3.Enabled = False
                    Form1.TextBox4.Enabled = False

                    Form1.Button2.Enabled = True
                    Form1.Button4.Enabled = True
                    Form1.Button7.Enabled = True
                Else
                    ids = CInt(Form1.TextBox1.Text)
                    names = Form1.TextBox2.Text
                    marks = CDbl(Form1.TextBox3.Text)
                    departs = CInt(Form1.TextBox4.Text)
                    Try
                        'PREPARE THE CONNECTION TO DB
                        dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
                        'STATEMENT
                        strQuery1 = "UPDATE student SET NAME='" + Form1.TextBox2.Text + "',MARK=" + Form1.TextBox3.Text + ",DEPART=" + Form1.TextBox4.Text + " WHERE id=" + Form1.TextBox1.Text
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
                        SQLCmd = New MySqlCommand(strQuery3, dbCon)
                        'OPEN THE DB AND KICKOFF THE QUERY
                        SQLCmd.CommandType = CommandType.Text
                        SQLCmd.Parameters.AddWithValue("@id_", ids)
                        SQLCmd.Parameters.AddWithValue("@name_", names)
                        SQLCmd.Parameters.AddWithValue("@mark_", marks)
                        SQLCmd.Parameters.AddWithValue("@depart_", departs)
                        SQLCmd.ExecuteNonQuery()
                        Form1.RichTextBox1.Text = "Data sucessfully updated!"
                        'MsgBox("Data sucessfully updated!")
                        dbCon.Close()
                    Catch ex As Exception
                        Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
                        'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
                    End Try
                    Form1.TextBox2.Enabled = False
                    Form1.TextBox3.Enabled = False
                    Form1.TextBox4.Enabled = False

                    Form1.Button2.Enabled = True
                    Form1.Button3.Enabled = True
                    Form1.Button4.Enabled = True
                    Form1.Button7.Enabled = True
                End If
            End If
        End If
    End Sub
End Module
