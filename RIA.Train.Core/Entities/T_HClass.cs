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
    /// 培训班人员信息表
    /// </summary>
  public  class T_HClass:Entity
    {

        public virtual int FK_ClassId { get; set; }

        [ForeignKey("FK_ClassId")]
        public virtual T_Class T_Class { get; set; }


        public virtual int FK_UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string UserName { get; set; }

        
    }
}
