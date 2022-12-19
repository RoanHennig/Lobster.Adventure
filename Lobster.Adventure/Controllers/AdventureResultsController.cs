namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureResultsController : ControllerBase
{
    private readonly ILogger<AdventureResultsController> _logger;
    private readonly ISaveAdventureResultsService _saveAdventureResultsService;
    private readonly IGetAdventureResultService _getAdventureResultService;

    public AdventureResultsController(ILogger<AdventureResultsController> logger,
                               ISaveAdventureResultsService saveAdventureResultsService,
                               IGetAdventureResultService getAdventureResultService)
    {
        _logger = logger;
        _saveAdventureResultsService = saveAdventureResultsService;
        _getAdventureResultService = getAdventureResultService;
    }

    [HttpPost(Name = "SaveAdventureResults")]
    public async Task<IActionResult> Save(LobsterAdventureResult adventureResult)
    {
        try
        {
            _logger.LogInformation(
                $"Received request {adventureResult.UserId} {adventureResult.AdventureName} - {JsonSerializer.Serialize(adventureResult)}");

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

    [HttpGet(Name = "GetAdventureResult")]
    public async Task<IActionResult> Get(string userId, string adventureName, string adventureDateTaken)
    {
        try
        {
            _logger.LogInformation($"Received get request {userId} - {adventureName} - {adventureDateTaken}");

            var adventureResult = _getAdventureResultService.Get(userId, adventureName, adventureDateTaken);

            if(adventureResult is null)
                return Problem($"Could not retrieve adventure result - result not found.");

            return Ok(adventureResult);
        }
        catch (Exception ex)
        {
            return Problem($"Could not retrieve adventure result - {ex.Message}");
        }
    }
}
