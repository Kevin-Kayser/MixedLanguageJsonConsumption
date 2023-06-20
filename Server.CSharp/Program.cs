using Server.CSharp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// create data array for ComplexPersonTest

var complexClassList = new List<ComplexPersonTest> { };

for (var i = 0; i < 10; i++)
{
    complexClassList.Add(
        new ComplexPersonTest
        {
            Name = "Person" + i,
            Age = 25 + i,
            IsMarried = i % 2 == 0,
            BirthDate = DateTime.Today.AddYears(-26 + i),
            Height = 1.70 + i / 100.0,
            Salary = 60000 + (i * 100),
            Hobbies = new List<string> { "Programming", "Reading", "Hiking" },
            ContactInfo = new Dictionary<string, string>
            {
                { "Email", "person" + i + "@gmail.com" },
                { "Phone", "555-555-55" + i },
            },
            PersonalInfo = new Tuple<string, int, bool>("Information" + i, i, i % 2 == 0),
        });
}

app.MapGet("/GetComplexData", () =>
    {
        return complexClassList.ToArray();
    })
.WithName("GetComplexData")
.WithOpenApi();

app.Run();

