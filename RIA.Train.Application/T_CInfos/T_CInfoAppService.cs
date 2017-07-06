


// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:28:17. All Rights Reserved.
//<生成时间>2017-05-25T22:28:17</生成时间>
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
    /// 培训信息配置表服务实现
    /// </summary>
    //[AbpAuthorize(T_CInfoAppPermissions.T_CInfo)]
    public class T_CInfoAppService : TrainAppServiceBase, IT_CInfoAppService
    {
        private readonly IRepository<T_CInfo, int> _t_CInfoRepository;


        private readonly T_CInfoManage _t_CInfoManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_CInfoAppService(IRepository<T_CInfo, int> t_CInfoRepository,
T_CInfoManage t_CInfoManage

  )
        {
            _t_CInfoRepository = t_CInfoRepository;
            _t_CInfoManage = t_CInfoManage;

        }

        #region 培训信息配置表管理

        /// <summary>
        /// 根据查询条件获取培训信息配置表分页列表
        /// </summary>
        public async Task<PagedResultDto<T_CInfoListDto>> GetPagedT_CInfosAsync(GetT_CInfoInput input)
        {

            var query = _t_CInfoRepository.GetAll().WhereIf(input.Fk_Item_CInfo_Id >= 1, o => o.Fk_Item_CInfo_Id == input.Fk_Item_CInfo_Id);
            //TODO:根据传入的参数添加过滤条件

            var t_CInfoCount = await query.CountAsync();

            var t_CInfos = await query
            .OrderBy(input.Sorting)
            //.PageBy(input)
            .ToListAsync();

            var t_CInfoListDtos = t_CInfos.MapTo<List<T_CInfoListDto>>();
            return new PagedResultDto<T_CInfoListDto>(
            100,
            t_CInfoListDtos
            );
            //return new JtableResult<List<T_CInfoListDto>>(t_CInfoCount, t_CInfoListDtos);
        }

        public async Task<JtableResult<List<T_CInfoListDto>>> GetPagedT_CInfosByItemIdAsync(int id)
        {

            var query = _t_CInfoRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            //var t_CInfoCount = await query.CountAsync();

            var t_CInfos = await query
            .Where(o => o.Fk_Item_CInfo_Id == id)
            .ToListAsync();

            var t_CInfoListDtos = t_CInfos.MapTo<List<T_CInfoListDto>>();
            //return new PagedResultDto<T_CInfoListDto>(
            //t_CInfoCount,
            //t_CInfoListDtos
            //);
            return new JtableResult<List<T_CInfoListDto>>(1000, t_CInfoListDtos);
        }

        /// <summary>
        /// 通过Id获取培训信息配置表信息进行编辑或修改 
        /// </summary>
        public async Task<GetT_CInfoForEditOutput> GetT_CInfoForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetT_CInfoForEditOutput();

            T_CInfoEditDto t_CInfoEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _t_CInfoRepository.GetAsync(input.Id.Value);
                t_CInfoEditDto = entity.MapTo<T_CInfoEditDto>();
            }
            else
            {
                t_CInfoEditDto = new T_CInfoEditDto();
            }

            output.T_CInfo = t_CInfoEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取培训信息配置表ListDto信息
        /// </summary>
        public async Task<T_CInfoListDto> GetT_CInfoByIdAsync(EntityDto<int> input)
        {
            var entity = await _t_CInfoRepository.GetAsync(input.Id);

            return entity.MapTo<T_CInfoListDto>();
        }

        public T_CInfoListDto IsJoinItem(int item_id, int userId)
        {
            var entity = _t_CInfoRepository.GetAll().FirstOrDefault(o => o.Fk_CInfo_UserId == userId && o.Fk_Item_CInfo_Id == item_id);

            return entity.MapTo<T_CInfoListDto>();
        }

        //public T_CInfoListDto GetJoinItem(int userId)
        //{
        //    var entity = _t_CInfoRepository.GetAll().Where(o => o.Fk_CInfo_UserId == userId && o.T_Item.T_Require.UserName == null);

        //    return entity.MapTo<T_CInfoListDto>();
        //}







        /// <summary>
        /// 新增或更改培训信息配置表
        /// </summary>
        public async Task CreateOrUpdateT_CInfoAsync(CreateOrUpdateT_CInfoInput input)
        {
            if (input.T_CInfoEditDto.Id.HasValue)
            {
                await UpdateT_CInfoAsync(input.T_CInfoEditDto);
            }
            else
            {
                await CreateT_CInfoAsync(input.T_CInfoEditDto);
            }
        }

        public async Task BatchCreateOrUpdateT_CInfoAsync(BatchCreateOrUpdateT_CInfoInput inputList)
        {
            foreach (var input in inputList.T_CInfoEditDto)
                await CreateT_CInfoAsync(input);

        }

        /// <summary>
        /// 新增培训信息配置表
        /// </summary>
        //[AbpAuthorize(T_CInfoAppPermissions.T_CInfo_CreateT_CInfo)]
        public virtual async Task<T_CInfoEditDto> CreateT_CInfoAsync(T_CInfoEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<T_CInfo>();

            entity = await _t_CInfoRepository.InsertAsync(entity);
            return entity.MapTo<T_CInfoEditDto>();
        }

        /// <summary>
        /// 编辑培训信息配置表
        /// </summary>
        //[AbpAuthorize(T_CInfoAppPermissions.T_CInfo_EditT_CInfo)]
        public virtual async Task UpdateT_CInfoAsync(T_CInfoEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _t_CInfoRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _t_CInfoRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除培训信息配置表
        /// </summary>
        //[AbpAuthorize(T_CInfoAppPermissions.T_CInfo_DeleteT_CInfo)]
        public async Task DeleteT_CInfoAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _t_CInfoRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除培训信息配置表
        /// </summary>
        [AbpAuthorize(T_CInfoAppPermissions.T_CInfo_DeleteT_CInfo)]
        public async Task BatchDeleteT_CInfoAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _t_CInfoRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion












    }
}
