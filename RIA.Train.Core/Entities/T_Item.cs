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
    /// 培训项目设置
    /// </summary>
    public class T_Item : Entity<int>
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(TypeName = "nvarchar"), MaxLength(30)]
        public virtual string ProjectName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public virtual int CreatorUserId { get; set; }

        public virtual List<T_KPoint> T_KPoints { get; set; }

        public virtual List<T_CInfo> T_CInfos { get; set; }

        public T_Item()
        {
            CreateTime = DateTime.Now;
        }
    }
}
