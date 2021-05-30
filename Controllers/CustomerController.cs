using CQRSwithMediatR.RequestModels.CommandRequests;
using CQRSwithMediatR.RequestModels.QueryRequests;
using CQRSwithMediatR.ResponseModels.QueryResponses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("save-customer")]
        public async Task<IActionResult> SaveCustomerAsync(SaveCustomerRequestModel requestModel)
        {
            try
            {
                var result = await mediator.Send(requestModel);
                return Ok("New customer created !!");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<List<AllCustomerQueryResponseModel>> GetAllCustomerAsync(AllCustomerQueryRequestModel requestModel)
        {
            try
            {
                return await mediator.Send(requestModel);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("customer-id")]
        [ProducesResponseType(typeof(CustomerIdQueryResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerAsync(CustomerIdQueryRequestModel requestModel)
        {
            try
            {
                var result = await mediator.Send(requestModel);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound($"Customer Id '{requestModel.CustomerId}' does not exists!!");
            }
            catch
            {
                throw;
            }
        }
    }
}



