

// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:35:56. All Rights Reserved.
//<生成时间>2017-05-25T22:35:56</生成时间>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;

namespace RIA.Train.Application
{
	/// <summary>
    /// 考评等级服务接口
    /// </summary>
    public interface IT_GradeAppService : IApplicationService
    {
        #region 考评等级管理

        /// <summary>
        /// 根据查询条件获取考评等级分页列表
        /// </summary>
        Task<PagedResultDto<T_GradeListDto>> GetPagedT_GradesAsync(GetT_GradeInput input);

        /// <summary>
        /// 通过Id获取考评等级信息进行编辑或修改 
        /// </summary>
        Task<GetT_GradeForEditOutput> GetT_GradeForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取考评等级ListDto信息
        /// </summary>
		Task<T_GradeListDto> GetT_GradeByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改考评等级
        /// </summary>
        Task CreateOrUpdateT_GradeAsync(CreateOrUpdateT_GradeInput input);





        /// <summary>
        /// 新增考评等级
        /// </summary>
        Task<T_GradeEditDto> CreateT_GradeAsync(T_GradeEditDto input);

        /// <summary>
        /// 更新考评等级
        /// </summary>
        Task UpdateT_GradeAsync(T_GradeEditDto input);

        /// <summary>
        /// 删除考评等级
        /// </summary>
        Task DeleteT_GradeAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除考评等级
        /// </summary>
        Task BatchDeleteT_GradeAsync(List<int> input);

        #endregion




    }
}
