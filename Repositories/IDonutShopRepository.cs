using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public interface IDonutShopRepository
{
    DonutShop GetDonutShopById(int donutShopId);
    DonutShop CreateDonutShop(DonutShop newDonutShop);
    DonutShop UpdateDonutShop(DonutShop updatedDonutShop);
    void DeleteDonutShopById(int donutShopId);
}