Imports System.IO
Imports System.Net

Public Class callAPI
    Public email As String
    Public response As WebResponse
    Public API As String
    Public Function getJSON() As String
        'Dim request As WebRequest = WebRequest.Create("https://api.peopledatalabs.com/v4/person?pretty=true&api_key=4095df2e-9760-47d9-8e23-869216431981&email=" & email)
        'Dim request As WebRequest = WebRequest.Create("https://api.peopledatalabs.com/v4/person?api_key=4095df2e-9760-47d9-8e23-869216431981&email=" & email)
        Dim request As WebRequest = WebRequest.Create(API & email)
        ' If required by the server, set the credentials.
        'request.Credentials = CredentialCache.DefaultCredentials
        ' Get the response.
        Try
            response = request.GetResponse()
        Catch ex As Exception
            Dim responseFromServerError As String = "{""status"": 404, ""error"": {""type"": ""not_found"", ""message"": ""No records were found matching your request""}, ""metadata"": {""in"": [1, """", ""email""]}}"
            responseFromServerError = responseFromServerError.Replace("email", email)
            Return responseFromServerError
        End Try
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Console.WriteLine(responseFromServer)
        ' Clean up the streams and the response.
        reader.Close()
        response.Close()
        Return responseFromServer
    End Function

End Class
