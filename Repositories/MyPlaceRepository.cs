using rexfinder_api.Migrations;
using rexfinder_api.Models;
using rexfinder_api.Repositories;

public class MyPlaceRepository : IMyPlaceRepository
{
    private readonly MyPlacesDbContext _context;

    public MyPlaceRepository(MyPlacesDbContext context)
    {
        _context = context;
    }
    public MyPlace CreateMyPlace(MyPlace newMyPlace)
    {
        newMyPlace.CreatedOn = DateTime.Now.ToString();
        _context.MyPlaces.Add(newMyPlace);
        _context.SaveChanges();
        return newMyPlace;
    }

    public void DeleteMyPlaceById(int myPlaceId)
    {
        var myPlace = _context.MyPlaces.Find(myPlaceId);
        if (myPlace != null)
        {
            _context.MyPlaces.Remove(myPlace);
            _context.SaveChanges();
        }
    }

    public IEnumerable<MyPlace> GetAllMyPlacesByUserId(int userId)
    {
        var placeList = _context.MyPlaces.Where(p => p.UserId == userId).ToList();
        return placeList;

    }

    public MyPlace GetMyPlaceById(int myPlaceId)
    {
        return _context.MyPlaces.SingleOrDefault(mp => mp.MyPlaceId == myPlaceId);

    }

    public MyPlace UpdateMyPlace(MyPlace updatedMyPlace)
    {
        var ogMyPlace = _context.MyPlaces.Find(updatedMyPlace.MyPlaceId);
        if (ogMyPlace != null) {
            ogMyPlace.Visited = updatedMyPlace.Visited;
            _context.SaveChanges();
        }
        return ogMyPlace;
    }
}