namespace Lobster.Adventure.Logic.Tests.Models;

public class ChoiceTests
{
    [Fact()]
    public void Validate_OnSuccess_ReturnsEmptyList()
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
}
