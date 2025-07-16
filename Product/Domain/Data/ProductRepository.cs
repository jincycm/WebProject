using Microsoft.EntityFrameworkCore;
using ProductProject.Data;
using ProductProject.Domain.Interface;

namespace ProductProject.Domain.Data
{
    public class ProductRepository <T> : IProductRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbset.ToListAsync();
        }

        public void Create(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }


    }

}

