using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Entities
{
    /// <summary>
    /// 人员信息表
    /// </summary>
   public class T_Staff:Entity
    {
        public virtual int FK_GroupId { get; set; }

        [ForeignKey("FK_GroupId")]
        public virtual T_Group T_Group { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string StaffName { get; set; }

        public virtual DateTime? CreteTime { get; set; }
    }
}
