

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:47:39. All Rights Reserved.
//<生成时间>2017-05-25T22:47:39</生成时间>
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
    /// 培训需求提报服务接口
    /// </summary>
    public interface IT_RequireAppService : IApplicationService
    {
        #region 培训需求提报管理

        /// <summary>
        /// 根据查询条件获取培训需求提报分页列表
        /// </summary>
        Task<PagedResultDto<T_RequireListDto>> GetPagedT_RequiresAsync(GetT_RequireInput input);

        /// <summary>
        /// 通过Id获取培训需求提报信息进行编辑或修改 
        /// </summary>
        Task<GetT_RequireForEditOutput> GetT_RequireForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取培训需求提报ListDto信息
        /// </summary>
		Task<T_RequireListDto> GetT_RequireByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改培训需求提报
        /// </summary>
        Task CreateOrUpdateT_RequireAsync(CreateOrUpdateT_RequireInput input);





        /// <summary>
        /// 新增培训需求提报
        /// </summary>
        Task<T_RequireEditDto> CreateT_RequireAsync(T_RequireEditDto input);

        /// <summary>
        /// 更新培训需求提报
        /// </summary>
        Task UpdateT_RequireAsync(T_RequireEditDto input);

        /// <summary>
        /// 删除培训需求提报
        /// </summary>
        Task DeleteT_RequireAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除培训需求提报
        /// </summary>
        Task BatchDeleteT_RequireAsync(List<int> input);

        List<T_ItemListDto> GetJoinItem(int userId);
        Task<FileDto> GetT_RequireToExcel(GetT_RequireInput input);
        #endregion




    }
}
