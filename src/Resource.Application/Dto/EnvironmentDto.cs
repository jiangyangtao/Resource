using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Resource.Enums;
using Resource.Model;
using System.ComponentModel.DataAnnotations;
using Yangtao.Hosting.Mvc.FormatResult;
using Environment = Resource.Model.Environment;

namespace Resource.Application.Dto
{
    public class EnvironmentDtoBase
    {
        [Required]
        public string EnvironmentCode { set; get; }
    }

    public class EnvironmentDto : EnvironmentDtoBase
    {
        /// <summary>
        /// 环境名称
        /// </summary>
        [Required]
        public string EnvironmentName { set; get; }

        /// <summary>
        /// 环境类型
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnvironmentType? EnvironmentType { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public Environment GetEnvironment()
        {
            return new Environment
            {
                EnvironmentCode = EnvironmentCode,
                EnvironmentName = EnvironmentName,
                EnvironmentType = EnvironmentType.Value,
                Description = Description,
            };
        }
    }

    public class EnvironmentQueryDto : PagingParameter
    {
        /// <summary>
        /// 环境代码
        /// </summary>
        public string? environmentCode { set; get; }

        /// <summary>
        /// 环境名称
        /// </summary>
        public string? environmentName { set; get; }

        /// <summary>
        /// 环境类型
        /// </summary>
        public EnvironmentType? environmentType { set; get; }

        /// <summary>
        /// 环境状态
        /// </summary>
        public EnvironmentStatus? environmentStatus { set; get; }

        public EnvironmentQueryParams GetEnvironmentQueryParams()
        {
            return new EnvironmentQueryParams
            {
                EnvironmentCode = environmentCode,
                EnvironmentName = environmentName,
                EnvironmentType = environmentType,
                EnvironmentStatus = environmentStatus,
                Start = startIndex,
                Size = size,
            };
        }
    }

    public class EnvironmentResult : EnvironmentDto
    {
        public EnvironmentResult(Environment environment)
        {
            EnvironmentCode = environment.EnvironmentCode;
            EnvironmentName = environment.EnvironmentName;
            EnvironmentType = environment.EnvironmentType;
            EnvironmentStatus = environment.EnvironmentStatus;
            Description = environment.Description;
        }

        /// <summary>
        /// 环境状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EnvironmentStatus EnvironmentStatus { set; get; }
    }

    public class EnvironmentPaginationResult : PaginationResult<EnvironmentResult>
    {
        public EnvironmentPaginationResult(Environment[] environments, long count) : base(count)
        {
            List = environments.Select(a => new EnvironmentResult(a)).ToArray();
        }
    }
}
