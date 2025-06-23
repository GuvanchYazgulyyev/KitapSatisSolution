using KitapSatisAPI.Data;
using KitapSatisAPI.Features.Feedback.Commands;
using MediatR;

namespace KitapSatisAPI.Features.Feedback.Handler
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, KitapSatisAPI.Models.Feedback>
    {
        private readonly KitapDbContext _context;

        public CreateFeedbackCommandHandler(KitapDbContext context)
        {
            _context = context;
        }

        public async Task<KitapSatisAPI.Models.Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = new KitapSatisAPI.Models.Feedback
            {
                Message = request.Dto.Message
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }
    }
}
