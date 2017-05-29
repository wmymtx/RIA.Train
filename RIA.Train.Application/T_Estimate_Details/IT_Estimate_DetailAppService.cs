

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:59:46. All Rights Reserved.
//<生成时间>2017-05-25T22:59:46</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 评价明细服务接口
    /// </summary>
    public interface IT_Estimate_DetailAppService : IApplicationService
    {
        #region 评价明细管理

        /// <summary>
        /// 根据查询条件获取评价明细分页列表
        /// </summary>
        Task<PagedResultDto<T_Estimate_DetailListDto>> GetPagedT_Estimate_DetailsAsync(GetT_Estimate_DetailInput input);

        /// <summary>
        /// 通过Id获取评价明细信息进行编辑或修改 
        /// </summary>
        Task<GetT_Estimate_DetailForEditOutput> GetT_Estimate_DetailForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取评价明细ListDto信息
        /// </summary>
		Task<T_Estimate_DetailListDto> GetT_Estimate_DetailByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改评价明细
        /// </summary>
        Task CreateOrUpdateT_Estimate_DetailAsync(CreateOrUpdateT_Estimate_DetailInput input);





        /// <summary>
        /// 新增评价明细
        /// </summary>
        Task<T_Estimate_DetailEditDto> CreateT_Estimate_DetailAsync(T_Estimate_DetailEditDto input);

        /// <summary>
        /// 更新评价明细
        /// </summary>
        Task UpdateT_Estimate_DetailAsync(T_Estimate_DetailEditDto input);

        /// <summary>
        /// 删除评价明细
        /// </summary>
        Task DeleteT_Estimate_DetailAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除评价明细
        /// </summary>
        Task BatchDeleteT_Estimate_DetailAsync(List<int> input);

        #endregion




    }
}
