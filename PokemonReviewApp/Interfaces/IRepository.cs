namespace PokemonReviewApp.Interface
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        bool Exists(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
