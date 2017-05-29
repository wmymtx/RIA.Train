using Abp.AutoMapper;
using RIA.Train.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    /// <summary>
    /// 新建或编辑考评等级时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetT_GradeForEditOutput))]
    public class CreateOrEditT_GradeModalViewModel : GetT_GradeForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditT_GradeModalViewModel(GetT_GradeForEditOutput output)
        {
            output.MapTo(this);
        }



        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return T_Grade.Id.HasValue; } }



        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}