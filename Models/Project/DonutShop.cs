using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

public class DonutShop
{
    [Required]
    public int DonutShopId { get; set; }
    public string DonutShopName { get; set; }
    public string DonutShopAddress { get; set; }
    public string DonutShopWebsite { get; set; }
    public string DonutShopImage { get; set; }
}