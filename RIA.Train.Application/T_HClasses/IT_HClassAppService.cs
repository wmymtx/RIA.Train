

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:38:50. All Rights Reserved.
//<生成时间>2017-05-25T22:38:50</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 培训班人员信息表服务接口
    /// </summary>
    public interface IT_HClassAppService : IApplicationService
    {
        #region 培训班人员信息表管理

        /// <summary>
        /// 根据查询条件获取培训班人员信息表分页列表
        /// </summary>
        Task<PagedResultDto<T_HClassListDto>> GetPagedT_HClasssAsync(GetT_HClassInput input);

        /// <summary>
        /// 通过Id获取培训班人员信息表信息进行编辑或修改 
        /// </summary>
        Task<GetT_HClassForEditOutput> GetT_HClassForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取培训班人员信息表ListDto信息
        /// </summary>
		Task<T_HClassListDto> GetT_HClassByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改培训班人员信息表
        /// </summary>
        Task CreateOrUpdateT_HClassAsync(CreateOrUpdateT_HClassInput input);





        /// <summary>
        /// 新增培训班人员信息表
        /// </summary>
        Task<T_HClassEditDto> CreateT_HClassAsync(T_HClassEditDto input);

        /// <summary>
        /// 更新培训班人员信息表
        /// </summary>
        Task UpdateT_HClassAsync(T_HClassEditDto input);

        /// <summary>
        /// 删除培训班人员信息表
        /// </summary>
        Task DeleteT_HClassAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除培训班人员信息表
        /// </summary>
        Task BatchDeleteT_HClassAsync(List<int> input);

        #endregion




    }
}
