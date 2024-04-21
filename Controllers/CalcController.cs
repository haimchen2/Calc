using Calc.Models;
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
        public  IActionResult Calc([FromBody] CalcModel model)
        {
            string result = "";
            switch (Request.Headers["Operation"])
            {
                case "+":
                    result=(model.value1 + model.value2).ToString(); break;
                case "-":
                     result = (model.value1 - model.value2).ToString(); break;
                case "*":
                     result = (model.value1 * model.value2).ToString(); break;
                case "/":
                     result = (model.value1 / model.value2).ToString(); break;
                default:
                     result = ("please insert operation"); break;

            }
            Result res =new Result() { result = result };
            return Ok(res);

        }
       

        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

       
    }
   
}
