using Resource.Enums;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Models
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
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
