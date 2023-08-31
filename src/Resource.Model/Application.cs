﻿using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Models
{
    public class Application : BaseEntity
    {
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { set; get; }

        /// <summary>
        /// 应用标识
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { set; get; }
    }
}