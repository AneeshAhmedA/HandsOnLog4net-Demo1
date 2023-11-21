using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLog4net_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestController : ControllerBase
    {
        private readonly ILog _logger;

        public LogTestController(ILog logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.Info("This is an informational log");
            _logger.Error("This is an error log");
           
            return Ok("Test Success");
        }
        [HttpGet,Route("Div/{a}/{b}")]
        public IActionResult Div(int a,int b)
        {
            try
            {
                int c = a / b;
                _logger.Info("Result: " + c);
                return Ok("Test Done");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500,ex.Message);
            }
        }
    }
}
