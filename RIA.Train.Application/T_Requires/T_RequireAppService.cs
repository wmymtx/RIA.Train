


// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:47:40. All Rights Reserved.
//<生成时间>2017-05-25T22:47:40</生成时间>
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
using RIA.Train.T_Requires.Exporting;

namespace RIA.Train.Application
{
    /// <summary>
    /// 培训需求提报服务实现
    /// </summary>
   // [AbpAuthorize(T_RequireAppPermissions.T_Require)]
    public class T_RequireAppService : TrainAppServiceBase, IT_RequireAppService
    {
        private readonly IRepository<T_Item, int> _t_ItemRepository;
        private readonly IRepository<T_Require, int> _t_RequireRepository;

        private readonly IT_RequireExcelExporter excelExporter;
        private readonly T_RequireManage _t_RequireManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_RequireAppService(IRepository<T_Require, int> t_RequireRepository,
T_RequireManage t_RequireManage, IRepository<T_Item, int> t_ItemRepository

  )
        {
            _t_RequireRepository = t_RequireRepository;
            _t_RequireManage = t_RequireManage;
            _t_ItemRepository = t_ItemRepository;
            excelExporter = new T_RequireExcelExporter(); ;
        }

        #region 培训需求提报管理

        /// <summary>
        /// 根据查询条件获取培训需求提报分页列表
        /// </summary>
        public async Task<PagedResultDto<T_RequireListDto>> GetPagedT_RequiresAsync(GetT_RequireInput input)
        {

            var query = _t_RequireRepository.GetAll().WhereIf(input.Fk_Item_Require_Id >= 1, _ => _.Fk_Item_Require_Id == input.Fk_Item_Require_Id);
            //TODO:根据传入的参数添加过滤条件

            var t_RequireCount = await query.CountAsync();

            var t_Requires = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_RequireListDtos = t_Requires.MapTo<List<T_RequireListDto>>();
            return new PagedResultDto<T_RequireListDto>(
            t_RequireCount,
            t_RequireListDtos
            );
            // return new JtableResult<List<T_RequireListDto>>(t_RequireCount, t_RequireListDtos);
        }


        public List<T_ItemListDto> GetJoinItem(int userId)
        {
            var query = (from item in _t_ItemRepository.GetAll().Where(o => o.T_CInfos.Any(_ => _.Fk_CInfo_UserId == userId))
                         join re in _t_RequireRepository.GetAll().Where(o => o.Fk_Require_UserId == userId)
on item.Id equals re.Fk_Item_Require_Id
                          into b_join
                         from f in b_join.DefaultIfEmpty()
                         where f.UserName == null
                         select new T_ItemListDto { ProjectName = item.ProjectName, Id = item.Id }
                         );
            //var entity = _t_RequireRepository.GetAll().Where(o => o.I_Item.T_CInfos.Any(_ => _.Fk_CInfo_UserId == userId);
            //return entity.ToList().MapTo<List<T_ItemListDto>>();
            return query.ToList();
        }

        /// <summary>
        /// 通过Id获取培训需求提报信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_RequireForEditOutput> GetT_RequireForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_RequireForEditOutput();

            T_RequireEditDto t_RequireEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_RequireRepository.GetAsync(input.Id.Value);
                t_RequireEditDto = entity.MapTo<T_RequireEditDto>();
            }
            else
            {
                t_RequireEditDto = new T_RequireEditDto();
            }

            output.T_Require = t_RequireEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取培训需求提报ListDto信息
        /// </summary>
        public async Task<T_RequireListDto> GetT_RequireByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_RequireRepository.GetAsync(input.Id);

            return entity.MapTo<T_RequireListDto>();
        }







        /// <summary>
        /// 新增或更改培训需求提报
        /// </summary>
        public async Task CreateOrUpdateT_RequireAsync(CreateOrUpdateT_RequireInput input)
        {
            //if (input.T_RequireEditDto.Id.HasValue)
            //{
            //    await UpdateT_RequireAsync(input.T_RequireEditDto);
            //}
            //else
            //{
            //    await CreateT_RequireAsync(input.T_RequireEditDto);
            //}
            foreach (var item in input.T_RequireEditDto)
                await CreateT_RequireAsync(item);
        }

        /// <summary>
        /// 新增培训需求提报
        /// </summary>
        // [AbpAuthorize(T_RequireAppPermissions.T_Require_CreateT_Require)]
        public virtual async Task<T_RequireEditDto> CreateT_RequireAsync(T_RequireEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_Require>();

            entity = await _t_RequireRepository.InsertAsync(entity);
            return entity.MapTo<T_RequireEditDto>();
        }

        /// <summary>
        /// 编辑培训需求提报
        /// </summary>
        // [AbpAuthorize(T_RequireAppPermissions.T_Require_EditT_Require)]
        public virtual async Task UpdateT_RequireAsync(T_RequireEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_RequireRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_RequireRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除培训需求提报
        /// </summary>
        // [AbpAuthorize(T_RequireAppPermissions.T_Require_DeleteT_Require)]
        public async Task DeleteT_RequireAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_RequireRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除培训需求提报
        /// </summary>
        [AbpAuthorize(T_RequireAppPermissions.T_Require_DeleteT_Require)]
        public async Task BatchDeleteT_RequireAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_RequireRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion




        public async Task<FileDto> GetT_RequireToExcel(GetT_RequireInput input)
        {
            var auditLogs = await _t_RequireRepository.GetAll().WhereIf(input.Fk_Item_Require_Id >= 1, o => o.Fk_Item_Require_Id == input.Fk_Item_Require_Id)
                        .AsNoTracking()
                        .OrderByDescending(al => al.SubmitTime)
                        .ToListAsync();

            // var auditLogListDtos = ConvertToAuditLogListDtos(auditLogs);

            return excelExporter.ExportToFile(auditLogs.MapTo<List<T_RequireListDto>>());
        }







    }
}
