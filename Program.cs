using Sandqvist.Models;

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

var swedishRoyalFamilyList = new List<Familymember2>
{
    new(0,"Bernadotte", "Carl XVI Gustaf", Gender.Male, new(1946, 4, 30), null),
    new(1,"Sommerlath", "Silvia", Gender.Female, new(1943, 12, 23), null),
    new(2,"Bernadotte", "Victoria", Gender.Female, new(1977, 7, 14), null),
    new(3,"Westling", "Daniel", Gender.Male, new(1973, 9, 15), null),
    new(4,"Bernadotte", "Carl Philip", Gender.Male, new(1979, 5, 13), null),
    new(5,"Hellqvist", "Sofia", Gender.Female, new(1984, 12, 6), null),
    new(6,"Bernadotte", "Madeleine", Gender.Female, new(1982, 6, 10), null),
    new(7,"O'Neill", "Christopher", Gender.Male, new(1974, 6, 27), null),
    new(8,"Bernadotte", "Estelle", Gender.Female, new(2012, 2, 23), null),
    new(9,"Bernadotte", "Oscar", Gender.Male, new(2016, 3, 2), null),
    new(10,"Bernadotte", "Alexander", Gender.Male, new(2016, 4, 19), null),
    new(11,"Bernadotte", "Gabriel", Gender.Male, new(2017, 8, 31), null),
    new(12,"Bernadotte", "Julian", Gender.Male, new(2021, 3, 26), null),
    new(13,"Bernadotte", "Leonore", Gender.Female, new(2014, 2, 20), null),
    new(14,"Bernadotte", "Nicolas", Gender.Male, new(2015, 6, 15), null),
    new(15,"Bernadotte", "Adrienne", Gender.Female, new(2018, 3, 9), null),

    // Add more family members here...
};

app.MapGet("/swedish-royal-family-api", () =>
{
    var swedishRoyalFamilyArray = Enumerable.Range(1, 5).Select(index => swedishRoyalFamilyList).ToArray();
    return swedishRoyalFamilyArray;
})
.WithName("GetSwedishRoyalFamily");

app.Run();

record Familymember2(int Id, string FamilyName, string FirstName, Gender Gender, DateOnly? BirthDate, DateOnly? DeathDate)
{

}
