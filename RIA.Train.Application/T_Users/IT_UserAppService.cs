

// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:53:28. All Rights Reserved.
//<生成时间>2017-05-25T22:53:28</生成时间>
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
    /// 用户管理服务接口
    /// </summary>
    public interface IT_UserAppService : IApplicationService
    {
        #region 用户管理管理

        /// <summary>
        /// 根据查询条件获取用户管理分页列表
        /// </summary>
        Task<JtableResult<List<T_UserListDto>>> GetPagedT_UsersAsync(GetT_UserInput input);

        /// <summary>
        /// 通过Id获取用户管理信息进行编辑或修改 
        /// </summary>
        Task<GetT_UserForEditOutput> GetT_UserForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取用户管理ListDto信息
        /// </summary>
        Task<T_UserListDto> GetT_UserByIdAsync(EntityDto<int> input);

        T_UserListDto GetT_UserByOpenIdAsync(string openId);

        /// <summary>
        /// 新增或更改用户管理
        /// </summary>
        Task CreateOrUpdateT_UserAsync(CreateOrUpdateT_UserInput input);


        T_UserListDto GetT_UserByLoginNo(T_UserEditDto input);
        Task BindWeChat(T_UserEditDto input);

        /// <summary>
        /// 新增用户管理
        /// </summary>
        Task<T_UserEditDto> CreateT_UserAsync(T_UserEditDto input);

        bool ModifyPwd(T_UserModifyDto input);

        /// <summary>
        /// 更新用户管理
        /// </summary>
        Task UpdateT_UserAsync(T_UserEditDto input);

        /// <summary>
        /// 删除用户管理
        /// </summary>
        Task DeleteT_UserAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除用户管理
        /// </summary>
        Task BatchDeleteT_UserAsync(List<int> input);

        #endregion




    }
}
