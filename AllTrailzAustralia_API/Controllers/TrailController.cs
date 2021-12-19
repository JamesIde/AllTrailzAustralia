using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace AllTrailzAustralia_API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {

        private readonly ITrailsRepository _trailsRepository;

        public TrailController(ITrailsRepository trailsRepository) 
        {
            _trailsRepository = trailsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrails()
        {
            var trailList = await _trailsRepository.GetAll();

            if(trailList == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);  
            }
            return Ok(trailList);
        }
        [HttpGet("{trailId}")]
        public async  Task<IActionResult> GetTrailsById(int? trailId)
        {
            if(trailId == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);

            }
            var trailById = await _trailsRepository.Get(trailId.Value);
            if(trailById == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);

            }
            return Ok(trailById);
        }
    }
}
