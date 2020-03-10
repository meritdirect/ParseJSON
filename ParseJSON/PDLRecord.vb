Public Class PDLRecord
    Private _pdl As PDL
    Private bStatus As Boolean

    Public Sub New(pdl As PDL)
        _pdl = pdl
        Select Case _pdl.status
            Case "200"
                bStatus = True
            Case "404"

                bStatus = False
            Case Else

                bStatus = False
        End Select

    End Sub

    Public ReadOnly Property LinkedInURL As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").Count > 0 Then
                LinkedInURL = _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").First.url

            Else
                LinkedInURL = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property LinkedInUsername As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").Count > 0 Then
                LinkedInUsername = _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").First.username
            Else
                LinkedInUsername = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property LinkedInId As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").Count > 0 AndAlso _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").First.ids.Count > 0 Then
                LinkedInId = _pdl.data.profiles.Where(Function(x As Profile) x.network = "linkedin").First.ids.First
            Else
                LinkedInId = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property Status As String
        Get

            Status = _pdl.status
        End Get
    End Property

    Public ReadOnly Property Likelyhood As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            Likelyhood = _pdl.likelihood
        End Get
    End Property
    Public ReadOnly Property FullName As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.name IsNot Nothing Then
                FullName = _pdl.data.primary.name.clean
            Else
                FullName = String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property FirstName As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.name IsNot Nothing Then
                FirstName = _pdl.data.primary.name.first_name
            Else
                FirstName = String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property LastName As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.name IsNot Nothing Then
                LastName = _pdl.data.primary.name.last_name
            Else
                LastName = String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property PrimaryLocation As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If Not _pdl.data.primary.location Is Nothing Then
                PrimaryLocation = _pdl.data.primary.location.name
            Else
                PrimaryLocation = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property PrimaryLocationCity As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If Not _pdl.data.primary.location Is Nothing Then
                PrimaryLocationCity = _pdl.data.primary.location.locality
            Else
                PrimaryLocationCity = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property PrimaryLocationState As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If Not _pdl.data.primary.location Is Nothing Then
                PrimaryLocationState = _pdl.data.primary.location.region
            Else
                PrimaryLocationState = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property PrimaryLocationCountry As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If Not _pdl.data.primary.location Is Nothing Then
                PrimaryLocationCountry = _pdl.data.primary.location.country
            Else
                PrimaryLocationCountry = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property Email1 As String
        Get
            If bStatus = False Then
                Return _pdl.metadata.c_in(2)
                'Return l_email
            End If
            If _pdl.data.emails.Count > 0 Then
                Return _pdl.data.emails(0).address
            Else
                Return String.Empty
            End If
        End Get

    End Property
    Public ReadOnly Property Email2 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.emails.Count > 1 Then
                Email2 = _pdl.data.emails(1).address
            Else
                Email2 = String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property Email3 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.emails.Count > 2 Then
                Email3 = _pdl.data.emails(2).address
            Else
                Email3 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property WorkEmail1 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.work_emails.Count > 0 Then
                WorkEmail1 = _pdl.data.primary.work_emails(0)
            Else
                WorkEmail1 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property WorkEmail2 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.work_emails.Count > 1 Then
                WorkEmail2 = _pdl.data.primary.work_emails(1)
            Else
                WorkEmail2 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property JobCompanyName As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.company IsNot Nothing Then
                JobCompanyName = _pdl.data.primary.job.company.name
            Else
                JobCompanyName = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobCompanyWebsite As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.company IsNot Nothing Then
                JobCompanyWebsite = _pdl.data.primary.job.company.website
            Else
                JobCompanyWebsite = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobCompanyDateFounded As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.company IsNot Nothing Then
                JobCompanyDateFounded = _pdl.data.primary.job.company.founded
            Else
                JobCompanyDateFounded = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobCompanyIndustry As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.company IsNot Nothing Then
                JobCompanyIndustry = _pdl.data.primary.job.company.industry
            Else
                JobCompanyIndustry = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobCompanySize As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.company IsNot Nothing Then
                JobCompanySize = _pdl.data.primary.job.company.size
            Else
                JobCompanySize = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobTitle As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.title IsNot Nothing Then
                JobTitle = _pdl.data.primary.job.title.name
            Else
                JobTitle = String.Empty
            End If

        End Get
    End Property
    Public ReadOnly Property JobLevels As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing AndAlso _pdl.data.primary.job.title IsNot Nothing AndAlso _pdl.data.primary.job.title.levels.Count > 0 Then
                JobLevels = _pdl.data.primary.job.title.levels.Aggregate(Function(current, [next]) current & ";" & [next])
            Else
                JobLevels = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property JobUpdated As String

        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.primary.job IsNot Nothing Then
                JobUpdated = _pdl.data.primary.job.last_updated
            Else
                JobUpdated = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property FacebookURL As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").Count > 0 Then
                FacebookURL = _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").First.url

            Else
                FacebookURL = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property FacebookUsername As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").Count > 0 Then
                FacebookUsername = _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").First.username
            Else
                FacebookUsername = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property FacebookId As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").Count > 0 AndAlso _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").First.ids.Count > 0 Then
                FacebookId = _pdl.data.profiles.Where(Function(x As Profile) x.network = "facebook").First.ids.First
            Else
                FacebookId = String.Empty
            End If
        End Get

    End Property
    Public ReadOnly Property twitterURL As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "twitter").Count > 0 Then
                twitterURL = _pdl.data.profiles.Where(Function(x As Profile) x.network = "twitter").First.url

            Else
                twitterURL = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property TwitterUsername As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "twitter").Count > 0 Then
                TwitterUsername = _pdl.data.profiles.Where(Function(x As Profile) x.network = "twitter").First.username
            Else
                TwitterUsername = String.Empty
            End If
        End Get

    End Property
    Public ReadOnly Property GithubURL As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "github").Count > 0 Then
                GithubURL = _pdl.data.profiles.Where(Function(x As Profile) x.network = "github").First.url

            Else
                GithubURL = String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property GithubURLUsername As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Where(Function(x As Profile) x.network = "github").Count > 0 Then
                GithubURLUsername = _pdl.data.profiles.Where(Function(x As Profile) x.network = "github").First.username
            Else
                GithubURLUsername = String.Empty
            End If
        End Get

    End Property
    Public ReadOnly Property Industry As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            Industry = _pdl.data.primary.industry
        End Get
    End Property
    Public ReadOnly Property Mobile_Phone As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type = "mobile").Count > 0 Then
                Mobile_Phone = _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type = "mobile").First.number
            Else
                Mobile_Phone = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property Phone1 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").Count > 0 Then
                Phone1 = _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").First.number
            Else
                Phone1 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property Phone2 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").Count > 1 Then
                Phone2 = _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").ElementAt(1).number
            Else
                Phone2 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property Phone3 As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").Count > 2 Then
                Phone3 = _pdl.data.phone_numbers.Where(Function(x As PhoneNumber) x.type <> "mobile").ElementAt(2).number
            Else
                Phone3 = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property SocialNetworkUrls As String
        Get
            If bStatus = False Then
                Return String.Empty
            End If
            If _pdl.data.profiles.Count > 0 Then
                SocialNetworkUrls = _pdl.data.profiles.Aggregate(Of String)("", Function(current, [next]) current & ";" & [next].url).TrimStart(";")
            Else
                SocialNetworkUrls = String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property output As String
        Get
            output = Status & vbTab & Likelyhood & vbTab & FullName & vbTab & FirstName & vbTab & LastName & vbTab & LinkedInURL & vbTab & LinkedInUsername & vbTab & LinkedInId & vbTab &
                PrimaryLocation & vbTab & PrimaryLocationCity & vbTab & PrimaryLocationState & vbTab & vbTab & PrimaryLocationCountry & vbTab & vbTab & Email1 & vbTab & Email2 & vbTab & Email3 & vbTab &
                WorkEmail1 & vbTab & WorkEmail2 & vbTab & JobCompanyName & vbTab & JobCompanyWebsite & vbTab & JobCompanyDateFounded & vbTab & JobCompanyIndustry & vbTab & JobCompanySize & vbTab &
                JobTitle & vbTab & JobLevels & vbTab & JobUpdated & vbTab & FacebookURL & vbTab & FacebookUsername & vbTab & FacebookId & vbTab &
                twitterURL & vbTab & TwitterUsername & vbTab & GithubURL & vbTab & GithubURLUsername & vbTab & Industry & vbTab & Mobile_Phone & vbTab & Phone1 & vbTab & Phone2 & vbTab & Phone3 & vbTab & SocialNetworkUrls

        End Get
    End Property
End Class
