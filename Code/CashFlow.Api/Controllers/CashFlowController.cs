using Microsoft.AspNetCore.Mvc;
using System;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashFlowController : ControllerBase
    {
        [HttpGet]
        public IActionResult CashFlow()
        {
            throw new NotImplementedException();
        }

        [HttpPost("received")]
        public IActionResult Received()
        {
            throw new NotImplementedException();
        }

        [HttpPost("payment")]
        public IActionResult Payment()
        {
            throw new NotImplementedException();
        }
    }
}