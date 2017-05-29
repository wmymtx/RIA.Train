
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
//<Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T21:57:57. All Rights Reserved.
//<生成时间>2017-05-25T21:57:57</生成时间>
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
	/// <summary>
    /// 培训信息配置表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(T_Class))]
    public class T_ClassListDto : EntityDto<int>
    {
        /// <summary>
        /// 培训项目外键
        /// </summary>
        [DisplayName("培训项目外键")]
        public      int Fk_Id { get; set; }
        /// <summary>
        /// 培训时间
        /// </summary>
        [DisplayName("培训时间")]
        public      DateTime? TrainingTime { get; set; }
        /// <summary>
        /// 培训地点
        /// </summary>
        [DisplayName("培训地点")]
        public      string TrainingPlace { get; set; }
        /// <summary>
        /// 培训教师
        /// </summary>
        [DisplayName("培训教师")]
        public      string TrainintTeacher { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime? CreateTime { get; set; }
    }
}
