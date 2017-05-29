
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:53:25. All Rights Reserved.
//<生成时间>2017-05-25T22:53:25</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
	/// <summary>
    /// 用户管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(T_User))]
    public class T_UserListDto : EntityDto<int>
    {
        public      int FK_StaffId { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        public      int LoginNo { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public      string PassWord { get; set; }
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [DisplayName("微信OpenId")]
        public      string OpenId { get; set; }
        public      DateTime? CreteTime { get; set; }
    }
}
