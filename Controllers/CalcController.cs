using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        
        [HttpPost("Calc")]
        [Authorize]
        public async Task<IActionResult> Calc([FromBody] CalcModel model)
        {
            switch (Request.Headers["Operation"])
            {
              case   "+":return Ok(model.value1 + model.value2);
                    break;
                case "-":
                    return Ok(model.value1 - model.value2);
                    break;
                case "*":
                    return Ok(model.value1 * model.value2);
                    break;
                case "/":
                    return Ok(model.value1 / model.value2);
                    break;
                default:
                    return Ok("please insert operation");

            }
            return Ok(model.value1 + model.value2);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add( [FromBody]  CalcModel model)
        {
            return Ok( model.value1 + model.value2);
        }

        [HttpPost("Substract")]
        public async Task<IActionResult> Substract([FromBody] CalcModel model)
        {
            return Ok(model.value1 - model.value2);
        }

        [HttpPost("Multiply")]
        public async Task<IActionResult> Multiply([FromBody] CalcModel model)
        {
            return Ok(model.value1 * model.value2);
        }

        [HttpPost("Divide")]
        public async Task<IActionResult> Divide([FromBody] CalcModel model)
        {
            return Ok(model.value1 / model.value2);
        }
       

        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
    public class CalcModel {
        public int value1 { get; set; }
        public int value2 { get; set; }
    }
}
