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
    /// 考评内容（档次）
    /// </summary>
  public class T_Content:Entity
    {
        /// <summary>
        /// 考评内容
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(50)]
        public virtual string Content { get; set; }
    }
}
