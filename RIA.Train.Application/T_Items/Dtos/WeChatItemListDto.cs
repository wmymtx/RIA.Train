using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RIA.Train.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Application.Dtos
{
    [AutoMapFrom(typeof(T_Item))]
    public class WeChatItemListDto : EntityDto<int>
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [DisplayName("项目名称")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }

        public  List<T_KPoint> T_KPoints { get; set; }

        public  List<T_CInfo> T_CInfos { get; set; }
    }
}
