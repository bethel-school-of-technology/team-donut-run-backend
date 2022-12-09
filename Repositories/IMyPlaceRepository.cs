using rexfinder_api.Models;
namespace rexfinder_api.Repositories;

public interface IMyPlaceRepository
{
    MyPlace GetMyPlaceById(int myPlaceId);
    MyPlace CreateMyPlace(MyPlace newMyPlace);
    MyPlace UpdateMyPlace(MyPlace updatedMyPlace);
    void DeleteMyPlaceById(int myPlaceId);
    IEnumerable<MyPlace> GetAllMyPlacesByUserId(int userId);
    MyPlace GetMyPlaceByUserIdGoogleId(int userId, string googlePlaceId);
}