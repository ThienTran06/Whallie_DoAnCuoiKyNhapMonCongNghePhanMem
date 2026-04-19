using Google.Cloud.Firestore;
var builder = WebApplication.CreateBuilder(args);
string path = Path.Combine(builder.Environment.ContentRootPath, "firebase.json");
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
// Add services to the container.
builder.Services.AddSingleton<FirestoreDb>(s =>
{
    
    return FirestoreDb.Create("whallie-b1bda");
});
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
