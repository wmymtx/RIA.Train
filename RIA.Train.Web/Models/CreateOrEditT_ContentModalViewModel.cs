using Abp.AutoMapper;
using RIA.Train.Application.Dtos;
using RIA.Train.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    /// <summary>
    /// 新建或编辑考评内容（档次）时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetT_ContentForEditOutput))]
    public class CreateOrEditT_ContentModalViewModel : GetT_ContentForEditOutput
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
        public CreateOrEditT_ContentModalViewModel(GetT_ContentForEditOutput output)
        {
            output.MapTo(this);
        }



        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditMode { get { return T_Content.Id.HasValue; } }



        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}