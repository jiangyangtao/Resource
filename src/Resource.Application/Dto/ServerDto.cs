using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Resource.Enums;
using Resource.Model;
using System.ComponentModel.DataAnnotations;
using Yangtao.Hosting.Mvc.FormatResult;

namespace Resource.Application.Dto
{
    public class ServerDtoBase
    {
        [Required]
        public string ServerInstanceId { set; get; }
    }

    public class ServerDeployeResult : ServerDtoBase
    {
        public ServerDeployeResult() { }

        public ServerDeployeResult(ServerDeploye serverDeploye)
        {
            ServerInstanceId = serverDeploye.InstanceId;
            EnvironmentCode = serverDeploye.EnvironmentCode;
            PublicIPAddress = serverDeploye.PublicIPAddress;
            IntranetIPAddress = serverDeploye.IntranetIPAddress;
        }


        /// <summary>
        /// 环境代码
        /// </summary>
        [Required]
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

    public class ServerDto : ServerDeployeResult
    {
        /// <summary>
        /// 服务器类型
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServerType? ServerType { set; get; }

        /// <summary>
        /// 云平台
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CloudPlatform? CloudPlatform { set; get; }

        /// <summary>
        /// 服务器类别
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceCategory? ServiceCategory { set; get; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.OperatingSystem? OperatingSystem { set; get; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string? OperatingSystemVersion { set; get; }

        /// <summary>
        /// 所在区域
        /// </summary>
        public string? LocatedArea { set; get; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpirationTime { set; get; }

        /// <summary>
        /// CPU
        /// </summary>
        [Required]
        public int? CPU { set; get; }

        /// <summary>
        /// 内存
        /// </summary>
        [Required]
        public int? Memory { set; get; }

        /// <summary>
        /// 硬盘容量
        /// </summary>
        public int? HardDiskCapacity { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public Server GetServer()
        {
            return new Server
            {
                InstanceId = ServerInstanceId,
                EnvironmentCode = EnvironmentCode,
                PublicIPAddress = EnvironmentCode,
                IntranetIPAddress = EnvironmentCode,
                ServerType = ServerType.Value,
                CloudPlatform = CloudPlatform.Value,
                ServiceCategory = ServiceCategory.Value,
                OperatingSystem = OperatingSystem.Value,
                OperatingSystemVersion = OperatingSystemVersion,
                LocatedArea = LocatedArea,
                ExpirationTime = ExpirationTime,
                CPU = CPU.Value,
                Memory = Memory.Value,
                HardDiskCapacity = HardDiskCapacity,
                Description = Description,
            };
        }
    }

    public class ServerQueryDto : PagingParameter
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
        [JsonConverter(typeof(StringEnumConverter))]
        public ServerType? ServerType { set; get; }

        /// <summary>
        /// 云平台
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CloudPlatform? CloudPlatform { set; get; }

        /// <summary>
        /// 服务器类别
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceCategory? ServiceCategory { set; get; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
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

        public ServerQueryParams GetServerQueryParams()
        {
            return new ServerQueryParams
            {
                InstanceId = InstanceId,
                EnvironmentCode = EnvironmentCode,
                PublicIPAddress = EnvironmentCode,
                IntranetIPAddress = EnvironmentCode,
                ServerType = ServerType,
                CloudPlatform = CloudPlatform,
                ServiceCategory = ServiceCategory,
                OperatingSystem = OperatingSystem,
                OperatingSystemVersion = OperatingSystemVersion,
                LocatedArea = LocatedArea,
                CPU = CPU,
                Memory = Memory,
                Start = startIndex,
                Size = size,
            };
        }
    }

    public class ServerResult : ServerDto
    {
        public ServerResult(Server server)
        {
            ServerInstanceId = server.InstanceId;
            EnvironmentCode = server.EnvironmentCode;
            PublicIPAddress = server.EnvironmentCode;
            IntranetIPAddress = server.EnvironmentCode;
            ServerType = server.ServerType;
            CloudPlatform = server.CloudPlatform;
            ServiceCategory = server.ServiceCategory;
            OperatingSystem = server.OperatingSystem;
            OperatingSystemVersion = server.OperatingSystemVersion;
            LocatedArea = server.LocatedArea;
            ExpirationTime = server.ExpirationTime;
            CPU = server.CPU;
            Memory = server.Memory;
            HardDiskCapacity = server.HardDiskCapacity;
            Description = server.Description;

            ServerStatus = ServerStatus.Effective;
            if (ExpirationTime > DateTime.Now) ServerStatus = ServerStatus.Expired;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServerStatus ServerStatus { set; get; }
    }

    public class ServerPaginationResult : PaginationResult<ServerResult>
    {
        public ServerPaginationResult(Server[] servers, long count) : base(count)
        {
            List = servers.Select(a => new ServerResult(a)).ToArray();
        }
    }
}
