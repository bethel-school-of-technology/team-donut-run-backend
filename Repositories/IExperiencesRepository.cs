using rexfinder_api.Models;
namespace rexfinder_api.Repositories;

public interface IExperiencesRepository
{
    Experiences GetExperiencesById(int experienceId);
    Experiences CreateExperience(Experiences newExperience);
    Experiences UpdateExperience(Experiences updatedExperience);
    void DeleteExperienceById(int experienceId);
    IEnumerable<Experiences> GetAllExperiencesByUserId(int userId);
    Experiences GetExperiencesByUserIdGoogleId(int userId, string googlePlaceId);
}