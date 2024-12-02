using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.DTO;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Business.Services;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private RegionService _service;
        private IMapper _mapper;

        public RegionController(RegionService service, IMapper mapper)
        {
            _service = service; //Dependency Injection
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRegion")]
        [AllowAnonymous]
        public async Task<ActionResult<GetRegionWithWalksDTO>> GetRegionAsync(int Id, bool includeWalks)
        {
            Region region = await _service.GetRegionAsync(Id, includeWalks);
            GetRegionWithWalksDTO dto = null;
            dto = _mapper.Map<GetRegionWithWalksDTO>(region);

            if (region == null)
            {
                return NotFound("Does not exist.");
            }
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult AddRegion(AddRegionDTO region)
        {
            if (region.Climate >= Enum.GetValues(typeof(Climate)).Length)
            {
                ModelState.AddModelError("Error", "Gekozen Klimaat bestaat niet");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Region model = null;
            model = _mapper.Map<Region>(region);
            _service.AddRegion(model);
            return Created();
        }

        [HttpGet]
        [Route("GetAllRegions")]
        [AllowAnonymous]

        public async Task<ActionResult<List<GetRegionWithWalksDTO>>> GetAllRegionAsync()
        {
            List<Region> regions = await _service.GetAllRegionsAsync();
            List<GetRegionWithWalksDTO> dto = new List<GetRegionWithWalksDTO>();

            if (regions.Count == 0)
            {
                return NotFound("No regions found");
            }
            else
            {
                dto = _mapper.Map(regions, dto);
            }
            return Ok(dto);
        }
    }
}