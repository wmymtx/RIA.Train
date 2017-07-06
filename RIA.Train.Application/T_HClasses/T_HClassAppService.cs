


// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:38:51. All Rights Reserved.
//<生成时间>2017-05-25T22:38:51</生成时间>
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
using RIA.Train.Core.Authorization;
using RIA.Train.Entities;
using RIA.Train.Core;
using RIA.Train.Application.Dtos;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
    /// <summary>
    /// 培训班人员信息表服务实现
    /// </summary>
    //[AbpAuthorize(T_HClassAppPermissions.T_HClass)]
    public class T_HClassAppService : TrainAppServiceBase, IT_HClassAppService
    {
        private readonly IRepository<T_HClass, int> _t_HClassRepository;


        private readonly T_HClassManage _t_HClassManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_HClassAppService(IRepository<T_HClass, int> t_HClassRepository,
T_HClassManage t_HClassManage

  )
        {
            _t_HClassRepository = t_HClassRepository;
            _t_HClassManage = t_HClassManage;

        }

        #region 培训班人员信息表管理

        /// <summary>
        /// 根据查询条件获取培训班人员信息表分页列表
        /// </summary>
        public async Task<PagedResultDto<T_HClassListDto>> GetPagedT_HClasssAsync(GetT_HClassInput input)
        {

            var query = _t_HClassRepository.GetAll().WhereIf(input.FK_ClassId >= 1, o => o.FK_HClass_ClassId == input.FK_ClassId).
                WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), o => o.UserName.Contains(input.FilterText));
            //TODO:根据传入的参数添加过滤条件

            var t_HClassCount = await query.CountAsync();

            var t_HClasss = await query
            .OrderBy(input.Sorting)
            //.PageBy(input)
            .ToListAsync();

            var t_HClassListDtos = t_HClasss.MapTo<List<T_HClassListDto>>();
            return new PagedResultDto<T_HClassListDto>(
            200,
            t_HClassListDtos
            );
            // return new JtableResult<List<T_HClassListDto>>(t_HClassCount, t_HClassListDtos);
        }

        public async Task BatchCreateOrUpdateT_HClassAsync(BatchCreateOrUpdateT_HClassInput inputList)
        {
            foreach (var input in inputList.T_HClassEditDto)
            {
                await CreateT_HClassAsync(input);
            }
        }
        /// <summary>
        /// 通过Id获取培训班人员信息表信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_HClassForEditOutput> GetT_HClassForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_HClassForEditOutput();

            T_HClassEditDto t_HClassEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_HClassRepository.GetAsync(input.Id.Value);
                t_HClassEditDto = entity.MapTo<T_HClassEditDto>();
            }
            else
            {
                t_HClassEditDto = new T_HClassEditDto();
            }

            output.T_HClass = t_HClassEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取培训班人员信息表ListDto信息
        /// </summary>
        public async Task<T_HClassListDto> GetT_HClassByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_HClassRepository.GetAsync(input.Id);

            return entity.MapTo<T_HClassListDto>();
        }







        /// <summary>
        /// 新增或更改培训班人员信息表
        /// </summary>
        public async Task CreateOrUpdateT_HClassAsync(CreateOrUpdateT_HClassInput input)
        {
            if (input.T_HClassEditDto.Id.HasValue)
            {
                await UpdateT_HClassAsync(input.T_HClassEditDto);
            }
            else
            {
                await CreateT_HClassAsync(input.T_HClassEditDto);
            }
        }

        /// <summary>
        /// 新增培训班人员信息表
        /// </summary>
        //[AbpAuthorize(T_HClassAppPermissions.T_HClass_CreateT_HClass)]
        public virtual async Task<T_HClassEditDto> CreateT_HClassAsync(T_HClassEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_HClass>();
            entity.FK_HClass_ClassId = input.FK_ClassId;
            entity.FK_HClass_UserId = input.FK_UserId;
            entity = await _t_HClassRepository.InsertAsync(entity);
            return entity.MapTo<T_HClassEditDto>();
        }

        public T_HClassEditDto IsJoinClass(int classId, int userId)
        {
            var query = _t_HClassRepository.GetAll();
            var entity = query.FirstOrDefault(o => o.FK_HClass_ClassId == classId && o.FK_HClass_UserId == userId);
            return entity.MapTo<T_HClassEditDto>();
        }

        /// <summary>
        /// 编辑培训班人员信息表
        /// </summary>
        // [AbpAuthorize(T_HClassAppPermissions.T_HClass_EditT_HClass)]
        public virtual async Task UpdateT_HClassAsync(T_HClassEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_HClassRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_HClassRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除培训班人员信息表
        /// </summary>
        // [AbpAuthorize(T_HClassAppPermissions.T_HClass_DeleteT_HClass)]
        public async Task DeleteT_HClassAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_HClassRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除培训班人员信息表
        /// </summary>
        [AbpAuthorize(T_HClassAppPermissions.T_HClass_DeleteT_HClass)]
        public async Task BatchDeleteT_HClassAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_HClassRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
