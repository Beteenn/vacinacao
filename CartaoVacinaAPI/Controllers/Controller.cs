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

        protected IActionResult TratarResultado<T>(Result<T> result) where T : class
        {
            if (!result)
                return BadRequest(result);

            if (result.Value == null)
                return NotFound();

            return Ok(result.Value);
        }
    }
}
