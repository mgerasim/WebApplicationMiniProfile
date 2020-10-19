using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationMiniProfile.Models;

namespace WebApplicationMiniProfile.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		private readonly ApplicationContext _applicationContext;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext applicationContext)
		{
			_logger = logger;

			_applicationContext = applicationContext;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> Get()
		{
			var user = new User
			{
				Name = "Test",
				Age = 20
			};
			await _applicationContext.Users.AddAsync(user);

			await _applicationContext.SaveChangesAsync();

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
