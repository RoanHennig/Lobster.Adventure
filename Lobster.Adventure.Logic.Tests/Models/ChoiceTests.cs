namespace Lobster.Adventure.Logic.Tests.Models;

public class ChoiceTests
{
    [Fact()]
    public void Validate_Choice_OnSuccess_ReturnsEmptyList()
    {
        //Arrange
        var choiceModel = new Choice()
        {
            Id = "dummyId2",
            Prompt = "dummyPrompt2",
            Choices = new List<Choice>()
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(0);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyChoiceId_ReturnsFailureReason()
    {
        //Arrange
        var choiceModel = new Choice()
        {
            Prompt = "dummyPrompt2",
            Choices = new List<Choice>()
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnNullOrEmptyChoicePrompt_ReturnsFailureReason()
    {
        //Arrange
        var choiceModel = new Choice()
        {
            Id = "dummyId2",
            Choices = new List<Choice>()
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceModel);

        //Assert
        result.Should().HaveCount(1);
    }
}
