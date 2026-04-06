using Entities;
using Microsoft.EntityFrameworkCore;

namespace Interfaces
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }  
        void SaveChanges();
        void Update<T>(T entity);
        void Remove<T>(T entity);
    }
}
