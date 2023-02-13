Imports System.IO

Friend NotInheritable Class CCsv

    ' RFC4180 Standard CSV output

    Friend Shared Sub SaveDatatableToCsv(dt As DataTable, sFile As String, sEndOfFileLine As String)

        ' Optionally include sEndOfFileLine, for example
        ' ## End Of FILE ## 
        ' to be included as an additional line, if specified

        Dim iCol As Integer

        Using sw = New StreamWriter(sFile)
            ' Output Header
            Dim sLine = String.Empty
            For Each dc As DataColumn In dt.Columns
                If Not String.IsNullOrEmpty(sLine) Then
                    sLine &= ","
                End If
                sLine &= """" & dc.ColumnName.Replace("""", """""") & """"
            Next
            sw.WriteLine(sLine)

            For Each dr As DataRow In dt.Rows
                sLine = String.Empty
                iCol = 0
                For Each dc As DataColumn In dt.Columns
                    If iCol > 0 Then
                        sLine &= ","
                    End If

                    If dr(dc.ColumnName) IsNot DBNull.Value Then
                        Select Case Type.GetTypeCode(dc.DataType)
                            Case TypeCode.Boolean
                                If DbToBool(dr(dc.ColumnName)) Then
                                    sLine &= "1"
                                Else
                                    sLine &= "0"
                                End If

                            Case TypeCode.Byte, TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.SByte, TypeCode.Single, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
                                ' Numbers
                                sLine &= dr(dc.ColumnName).ToString

                            Case TypeCode.Char, TypeCode.String
                                ' Strings
                                sLine &= """" & dr(dc.ColumnName).ToString.Replace("""", """""") & """"

                            Case TypeCode.DateTime
                                ' Dates
                                sLine &= Format(dr(dc.ColumnName), "yyyy-MM-dd HH:mm:ss")

                            Case Else
                                Throw New Exception($"Don't know how to convert type {dc.DataType} for use in a CSV file")

                        End Select
                    End If
                    iCol += 1
                Next

                sw.WriteLine(sLine)
            Next

            If Not String.IsNullOrEmpty(sEndOfFileLine) Then
                sw.WriteLine(sEndOfFileLine)
            End If

        End Using

    End Sub
    Private Shared Function DbToBool(o As Object) As Boolean

        ' This works for both access and sql

        If o Is Nothing OrElse IsDBNull(o) Then
            Return False
        ElseIf IsNumeric(o) Then
            Return Not (CInt(o) = 0)
        ElseIf CStr(o).ToUpper = "TRUE" OrElse CStr(o).ToUpper = "ON" OrElse CStr(o).ToUpper = "YES" Then
            Return True
        Else
            Return False
        End If

    End Function

    Friend Shared Sub SaveDatatableToCsv(dt As DataTable, sFile As String)

        SaveDatatableToCsv(dt, sFile, String.Empty)

    End Sub

    Friend Shared Function ReadCsvToDt(sFilename As String) As DataTable

        Dim parser As New FileIO.TextFieldParser(sFilename)
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(New String() {","})
        Dim columns = parser.ReadFields

        Dim dt As New DataTable
        For Each col In columns
            dt.Columns.Add(col)
        Next
        While Not parser.EndOfData
            Dim fields = parser.ReadFields
            Dim dr = dt.NewRow
            For i = 0 To fields.Length - 1
                dr(i) = fields(i)
            Next

            dt.Rows.Add(dr)
        End While
        Return dt
    End Function

End Class