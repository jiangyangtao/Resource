using System.Linq.Expressions;

namespace Resource.Repository.Abstractions
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEntityColumns<TEntity> CreateEntityColumnExpressions();

        // <summary>
        /// 添加一条数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity, bool isCommit = true);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> AddRangeAsync(IEnumerable<TEntity> entities, bool isCommit = true);

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, bool isCommit = true);

        Task<TEntity> UpdatePartAsync(TEntity entity, Expression<Func<TEntity, object>> updateColumns, bool isCommit = true);

        Task<TEntity> UpdatePartAsync(TEntity entity, IEntityColumns<TEntity> updateColumns, bool isCommit = true);

        Task<TEntity> UpdatePropertyAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression, bool isCommit = true);

        Task<long> UpdateRangePartAsync(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> updateColumns, bool isCommit = true);

        Task<long> UpdateRangePartAsync((TEntity entities, IEntityColumns<TEntity> updateColumns)[] values, bool isCommit = true);

        Task<long> UpdateRangePropertyAsync<TProperty>(TEntity[] entities, Expression<Func<TEntity, TProperty>> propertyExpression, bool isCommit = true);

        Task<TEntity> UpdateIfExistByIdAsync(string id, Action<TEntity> action, bool isCommit = true);

        Task<TEntity> UpdateIfExistAsync(Expression<Func<TEntity, bool>> predicate, Action<TEntity> action, bool isCommit = true);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> UpdateRangeAsync(TEntity[] entities, bool isCommit = true);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> DeleteIfExistAsync(Expression<Func<TEntity, bool>> predicate, bool isCommit = true);

        /// <summary>
        /// 根据 Id 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(string id, bool isCommit = true);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> DeleteAsync(TEntity entity, bool isCommit = true);

        /// <summary>
        /// 删除一个对象的所有数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> DeleteAllAsync(bool isCommit = true);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<long> DeleteRangeAsync(ICollection<TEntity> entities, bool isCommit = true);

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        Task<long> CommitAsync();

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        /// 获取一个 IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// 获取一个 IQueryable
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}
