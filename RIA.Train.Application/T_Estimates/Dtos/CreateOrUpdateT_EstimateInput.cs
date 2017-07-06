
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
    /// 老师评价结果表新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateT_EstimateInput  
    {
    /// <summary>
    /// 老师评价结果表编辑Dto
    /// </summary>
		public T_EstimateEditDto  T_EstimateEditDto {get;set;}
 
    }
}
