
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

        public string vContent { get; set; }

        public string vGrade { get; set; }
        /// <summary>
        /// 评价累积次数
        /// </summary>
        [DisplayName("评价累积次数")]
        public      int ContentCount { get; set; }

        public T_Grade T_Grade { get; set; }

        public T_Content T_Content { get; set; }

        public T_Class T_Class { get; set; }

       
    }
}
