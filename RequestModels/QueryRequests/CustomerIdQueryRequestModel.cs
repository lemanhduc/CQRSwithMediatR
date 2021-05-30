using CQRSwithMediatR.ResponseModels.QueryResponses;
using MediatR;

namespace CQRSwithMediatR.RequestModels.QueryRequests
{
    public class CustomerIdQueryRequestModel : IRequest<CustomerIdQueryResponseModel>
    {
        public int CustomerId { get; set; }
    }
}
