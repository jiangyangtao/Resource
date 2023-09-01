using System.ComponentModel.DataAnnotations;

namespace Resource.Enums
{
    public enum EnvironmentType
    {
        /// <summary>
        /// 开发
        /// </summary>
        [Display(Name = "开发")]
        Development,

        /// <summary>
        /// 测试
        /// </summary>
        [Display(Name = "测试")]
        UserAcceptanceTest,

        /// <summary>
        /// 生产
        /// </summary>
        [Display(Name = "生产")]
        Production
    }

    public enum EnvironmentStatus
    {
        Useing,

        Discarded,
    }
}