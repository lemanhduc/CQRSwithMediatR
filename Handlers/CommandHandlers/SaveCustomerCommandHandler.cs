using CQRSwithMediatR.Data;
using CQRSwithMediatR.Models;
using CQRSwithMediatR.RequestModels.CommandRequests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Handlers.CommandHandlers
{
    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerRequestModel, Unit>
    {
        private readonly CustomerDbContext context;

        public SaveCustomerCommandHandler(CustomerDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(SaveCustomerRequestModel saveCustomerRequestModel, CancellationToken cancellationToken)
        {
            var newCustomer = new PersonalDetails
            {
                Name = saveCustomerRequestModel.Name,
                Title = saveCustomerRequestModel.Title,
                City = saveCustomerRequestModel.City,
                LoyaltyPoints = saveCustomerRequestModel.LoyaltyPoints
            };

            this.context.PersonalDetails.Add(newCustomer);
            await this.context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
