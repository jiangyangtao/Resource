using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Models
{
    public class System : BaseEntity
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { set; get; }

        public string SystemName { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }
}