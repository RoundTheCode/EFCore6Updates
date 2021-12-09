using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoundTheCode.EFCore.Entities;

namespace RoundTheCode.EFCore.Controllers
{
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly EfCoreDbContext _dbContext;
		public TestController(EfCoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpPost("create-sample")]
		public virtual async Task<ActionResult> CreateSample()
		{
			var team = new Team
			{
				Name = "Brighton"
			};

			await _dbContext.AddAsync(team);
			await _dbContext.SaveChangesAsync();

			await _dbContext.AddAsync(new Player
			{
				TeamId = team.Id,
				FirstName = "Neal",
				Surname = "Maupay"
			});

			await _dbContext.AddAsync(new Player
			{
				TeamId = team.Id,
				FirstName = "Leandro",
				Surname = "Trossard"
			});

			await _dbContext.AddAsync(new Player
			{
				TeamId = team.Id,
				FirstName = "Tariq",
				Surname = "Lamptey"
			});

			await _dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpPost("update-sample")]
		public virtual async Task<ActionResult> UpdateSample()
		{
			var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.Id == 1);

			team.Name = "Brighton & Hove Albion";
			_dbContext.Entry(team).State = EntityState.Modified;

			await _dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpGet("sample")]
		public virtual async Task<ActionResult<List<Team>>> GetSample()
		{
			var teams = await _dbContext.Teams.TemporalAll().Where(x => x.Id == 1).ToListAsync();

			return Ok(teams);
		}
	}
}
