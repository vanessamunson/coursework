using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BloggerAPI.Test.Helper;

internal class DatabaseHelper
{
    public static BloggerDbContext GetDatabase()
    {
        var _contextOptions = new DbContextOptionsBuilder<BloggerDbContext>()
        .UseInMemoryDatabase("TestDatabase")
        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;


        var databaseObj = new BloggerDbContext(_contextOptions);
        databaseObj.Database.EnsureDeleted();
        databaseObj.Database.EnsureCreated();

        return databaseObj;
    }
}
