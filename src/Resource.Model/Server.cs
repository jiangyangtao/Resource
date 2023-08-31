using Yangtao.Hosting.Repository.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Resource.Model
{
    public class Server : BaseEntity
    {
        /// <summary>
        /// 实例标识
        /// </summary>
        [Key]
        public string ServerInstanceId { set; get; }

        /// <summary>
        /// 环境代码
        /// </summary>
        public string EnvironmentCode { set; get; }

        /// <summary>
        /// 公网IP地址
        /// </summary>
        public string PublicIPAddress { set; get; }

        /// <summary>
        /// 内网IP地址
        /// </summary>
        public string IntranetIPAddress { set; get; }

        /// <summary>
        /// CPU
        /// </summary>
        public int CPU { set; get; }

        /// <summary>
        /// 内存
        /// </summary>
        public decimal Memory { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
