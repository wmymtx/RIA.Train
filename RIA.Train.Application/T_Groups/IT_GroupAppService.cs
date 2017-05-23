

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-23T22:10:12. All Rights Reserved.
//<生成时间>2017-05-23T22:10:12</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 班组表服务接口
    /// </summary>
    public interface IT_GroupAppService : IApplicationService
    {
        #region 班组表管理

        /// <summary>
        /// 根据查询条件获取班组表分页列表
        /// </summary>
        Task<PagedResultDto<T_GroupListDto>> GetPagedT_GroupsAsync(GetT_GroupInput input);

        /// <summary>
        /// 通过Id获取班组表信息进行编辑或修改 
        /// </summary>
        Task<GetT_GroupForEditOutput> GetT_GroupForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取班组表ListDto信息
        /// </summary>
		Task<T_GroupListDto> GetT_GroupByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改班组表
        /// </summary>
        Task CreateOrUpdateT_GroupAsync(CreateOrUpdateT_GroupInput input);





        /// <summary>
        /// 新增班组表
        /// </summary>
        Task<T_GroupEditDto> CreateT_GroupAsync(T_GroupEditDto input);

        /// <summary>
        /// 更新班组表
        /// </summary>
        Task UpdateT_GroupAsync(T_GroupEditDto input);

        /// <summary>
        /// 删除班组表
        /// </summary>
        Task DeleteT_GroupAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除班组表
        /// </summary>
        Task BatchDeleteT_GroupAsync(List<int> input);

        #endregion




    }
}
