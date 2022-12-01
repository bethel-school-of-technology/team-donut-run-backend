using rexfinder_api.Migrations;
using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public class DonutShopRepository : IDonutShopRepository
{
    private readonly MyPlacesDbContext _context;

    public DonutShopRepository(MyPlacesDbContext context)
    {
        _context = context;
    }

    public DonutShop GetDonutShopById(int donutShopId)
    {
        return _context.DonutShop.SingleOrDefault(ds => ds.DonutShopId == donutShopId);
    }

    public DonutShop CreateDonutShop(DonutShop newDonutShop)
    {
        _context.DonutShop.Add(newDonutShop);
        _context.SaveChanges();
        return newDonutShop;
    }

    public DonutShop UpdateDonutShop(DonutShop updatedDonutShop)
    {
        var ogDonutShop = _context.DonutShop.Find(updatedDonutShop.DonutShopId);
        if (ogDonutShop != null)
        {
            ogDonutShop.DonutShopAddress = updatedDonutShop.DonutShopAddress;
            ogDonutShop.DonutShopName = updatedDonutShop.DonutShopName;
            ogDonutShop.DonutShopWebsite = updatedDonutShop.DonutShopWebsite;
            ogDonutShop.DonutShopCityState = updatedDonutShop.DonutShopCityState;
            _context.SaveChanges();
        }
        return ogDonutShop;
    }

    public void DeleteDonutShopById(int donutShopId)
    {
        var donutShop = _context.DonutShop.Find(donutShopId);
        if (donutShop != null)
        {
            _context.DonutShop.Remove(donutShop);
            _context.SaveChanges();
        }
    }
}