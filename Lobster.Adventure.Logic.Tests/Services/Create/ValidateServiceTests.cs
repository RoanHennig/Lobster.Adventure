namespace Lobster.Adventure.Logic.Services.Create.Tests;

public class ValidateServiceTests
{
    [Fact()]
    public void Validate_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var validateService = new ValidateService();


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact()]
    public void Validate_OnNullAdventure_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateService();


        var request = LobsterAdventureFixtures.GetNullAdventure();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(ValidationFailuresMessages.NullAdventure);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyAdventureName_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateService();


        var request = LobsterAdventureFixtures.GetEmptyAdventureName();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(ValidationFailuresMessages.NullOrEmptyAdventureName);
    }

    [Fact()]
    public void Validate_OnNullAdventureChoice_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateService();


        var request = LobsterAdventureFixtures.GetNullAdventureChoice();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(ValidationFailuresMessages.NullAdventureChoice);
    }
}