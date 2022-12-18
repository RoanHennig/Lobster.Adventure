namespace Lobster.Adventure.Logic.Tests.Models;

public class LobsterAdventureResultTests
{
    [Fact()]
    public void Validate_LobsterAdventureResult_OnSuccess_ReturnsEmptyList()
    {
        //Arrange
        var choiceModel = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(0);
    }

    [Fact()]
    public void Validate_OnNullAdventureUserId_ReturnsFailureReason()
    {
        //Arrange
        var choiceModel = LobsterAdventureResultsFixtures.GetNullUserIdAdventureResult();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnNullAdventureName_ReturnsFailureReason()
    {
        //Arrange
        var choiceModel = LobsterAdventureResultsFixtures.GetNullAdventureNameAdventureResult();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnNullChoiceList_ReturnsFailureReason()
    {
        //Arrange
        var choiceModel = LobsterAdventureResultsFixtures.GetNullChoicesAdventureResult();

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }
}
