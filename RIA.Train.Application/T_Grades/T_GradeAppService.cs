


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
    /// 考评等级服务实现
    /// </summary>
    //[AbpAuthorize(T_GradeAppPermissions.T_Grade)]
    public class T_GradeAppService : TrainAppServiceBase, IT_GradeAppService
    {
        private readonly IRepository<T_Grade, int> _t_GradeRepository;


        private readonly T_GradeManage _t_GradeManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_GradeAppService(IRepository<T_Grade, int> t_GradeRepository,
T_GradeManage t_GradeManage

  )
        {
            _t_GradeRepository = t_GradeRepository;
            _t_GradeManage = t_GradeManage;

        }

        #region 考评等级管理

        /// <summary>
        /// 根据查询条件获取考评等级分页列表
        /// </summary>
        public async Task<PagedResultDto<T_GradeListDto>> GetPagedT_GradesAsync(GetT_GradeInput input)
        {

            var query = _t_GradeRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var t_GradeCount = await query.CountAsync();

            var t_Grades = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_GradeListDtos = t_Grades.MapTo<List<T_GradeListDto>>();
            return new PagedResultDto<T_GradeListDto>(
            t_GradeCount,
            t_GradeListDtos
            );
            //return new JtableResult<List<T_GradeListDto>>(t_GradeCount, t_GradeListDtos);
        }

        public List<T_GradeListDto> GetT_Grades()
        {

            var query = _t_GradeRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            return query.ToList().MapTo<List<T_GradeListDto>>();
        }

        /// <summary>
        /// 通过Id获取考评等级信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_GradeForEditOutput> GetT_GradeForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_GradeForEditOutput();

            T_GradeEditDto t_GradeEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_GradeRepository.GetAsync(input.Id.Value);
                t_GradeEditDto = entity.MapTo<T_GradeEditDto>();
            }
            else
            {
                t_GradeEditDto = new T_GradeEditDto();
            }

            output.T_Grade = t_GradeEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取考评等级ListDto信息
        /// </summary>
        public async Task<T_GradeListDto> GetT_GradeByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_GradeRepository.GetAsync(input.Id);

            return entity.MapTo<T_GradeListDto>();
        }







        /// <summary>
        /// 新增或更改考评等级
        /// </summary>
        public async Task CreateOrUpdateT_GradeAsync(CreateOrUpdateT_GradeInput input)
        {
            if (input.T_GradeEditDto.Id.HasValue)
            {
                await UpdateT_GradeAsync(input.T_GradeEditDto);
            }
            else
            {
                await CreateT_GradeAsync(input.T_GradeEditDto);
            }
        }

        /// <summary>
        /// 新增考评等级
        /// </summary>
        // [AbpAuthorize(T_GradeAppPermissions.T_Grade_CreateT_Grade)]
        public virtual async Task<T_GradeEditDto> CreateT_GradeAsync(T_GradeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_Grade>();

            entity = await _t_GradeRepository.InsertAsync(entity);
            return entity.MapTo<T_GradeEditDto>();
        }

        /// <summary>
        /// 编辑考评等级
        /// </summary>
        //[AbpAuthorize(T_GradeAppPermissions.T_Grade_EditT_Grade)]
        public virtual async Task UpdateT_GradeAsync(T_GradeEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_GradeRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_GradeRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除考评等级
        /// </summary>
        // [AbpAuthorize(T_GradeAppPermissions.T_Grade_DeleteT_Grade)]
        public async Task DeleteT_GradeAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_GradeRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除考评等级
        /// </summary>
        [AbpAuthorize(T_GradeAppPermissions.T_Grade_DeleteT_Grade)]
        public async Task BatchDeleteT_GradeAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_GradeRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
