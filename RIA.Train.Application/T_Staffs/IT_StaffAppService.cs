﻿

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:50:31. All Rights Reserved.
//<生成时间>2017-05-25T22:50:31</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 人员信息表服务接口
    /// </summary>
    public interface IT_StaffAppService : IApplicationService
    {
        #region 人员信息表管理

        /// <summary>
        /// 根据查询条件获取人员信息表分页列表
        /// </summary>
        Task<PagedResultDto<T_StaffListDto>> GetPagedT_StaffsAsync(GetT_StaffInput input);

        /// <summary>
        /// 通过Id获取人员信息表信息进行编辑或修改 
        /// </summary>
        Task<GetT_StaffForEditOutput> GetT_StaffForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取人员信息表ListDto信息
        /// </summary>
		Task<T_StaffListDto> GetT_StaffByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改人员信息表
        /// </summary>
        Task CreateOrUpdateT_StaffAsync(CreateOrUpdateT_StaffInput input);





        /// <summary>
        /// 新增人员信息表
        /// </summary>
        Task<T_StaffEditDto> CreateT_StaffAsync(T_StaffEditDto input);

        /// <summary>
        /// 更新人员信息表
        /// </summary>
        Task UpdateT_StaffAsync(T_StaffEditDto input);

        /// <summary>
        /// 删除人员信息表
        /// </summary>
        Task DeleteT_StaffAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除人员信息表
        /// </summary>
        Task BatchDeleteT_StaffAsync(List<int> input);

        #endregion




    }
}