using CQRSwithMediatR.Data;
using CQRSwithMediatR.RequestModels.QueryRequests;
using CQRSwithMediatR.ResponseModels.QueryResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Handlers.QueryHandlers
{
    public class CustomerIdQueryHandler : IRequestHandler<CustomerIdQueryRequestModel, CustomerIdQueryResponseModel>
    {
        private readonly CustomerDbContext context;
        public CustomerIdQueryHandler(CustomerDbContext context)
        {
            this.context = context;
        }
        public async Task<CustomerIdQueryResponseModel> Handle(CustomerIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var result = await this.context.PersonalDetails.Where(p => p.Id == request.CustomerId)
                       .FirstOrDefaultAsync();

            if (result != null)
            {
                return new CustomerIdQueryResponseModel
                {
                    CustomerId = result.Id,
                    Name = $"{result.Title}.{result.Name}",
                    City = result.City
                };
            }

            return null;
        }
    }
}
