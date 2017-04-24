Imports Microsoft.VisualBasic

Public Class ConnectToBass

    Public Shared Function GetCustDetaisl()
        Dim SPD_Url As String = "http://prodbass.europolitan.se:9011"

        'Create a web request
        Dim WebRequestObj As HttpWebRequest = WebRequest.Create(SPD_Url & "/BASSCUST/MSISDN/" & Number)

        'Execute the request
        Dim WebResponseObj As HttpWebResponse = WebRequestObj.GetResponse

        'Read the responce into a Stream reader
        Dim reader As New System.IO.StreamReader(WebResponseObj.GetResponseStream(), System.Text.Encoding.GetEncoding("ISO-8859-1"))

        'Create an XML document
        Dim doc As New Xml.XmlDocument
        doc.Load(reader)

        'Close the Web request
        WebResponseObj.Close()
        WebResponseObj = Nothing
    End Function


End Class
