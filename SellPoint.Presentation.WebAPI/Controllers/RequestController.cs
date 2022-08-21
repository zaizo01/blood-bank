using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellPoint.Business.Interfaces;
using SellPoint.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellPoint.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IGenericRepository<Request> repository;

        public RequestController(IGenericRepository<Request> repository)
        {
            this.repository = repository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityById(Guid id)
        {
            try
            {
                var entity = await repository.GetById(id);
                if (entity is null) return NotFound("Esta entidad no existe.");
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntities()
        {
            try
            {
                var request = await repository.GetAll();
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(Request request)
        {
            try
            {
                request.Id = Guid.NewGuid();
                await repository.Create(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity(Request request)
        {
            try
            {
                await repository.Update(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(Guid id)
        {
            try
            {
                await repository.Delete(id);
                return Ok("Entidad eliminada.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
