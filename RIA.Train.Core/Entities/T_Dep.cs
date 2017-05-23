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
    /// 部门表
    /// </summary>
   public class T_Dep:Entity
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(50)]
        public virtual string DepName { get; set; }
    }
}
