                                                                    
     
        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-23T22:10:13. All Rights Reserved.
//<生成时间>2017-05-23T22:10:13</生成时间>
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

namespace RIA.Train.Application
{
    /// <summary>
    /// 班组表服务实现
    /// </summary>
    [AbpAuthorize(T_GroupAppPermissions.T_Group)]
    public class T_GroupAppService : TrainAppServiceBase, IT_GroupAppService
    {
        private readonly IRepository<T_Group,int> _t_GroupRepository;
		

		private readonly T_GroupManage _t_GroupManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_GroupAppService( IRepository<T_Group,int> t_GroupRepository	,
T_GroupManage t_GroupManage
	
  )
        {
            _t_GroupRepository = t_GroupRepository;
			 _t_GroupManage = t_GroupManage;
			 
        }

    #region 班组表管理

    /// <summary>
    /// 根据查询条件获取班组表分页列表
    /// </summary>
    public async Task<PagedResultDto<T_GroupListDto>> GetPagedT_GroupsAsync(GetT_GroupInput input)
{
			
    var query = _t_GroupRepository.GetAll();
    //TODO:根据传入的参数添加过滤条件

    var t_GroupCount = await query.CountAsync();

    var t_Groups = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var t_GroupListDtos = t_Groups.MapTo<List<T_GroupListDto>>();
    return new PagedResultDto<T_GroupListDto>(
    t_GroupCount,
    t_GroupListDtos
    );
    }

        /// <summary>
    /// 通过Id获取班组表信息进行编辑或修改 
    /// </summary>
    public async Task<GetT_GroupForEditOutput> GetT_GroupForEditAsync(NullableIdDto<int> input)
{
    var output=new GetT_GroupForEditOutput();

    T_GroupEditDto t_GroupEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _t_GroupRepository.GetAsync(input.Id.Value);
    t_GroupEditDto=entity.MapTo<T_GroupEditDto>();
    }
	else 
	{
	t_GroupEditDto=new T_GroupEditDto();	
	}

	output.T_Group=t_GroupEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取班组表ListDto信息
    /// </summary>
    public async Task<T_GroupListDto> GetT_GroupByIdAsync(EntityDto<int> input)
{
    var entity = await _t_GroupRepository.GetAsync(input.Id);

    return entity.MapTo<T_GroupListDto>();
    }







    /// <summary>
    /// 新增或更改班组表
    /// </summary>
    public async Task CreateOrUpdateT_GroupAsync(CreateOrUpdateT_GroupInput input)
{
    if (input.T_GroupEditDto.Id.HasValue)
{
    await UpdateT_GroupAsync(input.T_GroupEditDto);
    }
    else
{
    await CreateT_GroupAsync(input.T_GroupEditDto);
    }
    }

    /// <summary>
    /// 新增班组表
    /// </summary>
    [AbpAuthorize(T_GroupAppPermissions.T_Group_CreateT_Group)]
    public virtual async Task<T_GroupEditDto> CreateT_GroupAsync(T_GroupEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<T_Group>();
	
    entity = await _t_GroupRepository.InsertAsync(entity);
    return entity.MapTo<T_GroupEditDto>();
    }

    /// <summary>
    /// 编辑班组表
    /// </summary>
    [AbpAuthorize(T_GroupAppPermissions.T_Group_EditT_Group)]
    public virtual async Task UpdateT_GroupAsync(T_GroupEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _t_GroupRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _t_GroupRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除班组表
    /// </summary>
    [AbpAuthorize(T_GroupAppPermissions.T_Group_DeleteT_Group)]
    public async Task DeleteT_GroupAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _t_GroupRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除班组表
    /// </summary>
    [AbpAuthorize(T_GroupAppPermissions.T_Group_DeleteT_Group)]
    public async Task BatchDeleteT_GroupAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _t_GroupRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion


  









    }
    }
