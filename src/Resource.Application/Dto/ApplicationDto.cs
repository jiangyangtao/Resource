using Resource.Model;
using System.ComponentModel.DataAnnotations;
using Yangtao.Hosting.Mvc.FormatResult;

namespace Resource.Application.Dto
{
    public class ApplicationDtoBase
    {
        [Required]
        public string ApplicationCode { set; get; }
    }


    public class ApplicationDto : ApplicationDtoBase
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        [Required]
        public string SystemCode { set; get; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [Required]
        public string ApplicationName { set; get; }

        /// <summary>
        /// 应用描述
        /// </summary>
        public string? Description { set; get; }

        public Model.Application GetApplication()
        {
            return new Model.Application
            {
                ApplicationCode = ApplicationCode,
                ApplicationName = ApplicationName,
                SystemCode = SystemCode,
                Description = Description,
            };
        }
    }



    public class ApplicationQueryDto : PagingParameter
    {
        public string? applicationCode { set; get; }

        public string? applicationName { set; get; }

        public string? systemCode { set; get; }

        public ApplicationQueryParams GetApplicationQueryParams()
        {
            return new ApplicationQueryParams
            {
                ApplicationCode = applicationCode,
                ApplicationName = applicationName,
                SystemCode = systemCode,
                Start = startIndex,
                Size = size,
            };
        }
    }

    public class ApplicationResult : ApplicationDto
    {
        public ApplicationResult(Model.Application application)
        {
            ApplicationCode = application.ApplicationCode;
            SystemCode = application.ApplicationCode;
            SystemName = application.System?.SystemName;
            ApplicationName = application.ApplicationName;
            Description = application.Description;
        }

        public string SystemName { set; get; }
    }

    public class ApplicationPaginationResult : PaginationResult<ApplicationResult>
    {
        public ApplicationPaginationResult(Model.Application[] applications, long count) : base(count)
        {
            List = applications.Select(a => new ApplicationResult(a)).ToArray();
        }
    }
}
