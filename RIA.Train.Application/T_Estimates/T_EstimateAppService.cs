
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
using RIA.Train.T_Estimates.Exporting;

namespace RIA.Train.Application
{
    /// <summary>
    /// 老师评价结果表服务实现
    /// </summary>
    //[AbpAuthorize(T_EstimateAppPermissions.T_Estimate)]
    public class T_EstimateAppService : TrainAppServiceBase, IT_EstimateAppService
    {
        private readonly IRepository<T_Estimate, int> _t_EstimateRepository;
        private readonly IT_EstimateExcelExporter excelExporter;

        private readonly T_EstimateManage _t_EstimateManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_EstimateAppService(IRepository<T_Estimate, int> t_EstimateRepository,
T_EstimateManage t_EstimateManage

  )
        {
            _t_EstimateRepository = t_EstimateRepository;
            _t_EstimateManage = t_EstimateManage;
            excelExporter = new T_EstimateExcelExporter();
        }

        #region 老师评价结果表管理

        /// <summary>
        /// 根据查询条件获取老师评价结果表分页列表
        /// </summary>
        public async Task<PagedResultDto<T_EstimateListDto>> GetPagedT_EstimatesAsync(GetT_EstimateInput input)
        {

            var query = _t_EstimateRepository.GetAll().WhereIf(input.FK_ClassId >= 1, _ => _.FK_ClassId == input.FK_ClassId);
            //TODO:根据传入的参数添加过滤条件

            var t_EstimateCount = await query.CountAsync();

            var t_Estimates = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var t_EstimateListDtos = t_Estimates.MapTo<List<T_EstimateListDto>>();

            if (t_EstimateListDtos.Count >= 1)
            {
                List<T_EstimateListDto> output = new List<T_EstimateListDto>();
                for (int index = 0; index <= t_EstimateListDtos.Count - 1; index++)
                {
                    output.Add(new T_EstimateListDto()
                    {
                        vContent = t_EstimateListDtos[index].T_Content.Content,
                        ContentCount = t_EstimateListDtos[index].ContentCount,
                        vGrade = t_EstimateListDtos[index].T_Grade.Grade
                    });
                }
                return new PagedResultDto<T_EstimateListDto>(
               t_EstimateCount, output
                );

            }

            return new PagedResultDto<T_EstimateListDto>(t_EstimateCount, t_EstimateListDtos);
        }

        /// <summary>
        /// 通过Id获取老师评价结果表信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_EstimateForEditOutput> GetT_EstimateForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_EstimateForEditOutput();

            T_EstimateEditDto t_EstimateEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_EstimateRepository.GetAsync(input.Id.Value);
                t_EstimateEditDto = entity.MapTo<T_EstimateEditDto>();
            }
            else
            {
                t_EstimateEditDto = new T_EstimateEditDto();
            }

            output.T_Estimate = t_EstimateEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取老师评价结果表ListDto信息
        /// </summary>
        public async Task<T_EstimateListDto> GetT_EstimateByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_EstimateRepository.GetAsync(input.Id);

            return entity.MapTo<T_EstimateListDto>();
        }

        public List<T_EstimateEditDto> GetT_EstimateById(int classId)
        {
            var entity = _t_EstimateRepository.GetAll().Where(o => o.FK_ClassId == classId);

            return entity.MapTo<List<T_EstimateEditDto>>();
        }

        public T_EstimateEditDto CreateEstimate(T_EstimateEditDto input)
        {
            var entity = input.MapTo<T_Estimate>();

            entity = _t_EstimateRepository.Insert(entity);
            return entity.MapTo<T_EstimateEditDto>();
        }

        public void UpdateEstimate(T_EstimateEditDto input)
        {
            var entity = _t_EstimateRepository.Get(input.Id.Value);
            input.MapTo(entity);

            _t_EstimateRepository.Update(entity);
        }







        /// <summary>
        /// 新增或更改老师评价结果表
        /// </summary>
        public async Task CreateOrUpdateT_EstimateAsync(CreateOrUpdateT_EstimateInput input)
        {
            if (input.T_EstimateEditDto.Id.HasValue)
            {
                await UpdateT_EstimateAsync(input.T_EstimateEditDto);
            }
            else
            {
                await CreateT_EstimateAsync(input.T_EstimateEditDto);
            }
        }

        /// <summary>
        /// 新增老师评价结果表
        /// </summary>
       // [AbpAuthorize(T_EstimateAppPermissions.T_Estimate_CreateT_Estimate)]
        public virtual async Task<T_EstimateEditDto> CreateT_EstimateAsync(T_EstimateEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_Estimate>();

            entity = await _t_EstimateRepository.InsertAsync(entity);
            return entity.MapTo<T_EstimateEditDto>();
        }

        /// <summary>
        /// 编辑老师评价结果表
        /// </summary>
       // [AbpAuthorize(T_EstimateAppPermissions.T_Estimate_EditT_Estimate)]
        public virtual async Task UpdateT_EstimateAsync(T_EstimateEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_EstimateRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_EstimateRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除老师评价结果表
        /// </summary>
       // [AbpAuthorize(T_EstimateAppPermissions.T_Estimate_DeleteT_Estimate)]
        public async Task DeleteT_EstimateAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_EstimateRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除老师评价结果表
        /// </summary>
       // [AbpAuthorize(T_EstimateAppPermissions.T_Estimate_DeleteT_Estimate)]
        public async Task BatchDeleteT_EstimateAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_EstimateRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<FileDto> GetT_EstimateToExcel(GetT_EstimateInput input)
        {
            var auditLogs = await _t_EstimateRepository.GetAll().WhereIf(input.FK_ClassId >= 1, o => o.FK_ClassId == input.FK_ClassId)
                        .AsNoTracking()
                        .OrderByDescending(al => al.Id)
                        .ToListAsync();

            // var auditLogListDtos = ConvertToAuditLogListDtos(auditLogs);
            var exportList = auditLogs.MapTo<List<ExportListDto>>();
            return excelExporter.ExportToFile(auditLogs.MapTo<List<T_EstimateListDto>>());
        }

        #endregion












    }
}
