Imports Newtonsoft.Json

Public Class PDLJson

End Class
Public Class Skill
    Public Property name As String
End Class

Public Class Industry
    Public Property name As String
    Public Property is_primary As Boolean
End Class

Public Class Profile
    Public Property network As String
    Public Property ids As String()
    Public Property clean As String
    Public Property aliases As Object()
    Public Property username As String
    Public Property is_primary As Boolean
    Public Property url As String
End Class

Public Class Company
    Public Property name As String
    Public Property size As Object
    Public Property founded As Object
    Public Property industry As Object
    Public Property location As Object
    Public Property profiles As Object()
    Public Property website As Object
End Class

Public Class Title
    Public Property levels As Object()
    Public Property name As String
    Public Property functions As String()
End Class

Public Class Job
    Public Property company As Company
    Public Property locations As Object()
    Public Property end_date As Object
    Public Property start_date As String
    Public Property title As Title
    Public Property last_updated As String
End Class

Public Class Location
    Public Property name As String
    Public Property locality As String
    Public Property region As String
    Public Property country As String
    Public Property last_updated As String
    Public Property continent As String
End Class

Public Class Name
    Public Property first_name As String
    Public Property middle_name As Object
    Public Property last_name As String
    Public Property clean As String
End Class

Public Class Primary
    Public Property job As Job
    Public Property location As Primary_Location
    Public Property name As Primary_Name
    Public Property industry As String
    Public Property work_emails As String()
    Public Property personal_emails As String()
    Public Property other_emails As Object()
    Public Property linkedin As String
End Class

Public Class Primary_Name
    Public Property first_name As String
    Public Property last_name As String
    Public Property suffix As Object
    Public Property middle_name As Object
    Public Property middle_initial As Object
    Public Property name As String
    Public Property clean As String
    Public Property is_primary As Boolean
End Class

Public Class Primary_Location
    Public Property name As String
    Public Property locality As String
    Public Property region As String
    Public Property subregion As String
    Public Property country As String
    Public Property continent As String
    Public Property type As String
    Public Property geo As String
    Public Property postal_code As Object
    Public Property zip_plus_4 As Object
    Public Property street_address As Object
    Public Property address_line_2 As Object
    Public Property most_recent As Boolean
    Public Property is_primary As Boolean
    Public Property last_updated As String
End Class

Public Class Experience
    Public Property company As Company
    Public Property locations As Object()
    Public Property end_date As Object
    Public Property start_date As String
    Public Property title As Title
    Public Property type As String
    Public Property is_primary As Boolean
    Public Property most_recent As Boolean
    Public Property last_updated As String
End Class

Public Class School
    Public Property name As String
    Public Property type As String
    Public Property location As String
    Public Property profiles As String()
    Public Property website As String
End Class

Public Class Education
    Public Property school As School
    Public Property end_date As String
    Public Property start_date As String
    Public Property gpa As Object
    Public Property degrees As String()
    Public Property majors As String()
    Public Property minors As Object()
    Public Property locations As Object()
End Class

Public Class PDLData
    Public Property id As String
    Public Property skills As Skill()
    Public Property industries As Industry()
    Public Property interests As Object()
    Public Property profiles As Profile()
    Public Property emails As Email()
    Public Property phone_numbers As PhoneNumber()
    Public Property birth_date_fuzzy As Object
    Public Property birth_date As Object
    Public Property gender As Object
    Public Property primary As Primary
    Public Property names As Name()
    Public Property locations As Location()
    Public Property experience As Experience()
    Public Property education As Education()
End Class

Public Class Metadata
    <JsonProperty(PropertyName:="in")>
    Public Property c_in As Object()
End Class

Public Class PDL
    Public Property status As Integer
    Public Property likelihood As Integer
    Public Property data As PDLData
    Public Property dataset_version As String
    Public Property metadata As Metadata
End Class
Public Class Email

    Public Property address As String
    Public Property type As String
    Public Property sha256 As String
    Public Property domain As String
    Public Property local As String
End Class
Public Class PhoneNumber
    Public Property E164 As String
    Public Property extension As String
    Public Property type As String
    Public Property number As String
    Public Property national_number As String
    Public Property area_code As String
    Public Property is_primary As String
    Public Property country_code As String
End Class



