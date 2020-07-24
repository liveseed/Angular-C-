using System.Collections.Generic;
using System.Threading.Tasks;
using AngularDotNetProject.API.DTOs;
using AngularDotNetProject.Domain.Domain;
using AngularDotNetProject.Repository.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNetProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EventController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEvents = await _repository.GetAllEventAsync(true);

                var results = _mapper.Map<IEnumerable<EventDto>>(listEvents);

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
                var singleEvent = await _repository.GetEventByIdAsync(eventId, true);

                var result = _mapper.Map<EventDto>(singleEvent);

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
                var listEvents = await _repository.GetAllEventByNameAsync(name, true);

                var results = _mapper.Map<IEnumerable<EventDto>>(listEvents);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto model)
        {
            try
            {
                var singleEvent = _mapper.Map<Event>(model);

                _repository.Add(singleEvent);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{model.EventId}", _mapper.Map<EventDto>(singleEvent));
                }

            } 
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database access failed");
            }

            return BadRequest();
        }

        [HttpPut("{EventId}")]
        public async Task<IActionResult> Put(int eventId, EventDto model)
        {
            try
            {
                var eventTarget = await _repository.GetEventByIdAsync(eventId, false);
                
                if (eventTarget == null)
                    return NotFound();

                _mapper.Map(model, eventTarget);

                _repository.Update(eventTarget);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/event/{model.EventId}", _mapper.Map<EventDto>(eventTarget));
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
