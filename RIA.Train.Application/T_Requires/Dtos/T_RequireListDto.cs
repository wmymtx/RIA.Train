
// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-06-04T21:10:25. All Rights Reserved.
//<生成时间>2017-06-04T21:10:25</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
    /// <summary>
    /// 培训需求提报列表Dto
    /// </summary>
    [AutoMapFrom(typeof(T_Require))]
    public class T_RequireListDto : EntityDto<int>
    {
        public int Fk_Item_Require_Id { get; set; }
        /// <summary>
        /// 参培人员
        /// </summary>
        [DisplayName("参培人员")]
        public int Fk_Require_UserId { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [DisplayName("名字")]
        public string UserName { get; set; }
        /// <summary>
        /// 提报内容
        /// </summary>
        [DisplayName("提报内容")]
        public string Content { get; set; }
        public string CheckKPoint { get; set; }
        public string ChectKPointId { get; set; }
        /// <summary>
        /// 提报时间
        /// </summary>
        [DisplayName("提报时间")]
        public DateTime? SubmitTime { get; set; }

        public T_Item T_Item { get; set; }
    }
}
