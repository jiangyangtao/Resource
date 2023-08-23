namespace Resource.Repository.Abstractions
{
    public interface ICloneable<out TEntity> where TEntity : IEntity
    {
        TEntity Clone();
    }
}
