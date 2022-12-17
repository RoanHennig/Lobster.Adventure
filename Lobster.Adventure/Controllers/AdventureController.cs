namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureController : ControllerBase
{
    private readonly ILogger<AdventureController> _logger;

    public AdventureController()
    {

    }

    public AdventureController(ILogger<AdventureController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "CreateAdventure")]
    public async Task<ActionResult> Post(LobsterAdventure adventure)
    {
        return Ok();
    }
}
