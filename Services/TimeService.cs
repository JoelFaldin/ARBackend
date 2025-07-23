using Microsoft.EntityFrameworkCore;

public class TimeService
{
  private readonly DBContext _context;

  public TimeService(DBContext context)
  {
    _context = context;
  }

  public async Task<List<Times>> GetAllTimes()
  {
    return await _context.Times.ToListAsync();
  }

  public async Task<Times> AddTime(NewTimeDto dto)
  {
    var record = new Times { Time = dto.Time, Name = dto.Name };
    _context.Times.Add(record);

    await _context.SaveChangesAsync();
    return record;
  }
}