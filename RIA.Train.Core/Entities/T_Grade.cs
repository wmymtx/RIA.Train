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
    /// 考评等级
    /// </summary>
   public class T_Grade:Entity
    {
        /// <summary>
        /// 等级
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string Grade { get; set; }
    }
}
