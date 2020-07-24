using System.Linq;
using System.Threading.Tasks;
using AngularDotNetProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularDotNetProject.Repository.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GENERIC
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENT
        public async Task<Event[]> GetAllEventAsync(bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderBy(e => e.EventId);

            return await query.ToArrayAsync();

        }
        public async Task<Event> GetEventByIdAsync(int eventId, bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderByDescending(e => e.EventDate)
                .Where(e => e.EventId == eventId);
                  

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Event[]> GetAllEventByNameAsync(string name, bool includeHeadline = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Releases)
                .Include(e => e.SocialNetworks);

            if (includeHeadline)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(h => h.Headline);
            }

            query = query.OrderByDescending(e => e.EventDate)
                .Where(e => e.Name.ToLower().Contains(name.ToLower()));
                  

            return await query.ToArrayAsync();
        }

        //HEADLINE
        public async Task<Headline> GetHeadlineByIdAsync(int headlineId, bool includeEvent = false)
        {
            IQueryable<Headline> query = _context.Headlines
                .Include(h => h.SocialNetworks);

            if (includeEvent)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(h => h.Name)
                .Where(h => h.HeadlineId == headlineId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Headline[]> GetAllHeadlineByNameAsync(string name, bool includeEvent = false)
        {
            IQueryable<Headline> query = _context.Headlines
                .Include(h => h.SocialNetworks);

            if (includeEvent)
            {
                query = query
                    .Include(he => he.HeadlineEvents)
                    .ThenInclude(e => e.Event);
            }

            query = query.Where(h => h.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
