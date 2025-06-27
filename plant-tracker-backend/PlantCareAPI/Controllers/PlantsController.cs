using Microsoft.AspNetCore.Mvc;
using PlantCareAPI.Data;
using PlantCareAPI.LoggerService;
using PlantCareAPI.Models;

namespace PlantCareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController(AppDbContext context, ILoggerManager logger) : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnumerable<Plant>> GetAll()
    {
        logger.LogDebug("Get all plants");
        return Ok(context.Plants.ToList());
    }

    [HttpPost]
    public ActionResult<Plant> AddPlant([FromBody]Plant plant)
    {
        
        return Ok(context.Plants.Add(plant));
    }
    
    [HttpGet("{id}", Name = "GetPlant")]
    public ActionResult<Plant> GetPlant(int id)
    {
        var plant = context.Plants.Find(id);
        if (plant == null)
        {
            return NotFound();
        }
        return Ok(plant);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Plant> UpdatePlant(int id, Plant plant)
    {
        var existingPlant = context.Plants.Find(id);
        if (existingPlant == null)
        {
            return NotFound();
        }

        existingPlant.Name = plant.Name;
        existingPlant.Species = plant.Species;
        existingPlant.LastWatered = plant.LastWatered;
        existingPlant.Location = plant.Location;
        existingPlant.Notes = plant.Notes;

        context.SaveChanges();
        return Ok(existingPlant);
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeletePlant(int id)
    {
        var plant = context.Plants.Find(id);
        if (plant == null)
        {
            return NotFound();
        }

        context.Plants.Remove(plant);
        context.SaveChanges();
        return NoContent();
    }

}