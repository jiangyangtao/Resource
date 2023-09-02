using Microsoft.EntityFrameworkCore;
using Resource.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Model
{
    public class Application : BaseEntity
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { set; get; }

        [NotMapped]
        public System System { set; get; }

        /// <summary>
        /// 应用标识
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { set; get; }

        /// <summary>
        /// 应用描述
        /// </summary>
        public string Description { set; get; }
    }

    public class ApplicationQueryParams : PaginationBase
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { set; get; }

        /// <summary>
        /// 应用标识
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { set; get; }

        public IQueryable<Application> GetApplicationQueryable(IEntityRepositoryProvider<Application> repositoryProvider)
        {
            var query = repositoryProvider.Get();
            if (SystemCode.NotNullAndEmpty()) query = query.Where(a => a.SystemCode == SystemCode);
            if (ApplicationCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.ApplicationCode, $"%{ApplicationCode}%"));
            if (SystemCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.ApplicationName, $"%{ApplicationName}%"));

            return query;
        }
    }
}
