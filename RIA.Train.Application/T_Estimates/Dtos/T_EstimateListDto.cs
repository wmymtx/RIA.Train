﻿
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:56:58. All Rights Reserved.
//<生成时间>2017-05-25T22:56:58</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
	/// <summary>
    /// 老师评价结果表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(T_Estimate))]
    public class T_EstimateListDto : EntityDto<int>
    {
        public      int FK_ClassId { get; set; }
        public      int FK_ContentId { get; set; }
        public      int FK_GradeId { get; set; }
        /// <summary>
        /// 评价累积次数
        /// </summary>
        [DisplayName("评价累积次数")]
        public      int ContentCount { get; set; }
    }
}