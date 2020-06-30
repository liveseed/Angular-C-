using AngularDotNetProject.Domain.Domain;
using System.Threading.Tasks;

namespace AngularDotNetProject.Repository.Repository
{
    public interface IRepository
    {
        //GENERIC
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //EVENTS
        Task<Event[]> GetAllEventByNameAsync(string name, bool includeHeadline);
        Task<Event[]> GetAllEventAsync(bool includeHeadline);
        Task<Event> GetEventByIdAsync(int eventId, bool includeHeadline);

        //HEADLINE
        Task<Headline> GetHeadlineByIdAsync(int headlineId, bool includeEvent);
        Task<Headline[]> GetAllHeadlineByNameAsync(string name, bool includeEvent);
    }
}
