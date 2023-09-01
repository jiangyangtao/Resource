using Microsoft.EntityFrameworkCore;
using Resource.Enums;
using Resource.Model.Base;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Model
{
    public class Environment : BaseEntity
    {
        /// <summary>
        /// 环境代码
        /// </summary>
        public string EnvironmentCode { set; get; }

        /// <summary>
        /// 环境名称
        /// </summary>
        public string EnvironmentName { set; get; }

        /// <summary>
        /// 环境类型
        /// </summary>
        public EnvironmentType EnvironmentType { set; get; }

        /// <summary>
        /// 环境状态
        /// </summary>
        public EnvironmentStatus EnvironmentStatus { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }

    public class EnvironmentQueryParams : PaginationBase
    {
        /// <summary>
        /// 环境代码
        /// </summary>
        public string EnvironmentCode { set; get; }

        /// <summary>
        /// 环境名称
        /// </summary>
        public string EnvironmentName { set; get; }

        /// <summary>
        /// 环境类型
        /// </summary>
        public EnvironmentType? EnvironmentType { set; get; }

        /// <summary>
        /// 环境状态
        /// </summary>
        public EnvironmentStatus? EnvironmentStatus { set; get; }

        public IQueryable<Environment> GetEnvironmentQueryable(IEntityRepositoryProvider<Environment> environmentRepository)
        {
            var query = environmentRepository.Get();
            if (EnvironmentCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.EnvironmentCode, $"%{a.EnvironmentCode}%"));
            if (EnvironmentName.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.EnvironmentName, $"%{a.EnvironmentName}%"));
            if (EnvironmentType.HasValue) query = query.Where(a => a.EnvironmentType == EnvironmentType.Value);
            if (EnvironmentStatus.HasValue) query = query.Where(a => a.EnvironmentStatus == EnvironmentStatus.Value);

            return query;
        }
    }
}
