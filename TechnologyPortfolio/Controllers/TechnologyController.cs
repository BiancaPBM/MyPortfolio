using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnologyPortfolio.Data;
using TechnologyPortfolio.Data.Repository;

namespace TechnologyPortfolio.Controllers
{   [ApiController]
    [Route("api/v0/technology")]
    public class TechnologyController : Controller
    {
    private TechnologyRepository _repository;
    public TechnologyController( TechnologyRepository repository)
    {
      _repository = repository;
    }
    [HttpGet("getall")]
    public IActionResult GetAllTechnologies()
    {
      var result = _repository.GetAllTechnologies();
      if (result.Count == 0)
        return NoContent();
      return Ok(result);
    }
    [HttpGet("{id}", Name = "getTech")]
    public IActionResult GetTechnoloyById(Guid id)
    {
      return Ok(_repository.GetTechnologyById(id));
    }
    [HttpPost]
    public IActionResult CreateTechnology([FromBody] Technology technology)
    {
       _repository.CreateTechnoloy(technology);
      return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateTechnology([FromBody] TechnologyForUpdate technology, Guid id)
    {
      var tech = _repository.GetTechnologyById(id);
      tech.Description = technology.Description;
      tech.Url = technology.Url;
      if (tech == null)
        return NotFound();

      _repository.UpdateTechnoloy(tech);
      return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleleteTechnology(Guid id)
    {
      _repository.DeleteTechnology(id);
      return Ok();
    }
  }
}
