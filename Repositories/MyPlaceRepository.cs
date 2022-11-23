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

    // POST / create new my place with current user id
    public MyPlace CreateMyPlace(MyPlace newMyPlace)
    {
        newMyPlace.CreatedOn = DateTime.Now.ToString();
        _context.MyPlaces.Add(newMyPlace);
        _context.SaveChanges();
        return newMyPlace;
    }

    // DELETE / delete my place by my place id
    public void DeleteMyPlaceById(int myPlaceId)
    {
        var myPlace = _context.MyPlaces.Find(myPlaceId);
        if (myPlace != null)
        {
            _context.MyPlaces.Remove(myPlace);
            _context.SaveChanges();
        }
    }

    // GET / get all my places by user id
    public IEnumerable<MyPlace> GetAllMyPlacesByUserId(int userId)
    {
        var placeList = _context.MyPlaces.Where(p => p.UserId == userId).ToList();
        return placeList;
    }

    // GET / get one my place by my place id
    public MyPlace GetMyPlaceById(int myPlaceId)
    {
        return _context.MyPlaces.SingleOrDefault(mp => mp.MyPlaceId == myPlaceId);

    }

    // GET / get my place by user id and google place id (check if user has saved a place)
    public MyPlace GetMyPlaceByUserIdGoogleId(int userId, string googlePlaceId)
    {
        var placeList = this.GetAllMyPlacesByUserId(userId);

        // var foundPlace = placeList.SingleOrDefault(pl => pl.GooglePlaceId == googlePlaceId);
        // This returns an error if there is more than one value that meets the search, so we'll need to make sure each place can only be saved to each user once (unless we change to adding the values to a list but I don't think that's a good idea)

         var foundPlace = placeList.FirstOrDefault(pl => pl.GooglePlaceId == googlePlaceId);
         // This works to return the first occurrence of the place for that user

        return foundPlace;
    }

    // PUT / update my place by my place id
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