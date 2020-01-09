Public Class Form1
    Public firstNum As Decimal
    Public secondNum As Decimal
    Public lastSymbol As String = ""
    Public newLine As Boolean = True
    Public dot As Boolean = False

    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        NumericButton("0")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NumericButton("1")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NumericButton("2")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NumericButton("3")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NumericButton("4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NumericButton("5")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        NumericButton("6")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        NumericButton("7")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NumericButton("8")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        NumericButton("9")
    End Sub

    Private Sub ButtonDot_Click(sender As Object, e As EventArgs) Handles ButtonDot.Click
        If (Not dot) Then
            If (CStr(TextBox1.Text) = "") Then
                TextBox1.Text = "0."
            ElseIf (CStr(TextBox1.Text) = "-") Then
                TextBox1.Text = CStr(TextBox1.Text) + "0."
            ElseIf (newLine) Then
                TextBox1.Text = "0."
            Else
                TextBox1.Text = CStr(TextBox1.Text) + "."
            End If
        End If
        dot = True
        newLine = False
    End Sub

    Private Sub ButtonSum_Click(sender As Object, e As EventArgs) Handles ButtonSum.Click
        SymbolButton("+")
    End Sub

    Private Sub ButtonMinus_Click(sender As Object, e As EventArgs) Handles ButtonMinus.Click
        If (newLine And lastSymbol <> "=") Then
            TextBox1.Text = "-"
            newLine = False
        Else
            SymbolButton("-")
        End If
    End Sub

    Private Sub ButtonMulti_Click(sender As Object, e As EventArgs) Handles ButtonMulti.Click
        SymbolButton("x")
    End Sub

    Private Sub ButtonDiv_Click(sender As Object, e As EventArgs) Handles ButtonDiv.Click
        SymbolButton("/")
    End Sub

    Private Sub ButtonResult_Click(sender As Object, e As EventArgs) Handles ButtonResult.Click
        SymbolButton("=")
    End Sub

    Private Sub ButtonC_Click(sender As Object, e As EventArgs) Handles ButtonC.Click
        TextBox1.Text = ""
        firstNum = vbNull
        secondNum = vbNull
        lastSymbol = ""
        dot = False
        newLine = True
    End Sub

    Public Sub NumericButton(symb As String)
        If (newLine Or CStr(TextBox1.Text) = "0") Then
            TextBox1.Text = symb
        Else
            TextBox1.Text = CStr(TextBox1.Text) + symb
        End If
        newLine = False
    End Sub

    Public Sub SymbolButton(symb As String)
        If (CStr(TextBox1.Text) <> "" And CStr(TextBox1.Text) <> "-") Then
            If (Not IsDBNull(firstNum) And Not newLine) Then
                secondNum = CDec(TextBox1.Text)
                If (lastSymbol = "+") Then
                    firstNum = firstNum + secondNum
                    TextBox1.Text = CStr(firstNum)
                ElseIf (lastSymbol = "-") Then
                    firstNum = firstNum - secondNum
                    TextBox1.Text = CStr(firstNum)
                ElseIf (lastSymbol = "x") Then
                    firstNum = firstNum * secondNum
                    TextBox1.Text = CStr(firstNum)
                ElseIf (lastSymbol = "/") Then
                    firstNum = firstNum / secondNum
                    TextBox1.Text = CStr(firstNum)
                End If
            End If
            firstNum = CDec(TextBox1.Text)
            newLine = True
            lastSymbol = symb
            dot = False
        End If
    End Sub

End Class