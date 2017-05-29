// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:16:05. All Rights Reserved.
//<生成时间>2017-05-25T22:16:05</生成时间>
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
    /// <summary>
    /// 考评内容（档次）新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateT_ContentInput  
    {
    /// <summary>
    /// 考评内容（档次）编辑Dto
    /// </summary>
		public T_ContentEditDto  T_ContentEditDto {get;set;}
 
    }
}
