
using Microsoft.AspNetCore.Mvc;
using rexfinder_api.Models;
using rexfinder_api.Repositories;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DonutShopController: ControllerBase
{
    private readonly ILogger<DonutShopController> _logger;
    private readonly IDonutShopRepository _donutShopRepository;
    
    public DonutShopController(ILogger<DonutShopController> logger, IDonutShopRepository repository)
    {
        _logger = logger;
        _donutShopRepository = repository;
    }

    [HttpGet]
    [Route("{donutShopId:int}")]
    public ActionResult<DonutShop> GetDonutShopById(int donutShopId)
    {
        var DonutShop = _donutShopRepository.GetDonutShopById(donutShopId);

        if (DonutShop == null)
        {
            return NotFound();
        }

        return Ok(DonutShop);
    }

    [HttpPost]
    public ActionResult<DonutShop> CreateDonutShop(DonutShop newDonutShop)
    {
        if (!ModelState.IsValid || newDonutShop == null)
        {
            return BadRequest();
        }

        var createdDonutShop = _donutShopRepository.CreateDonutShop(newDonutShop);
        return Created(nameof(GetDonutShopById), createdDonutShop);
    }

    [HttpPut]
    [Route("edit/{donutShopId:int}")]

    public ActionResult<DonutShop> UpdateDonutShop(DonutShop updatedDonutShop)
    {
        if (!ModelState.IsValid || updatedDonutShop == null)
        {
            return BadRequest();
        }

        return Ok(_donutShopRepository.UpdateDonutShop(updatedDonutShop));
    }

    [HttpDelete]
    [Route("{donutShopId:int}")]

    public ActionResult DeleteDonutShopById(int donutShopId)
    {
        _donutShopRepository.DeleteDonutShopById(donutShopId);
        return NoContent();
    }
}