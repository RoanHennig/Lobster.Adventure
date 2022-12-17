namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureController : ControllerBase
{
    private readonly ILogger<AdventureController> _logger;
    private readonly ICreateAdventureService _createAdventureService;

    public AdventureController(ILogger<AdventureController> logger,
                               ICreateAdventureService createAdventureService)
    {
        _logger = logger;
        _createAdventureService = createAdventureService;
    }

    [HttpPost(Name = "CreateAdventure")]
    public async Task<IActionResult> Post(LobsterAdventure adventure)
    {
        try
        {
            _logger.LogInformation($"Received request {adventure.Id} - {JsonSerializer.Serialize(adventure)}");

            var failureReason = _createAdventureService.Create(adventure);

            if (!string.IsNullOrEmpty(failureReason))
            {
                return Problem($"Failed to create adventure - {failureReason}");
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
