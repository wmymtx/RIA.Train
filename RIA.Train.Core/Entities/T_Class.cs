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
   public class T_Class:Entity
    {
        /// <summary>
        /// 培训项目外键
        /// </summary>
        public virtual int Fk_Id { get; set; }

        [ForeignKey("Fk_Id")]
        public virtual T_Item T_Item { get; set; }

        /// <summary>
        /// 培训时间
        /// </summary>
        public virtual DateTime? TrainingTime { get; set; }

        /// <summary>
        /// 培训地点
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(50)]
        public virtual string TrainingPlace { get; set; }

        /// <summary>
        /// 培训教师
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string TrainintTeacher { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
    }
}
