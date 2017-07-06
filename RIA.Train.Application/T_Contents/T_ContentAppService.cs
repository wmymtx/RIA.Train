


// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:16:06. All Rights Reserved.
//<生成时间>2017-05-25T22:16:06</生成时间>
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
using RIA.Train.Entities;
using RIA.Train.Core;
using RIA.Train.Core.Authorization;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
    /// <summary>
    /// 考评内容（档次）服务实现
    /// </summary>
   // [AbpAuthorize(T_ContentAppPermissions.T_Content)]
    public class T_ContentAppService : TrainAppServiceBase, IT_ContentAppService
    {
        private readonly IRepository<T_Content, int> _t_ContentRepository;


        private readonly T_ContentManage _t_ContentManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_ContentAppService(IRepository<T_Content, int> t_ContentRepository,
T_ContentManage t_ContentManage

  )
        {
            _t_ContentRepository = t_ContentRepository;
            _t_ContentManage = t_ContentManage;

        }

        #region 考评内容（档次）管理

        /// <summary>
        /// 根据查询条件获取考评内容（档次）分页列表
        /// </summary>
        public async Task<PagedResultDto<T_ContentListDto>> GetPagedT_ContentsAsync(GetT_ContentInput input)
        {

            var query = _t_ContentRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var t_ContentCount = await query.CountAsync();

            var t_Contents = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_ContentListDtos = t_Contents.MapTo<List<T_ContentListDto>>();
            return new PagedResultDto<T_ContentListDto>(
            t_ContentCount,
            t_ContentListDtos
            );
           // return new JtableResult<List<T_ContentListDto>>(t_ContentCount, t_ContentListDtos);
        }

        public List<T_ContentListDto> GetT_Contents()
        {

            var query = _t_ContentRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            return query.ToList().MapTo<List<T_ContentListDto>>();
        }

        /// <summary>
        /// 通过Id获取考评内容（档次）信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_ContentForEditOutput> GetT_ContentForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_ContentForEditOutput();

            T_ContentEditDto t_ContentEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_ContentRepository.GetAsync(input.Id.Value);
                t_ContentEditDto = entity.MapTo<T_ContentEditDto>();
            }
            else
            {
                t_ContentEditDto = new T_ContentEditDto();
            }

            output.T_Content = t_ContentEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取考评内容（档次）ListDto信息
        /// </summary>
        public async Task<T_ContentListDto> GetT_ContentByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_ContentRepository.GetAsync(input.Id);

            return entity.MapTo<T_ContentListDto>();
        }







        /// <summary>
        /// 新增或更改考评内容（档次）
        /// </summary>
        public async Task CreateOrUpdateT_ContentAsync(CreateOrUpdateT_ContentInput input)
        {
            if (input.T_ContentEditDto.Id.HasValue)
            {
                await UpdateT_ContentAsync(input.T_ContentEditDto);
            }
            else
            {
                await CreateT_ContentAsync(input.T_ContentEditDto);
            }
        }

        /// <summary>
        /// 新增考评内容（档次）
        /// </summary>
        // [AbpAuthorize(T_ContentAppPermissions.T_Content_CreateT_Content)]
        public virtual async Task<T_ContentEditDto> CreateT_ContentAsync(T_ContentEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_Content>();

            entity = await _t_ContentRepository.InsertAsync(entity);
            return entity.MapTo<T_ContentEditDto>();
        }

        /// <summary>
        /// 编辑考评内容（档次）
        /// </summary>
        //[AbpAuthorize(T_ContentAppPermissions.T_Content_EditT_Content)]
        public virtual async Task UpdateT_ContentAsync(T_ContentEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_ContentRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_ContentRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除考评内容（档次）
        /// </summary>
        // [AbpAuthorize(T_ContentAppPermissions.T_Content_DeleteT_Content)]
        public async Task DeleteT_ContentAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_ContentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除考评内容（档次）
        /// </summary>
        [AbpAuthorize(T_ContentAppPermissions.T_Content_DeleteT_Content)]
        public async Task BatchDeleteT_ContentAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_ContentRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
