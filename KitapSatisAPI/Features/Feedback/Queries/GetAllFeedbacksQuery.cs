using KitapSatisAPI.Models;
using MediatR;
using System.Collections.Generic;

namespace KitapSatisAPI.Features.Feedback.Queries
{
    public class GetAllFeedbacksQuery : IRequest<IEnumerable<KitapSatisAPI.Models.Feedback>>
    {
    }
}
