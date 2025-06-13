using Microsoft.AspNetCore.Mvc;
using PlantCareAPI.Data;
using PlantCareAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlantsController(AppDbContext context)
    {
        _context = context;
    }

}