using rexfinder_api.Migrations;
using rexfinder_api.Models;
using rexfinder_api.Repositories;

public class ExperiencesRepository : IExperiencesRepository 
{
    private readonly MyPlacesDbContext _context;

    public ExperiencesRepository(MyPlacesDbContext context)
    {
        _context = context;
    }

    public Experiences CreateExperience(Experiences newExperience)
    {
        newExperience.CreatedOn = DateTime.Now.ToString();
        _context.Experiences.Add(newExperience);
        _context.SaveChanges();
        return newExperience;
    }

    public IEnumerable<Experiences> GetAllExperiences() {
        return _context.Experiences.ToList();
    }


    public IEnumerable<Experiences> GetAllExperiencesByUserId(int userId)
    {
        var experienceList = _context.Experiences.Where(e => e.UserId == userId).ToList();
        return experienceList;
    }

    public Experiences GetExperiencesById(int experienceId)
    {
        return _context.Experiences.SingleOrDefault(e => e.ExperienceId == experienceId);
    }

    public Experiences GetExperiencesByUserIdGoogleId(int userId, string googlePlaceId)
    {
        var experienceList = this.GetAllExperiencesByUserId(userId);

        var foundExperience = experienceList.FirstOrDefault(e => e.FirstGooglePlaceId == googlePlaceId);

        return foundExperience;
    }

    public Experiences UpdateExperience(Experiences updatedExperience)
    {
        var ogExperience = _context.Experiences.Find(updatedExperience.ExperienceId);
        if (ogExperience != null) {
            ogExperience.ExperienceTitle = updatedExperience.ExperienceTitle;
            ogExperience.ExperienceNotes = updatedExperience.ExperienceNotes;
            ogExperience.Completed = updatedExperience.Completed;
            ogExperience.ExperienceUserLocation = updatedExperience.ExperienceUserLocation;
            ogExperience.FirstGooglePlaceId = updatedExperience.FirstGooglePlaceId;
            ogExperience.SecondGooglePlaceId = updatedExperience.SecondGooglePlaceId;
            ogExperience.ThirdGooglePlaceId = updatedExperience.ThirdGooglePlaceId;
            _context.SaveChanges();
        }
        return ogExperience;
    }

    public void DeleteExperienceById(int experienceId)
    {
        var foundExperience = _context.Experiences.Find(experienceId);
        if (foundExperience != null)
        {
            _context.Experiences.Remove(foundExperience);
            _context.SaveChanges();
        }
    }
}