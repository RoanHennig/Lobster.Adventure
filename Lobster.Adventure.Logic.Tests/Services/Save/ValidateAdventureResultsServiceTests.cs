namespace Lobster.Adventure.Logic.Services.Save.Tests;

public class ValidateAdventureResultsServiceTests
{
    [Fact()]
    public void Validate_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact()]
    public void Validate_OnNullAdventureResult_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullAdventureResult);
    }

    [Fact()]
    public void Validate_OnNullAdventureUserId_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullUserIdAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyAdventureUserId);
    }

    [Fact()]
    public void Validate_OnNullAdventureName_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullAdventureNameAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyAdventureName);
    }

    [Fact()]
    public void Validate_OnNullChoiceResultChoiceId_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullChoiceIdAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyChoiceId);
    }

    [Fact()]
    public void Validate_OnNullChoiceResultChoiceIdTaken_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullChoiceIdTakenAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyChoiceIdTaken);
    }

    [Fact()]
    public void Validate_OnNullAdventureChoices_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullChoicesAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyAdventureResultChoices);
    }

    [Fact()]
    public void Validate_OnEmptyChoiceList_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetEmptyChoicesAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyAdventureResultChoices);
    }

    [Fact()]
    public void Validate_OnNullAdventureTakenDate_ReturnsFailureReason()
    {
        //Arrange
        var validateAdventureResultsService = new ValidateAdventureResultsService();


        var request = LobsterAdventureResultsFixtures.GetNullAdventureTakenDateAdventureResult();

        //Act

        var result = validateAdventureResultsService.Validate(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.NullOrEmptyAdventureTakenDate);
    }
}