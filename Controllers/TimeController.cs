using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TimeController : ControllerBase
{
  private readonly TimeService _timeService;

  public TimeController(TimeService service)
  {
    _timeService = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<Times>>> Get()
  {
    return await _timeService.GetAllTimes();
  }

  [HttpPost]
  public async Task<ActionResult<Times>> Post(NewTimeDto dto)
  {
    var result = await _timeService.AddTime(dto);
    return CreatedAtAction(nameof(Get), new { id = result.Id, result });
  }
}