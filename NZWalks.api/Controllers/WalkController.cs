using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.DTO;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Business.Services;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]

    public class WalkController : ControllerBase
    {
        private WalkService _service;
        private IMapper _mapper;

        public WalkController(WalkService service, IMapper mapper)
        {
            _service = service; //Dependency Injection
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetWalkDTO>> GetWalkAsync(int Id)
        {
            Walk walk = await _service.GetWalkAsync(Id);

            if (walk == null)
            {
                return NotFound("Does not exist.");
            }

            GetWalkDTO dto = _mapper.Map<GetWalkDTO>(walk);

            return Ok(dto);
        }

        [HttpGet]
        [Route("GetWalkWithRegion")]
        [Authorize(Roles = "admin,reader")]
        public async Task<ActionResult<GetWalkDTO>> GetWalkWithRegionAsync(int Id)
        {

            //UserManager<null> uManger = new UserManager<null>()
            //    CustomUser? gb = await _userManager.FindByEmailAsync(gpm.Email);

            //var huidigeRoles = await _userManager.GetRolesAsync(gb);

            //if (huidigeRoles.any(x => x == "admin"){ }

            Walk model = await _service.GetWalkAsync(Id, true);
            GetWalkDTO dto = new GetWalkDTO();

            if (model == null)
            {
                return NotFound("Does not exist.");
            }
            else
            {
                dto = _mapper.Map(model, dto);

                //GetWalkDTO dto = new GetWalkDTO();
                //dto.WalkName = model.Name;
                //dto.Climate = model.Region.Climate.ToString();
                //dto.Description = model.Description;
                //dto.PictureURL = model.PictureUrl;
                //dto.Altitude = model.Altidude;
                //dto.Region = model.Region.Name;

                return Ok(dto);
            }
        }

        [HttpGet]
        [Route("GetAllWalks")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Walk>>> GetAllWalksAsync()
        {
            List<Walk> walk = await _service.GetAllWalksAsync();
            List<GetWalkDTO> dto = new List<GetWalkDTO>();

            if (walk == null)
            {
                return NotFound("Walk does not exist.");
            }
            else
            {
                dto = _mapper.Map(walk, dto);
            }
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult AddWalk(AddWalkDTO walk)
        {
            Walk model = null;
            model = _mapper.Map(walk, model);
            _service.AddWalkAsync(model);
            return Created();
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteWalkAsync(int Id)
        {
            //Walk walk = await _service.GetWalkAsync(Id);
            //if (walk == null)
            //{
            //    return NotFound("Niet gevonden");
            //}
            await _service.DeleteWalkAsync(Id);
            return NoContent();
        }

        //update
        //delete

        //[HttpDelete]
        //public ActionResult DeleteWalk(Walk walk)
        //{
        //    service.DeleteWalk(walk);
        //    return Created("Walk was deleted.", null);
        //}

        //[HttpPut]
        //public ActionResult UpdateWalk(Walk walk)
        //{
        //    service.UpdateWalk(walk);
        //    return Created("Walk was updated.", null);
        //}
    }
}