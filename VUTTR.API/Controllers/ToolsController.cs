using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VUTTR.Domain.DTOs;
using VUTTR.Service.Interfaces.Interfaces;

namespace VUTTR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolService _ToolService;

        public ToolsController(IToolService toolService)
        {
            _ToolService = toolService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ToolDto>>> GetByTag([FromQuery]string tag = null)
        {
            try
            {
                if (tag == null)
                {
                    return Ok(await _ToolService.GetAll());
                }
                else
                {
                    tag = tag.Trim();
                    return Ok(await _ToolService.GetByTag(tag));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ToolDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo passado como parâmetro é inválido!");

                await _ToolService.Insert(dto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut]
        public async Task<ActionResult<ToolDto>> Put([FromBody] ToolDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo passado como parâmetro é inválido!");

                return Ok(await _ToolService.Update(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{ToolId:int}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] int ToolId)
        {
            try
            {
                await _ToolService.Delete(ToolId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
