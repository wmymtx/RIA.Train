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

        public virtual int FK_UserId{ get; set; }

        [ForeignKey("FK_UserId")]
        public virtual T_User T_User { get; set; }

        public virtual DateTime? CreateTime { get; set; }
    }
}
