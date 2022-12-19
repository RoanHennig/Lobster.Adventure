var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var connectionString = $"mongodb://{Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_USERNAME")}:{Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_PASSWORD")}@{Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")}/{Environment.GetEnvironmentVariable("DB_NAME")}?authSource=admin";

MongoClient dbClient = new MongoClient(connectionString);
var database = dbClient.GetDatabase(Environment.GetEnvironmentVariable("DB_NAME"));
var adventureCollection = database.GetCollection<LobsterAdventureMongoDbEntity>(Environment.GetEnvironmentVariable("TABLE_ADVENTURE_NAME"));
var adventureResultCollection = database.GetCollection<LobsterAdventureResultMongoDbEntity>(Environment.GetEnvironmentVariable("TABLE_ADVENTURE_RESULT_NAME"));

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
