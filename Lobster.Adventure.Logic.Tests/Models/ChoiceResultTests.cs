namespace Lobster.Adventure.Logic.Tests.Models;

public class ChoiceResultTests
{
    [Fact()]
    public void Validate_ChoiceResult_OnSuccess_ReturnsEmptyList()
    {
        //Arrange
        var choiceResultModel = new ChoiceResult()
        {
            ChoiceId = "1",
            ChoiceIdTaken = "2"
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceResultModel);

        //Assert
        result.Should().HaveCount(0);
    }

    [Fact()]
    public void Validate_OnNullChoiceId_ReturnsFailureReason()
    {
        //Arrange
        var choiceResultModel = new ChoiceResult()
        {
            ChoiceIdTaken = "2"
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceResultModel);


        //Assert
        result.Should().HaveCount(1);
    }

    [Fact()]
    public void Validate_OnEmptyChoiceIdTaken_ReturnsFailureReason()
    {
        //Arrange
        var choiceResultModel = new ChoiceResult()
        {
            ChoiceId = "1",
            ChoiceIdTaken = ""
        };

        //Act

        var result = DataAnnotationValidator.ValidateModel(choiceResultModel);

        //Assert
        result.Should().HaveCount(1);
    }
}
