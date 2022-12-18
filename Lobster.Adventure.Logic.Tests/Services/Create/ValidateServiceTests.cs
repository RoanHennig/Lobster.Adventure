namespace Lobster.Adventure.Logic.Services.Create.Tests;

public class ValidateServiceTests
{
    [Fact()]
    public void Validate_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var validateService = new ValidateAdventureService();


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
        var validateService = new ValidateAdventureService();


        var request = LobsterAdventureFixtures.GetNullAdventure();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(FailuresMessages.NullAdventure);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyAdventureName_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateAdventureService();


        var request = LobsterAdventureFixtures.GetEmptyAdventureName();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(FailuresMessages.NullOrEmptyAdventureName);
    }

    [Fact()]
    public void Validate_OnNullAdventureChoice_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateAdventureService();


        var request = LobsterAdventureFixtures.GetNullAdventureChoice();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(FailuresMessages.NullAdventureChoice);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyChoiceId_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateAdventureService();


        var request = LobsterAdventureFixtures.GetNullOrEmptyChoiceIdAdventure();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(FailuresMessages.NullOrEmptyChoiceId);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyChoicePrompt_ReturnsFailureReason()
    {
        //Arrange
        var validateService = new ValidateAdventureService();


        var request = LobsterAdventureFixtures.GetNullOrEmptyChoicePromptAdventure();

        //Act

        var result = validateService.Validate(request);

        //Assert
        result.Should().Be(FailuresMessages.NullOrEmptyChoicePrompt);
    }
}