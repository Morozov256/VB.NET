Imports MySql.Data.MySqlClient
Module Search
    Friend Sub SearchData()
        Form1.RichTextBox1.Text = ""
        Try
            'PREPARE THE CONNECTION TO DB
            dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
            'STATEMENT
            strQuery1 = "SELECT * FROM student where id=" + Form1.TextBox5.Text
            SQLCmd = New MySqlCommand(strQuery1, dbCon)
            'OPEN THE DB AND KICKOFF THE QUERY
            dbCon.Open()
            DR = SQLCmd.ExecuteReader
            If (DR.HasRows) Then
                Form1.RichTextBox1.Text = "Student with id=" + Form1.TextBox5.Text + " found successful in the list of curent students!"
                While DR.Read
                    Form1.TextBox1.Text = DR.Item("id")
                    ids = DR.Item("id")
                    Form1.TextBox1.Enabled = False
                    Form1.TextBox2.Text = DR.Item("name")
                    names = DR.Item("name")
                    Form1.TextBox2.Enabled = False
                    Form1.TextBox3.Text = DR.Item("mark")
                    marks = DR.Item("mark")
                    Form1.TextBox3.Enabled = False
                    Form1.TextBox4.Text = DR.Item("depart")
                    departs = DR.Item("depart")
                    Form1.TextBox4.Enabled = False

                    Form1.Button1.Enabled = True
                    Form1.Button2.Enabled = True
                    Form1.Button3.Enabled = True
                    Form1.Button4.Enabled = True
                    Form1.Button5.Enabled = True
                    Form1.Button6.Enabled = True
                    Form1.Button7.Enabled = True
                End While
            Else

                Form1.RichTextBox1.Text = "The record was not found in the list of curent students." & vbCrLf
                DR.Close()
                dbCon.Close()

                'STATEMENT
                strQuery1 = "SELECT * FROM `delete` where id=" + Form1.TextBox5.Text
                SQLCmd = New MySqlCommand(strQuery1, dbCon)
                'OPEN THE DB AND KICKOFF THE QUERY
                dbCon.Open()
                DR = SQLCmd.ExecuteReader
                If (DR.HasRows) Then
                    Form1.RichTextBox1.Text += "Student with id=" + Form1.TextBox5.Text + " found successful in the list of deleted students!"
                    While DR.Read
                        Form1.TextBox1.Text = DR.Item("id")
                        Form1.TextBox1.Enabled = False
                        Form1.TextBox2.Text = DR.Item("name")
                        Form1.TextBox2.Enabled = False
                        Form1.TextBox3.Text = DR.Item("mark")
                        Form1.TextBox3.Enabled = False
                        Form1.TextBox4.Text = DR.Item("depart")
                        Form1.TextBox4.Enabled = False

                        Form1.Button1.Enabled = True
                        Form1.Button2.Enabled = False
                        Form1.Button3.Enabled = False
                        Form1.Button4.Enabled = False
                        Form1.Button5.Enabled = True
                        Form1.Button6.Enabled = True
                        Form1.Button7.Enabled = True
                    End While
                Else
                    Form1.RichTextBox1.Text += "The record was not found in the list of deleted students." & vbCrLf
                End If
            End If
            'DONE, WE CLOSE EVERYTHING
            DR.Close()
            dbCon.Close()
        Catch ex As Exception
            Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message & vbCrLf

            'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub getPrevious()
        Try
            'PREPARE THE CONNECTION TO DB
            dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
            'STATEMENT
            strQuery1 = "select max(id)as res FROM `student` where id<" + Form1.TextBox5.Text
            SQLCmd = New MySqlCommand(strQuery1, dbCon)

            'OPEN THE DB AND KICKOFF THE QUERY
            dbCon.Open()
            SQLCmd = New MySqlCommand(strQuery1, dbCon)
            DR = SQLCmd.ExecuteReader
            While DR.Read
                If (DR.Item("res").ToString = "") Then
                    DR.Close()
                    dbCon.Close()

                    'STATEMENT
                    strQuery1 = "select max(id)as res FROM `student` "
                    SQLCmd = New MySqlCommand(strQuery1, dbCon)

                    'OPEN THE DB AND KICKOFF THE QUERY
                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery1, dbCon)
                    DR = SQLCmd.ExecuteReader
                    While DR.Read
                        Form1.TextBox5.Text = DR.Item("res")
                    End While
                Else
                    Form1.TextBox5.Text = DR.Item("res")
                End If
            End While
            DR.Close()
            dbCon.Close()
            SearchData()
            Form1.TextBox5.Text = Form1.TextBox1.Text
        Catch ex As Exception
            Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
            'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub getFollowing()
        Try
            'PREPARE THE CONNECTION TO DB
            dbCon = New MySqlConnection("Server=127.0.0.1;Database=vbnet;Uid=root;Pwd=''")
            'STATEMENT
            strQuery1 = "select min(id)as res FROM `student` where id>" + Form1.TextBox5.Text
            SQLCmd = New MySqlCommand(strQuery1, dbCon)

            'OPEN THE DB AND KICKOFF THE QUERY
            dbCon.Open()
            SQLCmd = New MySqlCommand(strQuery1, dbCon)
            DR = SQLCmd.ExecuteReader
            While DR.Read
                If (DR.Item("res").ToString = "") Then
                    DR.Close()
                    dbCon.Close()

                    'STATEMENT
                    strQuery1 = "select min(id)as res FROM `student` "
                    SQLCmd = New MySqlCommand(strQuery1, dbCon)

                    'OPEN THE DB AND KICKOFF THE QUERY
                    dbCon.Open()
                    SQLCmd = New MySqlCommand(strQuery1, dbCon)
                    DR = SQLCmd.ExecuteReader
                    While DR.Read
                        Form1.TextBox5.Text = DR.Item("res")
                    End While
                Else
                    Form1.TextBox5.Text = DR.Item("res")
                End If
            End While

            DR.Close()
            dbCon.Close()
            SearchData()
            Form1.TextBox5.Text = Form1.TextBox1.Text
        Catch ex As Exception
            Form1.RichTextBox1.Text = "Failure to communicate!" & vbCrLf & vbCrLf & ex.Message
            'MsgBox("Failure to communicate!" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
End Module
