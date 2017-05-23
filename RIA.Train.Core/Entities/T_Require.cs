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
    /// 培训需求提报
    /// </summary>
   public class T_Require:Entity
    {
        public virtual int Fk_Id { get; set; }

        /// <summary>
        /// 参培人员
        /// </summary>
        public virtual int Fk_UserId { get; set; }

        [ForeignKey("Fk_UserId")]
        public virtual T_User T_User { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// 提报内容
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(500)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 提报时间
        /// </summary>
        public virtual DateTime? SubmitTime { get; set; }
    }
}
