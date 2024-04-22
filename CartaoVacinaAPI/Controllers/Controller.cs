using CartaoVacina.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace CartaoVacina.API.Controllers
{
    public abstract class Controller : ControllerBase
    {
        protected IActionResult TratarResultado(Result result)
        {
            if (!result)
                return BadRequest(result);

            return Ok();
        }
    }
}
