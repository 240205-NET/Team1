using RecipeAPI.Model;

namespace RecipeAPI.Repository 
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        abstract Task<IEnumerable<TEntity>> GetAll();
        abstract Task<TEntity?> GetById(int id);
        abstract Task Add(TEntity ent);
        abstract Task DeleteByID(int id);

    }
}