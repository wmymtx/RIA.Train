

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:44:48. All Rights Reserved.
//<生成时间>2017-05-25T22:44:48</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 培训重点服务接口
    /// </summary>
    public interface IT_KPointAppService : IApplicationService
    {
        #region 培训重点管理

        /// <summary>
        /// 根据查询条件获取培训重点分页列表
        /// </summary>
        Task<PagedResultDto<T_KPointListDto>> GetPagedT_KPointsAsync(GetT_KPointInput input);

        /// <summary>
        /// 通过Id获取培训重点信息进行编辑或修改 
        /// </summary>
        Task<GetT_KPointForEditOutput> GetT_KPointForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取培训重点ListDto信息
        /// </summary>
		Task<T_KPointListDto> GetT_KPointByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改培训重点
        /// </summary>
        Task CreateOrUpdateT_KPointAsync(CreateOrUpdateT_KPointInput input);





        /// <summary>
        /// 新增培训重点
        /// </summary>
        Task<T_KPointEditDto> CreateT_KPointAsync(T_KPointEditDto input);

        /// <summary>
        /// 更新培训重点
        /// </summary>
        Task UpdateT_KPointAsync(T_KPointEditDto input);

        /// <summary>
        /// 删除培训重点
        /// </summary>
        Task DeleteT_KPointAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除培训重点
        /// </summary>
        Task BatchDeleteT_KPointAsync(List<int> input);

        #endregion




    }
}
