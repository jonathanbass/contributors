using Contributers.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contributers.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContributersController : ControllerBase
    {
        private readonly ISender _sender;

        public ContributersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public ActionResult GetProductById()
        {
            return Ok("Hello world");
        }

        [HttpGet("{username}/{repository}", Name = "GetContributers")]
        public async Task<ActionResult> GetProductById(string username, string repository)
        {
            var contributers = await _sender.Send(new GetContributersQuery(username, repository));
            return Ok(contributers);
        }
    }
}