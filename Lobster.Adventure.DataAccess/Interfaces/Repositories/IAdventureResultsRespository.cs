namespace Lobster.Adventure.DataAccess.Interfaces.Repositories;

public interface IAdventureResultsRespository
{
    void Create(ILobsterAdventureResultEntity entity);
    ILobsterAdventureResultEntity Read(LobsterAdventureResultKey key);
}
