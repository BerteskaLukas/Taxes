using Abstractions;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ITaxeOrderService _taxeOrderService;

        public ScheduleController(ITaxeOrderService taxeOrderService)
        {
            _taxeOrderService = taxeOrderService;
        }

        [HttpGet("{municipalityId}")]
        public async Task<ActionResult<IEnumerable<TaxeOrderModel>>> Get(Guid municipalityId)
        {
            try
            {
                var result = await _taxeOrderService.GetByMunicipalityId(municipalityId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{municipalityId}")]
        public async Task<ActionResult> Put(Guid municipalityId, [FromBody]List<UpdateTaxeOrderModel> order)
        {

            try
            {
                await _taxeOrderService.UpdateOrder(municipalityId, order);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
