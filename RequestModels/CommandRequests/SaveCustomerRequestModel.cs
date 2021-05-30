using MediatR;

namespace CQRSwithMediatR.RequestModels.CommandRequests
{
    public class SaveCustomerRequestModel : IRequest 
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
