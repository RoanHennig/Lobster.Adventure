using Lobster.Adventure.DataAccess.Keys;

namespace Lobster.Adventure.DataAccess.Interfaces.Repositories;

public interface IAdventureRespository
{
    void Create(LobsterAdventureEntity entity);
    LobsterAdventureEntity Read(LobsterAdventureKey key);
}
