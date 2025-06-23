using KitapSatisAPI.DTOs;
using KitapSatisAPI.Features.Feedback.Commands;
using KitapSatisAPI.Features.Feedback.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitapSatisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var query = new GetAllFeedbacksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDto dto)
        {
            var command = new CreateFeedbackCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
