using KitapSatisAPI.Data;
using KitapSatisAPI.Features.Feedback.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KitapSatisAPI.Features.Feedback.Handler
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<KitapSatisAPI.Models.Feedback>>
    {
        private readonly KitapDbContext _context;

        public GetAllFeedbacksQueryHandler(KitapDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KitapSatisAPI.Models.Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Feedbacks
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }
    }
}
