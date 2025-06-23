using KitapSatisAPI.DTOs;
using MediatR;

namespace KitapSatisAPI.Features.Feedback.Commands
{
    public class CreateFeedbackCommand : IRequest<KitapSatisAPI.Models.Feedback>
    {
        public CreateFeedbackDto Dto { get; set; }

        public CreateFeedbackCommand(CreateFeedbackDto dto)
        {
            Dto = dto;
        }
    }
}
