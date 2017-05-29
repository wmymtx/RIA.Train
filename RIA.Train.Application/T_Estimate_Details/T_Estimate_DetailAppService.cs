                                                                    
     
        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:59:47. All Rights Reserved.
//<生成时间>2017-05-25T22:59:47</生成时间>
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

namespace RIA.Train.Application
{
    /// <summary>
    /// 评价明细服务实现
    /// </summary>
    [AbpAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail)]
    public class T_Estimate_DetailAppService : TrainAppServiceBase, IT_Estimate_DetailAppService
    {
        private readonly IRepository<T_Estimate_Detail,int> _t_Estimate_DetailRepository;
		

		private readonly T_Estimate_DetailManage _t_Estimate_DetailManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_Estimate_DetailAppService( IRepository<T_Estimate_Detail,int> t_Estimate_DetailRepository	,
T_Estimate_DetailManage t_Estimate_DetailManage
	
  )
        {
            _t_Estimate_DetailRepository = t_Estimate_DetailRepository;
			 _t_Estimate_DetailManage = t_Estimate_DetailManage;
			 
        }

    #region 评价明细管理

    /// <summary>
    /// 根据查询条件获取评价明细分页列表
    /// </summary>
    public async Task<PagedResultDto<T_Estimate_DetailListDto>> GetPagedT_Estimate_DetailsAsync(GetT_Estimate_DetailInput input)
{
			
    var query = _t_Estimate_DetailRepository.GetAll();
    //TODO:根据传入的参数添加过滤条件

    var t_Estimate_DetailCount = await query.CountAsync();

    var t_Estimate_Details = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var t_Estimate_DetailListDtos = t_Estimate_Details.MapTo<List<T_Estimate_DetailListDto>>();
    return new PagedResultDto<T_Estimate_DetailListDto>(
    t_Estimate_DetailCount,
    t_Estimate_DetailListDtos
    );
    }

        /// <summary>
    /// 通过Id获取评价明细信息进行编辑或修改 
    /// </summary>
    public async Task<GetT_Estimate_DetailForEditOutput> GetT_Estimate_DetailForEditAsync(NullableIdDto<int> input)
{
    var output=new GetT_Estimate_DetailForEditOutput();

    T_Estimate_DetailEditDto t_Estimate_DetailEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _t_Estimate_DetailRepository.GetAsync(input.Id.Value);
    t_Estimate_DetailEditDto=entity.MapTo<T_Estimate_DetailEditDto>();
    }
	else 
	{
	t_Estimate_DetailEditDto=new T_Estimate_DetailEditDto();	
	}

	output.T_Estimate_Detail=t_Estimate_DetailEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取评价明细ListDto信息
    /// </summary>
    public async Task<T_Estimate_DetailListDto> GetT_Estimate_DetailByIdAsync(EntityDto<int> input)
{
    var entity = await _t_Estimate_DetailRepository.GetAsync(input.Id);

    return entity.MapTo<T_Estimate_DetailListDto>();
    }







    /// <summary>
    /// 新增或更改评价明细
    /// </summary>
    public async Task CreateOrUpdateT_Estimate_DetailAsync(CreateOrUpdateT_Estimate_DetailInput input)
{
    if (input.T_Estimate_DetailEditDto.Id.HasValue)
{
    await UpdateT_Estimate_DetailAsync(input.T_Estimate_DetailEditDto);
    }
    else
{
    await CreateT_Estimate_DetailAsync(input.T_Estimate_DetailEditDto);
    }
    }

    /// <summary>
    /// 新增评价明细
    /// </summary>
    [AbpAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail_CreateT_Estimate_Detail)]
    public virtual async Task<T_Estimate_DetailEditDto> CreateT_Estimate_DetailAsync(T_Estimate_DetailEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<T_Estimate_Detail>();
	
    entity = await _t_Estimate_DetailRepository.InsertAsync(entity);
    return entity.MapTo<T_Estimate_DetailEditDto>();
    }

    /// <summary>
    /// 编辑评价明细
    /// </summary>
    [AbpAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail_EditT_Estimate_Detail)]
    public virtual async Task UpdateT_Estimate_DetailAsync(T_Estimate_DetailEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _t_Estimate_DetailRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _t_Estimate_DetailRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除评价明细
    /// </summary>
    [AbpAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail_DeleteT_Estimate_Detail)]
    public async Task DeleteT_Estimate_DetailAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _t_Estimate_DetailRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除评价明细
    /// </summary>
    [AbpAuthorize(T_Estimate_DetailAppPermissions.T_Estimate_Detail_DeleteT_Estimate_Detail)]
    public async Task BatchDeleteT_Estimate_DetailAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _t_Estimate_DetailRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion


  









    }
    }
