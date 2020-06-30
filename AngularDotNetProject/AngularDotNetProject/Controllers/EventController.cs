using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AngularDotNetProject.Domain.Domain;
using AngularDotNetProject.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNetProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IRepository _repository;

        public EventController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllEventAsync(true);

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> Get(int eventId)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(eventId, true);

                return Ok(result);

            } 
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await _repository.GetAllEventByNameAsync(name, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{model.EventId}", model);
                }

            } 
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

        [HttpPut("{EventId}")]
        public async Task<IActionResult> Put(int eventId, Event model)
        {
            try
            {
                var eventTarget = await _repository.GetEventByIdAsync(eventId, false);
                
                if (eventTarget == null)
                    return NotFound();

                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{model.EventId}", model);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

        [HttpDelete("delete/{EventId}")]
        public async Task<IActionResult> Delete(int eventId)
        {
            try
            {
                var eventTarget = await _repository.GetEventByIdAsync(eventId, false);

                if (eventTarget == null)
                    return NotFound();

                _repository.Delete(eventTarget);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }
    }
}
