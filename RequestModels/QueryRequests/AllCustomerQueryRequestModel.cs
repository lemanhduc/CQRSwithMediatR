using CQRSwithMediatR.ResponseModels.QueryResponses;
using MediatR;
using System.Collections.Generic;

namespace CQRSwithMediatR.RequestModels.QueryRequests
{
    public class AllCustomerQueryRequestModel : IRequest<List<AllCustomerQueryResponseModel>>
    {
    }
}


