
namespace PokemonReviewApp.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetByName(string name)
        {
            // This assumes the entity has a "Name" property
            return _dbSet.FirstOrDefault(e => EF.Property<string>(e, "Name") == name);
        }

        public bool Exists(int id)
        {
            return _dbSet.Find(id) != null;
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
