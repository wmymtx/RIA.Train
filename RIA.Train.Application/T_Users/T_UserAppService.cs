


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
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using RIA.Train.Application.Dtos;
using RIA.Train.Core.Authorization;
using RIA.Train.Entities;
using RIA.Train.Core;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
    /// <summary>
    /// 用户管理服务实现
    /// </summary>
   // [AbpAuthorize(T_UserAppPermissions.T_User)]
    public class T_UserAppService : TrainAppServiceBase, IT_UserAppService
    {
        private readonly IRepository<T_User, int> _t_UserRepository;


        private readonly T_UserManage _t_UserManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_UserAppService(IRepository<T_User, int> t_UserRepository,
T_UserManage t_UserManage

  )
        {
            _t_UserRepository = t_UserRepository;
            _t_UserManage = t_UserManage;

        }

        #region 用户管理管理

        /// <summary>
        /// 根据查询条件获取用户管理分页列表
        /// </summary>
        public async Task<JtableResult<List<T_UserListDto>>> GetPagedT_UsersAsync(GetT_UserInput input)
        {

            var query = _t_UserRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var t_UserCount = await query.CountAsync();

            var t_Users = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_UserListDtos = t_Users.MapTo<List<T_UserListDto>>();
            //return new PagedResultDto<T_UserListDto>(
            //t_UserCount,
            //t_UserListDtos
            //);
            return new JtableResult<List<T_UserListDto>>(t_UserCount, t_UserListDtos);
        }

        /// <summary>
        /// 通过Id获取用户管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_UserForEditOutput> GetT_UserForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_UserForEditOutput();

            T_UserEditDto t_UserEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_UserRepository.GetAsync(input.Id.Value);
                t_UserEditDto = entity.MapTo<T_UserEditDto>();
            }
            else
            {
                t_UserEditDto = new T_UserEditDto();
            }

            output.T_User = t_UserEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取用户管理ListDto信息
        /// </summary>
        public async Task<T_UserListDto> GetT_UserByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_UserRepository.GetAsync(input.Id);

            return entity.MapTo<T_UserListDto>();
        }

        public T_UserListDto GetT_UserByLoginNo(T_UserEditDto input)
        {
            var query = _t_UserRepository.GetAll();
            var entity = query.FirstOrDefault(o => o.LoginNo == input.LoginNo && o.PassWord == input.PassWord);

            return entity.MapTo<T_UserListDto>();
        }

        public T_UserListDto GetT_UserByOpenIdAsync(string openId)
        {
            var query = _t_UserRepository.GetAll();
            var entity = query.FirstOrDefault(o => o.OpenId == openId);

            return entity.MapTo<T_UserListDto>();
        }


        public virtual async Task BindWeChat(T_UserEditDto input)
        {
            var query = _t_UserRepository.GetAll();

            var entity = query.FirstOrDefault(o => o.LoginNo == input.LoginNo && o.PassWord == input.PassWord);
            input.MapTo(entity);
            await _t_UserRepository.UpdateAsync(entity);
        }

        public bool ModifyPwd(T_UserModifyDto input)
        {
            var query = _t_UserRepository.GetAll();
            var no = int.Parse(input.LoginNo);
            var entity = query.FirstOrDefault(o => o.LoginNo == no && o.PassWord == input.OldPassword);
            if (entity != null)
            {
                entity.PassWord = input.NewPassword;
                _t_UserRepository.Update(entity);
                return true;
            }
            return false;
        }






        /// <summary>
        /// 新增或更改用户管理
        /// </summary>
        public async Task CreateOrUpdateT_UserAsync(CreateOrUpdateT_UserInput input)
        {
            if (input.T_UserEditDto.Id.HasValue)
            {
                await UpdateT_UserAsync(input.T_UserEditDto);
            }
            else
            {
                await CreateT_UserAsync(input.T_UserEditDto);
            }
        }

        /// <summary>
        /// 新增用户管理
        /// </summary>
        // [AbpAuthorize(T_UserAppPermissions.T_User_CreateT_User)]
        public virtual async Task<T_UserEditDto> CreateT_UserAsync(T_UserEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_User>();

            entity = await _t_UserRepository.InsertAsync(entity);
            return entity.MapTo<T_UserEditDto>();
        }

        /// <summary>
        /// 编辑用户管理
        /// </summary>
        //  [AbpAuthorize(T_UserAppPermissions.T_User_EditT_User)]
        public virtual async Task UpdateT_UserAsync(T_UserEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_UserRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_UserRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户管理
        /// </summary>
        // [AbpAuthorize(T_UserAppPermissions.T_User_DeleteT_User)]
        public async Task DeleteT_UserAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_UserRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户管理
        /// </summary>
        [AbpAuthorize(T_UserAppPermissions.T_User_DeleteT_User)]
        public async Task BatchDeleteT_UserAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_UserRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

    }
}










