
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using RIA.Train.Entities;

namespace RIA.Train.Application.Dtos
{
	/// <summary>
    /// 用于添加或编辑 老师评价结果表时使用的DTO
    /// </summary>
  
    public class GetT_EstimateForEditOutput 
    {
 

	      /// <summary>
         /// T_Estimate编辑状态的DTO
        /// </summary>
    public T_EstimateEditDto T_Estimate{get;set;}


    }
}
