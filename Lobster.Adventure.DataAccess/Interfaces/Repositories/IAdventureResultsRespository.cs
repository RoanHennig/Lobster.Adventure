namespace Lobster.Adventure.DataAccess.Interfaces.Repositories;

public interface IAdventureResultsRespository
{
    void Create(LobsterAdventureResultEntity entity);
    LobsterAdventureResultEntity Read(LobsterAdventureResultKey key);
}
