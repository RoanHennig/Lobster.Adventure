var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

MongoClient dbClient = new MongoClient(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
var database = dbClient.GetDatabase(Environment.GetEnvironmentVariable("DB_NAME"));
var adventureCollection = database.GetCollection<LobsterAdventureEntity>(Environment.GetEnvironmentVariable("TABLE_ADVENTURE_NAME"));
var adventureResultCollection = database.GetCollection<LobsterAdventureResultEntity>(Environment.GetEnvironmentVariable("TABLE_ADVENTURE_RESULT_NAME"));

ConfigureServices.GetServices(builder.Services, adventureCollection, adventureResultCollection);

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
