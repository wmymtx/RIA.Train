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
    /// 组织表
    /// </summary>
   public class T_Group:Entity
    {
        //public virtual int FK_DepId { get; set; }

        //[ForeignKey("FK_DepId")]
        //public virtual T_Dep T_Dep { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string GroupName { get; set; }

        public virtual int ParentId { get; set; }
    }
}
