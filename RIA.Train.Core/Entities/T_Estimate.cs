using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Entities
{
    /// <summary>
    /// 老师评价结果表
    /// </summary>
   public class T_Estimate:Entity
    {
        public virtual int FK_ClassId { get; set; }

        [ForeignKey("FK_ClassId")]
        public virtual T_Class T_Class { get; set; }

        public virtual int FK_ContentId { get; set; }

        [ForeignKey("FK_ContentId")]
        public virtual T_Content T_Content { get; set; }

        public virtual int FK_GradeId { get; set; }

        [ForeignKey("FK_GradeId")]
        public virtual T_Grade T_Grade { get; set; }

        /// <summary>
        /// 评价累积次数
        /// </summary>
        public virtual int ContentCount { get; set; }
    }
}
