namespace API.Controllers
{
    using Application.Core;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if(result == null) return NotFound();
            if(result.IsSuccess && result.Value != null) return Ok(result.Value);
            if(result.IsSuccess && result.Value == null) return NotFound();
            return BadRequest(result.Error);
        }

    }
}