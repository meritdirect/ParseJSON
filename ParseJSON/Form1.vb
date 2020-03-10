Option Infer On

Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Xamasoft.JsonClassGenerator
Imports System.Collections.Generic
Imports System.Data.Entity.Design.PluralizationServices
Imports System.Globalization
Imports Xamasoft.JsonClassGenerator.CodeWriters
Imports System.Net
Imports System.Net.Mail
Imports RegexUtilities
Imports OfficeOpenXml

Public Class Form1

    Public startTime As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim JSONreply As String = String.Empty
        Dim emailInput As String = String.Empty
        Dim emailAddress As MailAddress
        Dim outputFile As String = String.Empty
        Dim linesRead As Integer = 0
        Dim FileType As Integer = 1
        Dim lineCount As Integer = 0
        OpenFileDialog1.Title = "Open an email File"
        OpenFileDialog1.Filter = "CSV/TXT Files|*.csv; *.txt|Excel Files|*.xls; *.xlsx|All Files|*.*"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() <> DialogResult.OK OrElse OpenFileDialog1.FileName.Length = 0 Then Exit Sub
        outputFile = Path.GetDirectoryName(OpenFileDialog1.FileName) & "\" & Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & "_Output.txt"
        Dim ext As String = Path.GetExtension(OpenFileDialog1.FileName)
        If (ext = ".xls" Or ext = ".xlsx") Then
            FileType = 2
        Else
            '            lineCount = File.ReadLines(OpenFileDialog1.FileName).Count()
        End If

        Dim cAPI As New callAPI
        cAPI.API = My.Settings.APIPath & "&email="
        Using sw As New StreamWriter(outputFile)
            Dim header As String = "status" & vbTab & "likelihood" & vbTab & "full_name" & vbTab & "fname" & vbTab & "lname" & vbTab & "linkedin_url" & vbTab & "linkedin_username" & vbTab & "linkedin_id" & vbTab & "primary_location" & vbTab & "primary_location_city" & vbTab & "primary_location_state" & vbTab & "primary_location_state_code" & vbTab & "primary_location_country" & vbTab & "primary_location_country_code" & vbTab & "email_1" & vbTab & "email_2" & vbTab & "email_3" & vbTab & "work_email_1" & vbTab & "work_email_2" & vbTab & "job_company_name" & vbTab & "job_company_website" & vbTab & "job_company_date_founded" & vbTab & "job_company_industry" & vbTab & "job_company_size" & vbTab & "job_title" & vbTab & "job_title_levels" & vbTab & "job_updated" & vbTab & "facebook_url" & vbTab & "facebook_username" & vbTab & "facebook_id" & vbTab & "twitter_url" & vbTab & "twitter_username" & vbTab & "github_url" & vbTab & "github_username" & vbTab & "industry" & vbTab & "mobile_phone" & vbTab & "phone_1" & vbTab & "phone_2" & vbTab & "phone_3" & vbTab & "social_network_urls" & vbTab
            sw.WriteLine(header)
            Using srInput As New StreamReader(ReadInput(OpenFileDialog1.FileName, FileType, lineCount))
                While srInput.Peek > 0
                    emailInput = srInput.ReadLine
                    emailInput = emailInput.Replace(vbTab, " ")
                    If linesRead = 0 AndAlso (String.Compare(emailInput, "Email", True) = 0 Or String.Compare(emailInput, "E-mail", True) = 0) Then Continue While 'skip header
                    linesRead += 1
                    If linesRead Mod 10 = 0 Then
                        TextBox1.Text = linesRead.ToString & " of " & lineCount.ToString
                    End If
                    Try
                        If (IsValidEmail(emailInput)) Then
                            'emailAddress = New MailAddress(emailInput)
                            cAPI.email = emailInput
                            LogError(emailInput)
                            JSONreply = cAPI.getJSON()
                            If cAPI.response IsNot Nothing Then
                                LogError(CType(cAPI.response, HttpWebResponse).StatusDescription)
                            End If
                            LogError(JSONreply)
                            Dim PDL1 As PDL = JsonConvert.DeserializeObject(Of PDL)(JSONreply)
                            Dim rPDL As PDLRecord = New PDLRecord(PDL1)
                            sw.WriteLine(rPDL.output)
                        Else
                            Dim badJSON As String = "{""status"": 404, ""error"": {""type"": ""not_found"", ""message"": ""Invalid Email""}, ""metadata"": {""in"": [1, """", ""email""]}}"
                            badJSON = badJSON.Replace("email", emailInput)
                            LogError(badJSON)
                            Dim PDL1 As PDL = JsonConvert.DeserializeObject(Of PDL)(badJSON)
                            Dim rPDL As PDLRecord = New PDLRecord(PDL1)
                            sw.WriteLine(rPDL.output)
                        End If
                    Catch ex As Exception
                        LogError(ex.ToString)
                    End Try

                End While
            End Using 'streamreader
        End Using 'streamwriter
        TextBox1.Text = linesRead.ToString & " of " & lineCount.ToString

        MessageBox.Show("done")


    End Sub


    Private Function CreateUniqueClassName(name As String) As String

        name = ToTitleCase(name)

        Return name
    End Function
    Private Function ToTitleCase(str As String) As String

        Dim sb = New StringBuilder(str.Length)
        Dim flag = True

        For i As Integer = 0 To str.Length

            Dim c = str(i)
            If Char.IsLetterOrDigit(c) Then

                sb.Append(IIf(flag = True, Char.ToUpper(c), c))
                flag = False
            Else
                flag = True
            End If
        Next

        Return sb.ToString()
    End Function

    Private Function CreateUniqueClassNameFromPlural(plural As String) As String
        Dim pluralizationService = System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(New CultureInfo("en-us"))
        plural = ToTitleCase(plural)
        Return CreateUniqueClassName(pluralizationService.Singularize(plural))
    End Function

    Private Sub genJSON(fileName As String)
        Dim gen = New JsonClassGenerator()
        Dim JSON As String = String.Empty
        Using sr As New StreamReader(fileName)
            JSON = sr.ReadToEnd()
        End Using
        gen.Example = JSON
        gen.InternalVisibility = False
        Dim writer As ICodeWriter = New VisualBasicCodeWriter()
        gen.CodeWriter = writer
        gen.ExplicitDeserialization = False
        'If (nest) Then
        ' gen.Namespace = nameSpace;
        '  Else
        gen.Namespace = Nothing

        gen.NoHelperClass = False
        gen.SecondaryNamespace = Nothing
        gen.UseProperties = True
        gen.MainClass = "Test"
        gen.UsePascalCase = False
        gen.PropertyAttribute = "None"

        gen.UseNestedClasses = False
        gen.ApplyObfuscationAttributes = False
        gen.SingleFile = True
        gen.ExamplesInDocumentation = False

        gen.TargetFolder = Nothing
        gen.SingleFile = True

        Using sw As StringWriter = New StringWriter()

            gen.OutputStream = sw
            gen.GenerateClasses()
            sw.Flush()

        End Using

    End Sub


    Private Sub LogError(sText As String)
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + sText)
        File.AppendAllText(My.Settings.LogPath & "ParseJSON" & startTime & ".txt", sb.ToString() + vbCrLf)
        sb.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        startTime = DateTime.Now.ToString("yyyyMMdd")
    End Sub
    Private Function ReadInput(fileName As String, nType As Integer, ByRef lineCount As Integer) As Stream
        Dim Stream
        If nType = 1 Then
            lineCount = File.ReadLines(fileName).Count()
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(File.ReadAllText(fileName))
            Stream = New MemoryStream(byteArray)
        Else
            Dim strExcel As StringBuilder = New StringBuilder
            Using pck As ExcelPackage = New ExcelPackage(New FileInfo(fileName))
                Dim worksheet As ExcelWorksheet = pck.Workbook.Worksheets(1)
                Dim colCount As Integer = worksheet.Dimension.End.Column
                Dim rowCount As Integer = worksheet.Dimension.End.Row
                lineCount = rowCount
                For row As Integer = 1 To rowCount
                    strExcel.AppendLine(worksheet.Cells(row, 1).Value?.ToString().Trim())
                Next

            End Using
            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(strExcel.ToString)
            Stream = New MemoryStream(byteArray)
        End If
        Return Stream
    End Function
End Class
