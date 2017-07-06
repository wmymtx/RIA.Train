using Abp.AutoMapper;
using RIA.Train.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    [AutoMapFrom(typeof(GetT_DepForEditOutput))]
    public class CreateOrEditT_DepModalViewModel: GetT_DepForEditOutput
    {
        public CreateOrEditT_DepModalViewModel(GetT_DepForEditOutput output)
        {
            output.MapTo(this);
        }



        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return T_Dep.Id.HasValue; } }



        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }
    }
}