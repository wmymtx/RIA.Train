﻿

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T21:57:59. All Rights Reserved.
//<生成时间>2017-05-25T21:57:59</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 培训信息配置表服务接口
    /// </summary>
    public interface IT_ClassAppService : IApplicationService
    {
        #region 培训信息配置表管理

        /// <summary>
        /// 根据查询条件获取培训信息配置表分页列表
        /// </summary>
        Task<PagedResultDto<T_ClassListDto>> GetPagedT_ClasssAsync(GetT_ClassInput input);

        /// <summary>
        /// 通过Id获取培训信息配置表信息进行编辑或修改 
        /// </summary>
        Task<GetT_ClassForEditOutput> GetT_ClassForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取培训信息配置表ListDto信息
        /// </summary>
		Task<T_ClassListDto> GetT_ClassByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改培训信息配置表
        /// </summary>
        Task CreateOrUpdateT_ClassAsync(CreateOrUpdateT_ClassInput input);





        /// <summary>
        /// 新增培训信息配置表
        /// </summary>
        Task<T_ClassEditDto> CreateT_ClassAsync(T_ClassEditDto input);

        /// <summary>
        /// 更新培训信息配置表
        /// </summary>
        Task UpdateT_ClassAsync(T_ClassEditDto input);

        /// <summary>
        /// 删除培训信息配置表
        /// </summary>
        Task DeleteT_ClassAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除培训信息配置表
        /// </summary>
        Task BatchDeleteT_ClassAsync(List<int> input);

        #endregion




    }
}
