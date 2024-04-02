using Filter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TecheSoft.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
