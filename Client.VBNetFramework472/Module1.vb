Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Module Module1

    Public Sub Main(args As String())
        Dim complexClassList = GetDataAsObjectAsync().GetAwaiter().GetResult()

        For Each complexClass As ComplexPersonTest In complexClassList
            Console.WriteLine("Name: " & complexClass.Name & ", Age: " & complexClass.Age & ", Is Married: " & complexClass.IsMarried & ", Birth Date: " & complexClass.BirthDate & ", Height: " & complexClass.Height & ", Salary: " & complexClass.Salary & ", Contact Info Email: " & complexClass.ContactInfo("Email") & ", Contact Info Phone: " & complexClass.ContactInfo("Phone") & ", Personal Info: " & complexClass.PersonalInfo.Item1 & " " & complexClass.PersonalInfo.Item2 & " " & complexClass.PersonalInfo.Item3)
        Next

        Console.ReadLine()
    End Sub


        Public Async Function GetDataAsObjectAsync() As Task(Of List(Of ComplexPersonTest))
            Using client As HttpClient = New HttpClient()
                client.BaseAddress = New Uri("https://localhost:7182")

                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

                Dim response As HttpResponseMessage = Await client.GetAsync("GetComplexData")

                If response.IsSuccessStatusCode Then
                    Dim complexClassList As List(Of ComplexPersonTest) = JsonConvert.DeserializeObject(Of List(Of ComplexPersonTest))(Await response.Content.ReadAsStringAsync())

                    Return complexClassList
                End If
            End Using

            Return Nothing
        End Function


    Public Async Function GetDataAsJArrayAsync() As Task(Of JArray)

        Using client As HttpClient = New HttpClient()
            client.BaseAddress = New Uri("https://localhost:7182")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            Dim response As HttpResponseMessage = Await client.GetAsync("GetComplexData")
            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim json As JArray = JArray.Parse(jsonString)
                Return json
            End If
        End Using
        Return Nothing
    End Function



End Module
