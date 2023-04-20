using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ServiceInterfaces;
using System.Diagnostics;

namespace MainProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IFibonacciService _fibonacciService;
        public FibonacciController(IFibonacciService fibonacciService)
        {
            this._fibonacciService = fibonacciService;
        }

        [HttpGet("GetNumberAtPosition/{position}")]
        public IActionResult FibonacciNumberAtPosition(int position)
        {
            if (position < 0)
            { return BadRequest(); }

            return Ok(_fibonacciService.FibonacciNumberAtPosition(position));
        }
    }
}
