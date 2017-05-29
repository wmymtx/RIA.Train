using Abp.AutoMapper;
using RIA.Train.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    /// <summary>
    /// 新建或编辑培训需求提报时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetT_RequireForEditOutput))]
    public class CreateOrEditT_RequireModalViewModel : GetT_RequireForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditT_RequireModalViewModel(GetT_RequireForEditOutput output)
        {
            output.MapTo(this);
        }



        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return T_Require.Id.HasValue; } }



        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}