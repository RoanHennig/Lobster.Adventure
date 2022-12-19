using Lobster.Adventure.DataAccess.Keys;

namespace Lobster.Adventure.DataAccess.Interfaces.Repositories;

public interface IAdventureRespository
{
    void Create(ILobsterAdventureEntity entity);
    ILobsterAdventureEntity Read(LobsterAdventureKey key);
}
