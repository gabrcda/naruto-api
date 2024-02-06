using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ninja;
using api.Models;
using api.Services.NinjaServices;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NinjaController : ControllerBase
    {
        private readonly INinjaService _ninjaService;

        public NinjaController(INinjaService ninjaService)
        {
            _ninjaService = ninjaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<NinjaGetDto>>>> GetAll()
        {
            var response = await _ninjaService.GetAll();
            if(response.Data is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<NinjaGetDto>>> GetById(int id)
        {
            var response = await _ninjaService.GetById(id);
            if(response.Data is null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<NinjaGetDto>>>> AddNinja(NinjaPostDto newNinja)
        {
            var response = await _ninjaService.AddNinja(newNinja);
            if(response.IsSucess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<NinjaGetDto>>> UpdateNinja(NinjaUpdateDto updatedNinja)
        {
            var response = await _ninjaService.UpdateNinja(updatedNinja);
            if(response.IsSucess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<NinjaGetDto>>>> DeleteNinja(int id)
        {
            var response = await _ninjaService.DeleteNinja(id);
            if(response.Data is null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}