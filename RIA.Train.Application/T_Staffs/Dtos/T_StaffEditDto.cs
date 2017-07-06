﻿
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-06-03T22:37:52. All Rights Reserved.
//<生成时间>2017-06-03T22:37:52</生成时间>
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
    /// 人员信息表编辑用Dto
    /// </summary>
    [AutoMap(typeof(T_Staff))]
    public class T_StaffEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        public   int  FK_Staff_GroupId { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        [DisplayName("人员名称")]
        [MaxLength(30)]
        public   string  StaffName { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        public   int  LoginNo { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [MaxLength(50)]
        public   string  PassWord { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [DisplayName("微信OpenId")]
        [MaxLength(100)]
        public   string  OpenId { get; set; }

        public   DateTime?  CreteTime { get; set; }

    }
}
