using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.RepositoryManager
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id); //Id ile data getirir
        IEnumerable<TEntity> GetAll(); //bir tablodaki bütün dataları getirir.
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //verilen data için bulma işlemi yapar
        void Update(TEntity entity);
        void Add(TEntity entity); //ekleme
        void AddRange(IEnumerable<TEntity> entities); //toplu ekleme
        void Remove(TEntity entity);//silme
        void RemoveRange(IEnumerable<TEntity> entities);//Toplu silme
    }
}
