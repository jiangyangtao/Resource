using System.Linq.Expressions;

namespace Resource.Repository.Abstractions
{
    public interface IEntityColumns<out TEntity> : IEnumerable<Expression<Func<IEntity, object>>> where TEntity : BaseEntity
    {
    }
}
