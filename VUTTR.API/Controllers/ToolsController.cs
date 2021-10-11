using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VUTTR.Domain.ViewModels;
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
        [ProducesResponseType(typeof(List<ToolViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<ToolViewModel>>> GetByTag([FromQuery] string tag = null)
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Post([FromBody] ToolViewModel dto)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ToolViewModel>> Put([FromBody] ToolViewModel dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo passado como parâmetro é inválido!");

                await _ToolService.Update(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{ToolId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
