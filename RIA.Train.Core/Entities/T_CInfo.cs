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
    ///  培训信息配置表
    /// </summary>
   public class T_CInfo:Entity
    {
        /// <summary>
        /// 培训项目外键
        /// </summary>
        public virtual int Fk_Item_CInfo_Id { get; set; }

        [ForeignKey("Fk_Item_CInfo_Id")]
        public virtual T_Item T_Item { get; set; }

        /// <summary>
        /// 参培人员
        /// </summary>
        public virtual int Fk_CInfo_UserId { get; set; }

        [ForeignKey("Fk_CInfo_UserId")]
        public virtual T_Staff T_Staff { get; set; }

        /// <summary>
        /// 参培人员名字
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(30)]
        public virtual string UserName { get; set; }
    }
}
