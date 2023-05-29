Public Class Form1
    Private randomizer As New Random

    Private addend1 As Integer
    Private addend2 As Integer

    ' These integer variables store the numbers 
    ' for the subtraction problem. 
    Private minuend As Integer
    Private subtrahend As Integer

    ' These integer variables store the numbers 
    ' for the multiplication problem. 
    Private multiplicand As Integer
    Private multiplier As Integer

    ' These integer variables store the numbers 
    ' for the division problem. 
    Private dividend As Integer
    Private divisor As Integer

    Private timeLeft As Integer
    Public Sub StartTheQuiz()

        timeLabel.BackColor = Color.Transparent

        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        plusleftLabel.Text = addend1.ToString
        plusRightLabel.Text = addend2.ToString

        sum.Value = 0

        ' Fill in the subtraction problem.
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0

        ' Fill in the multiplication problem.
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        product.Value = 0

        ' Fill in the division problem.
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString()
        dividedRightLabel.Text = divisor.ToString()
        quotient.Value = 0

        ' Start the timer.
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()




    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        StartTheQuiz()
        startButton.Enabled = False
    End Sub

    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = sum.Value AndAlso
           minuend - subtrahend = difference.Value AndAlso
           multiplicand * multiplier = product.Value AndAlso
           dividend / divisor = quotient.Value Then

            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If CheckTheAnswer() Then
            ' If CheckTheAnswer() returns true, then the user 
            ' got the answer right. Stop the timer  
            ' and show a MessageBox.
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Congratulations!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            ' If CheckTheAnswer() returns false, keep counting
            ' down. Decrease the time left by one second and 
            ' display the new time left by updating the 
            ' Time Left label.
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"
            If timeLeft <= 5 Then
                timeLabel.BackColor = Color.Red
            End If

        Else
            ' If the user ran out of time, stop the timer, show
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            product.Value = multiplicand * multiplier
            quotient.Value = dividend / divisor
            startButton.Enabled = True
        End If
    End Sub



    Private Sub answerEnter(sender As Object, e As EventArgs) Handles difference.Enter, product.Enter, quotient.Enter, sum.Enter, sum.Click, quotient.Click, product.Click, difference.Click
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub

    Private Sub valueCorrect(sender As Object, e As EventArgs) Handles sum.ValueChanged, difference.ValueChanged, product.ValueChanged, quotient.ValueChanged
        If sum.Value = addend1 + addend2 Then
            My.Computer.Audio.Play("C:\Users\ronny.joza\Music\correcto.wav")
        ElseIf difference.Value = minuend - subtrahend Then
            My.Computer.Audio.Play("C:\Users\ronny.joza\Music\correcto.wav")
        ElseIf product.Value = multiplicand * multiplier Then
            My.Computer.Audio.Play("C:\Users\ronny.joza\Music\correcto.wav")
        ElseIf quotient.Value = dividend / divisor Then
            My.Computer.Audio.Play("C:\Users\ronny.joza\Music\correcto.wav")
        End If


    End Sub
End Class
