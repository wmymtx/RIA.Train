

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:57:01. All Rights Reserved.
//<生成时间>2017-05-25T22:57:01</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 老师评价结果表服务接口
    /// </summary>
    public interface IT_EstimateAppService : IApplicationService
    {
        #region 老师评价结果表管理

        /// <summary>
        /// 根据查询条件获取老师评价结果表分页列表
        /// </summary>
        Task<PagedResultDto<T_EstimateListDto>> GetPagedT_EstimatesAsync(GetT_EstimateInput input);

        /// <summary>
        /// 通过Id获取老师评价结果表信息进行编辑或修改 
        /// </summary>
        Task<GetT_EstimateForEditOutput> GetT_EstimateForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取老师评价结果表ListDto信息
        /// </summary>
		Task<T_EstimateListDto> GetT_EstimateByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改老师评价结果表
        /// </summary>
        Task CreateOrUpdateT_EstimateAsync(CreateOrUpdateT_EstimateInput input);





        /// <summary>
        /// 新增老师评价结果表
        /// </summary>
        Task<T_EstimateEditDto> CreateT_EstimateAsync(T_EstimateEditDto input);

        /// <summary>
        /// 更新老师评价结果表
        /// </summary>
        Task UpdateT_EstimateAsync(T_EstimateEditDto input);

        /// <summary>
        /// 删除老师评价结果表
        /// </summary>
        Task DeleteT_EstimateAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除老师评价结果表
        /// </summary>
        Task BatchDeleteT_EstimateAsync(List<int> input);

        #endregion




    }
}
