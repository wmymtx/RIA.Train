
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
    /// 老师评价结果表编辑用Dto
    /// </summary>
    [AutoMap(typeof(T_Estimate))]
    public class T_EstimateEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        public   int  FK_ClassId { get; set; }

        public   int  FK_ContentId { get; set; }

        public   int  FK_GradeId { get; set; }

        /// <summary>
        /// 评价累积次数
        /// </summary>
        [DisplayName("评价累积次数")]
        public   int  ContentCount { get; set; }

    }
}
