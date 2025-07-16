using ProductProject.Models.Entities;

namespace ProductProject.Domain.Interface
{
    public interface IProductRepository <T> where T : class
    {
        
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }

}
