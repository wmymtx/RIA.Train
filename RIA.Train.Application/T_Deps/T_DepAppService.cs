                                                                    
     
        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-21T22:00:03. All Rights Reserved.
//<生成时间>2017-05-21T22:00:03</生成时间>
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
using System.Data.Entity;
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
using RIA.Train.Entities;
using RIA.Train.Application.Dtos;
using RIA.Train.Core.Authorization;
using RIA.Train.Core;

namespace RIA.Train.Application
{
    /// <summary>
    /// 部门表服务实现
    /// </summary>
    [AbpAuthorize(T_DepAppPermissions.T_Dep)]
    public class T_DepAppService : TrainAppServiceBase, IT_DepAppService
    {
        private readonly IRepository<T_Dep,int> _t_DepRepository;
		

		private readonly T_DepManage _t_DepManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_DepAppService( IRepository<T_Dep,int> t_DepRepository	,
T_DepManage t_DepManage
	
  )
        {
            _t_DepRepository = t_DepRepository;
			 _t_DepManage = t_DepManage;
			 
        }

    #region 部门表管理

    /// <summary>
    /// 根据查询条件获取部门表分页列表
    /// </summary>
    public async Task<PagedResultDto<T_DepListDto>> GetPagedT_DepsAsync(GetT_DepInput input)
{
			
    var query = _t_DepRepository.GetAll();
    //TODO:根据传入的参数添加过滤条件

    var t_DepCount = await query.CountAsync();

    var t_Deps = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var t_DepListDtos = t_Deps.MapTo<List<T_DepListDto>>();
    return new PagedResultDto<T_DepListDto>(
    t_DepCount,
    t_DepListDtos
    );
    }

        /// <summary>
    /// 通过Id获取部门表信息进行编辑或修改 
    /// </summary>
    public async Task<GetT_DepForEditOutput> GetT_DepForEditAsync(NullableIdDto<int> input)
{
    var output=new GetT_DepForEditOutput();

    T_DepEditDto t_DepEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _t_DepRepository.GetAsync(input.Id.Value);
    t_DepEditDto=entity.MapTo<T_DepEditDto>();
    }
	else 
	{
	t_DepEditDto=new T_DepEditDto();	
	}

	output.T_Dep=t_DepEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取部门表ListDto信息
    /// </summary>
    public async Task<T_DepListDto> GetT_DepByIdAsync(EntityDto<int> input)
{
    var entity = await _t_DepRepository.GetAsync(input.Id);

    return entity.MapTo<T_DepListDto>();
    }







    /// <summary>
    /// 新增或更改部门表
    /// </summary>
    public async Task CreateOrUpdateT_DepAsync(CreateOrUpdateT_DepInput input)
{
    if (input.T_DepEditDto.Id.HasValue)
{
    await UpdateT_DepAsync(input.T_DepEditDto);
    }
    else
{
    await CreateT_DepAsync(input.T_DepEditDto);
    }
    }

    /// <summary>
    /// 新增部门表
    /// </summary>
    [AbpAuthorize(T_DepAppPermissions.T_Dep_CreateT_Dep)]
    public virtual async Task<T_DepEditDto> CreateT_DepAsync(T_DepEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<T_Dep>();
	
    entity = await _t_DepRepository.InsertAsync(entity);
    return entity.MapTo<T_DepEditDto>();
    }

    /// <summary>
    /// 编辑部门表
    /// </summary>
    [AbpAuthorize(T_DepAppPermissions.T_Dep_EditT_Dep)]
    public virtual async Task UpdateT_DepAsync(T_DepEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _t_DepRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _t_DepRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除部门表
    /// </summary>
    [AbpAuthorize(T_DepAppPermissions.T_Dep_DeleteT_Dep)]
    public async Task DeleteT_DepAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _t_DepRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除部门表
    /// </summary>
    [AbpAuthorize(T_DepAppPermissions.T_Dep_DeleteT_Dep)]
    public async Task BatchDeleteT_DepAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _t_DepRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion


  









    }
    }
