﻿namespace Lobster.Adventure.Logic.Services.Create.Tests;

public class PersistAdventureServiceTests
{
    [Fact()]
    public void Persist_OnSuccess_InvokesMapperExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        persistAdventureService.Persist(request);

        //Assert
        mockMapLobsterAdventure.Verify(service => service.Map(request), Times.Once());
    }

    [Fact()]
    public void Persist_OnSuccess_InvokesRepositoryExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        persistAdventureService.Persist(request);

        //Assert
        mockAdventureRespository.Verify(service => service.Create(It.IsAny<LobsterAdventureEntity>()), Times.Once());
    }
}