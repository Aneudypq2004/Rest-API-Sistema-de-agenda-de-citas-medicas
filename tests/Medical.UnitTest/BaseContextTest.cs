using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Medical.UnitTest
{
    public class BaseContextTest : IDisposable
    {
        protected readonly ApplicationDbContext _context;

        public BaseContextTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
                
            this._context = new ApplicationDbContext(options);
            this._context.Database.EnsureCreated();


        }
        public void Dispose()
        {
            this._context.Database.EnsureDeleted();
            this._context.Dispose();
        }
    }
}
