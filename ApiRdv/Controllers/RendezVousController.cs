using ApiRdv.Services;
using ApiRdv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRdv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly RendezVousService _service;

        public RendezVousController(RendezVousService service)
        {
            _service = service;
        }
        [HttpGet] public IActionResult GetAllRendezVous() 
        {
         var rendezVous= _service.GetAllRendezvous();
            return Ok(rendezVous);
        }
        [HttpGet("{id}")]
        public IActionResult GetRendezVousById(int id)
        {
            var rendezVous= _service.GetRendezVousById(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            return Ok(rendezVous);
        }
        [HttpPost]
        public IActionResult CreateRendezVous([FromBody] RendezVous rendezVous)
            {
        _service.CreateRendezVous(rendezVous);
            return CreatedAtAction(nameof(GetRendezVousById),new { Id = rendezVous });

        }
        [HttpPut("{id}")]
        public IActionResult UpdateRendezVous(int id, [FromBody]RendezVous updatedRendezVous)
        {
                _service.UpdateRendezVous(id, updatedRendezVous);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRendezVous(int id) 
        { 
        _service.DeleteRendezVous(id);
            return NoContent();
        }
    
    
    
    
    }
}
