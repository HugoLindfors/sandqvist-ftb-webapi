using Sandqvist.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Allow your Nuxt app's origin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var swedishRoyalFamilyList = new List<FamilyMember>
{
    new(0, "Bernadotte", "Carl XVI Gustaf", Gender.Male, new(1946, 4, 30), new(2025, 2, 24), null, null, null, null),
    new(1,"Sommerlath", "Silvia", Gender.Female, new(1943, 12, 23), null, null, null, null, null),
    new(2,"Bernadotte", "Victoria", Gender.Female, new(1977, 7, 14), null, null, null, null, null),
    new(3,"Westling", "Daniel", Gender.Male, new(1973, 9, 15), null, null, null, null, null),
    new(4,"Bernadotte", "Carl Philip", Gender.Male, new(1979, 5, 13), null, null, null, null, null),
    new(5,"Hellqvist", "Sofia", Gender.Female, new(1984, 12, 6), null, null, null, null, null),
    new(6,"Bernadotte", "Madeleine", Gender.Female, new(1982, 6, 10), null, null, null, null, null),
    new(7,"O'Neill", "Christopher", Gender.Male, new(1974, 6, 27), null, null, null, null, null),
    new(8,"Bernadotte", "Estelle", Gender.Female, new(2012, 2, 23), null, null, null, null, null),
    new(9,"Bernadotte", "Oscar", Gender.Male, new(2016, 3, 2), null, null, null, null, null),
    new(10,"Bernadotte", "Alexander", Gender.Male, new(2016, 4, 19), null, null, null, null, null),
    new(11,"Bernadotte", "Gabriel", Gender.Male, new(2017, 8, 31), null, null, null, null, null),
    new(12,"Bernadotte", "Julian", Gender.Male, new(2021, 3, 26), null, null, null, null, null),
    new(13,"Bernadotte", "Leonore", Gender.Female, new(2014, 2, 20), null, null, null, null, null),
    new(14,"Bernadotte", "Nicolas", Gender.Male, new(2015, 6, 15), null, null, null, null, null),
    new(15,"Bernadotte", "Adrienne", Gender.Female, new(2018, 3, 9), null, null, null, null, null),

    // Add more family members here...
};

// Adding relationships. Note, this is a simplified example. In a real application, you would manage relationships through a more robust system.
// Carl XVI Gustaf and Silvia are parents of Victoria, Carl Philip, and Madeleine
swedishRoyalFamilyList.First(m => m.FirstName == "Victoria").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl XVI Gustaf"), swedishRoyalFamilyList.First(m => m.FirstName == "Silvia") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl XVI Gustaf"), swedishRoyalFamilyList.First(m => m.FirstName == "Silvia") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl XVI Gustaf"), swedishRoyalFamilyList.First(m => m.FirstName == "Silvia") }.AsReadOnly();

// Victoria and Daniel are parents of Estelle and Oscar.
swedishRoyalFamilyList.First(m => m.FirstName == "Estelle").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Victoria"), swedishRoyalFamilyList.First(m => m.FirstName == "Daniel") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Oscar").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Victoria"), swedishRoyalFamilyList.First(m => m.FirstName == "Daniel") }.AsReadOnly();

// Carl Philip and Sofia are parents of Alexander, Gabriel, and Julian.
swedishRoyalFamilyList.First(m => m.FirstName == "Alexander").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip"), swedishRoyalFamilyList.First(m => m.FirstName == "Sofia") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Gabriel").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip"), swedishRoyalFamilyList.First(m => m.FirstName == "Sofia") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Julian").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip"), swedishRoyalFamilyList.First(m => m.FirstName == "Sofia") }.AsReadOnly();

// Madeleine and Christopher are parents of Leonore, Nicolas, and Adrienne.
swedishRoyalFamilyList.First(m => m.FirstName == "Leonore").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine"), swedishRoyalFamilyList.First(m => m.FirstName == "Christopher") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Nicolas").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine"), swedishRoyalFamilyList.First(m => m.FirstName == "Christopher") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Adrienne").Parents = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine"), swedishRoyalFamilyList.First(m => m.FirstName == "Christopher") }.AsReadOnly();

// Spouse relationships
swedishRoyalFamilyList.First(m => m.FirstName == "Carl XVI Gustaf").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Silvia") }.AsReadOnly();
swedishRoyalFamilyList.First(m => m.FirstName == "Silvia").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl XVI Gustaf") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Victoria").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Daniel") }.AsReadOnly();
swedishRoyalFamilyList.First(m => m.FirstName == "Daniel").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Victoria") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Sofia") }.AsReadOnly();
swedishRoyalFamilyList.First(m => m.FirstName == "Sofia").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Carl Philip") }.AsReadOnly();

swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Christopher") }.AsReadOnly();
swedishRoyalFamilyList.First(m => m.FirstName == "Christopher").Spouses = new List<FamilyMember> { swedishRoyalFamilyList.First(m => m.FirstName == "Madeleine") }.AsReadOnly();

app.MapGet("/swedish-royal-family-api", () =>
{
    var options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        WriteIndented = true // Optional: For better readability
    };

    return JsonSerializer.Serialize(swedishRoyalFamilyList, options);
})
.WithName("GetSwedishRoyalFamily");

app.Run();