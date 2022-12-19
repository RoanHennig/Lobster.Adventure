using Lobster.Adventure.DataAccess.Interfaces.Repositories;
using Lobster.Adventure.DataAccess.Repositories;

namespace Lobster.Adventure;

public static class ConfigureServices
{
    public static IServiceCollection GetServices(IServiceCollection services,
                                                 IMongoCollection<LobsterAdventureMongoDbEntity> adventureCollection,
                                                 IMongoCollection<LobsterAdventureResultMongoDbEntity> adventureResultCollection)
    {
        services
            .AddSingleton<IAdventureRespository>(new AdventureMongoDbRespository(adventureCollection))
            .AddSingleton<IAdventureResultsRespository>(new AdventureResultsMongoDbRespository(adventureResultCollection))
            .AddSingleton<IMapLobsterAdventure, MapLobsterAdventure>()
            .AddSingleton<IMapLobsterAdventureResult, MapLobsterAdventureResult>()
            .AddSingleton<ICreateAdventureService, CreateAdventureService>()
            .AddSingleton<IPersistAdventureService, PersistAdventureService>()
            .AddSingleton<IValidateAdventureService, ValidateAdventureService>()
            .AddSingleton<ICreateLobsterAdventureKeyService, CreateLobsterAdventureKeyService>()
            .AddSingleton<ICreateLobsterAdventureResultKeyService, CreateLobsterAdventureResultKeyService>()
            .AddSingleton<IGetAdventureResultService, GetAdventureResultService>()
            .AddSingleton<IGetAdventureService, GetAdventureService>()
            .AddSingleton<IPersistAdventureResultsService, PersistAdventureResultsService>()
            .AddSingleton<ISaveAdventureResultsService, SaveAdventureResultsService>()
            .AddSingleton<IValidateAdventureResultsService, ValidateAdventureResultsService>();

        return services;
    }
}
