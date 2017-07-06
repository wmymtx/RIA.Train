

// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T21:42:08. All Rights Reserved.
//<生成时间>2017-05-21T21:42:08</生成时间>
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
    /// 培训项目设置服务接口
    /// </summary>
    public interface IT_ItemAppService : IApplicationService
    {
        #region 培训项目设置管理

        /// <summary>
        /// 根据查询条件获取培训项目设置分页列表
        /// </summary>
        Task<PagedResultDto<T_ItemListDto>> GetPagedT_ItemsAsync(GetT_ItemInput input);

        /// <summary>
        /// 通过Id获取培训项目设置信息进行编辑或修改 
        /// </summary>
        Task<GetT_ItemForEditOutput> GetT_ItemForEditAsync(NullableIdDto<int> input);
        WeChatItemListDto GetT_ItemById(int id);
        /// <summary>
        /// 通过指定id获取培训项目设置ListDto信息
        /// </summary>
        Task<T_ItemListDto> GetT_ItemByIdAsync(EntityDto<int> input);

        //List<T_ItemListDto> GetJoinItem(int userId);

        /// <summary>
        /// 新增或更改培训项目设置
        /// </summary>
        Task CreateOrUpdateT_ItemAsync(CreateOrUpdateT_ItemInput input);





        /// <summary>
        /// 新增培训项目设置
        /// </summary>
        Task<T_ItemEditDto> CreateT_ItemAsync(T_ItemEditDto input);

        /// <summary>
        /// 更新培训项目设置
        /// </summary>
        Task UpdateT_ItemAsync(T_ItemEditDto input);

        /// <summary>
        /// 删除培训项目设置
        /// </summary>
        Task DeleteT_ItemAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除培训项目设置
        /// </summary>
        Task BatchDeleteT_ItemAsync(List<int> input);

        #endregion




    }
}
