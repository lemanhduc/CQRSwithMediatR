using CQRSwithMediatR.Data;
using CQRSwithMediatR.RequestModels.QueryRequests;
using CQRSwithMediatR.ResponseModels.QueryResponses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Handlers.QueryHandlers
{
    public class AllCustomerQueryHandler : IRequestHandler<AllCustomerQueryRequestModel, List<AllCustomerQueryResponseModel>>
    {
        private readonly CustomerDbContext context;

        public AllCustomerQueryHandler(CustomerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<AllCustomerQueryResponseModel>> Handle(AllCustomerQueryRequestModel request, CancellationToken cancellationToken)
        {
            return await this.context.PersonalDetails.Select(s => new AllCustomerQueryResponseModel
            {
                CustomerId = s.Id,
                Name = $"{s.Title}.{s.Name }",
                City = s.City,
                LoyaltyPoints = s.LoyaltyPoints
            }).ToListAsync();
        }
    }
}
