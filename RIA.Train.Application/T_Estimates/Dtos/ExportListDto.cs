using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Application.Dtos
{
    [AutoMapFrom(typeof(T_Estimate))]
    public class ExportListDto : EntityDto<int>
    {
        //public int FK_ClassId { get; set; }
        //public T_Class T_Class { get; set; }
        //public int FK_ContentId { get; set; }
        //public T_Content T_Content { get; set; }
        //public int FK_GradeId { get; set; }
        //public T_Grade T_Grade { get; set; }

        public string vContent { get; set; }

        public string vGrade { get; set; }

        public string vClass { get; set; }
        /// <summary>
        /// 评价累积次数
        /// </summary>
        [DisplayName("评价累积次数")]
        public int ContentCount { get; set; }
    }

    public class Export2ColListDto 
    {
        //public int FK_ClassId { get; set; }
        //public T_Class T_Class { get; set; }
        //public int FK_ContentId { get; set; }
        //public T_Content T_Content { get; set; }
        //public int FK_GradeId { get; set; }
        //public T_Grade T_Grade { get; set; }

        public string vContent { get; set; }

        public string vItem { get; set; }

        public string vGrade { get; set; }

        public string vClass { get; set; }
        /// <summary>
        /// 评价累积次数
        /// </summary>
        [DisplayName("评价累积次数")]
        public int ContentCount { get; set; }
    }

    public class Export2ListDto
    {
        public string vContent { get; set; }

        public string vItem { get; set; }

        public string vClass { get; set; }

        public int ContentCount优 { get; set; }

        public int ContentCount良 { get; set; }

        public int ContentCount中 { get; set; }

        public int ContentCount差 { get; set; }
    }
}
