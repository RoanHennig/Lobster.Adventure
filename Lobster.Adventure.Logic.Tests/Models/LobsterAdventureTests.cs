namespace Lobster.Adventure.Logic.Tests.Models;

public class LobsterAdventureTests
{
    [Fact()]
    public void Validate_LobsterAdventure_OnSuccess_ReturnsEmptyList()
    {
        //Arrange
        var choiceModel = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(0);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyAdventureName_ReturnsFailureReason()
    {
        //Arrange
        LobsterAdventure choiceModel = LobsterAdventureFixtures.GetEmptyAdventureName();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyAdventureUserId_ReturnsFailureReason()
    {
        //Arrange
        LobsterAdventure choiceModel = LobsterAdventureFixtures.GetEmptyAdventureUserId();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnNullAdventureChoice_ReturnsFailureReason()
    {
        //Arrange
        LobsterAdventure choiceModel = LobsterAdventureFixtures.GetNullAdventureChoice();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

}
