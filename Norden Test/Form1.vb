Public Class Form1
    Dim fiveminuteint As Integer = 300
    Dim shiplist As String = "Gainer,Guardian,Penguin"








    Private Sub FiveMinuteTMR_Tick(sender As Object, e As EventArgs) Handles FiveMinuteTMR.Tick

        fiveminuteint -= 1 ' Subtract 1 second from 5 minutes, every time FiveMinuteTMR ticks.

        Label5.Text = ConvertSecondsToMinutes(fiveminuteint)


        If (fiveminuteint <= 0) Then ' If it has been five minutes since syncrhonization reset timer.

            fiveminuteint = 300

        End If



    End Sub



    Private Function ConvertSecondsToMinutes(ByVal in_seconds As Integer) As String
        Dim temp_minute As Long = 0
        Dim temp_seconds As Long = 0
        ' Divide seconds by 60.

        temp_minute = (in_seconds \ 60)

        temp_seconds = (in_seconds Mod 60)

        If (temp_seconds < 10) Then

            ConvertSecondsToMinutes = (temp_minute.ToString + ":0" + temp_seconds.ToString).ToString


        Else
            ConvertSecondsToMinutes = (temp_minute.ToString + ":" + temp_seconds.ToString).ToString

        End If



        Return ConvertSecondsToMinutes


    End Function





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        TextBox4.Text = ConvertSecondsToMinutes(TextBox3.Text)







    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tmp_shiplist() As String



        tmp_shiplist = Split(shiplist, ",")

        ComboBox1.Text = tmp_shiplist(0) ' Combolist, should contain first entry in shiplist() array.


        For index As Integer = 0 To shiplist.Length

            ComboBox1.Items.Add(tmp_shiplist(index))

        Next



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim input_fromaddbutton As String = ""


        input_fromaddbutton = InputBox("Name of the ship?:", "Vessel Add Button Dialog", "Shipname")



        If (input_fromaddbutton = Nothing) Then
            Exit Sub
        End If

        If (input_fromaddbutton = "Shipname") Then



            'Do nothing, because that is an invalid input.

        Else

            shiplist = shiplist + "," + input_fromaddbutton
            ComboBox1.Items.Add(input_fromaddbutton)
        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim shipselected As String = ""
        Dim input_confirmbox As String = ""

        shipselected = ComboBox1.Text

        input_confirmbox = InputBox("Please confirm that you wish to delete [" + shipselected + "] from the list of ships, by typing ""delete""", "Vessel Delete Button Dialog")


        If (input_confirmbox = "delete") Then


            ' Go for loop to find ship.
            Dim tmp_shiplist() As String
            tmp_shiplist = Split(shiplist, ",")

            For index = 0 To tmp_shiplist.Length

                If (tmp_shiplist(index) = shipselected) Then

                    tmp_shiplist(index) = ""
                    Exit For
                End If

            Next

            ' Now make another for loop to reconstruct ship list.

            For index = 0 To tmp_shiplist.Length - 1

                If (index = 0) Then
                    shiplist = "" ' Reset shiplist if first runthrough for loop.
                End If

                If (tmp_shiplist(index) = "") Then

                    ' Do nothing


                Else

                    ' Else if the element at this index is not empty then add it to shiplist.



                    ' We need this to maintain order in shiplist, so we don't get a comma seperator last time for loop is run through.
                    If (index = tmp_shiplist.Length - 1) Then
                        shiplist = shiplist + tmp_shiplist(index)
                    Else
                        shiplist = shiplist + tmp_shiplist(index) + ","
                    End If



                    End If


            Next


            ' Need to reset ComboBox1 as well.

            ComboBox1.Items.Clear()

            '<Test>
            MsgBox(shiplist)
            '<Test>

            Dim tmp_newlist() As String

            tmp_newlist = Split(shiplist, ",")

            ComboBox1.Items.AddRange(tmp_newlist)
            ComboBox1.Text = tmp_newlist(0)



        Else

            ' Do nothing.


        End If




    End Sub

   

End Class
