using Abstractions;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaxeController : ControllerBase
    {
        private readonly ITaxeService _taxeService;

        public TaxeController(ITaxeService taxeService)
        {
            _taxeService = taxeService;
        }

        [HttpGet("{municipality}/{date}")]
        public async Task<ActionResult<TaxeModel>> Get(string municipality, DateTime date) 
        {
            try
            {
                var result = await _taxeService.Get(municipality, date);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        
        }

        [HttpPost]
        public async Task<ActionResult<TaxeModel>> Post([FromBody]AddTaxeModel model)
        {
            try
            {
                await _taxeService.Add(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
