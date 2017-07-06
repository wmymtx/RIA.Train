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
    /// 培训重点
    /// </summary>
   public class T_KPoint:Entity
    {
        public virtual int Fk_Item_KPoint_Id { get; set; }

        [ForeignKey("Fk_Item_KPoint_Id")]
        public virtual T_Item T_Item { get; set; }

        /// <summary>
        /// 培训重点
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(50)]
        public virtual string TrainContent { get; set; }
    }
}
