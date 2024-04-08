namespace FinalProject.Infrastructure.EFCore
{
    internal abstract class Repository<T> where T : class
    {
        protected WaigayaDbContext _context;
        public Repository(WaigayaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
