

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T22:00:02. All Rights Reserved.
//<生成时间>2017-05-21T22:00:02</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 部门表服务接口
    /// </summary>
    public interface IT_DepAppService : IApplicationService
    {
        #region 部门表管理

        /// <summary>
        /// 根据查询条件获取部门表分页列表
        /// </summary>
        Task<PagedResultDto<T_DepListDto>> GetPagedT_DepsAsync(GetT_DepInput input);

        /// <summary>
        /// 通过Id获取部门表信息进行编辑或修改 
        /// </summary>
        Task<GetT_DepForEditOutput> GetT_DepForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取部门表ListDto信息
        /// </summary>
		Task<T_DepListDto> GetT_DepByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改部门表
        /// </summary>
        Task CreateOrUpdateT_DepAsync(CreateOrUpdateT_DepInput input);





        /// <summary>
        /// 新增部门表
        /// </summary>
        Task<T_DepEditDto> CreateT_DepAsync(T_DepEditDto input);

        /// <summary>
        /// 更新部门表
        /// </summary>
        Task UpdateT_DepAsync(T_DepEditDto input);

        /// <summary>
        /// 删除部门表
        /// </summary>
        Task DeleteT_DepAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除部门表
        /// </summary>
        Task BatchDeleteT_DepAsync(List<int> input);

        #endregion




    }
}
