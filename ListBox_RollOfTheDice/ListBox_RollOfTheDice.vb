'Jessica McArthur
'RCET0265
'Spring 2020
'Roll of the Dice- List box
'https://github.com/jmcarth4/

Public Class ListBox_RollOfTheDice

    'variables to set data array
    Dim arrayLength As Integer = 12
    Dim temp As String

    'variables for easy display of the data
    Dim seperator As String
    Dim columnLength As Integer = 1
    Dim lineLength As Integer = 12


    'creates random numbers in an array. 
    'numbers are those of two rolled dice
    Sub RollDice()
        Dim randomNumbers(arrayLength) As Integer
        Dim currentNumber As Integer

        'count random numbers of range of two dice. (2 to 12)
        For i = 1 To 1000
            currentNumber = RandomNumberInRange()
            randomNumbers(currentNumber) += 1
        Next

        For j = 2 To UBound(randomNumbers)
            temp += CStr(randomNumbers(j)).PadLeft(5)
        Next

        ListBox.Items.Add(temp)
        Console.WriteLine(temp)
        temp = ""
    End Sub

    'Displays the generated data
    Sub Display()
        ' write title
        ListBox.Items.Add((CStr("Roll of the Dice").PadLeft(45)))
        ListBox.Items.Add((StrDup(85, "-")))

        ' space between numbers
        For j = 2 To lineLength

            seperator += Str(j).PadLeft(6)
            Console.WriteLine(seperator)
        Next

        ListBox.Items.Add(seperator)
        Console.WriteLine(seperator)
        seperator = " "

        'divides upper and lower row
        ListBox.Items.Add((StrDup((85), "-")))
    End Sub

    ' Function GetRandomInteger() As Integer
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function

    'Buttons to prompt roll, clear box and exit program
    Private Sub RollDiceButton_Click(sender As Object, e As EventArgs) Handles RollDiceButton.Click
        Display()
        RollDice()
     End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ListBox.Items.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

End Class
