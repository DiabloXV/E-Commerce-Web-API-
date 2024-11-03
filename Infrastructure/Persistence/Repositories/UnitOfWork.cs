
using System.Collections.Concurrent;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private readonly ConcurrentDictionary<string, object> _repositories; //Using Concurrent Dictionary to Keep the object that GetRepository uses safe if it was used by multiple threads

        public UnitOfWork(StoreContext storeContext, Dictionary<string, object> repositories)
        {
            _storeContext = storeContext;
            _repositories = new();
        }

        public Task<int> SaveChangesAsync() => _storeContext.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
             => (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, TKey>(_storeContext));
        //var typeName = typeof(TEntity).Name;

        //if(_repositories.ContainsKey(typeName)) return (IGenericRepository<TEntity, TKey>)_repositories[typeName];

        //var repo = new GenericRepository <TEntity, TKey>(_storeContext);

        //_repositories.Add(typeName, repo);

        //return repo;


    }

}
