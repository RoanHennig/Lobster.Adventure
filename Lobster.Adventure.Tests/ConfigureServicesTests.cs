namespace Lobster.Adventure.Tests;

public class ConfigureServicesTests
{
    [Fact()]
    public void GetServices_OnSuccess_ReturnsServiceCollection()
    {
        //Arrange
        var request = new ServiceCollection();
        var mockadventureCollection = new Mock<IMongoCollection<LobsterAdventureEntity>>();
        var mockadventureResultCollection = new Mock<IMongoCollection<LobsterAdventureResultEntity>>();

        //Act

        var result = ConfigureServices.GetServices(request, mockadventureCollection.Object, mockadventureResultCollection.Object);

        //Assert
        result.Where(x => x.ServiceType == typeof(IMapLobsterAdventure)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IAdventureRespository)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IAdventureResultsRespository)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IMapLobsterAdventureResult)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(ICreateAdventureService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IPersistAdventureService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IValidateAdventureService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(ICreateLobsterAdventureKeyService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(ICreateLobsterAdventureResultKeyService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IGetAdventureResultService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IGetAdventureService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IPersistAdventureResultsService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(ISaveAdventureResultsService)).Should().HaveCount(1);
        result.Where(x => x.ServiceType == typeof(IValidateAdventureResultsService)).Should().HaveCount(1);
    }
}