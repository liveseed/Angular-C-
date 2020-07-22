using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotNetProject.Domain.Domain;
using AngularDotNetProject.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNetProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeadlineController : Controller
    {
        private readonly IRepository _repository;

        public HeadlineController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{headlineId}")]
        public async Task<IActionResult> Get(int headlineId)
        {
            try
            {
                var result = await _repository.GetHeadlineByIdAsync(headlineId, true);

                return Ok(result);
            }
            catch (SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpGet("getByName/{Name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await _repository.GetAllHeadlineByNameAsync(name, true);

                return Ok(results);
            }
            catch(SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Headline model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/headline/{model.HeadlineId}", model);
                }
            }
            catch (SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

        [HttpPut("{HeadlineId}")]
        public async Task<IActionResult> Put(int headlineId, Headline model)
        {
            try
            {
                var headlineTarget = await _repository.GetHeadlineByIdAsync(headlineId, false);

                if (headlineTarget == null)
                    return NotFound();

                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/headline/{model.HeadlineId}", model);
                }
            }
            catch (SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

        [HttpDelete("delete/{HeadlineId}")]
        public async Task<IActionResult> Delete(int headlineId)
        {
            try
            {
                var headlineTarget = await _repository.GetHeadlineByIdAsync(headlineId, false);

                if (headlineTarget == null)
                    return NotFound();

                _repository.Delete(headlineTarget);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

    }
}
