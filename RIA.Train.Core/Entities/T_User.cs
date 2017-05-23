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
    /// 用户管理
    /// </summary>
    public class T_User : Entity
    {
        public virtual int FK_StaffId { get; set; }

        [ForeignKey("FK_StaffId")]
        public virtual T_Staff T_Staff { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public virtual int LoginNo { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string PassWord { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Column(TypeName ="varchar"),MaxLength(100)]
        public virtual string OpenId { get; set; }

        public virtual DateTime? CreteTime { get; set; }
    }
}
