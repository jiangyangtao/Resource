
namespace Resource.Enums
{
    /// <summary>
    /// 服务器类型
    /// </summary>
    public enum ServerType
    {
        /// <summary>
        /// 云服务器
        /// </summary>
        CloudServer,

        /// <summary>
        /// 物理服务器
        /// </summary>
        PhysicalServer
    }

    public enum CloudPlatform
    {
        /// <summary>
        /// 阿里云
        /// </summary>
        AliYun,

        /// <summary>
        /// 腾讯云
        /// </summary>
        TencentCloud,

        /// <summary>
        /// 华为云
        /// </summary>
        HuaweiCloud
    }

    /// <summary>
    /// 服务器类别
    /// </summary>
    public enum ServiceCategory
    {
        /// <summary>
        /// 常规云服务器
        /// </summary>
        NormalServer,

        /// <summary>
        /// 轻量应用服务器
        /// </summary>
        SimpleApplicationServer
    }

    /// <summary>
    /// 操作系统
    /// </summary>
    public enum OperatingSystem
    {
        WindowServer,

        CentOS,

        Ubuntu,

        Debian
    }
}
