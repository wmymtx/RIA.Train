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
    /// 评价明细
    /// </summary>
    public class T_Estimate_Detail : Entity
    {
        public virtual int FK_EstimateId { get; set; }

        [ForeignKey("FK_EstimateId")]
        public virtual T_Estimate T_Estimate { get; set; }

        public virtual int FK_TstaffId{ get; set; }

        [ForeignKey("FK_TstaffId")]
        public virtual T_Staff T_Staff { get; set; }

        public virtual DateTime? CreateTime { get; set; }

        public T_Estimate_Detail()
        {
            CreateTime = DateTime.Now;
        }
    }
}
