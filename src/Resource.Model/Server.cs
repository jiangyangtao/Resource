using Yangtao.Hosting.Repository.Abstractions;
using System.ComponentModel.DataAnnotations;
using Resource.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Resource.Model.Base;
using Microsoft.EntityFrameworkCore;
using Yangtao.Hosting.Extensions;

namespace Resource.Model
{
    public class Server : BaseEntity
    {
        /// <summary>
        /// 实例标识
        /// </summary>
        [Key]
        public string InstanceId { set; get; }

        /// <summary>
        /// 环境代码
        /// </summary>
        public string EnvironmentCode { set; get; }

        /// <summary>
        /// 环境信息
        /// </summary>
        [NotMapped]
        public Environment Environment { set; get; }

        /// <summary>
        /// 公网IP地址
        /// </summary>
        public string PublicIPAddress { set; get; }

        /// <summary>
        /// 内网IP地址
        /// </summary>
        public string IntranetIPAddress { set; get; }

        /// <summary>
        /// 服务器类型
        /// </summary>
        public ServerType ServerType { set; get; }

        /// <summary>
        /// 云平台
        /// </summary>
        public CloudPlatform? CloudPlatform { set; get; }

        /// <summary>
        /// 服务器类别
        /// </summary>
        public ServiceCategory ServiceCategory { set; get; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public Enums.OperatingSystem OperatingSystem { set; get; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string OperatingSystemVersion { set; get; }

        /// <summary>
        /// 所在区域
        /// </summary>
        public string LocatedArea { set; get; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpirationTime { set; get; }

        /// <summary>
        /// CPU
        /// </summary>
        public int CPU { set; get; }

        /// <summary>
        /// 内存
        /// </summary>
        public int Memory { set; get; }

        /// <summary>
        /// 硬盘容量
        /// </summary>
        public int? HardDiskCapacity { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }

    public class ServerDeploye
    {
        /// <summary>
        /// 实例标识
        /// </summary>
        public string InstanceId { set; get; }

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
    }

    public class ServerQueryParams : PaginationBase
    {
        /// <summary>
        /// 实例标识
        /// </summary>
        public string InstanceId { set; get; }

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
        /// 服务器类型
        /// </summary>
        public ServerType? ServerType { set; get; }

        /// <summary>
        /// 云平台
        /// </summary>
        public CloudPlatform? CloudPlatform { set; get; }

        /// <summary>
        /// 服务器类别
        /// </summary>
        public ServiceCategory? ServiceCategory { set; get; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public Enums.OperatingSystem? OperatingSystem { set; get; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string OperatingSystemVersion { set; get; }

        /// <summary>
        /// 所在区域
        /// </summary>
        public string LocatedArea { set; get; }

        /// <summary>
        /// CPU
        /// </summary>
        public int? CPU { set; get; }

        /// <summary>
        /// 内存
        /// </summary>
        public int? Memory { set; get; }

        public IQueryable<Server> GetQueryable(IEntityRepositoryProvider<Server> repositoryProvider)
        {
            var query = repositoryProvider.Get();
            if (InstanceId.NotNullAndEmpty()) query = query.Where(a => a.InstanceId == InstanceId);
            if (EnvironmentCode.NotNullAndEmpty()) query = query.Where(a => a.EnvironmentCode == EnvironmentCode);
            if (PublicIPAddress.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.PublicIPAddress, $"{PublicIPAddress}"));
            if (IntranetIPAddress.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.IntranetIPAddress, $"{IntranetIPAddress}"));
            if (ServerType.HasValue) query = query.Where(a => a.ServerType == ServerType.Value);
            if (CloudPlatform.HasValue) query = query.Where(a => a.CloudPlatform == CloudPlatform.Value);
            if (ServiceCategory.HasValue) query = query.Where(a => a.ServiceCategory == ServiceCategory.Value);
            if (OperatingSystem.HasValue) query = query.Where(a => a.OperatingSystem == OperatingSystem.Value);
            if (LocatedArea.NotNullAndEmpty()) query = query.Where(a => a.LocatedArea == LocatedArea);
            if (CPU.HasValue) query = query.Where(a => a.CPU == CPU);
            if (Memory.HasValue) query = query.Where(a => a.Memory == Memory);

            return query;
        }
    }
}
