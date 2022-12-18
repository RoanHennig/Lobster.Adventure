namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureResultsController : ControllerBase
{
    private readonly ILogger<AdventureResultsController> _logger;
    private readonly ISaveAdventureResultsService _saveAdventureResultsService;

    public AdventureResultsController(ILogger<AdventureResultsController> logger,
                               ISaveAdventureResultsService saveAdventureResultsService)
    {
        _logger = logger;
        _saveAdventureResultsService = saveAdventureResultsService;
    }

    [HttpPost(Name = "SaveAdventureResults")]
    public async Task<IActionResult> Save(LobsterAdventureResult adventureResult)
    {
        try
        {
            _logger.LogInformation($"Received request {adventureResult.UserId} {adventureResult.Name} - {JsonSerializer.Serialize(adventureResult)}");

            var failureReason = _saveAdventureResultsService.Save(adventureResult);

            if (!string.IsNullOrEmpty(failureReason))
            {
                return Problem($"Failed to save adventure results - {failureReason}");
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
