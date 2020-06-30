using AngularDotNetProject.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace AngularDotNetProject.API
{
    public class TestConnection : ITestConnection
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private string _connectionString = string.Empty;

        public TestConnection(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _connectionString = _applicationDbContext.Database.GetDbConnection().ConnectionString;
        }

        public string TestCon()
        {
            return _connectionString;
        }
    }

    public interface ITestConnection
    {
        string TestCon();

    }
}
