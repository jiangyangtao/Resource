using Resource.Model;
using System.ComponentModel.DataAnnotations;
using Yangtao.Hosting.Mvc.FormatResult;

namespace Resource.Application.Dto
{
    public class SystemDtoBase
    {
        [Required]
        public string SystemCode { set; get; }
    }

    public class SystemDto : SystemDtoBase
    {
        [Required]
        public string? SystemName { set; get; }

        /// <summary>
        /// 首页
        /// </summary>
        public string? HomePage { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        public Model.System GetSystem()
        {
            return new Model.System
            {
                SystemCode = SystemCode,
                SystemName = SystemName,
                HomePage = HomePage,
                Description = Description,
            };
        }
    }

    public class SystemQueryDto : PagingParameter
    {
        public string? systemCode { set; get; }

        public string? systemName { set; get; }

        public SystemQueryParams GetSystemQueryParams()
        {
            return new SystemQueryParams
            {
                SystemCode = systemCode,
                SystemName = systemName,
                Start = startIndex,
                Size = size,
            };
        }
    }

    public class SystemResult : SystemDto
    {
        public SystemResult(Model.System system)
        {
            SystemCode = SystemCode;
            SystemName = SystemName;
            HomePage = HomePage;
            Description = Description;
        }
    }

    public class SystemPaginationResult : PaginationResult<SystemResult>
    {
        public SystemPaginationResult(Model.System[] systems, long count) : base(count)
        {
            List = systems.Select(a => new SystemResult(a)).ToArray();
        }
    }
}
