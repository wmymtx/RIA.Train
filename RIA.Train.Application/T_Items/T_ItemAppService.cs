


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
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using RIA.Train.Authorization;
using RIA.Train.Entities;
using RIA.Train.Core;
using RIA.Train.Core.Authorization;
using RIA.Train.Application.Dtos;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
    /// <summary>
    /// 培训项目设置服务实现
    /// </summary>
   // [AbpAuthorize(T_ItemAppPermissions.T_Item)]
    public class T_ItemAppService : TrainAppServiceBase, IT_ItemAppService
    {
        private readonly IRepository<T_Item, int> _t_ItemRepository;
        private readonly IRepository<T_Require, int> _t_RequireRepository;

        private readonly T_ItemManage _t_ItemManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_ItemAppService(IRepository<T_Item, int> t_ItemRepository,
T_ItemManage t_ItemManage, IRepository<T_Require, int> t_RequireRepository

  )
        {
            _t_RequireRepository = t_RequireRepository;
            _t_ItemRepository = t_ItemRepository;
            _t_ItemManage = t_ItemManage;

        }

        #region 培训项目设置管理

        /// <summary>
        /// 根据查询条件获取培训项目设置分页列表
        /// </summary>
        public async Task<PagedResultDto<T_ItemListDto>> GetPagedT_ItemsAsync(GetT_ItemInput input)
        {

            var query = _t_ItemRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), o => o.ProjectName.Contains(input.FilterText)); ;
            //TODO:根据传入的参数添加过滤条件

            var query1 = from i in _t_ItemRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), o => o.ProjectName.Contains(input.FilterText))
                         join r in _t_RequireRepository.GetAll()
on i.Id equals r.Fk_Item_Require_Id into ji
                         from j2 in ji.DefaultIfEmpty()
                         group j2 by new { i.CreateTime, i.Id, i.ProjectName } into grouped
                         select new T_ItemListDto { ProjectName = grouped.Key.ProjectName, CreateTime = grouped.Key.CreateTime, Id = grouped.Key.Id, Count = grouped.Count(_ => _.UserName != null) };
            dynamic rst = query1.ToList();
            var t_ItemCount = await query1.CountAsync();//await query.CountAsync();

            //var t_Items = await query
            //    .AsNoTracking()
            //.OrderBy(input.Sorting)
            //.PageBy(input)
            //.ToListAsync();

            var t_Items = await query1
               .AsNoTracking()
           .OrderBy(input.Sorting)
           .PageBy(input)
           .ToListAsync();

            var t_ItemListDtos = t_Items;// t_Items.MapTo<List<T_ItemListDto>>();
            return new PagedResultDto<T_ItemListDto>(
            t_ItemCount,
            t_ItemListDtos
            );
            //return new JtableResult<List<T_ItemListDto>>(t_ItemCount, t_ItemListDtos);
        }

        /// <summary>
        /// 通过Id获取培训项目设置信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_ItemForEditOutput> GetT_ItemForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_ItemForEditOutput();

            T_ItemEditDto t_ItemEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_ItemRepository.GetAsync(input.Id.Value);
                t_ItemEditDto = entity.MapTo<T_ItemEditDto>();
            }
            else
            {
                t_ItemEditDto = new T_ItemEditDto();
            }

            output.T_Item = t_ItemEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取培训项目设置ListDto信息
        /// </summary>
        public async Task<T_ItemListDto> GetT_ItemByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_ItemRepository.GetAsync(input.Id);

            return entity.MapTo<T_ItemListDto>();
        }

        public WeChatItemListDto GetT_ItemById(int id)
        {
            var entity = _t_ItemRepository.GetAllIncluding(o => o.T_KPoints).FirstOrDefault(o => o.Id == id);

            return entity.MapTo<WeChatItemListDto>();
        }







        /// <summary>
        /// 新增或更改培训项目设置
        /// </summary>
        public async Task CreateOrUpdateT_ItemAsync(CreateOrUpdateT_ItemInput input)
        {
            if (input.T_ItemEditDto.Id.HasValue)
            {
                await UpdateT_ItemAsync(input.T_ItemEditDto);
            }
            else
            {
                await CreateT_ItemAsync(input.T_ItemEditDto);
            }
        }

        /// <summary>
        /// 新增培训项目设置
        /// </summary>
        // [AbpAuthorize(T_ItemAppPermissions.T_Item_CreateT_Item)]
        public virtual async Task<T_ItemEditDto> CreateT_ItemAsync(T_ItemEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            input.CreateTime = DateTime.Now;
            var entity = input.MapTo<T_Item>();

            entity = await _t_ItemRepository.InsertAsync(entity);
            return entity.MapTo<T_ItemEditDto>();
        }

        //public List<T_ItemListDto> GetJoinItem(int userId)
        //{
        //    var entity = _t_ItemRepository.GetAll().Where(o => o.T_CInfos.FirstOrDefault(_ => _.Fk_CInfo_UserId == userId) != null && o.T_Require.UserName == null);
        //    return entity.ToList().MapTo<List<T_ItemListDto>>();
        //}

        /// <summary>
        /// 编辑培训项目设置
        /// </summary>
        // [AbpAuthorize(T_ItemAppPermissions.T_Item_EditT_Item)]
        public virtual async Task UpdateT_ItemAsync(T_ItemEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_ItemRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_ItemRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除培训项目设置
        /// </summary>
        // [AbpAuthorize(T_ItemAppPermissions.T_Item_DeleteT_Item)]
        public async Task DeleteT_ItemAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_ItemRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除培训项目设置
        /// </summary>
        [AbpAuthorize(T_ItemAppPermissions.T_Item_DeleteT_Item)]
        public async Task BatchDeleteT_ItemAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_ItemRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
