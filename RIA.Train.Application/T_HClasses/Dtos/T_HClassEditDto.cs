
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:38:47. All Rights Reserved.
//<生成时间>2017-05-25T22:38:47</生成时间>
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
    /// <summary>
    /// 培训班人员信息表编辑用Dto
    /// </summary>
    [AutoMap(typeof(T_HClass))]
    public class T_HClassEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        public   int  FK_ClassId { get; set; }

        public   int  FK_UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        [MaxLength(30)]
        public   string  UserName { get; set; }

    }


}
