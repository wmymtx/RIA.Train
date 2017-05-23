namespace RIA.Train
{
    public class TrainConsts
    {
        public const string LocalizationSourceName = "听课系统";

        public const bool MultiTenancyEnabled = false;

        /// <summary>
        /// 名字最大长度
        /// </summary>
        public const int MaxNameLength = 32;
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;
        /// <summary>
        /// 邮件地址最大长度
        /// </summary>
        public const int MaxEmailAddressLength = 255;

        /// <summary>
        /// 数据库架构名
        /// </summary>
        public static class SchemaName
        {
            /// <summary>
            /// 基础设置
            /// </summary>
            public const string Basic = "Basic";

            /// <summary>
            /// 模块管理
            /// </summary>
            public const string Moudle = "Moudle";

            /// <summary>
            /// 网站设置
            /// </summary>
            public const string WebSetting = "WebSetting";
            /// <summary>
            /// 用于对多对表关系的结构
            /// </summary>
            public const string HasMany = "HasMany";

            /// <summary>
            /// 业务
            /// </summary>
            public const string Business = "Business";

        }
    }
}