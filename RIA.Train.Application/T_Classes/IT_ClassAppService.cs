﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;
using RIA.Train.Dto;

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

        T_ClassListDto GetT_ClassById(EntityDto<int> input);

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
