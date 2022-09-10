using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PGSAssignment.Data.Services;
using PGSAssignment.Models;

namespace PGSAssignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _service;

        public RatesController(IRatesService service)
        {
            _service = service;
        }


        [HttpGet("AllRates"),Authorize]
        public async Task<IActionResult> AllRates(int pageSize, int? pageNumber)
        {
            try
            {
                var AllRates = await _service.GetAllAsync(pageSize,pageNumber);

                if (AllRates != null)
                {
                    return Ok(AllRates);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we can not load rates.");
            }
        }


        [HttpGet("RatesDetails/{id}"), Authorize]
        public async Task<IActionResult> RatesDetails(int id)
        {
            try
            {
                var RateDetail = await _service.GetByIdAsync(id);

                if (RateDetail != null)
                {
                    return Ok(RateDetail);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we can not load rate details.");
            }
        }


        [HttpPut("EditRate/{id}"), Authorize]
        public async Task<IActionResult> EditRate(int id, [FromBody] Rate rate)
        {
            try
            {
                await _service.UpdateAsync(id, rate);

                return Ok("Updated");
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we can not edit the rate");
            }
        }
    }
}
