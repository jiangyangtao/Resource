using System.Linq.Expressions;

namespace Resource.Repository.Abstractions
{
    public interface IEntityColumns<TEntity> : IEnumerable<Expression<Func<TEntity, object>>> where TEntity : BaseEntity
    {
        public void Add(Expression<Func<TEntity, object>> expression);

        public void Remove(Expression<Func<TEntity, object>> expression);

        public bool IsEmpty { get; }

        public string[] GetColumns();
    }
}
