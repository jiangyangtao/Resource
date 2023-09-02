using Microsoft.EntityFrameworkCore;
using Resource.Model.Base;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Model
{
    public class System : BaseEntity
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string? SystemCode { set; get; }

        public string? SystemName { set; get; }

        /// <summary>
        /// 首页
        /// </summary>
        public string HomePage { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }

    public class SystemQueryParams : PaginationBase
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string? SystemCode { set; get; }

        public string? SystemName { set; get; }

        public IQueryable<System> GetSystemQueryable(IEntityRepositoryProvider<System> systemRepository)
        {
            var query = systemRepository.Get();
            if (SystemCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.SystemCode, $"%{SystemCode}%"));
            if (SystemName.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.SystemName, $"%{SystemName}%"));

            return query;
        }
    }
}