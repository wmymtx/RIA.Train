
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T21:42:06. All Rights Reserved.
//<生成时间>2017-05-21T21:42:06</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
	/// <summary>
    /// 培训项目设置列表Dto
    /// </summary>
    [AutoMapFrom(typeof(T_Item))]
    public class T_ItemListDto : EntityDto<int>
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [DisplayName("项目名称")]
        public      string ProjectName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime? CreateTime { get; set; }
    }
}
