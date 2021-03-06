﻿

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
using RIA.Train.Core;
using RIA.Train.Entities;
using RIA.Train.Application.Dtos;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
    /// <summary>
    /// 培训信息配置表服务实现
    /// </summary>
    //[AbpAuthorize(T_ClassAppPermissions.T_Class)]
    public class T_ClassAppService : TrainAppServiceBase, IT_ClassAppService
    {
        private readonly IRepository<T_Class, int> _t_ClassRepository;


        private readonly T_ClassManage _t_ClassManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_ClassAppService(IRepository<T_Class, int> t_ClassRepository,
T_ClassManage t_ClassManage

  )
        {
            _t_ClassRepository = t_ClassRepository;
            _t_ClassManage = t_ClassManage;

        }

        #region 培训信息配置表管理

        /// <summary>
        /// 根据查询条件获取培训信息配置表分页列表
        /// </summary>
        public async Task<PagedResultDto<T_ClassListDto>> GetPagedT_ClasssAsync(GetT_ClassInput input)
        {

            var query = _t_ClassRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), o => o.TrainintTeacher.Contains(input.FilterText)); ;
            //TODO:根据传入的参数添加过滤条件

            var t_ClassCount = await query.CountAsync();

            var t_Classs = await query
                 .AsNoTracking()
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_ClassListDtos = t_Classs.MapTo<List<T_ClassListDto>>();
            for (int index = 0; index <= t_Classs.Count - 1; index++)
            {
                t_ClassListDtos[index].ProjectName = t_Classs[index].T_Item.ProjectName;
            }
            return new PagedResultDto<T_ClassListDto>(
            t_ClassCount,
            t_ClassListDtos
            );
            // return new JtableResult<List<T_ClassListDto>>(t_ClassCount, t_ClassListDtos);
        }

        /// <summary>
        /// 通过Id获取培训信息配置表信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_ClassForEditOutput> GetT_ClassForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_ClassForEditOutput();

            T_ClassEditDto t_ClassEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_ClassRepository.GetAsync(input.Id.Value);
                t_ClassEditDto = entity.MapTo<T_ClassEditDto>();
            }
            else
            {
                t_ClassEditDto = new T_ClassEditDto();
            }

            output.T_Class = t_ClassEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取培训信息配置表ListDto信息
        /// </summary>
        public async Task<T_ClassListDto> GetT_ClassByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_ClassRepository.GetAsync(input.Id);

            return entity.MapTo<T_ClassListDto>();
        }

        public T_ClassListDto GetT_ClassById(EntityDto<int> input)
        {
            var entity = _t_ClassRepository.Get(input.Id);

            return entity.MapTo<T_ClassListDto>();
        }







        /// <summary>
        /// 新增或更改培训信息配置表
        /// </summary>
        public async Task CreateOrUpdateT_ClassAsync(CreateOrUpdateT_ClassInput input)
        {
            if (input.T_ClassEditDto.Id.HasValue)
            {
                await UpdateT_ClassAsync(input.T_ClassEditDto);
            }
            else
            {
                await CreateT_ClassAsync(input.T_ClassEditDto);
            }
        }

        /// <summary>
        /// 新增培训信息配置表
        /// </summary>
        //[AbpAuthorize(T_ClassAppPermissions.T_Class_CreateT_Class)]
        public virtual async Task<T_ClassEditDto> CreateT_ClassAsync(T_ClassEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            input.CreateTime = DateTime.Now;
            var entity = input.MapTo<T_Class>();
            entity.Fk_Item_Id = input.Fk_Id;

            entity = await _t_ClassRepository.InsertAsync(entity);
            return entity.MapTo<T_ClassEditDto>();
        }

        /// <summary>
        /// 编辑培训信息配置表
        /// </summary>
        // [AbpAuthorize(T_ClassAppPermissions.T_Class_EditT_Class)]
        public virtual async Task UpdateT_ClassAsync(T_ClassEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_ClassRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_ClassRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除培训信息配置表
        /// </summary>
        // [AbpAuthorize(T_ClassAppPermissions.T_Class_DeleteT_Class)]
        public async Task DeleteT_ClassAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_ClassRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除培训信息配置表
        /// </summary>
        [AbpAuthorize(T_ClassAppPermissions.T_Class_DeleteT_Class)]
        public async Task BatchDeleteT_ClassAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_ClassRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
