                                                                    
     
        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:44:48. All Rights Reserved.
//<生成时间>2017-05-25T22:44:48</生成时间>
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
    /// 培训重点服务实现
    /// </summary>
    [AbpAuthorize(T_KPointAppPermissions.T_KPoint)]
    public class T_KPointAppService : TrainAppServiceBase, IT_KPointAppService
    {
        private readonly IRepository<T_KPoint,int> _t_KPointRepository;
		

		private readonly T_KPointManage _t_KPointManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_KPointAppService( IRepository<T_KPoint,int> t_KPointRepository	,
T_KPointManage t_KPointManage
	
  )
        {
            _t_KPointRepository = t_KPointRepository;
			 _t_KPointManage = t_KPointManage;
			 
        }

    #region 培训重点管理

    /// <summary>
    /// 根据查询条件获取培训重点分页列表
    /// </summary>
    public async Task<PagedResultDto<T_KPointListDto>> GetPagedT_KPointsAsync(GetT_KPointInput input)
{
			
    var query = _t_KPointRepository.GetAll();
    //TODO:根据传入的参数添加过滤条件

    var t_KPointCount = await query.CountAsync();

    var t_KPoints = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var t_KPointListDtos = t_KPoints.MapTo<List<T_KPointListDto>>();
    return new PagedResultDto<T_KPointListDto>(
    t_KPointCount,
    t_KPointListDtos
    );
    }

        /// <summary>
    /// 通过Id获取培训重点信息进行编辑或修改 
    /// </summary>
    public async Task<GetT_KPointForEditOutput> GetT_KPointForEditAsync(NullableIdDto<int> input)
{
    var output=new GetT_KPointForEditOutput();

    T_KPointEditDto t_KPointEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _t_KPointRepository.GetAsync(input.Id.Value);
    t_KPointEditDto=entity.MapTo<T_KPointEditDto>();
    }
	else 
	{
	t_KPointEditDto=new T_KPointEditDto();	
	}

	output.T_KPoint=t_KPointEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取培训重点ListDto信息
    /// </summary>
    public async Task<T_KPointListDto> GetT_KPointByIdAsync(EntityDto<int> input)
{
    var entity = await _t_KPointRepository.GetAsync(input.Id);

    return entity.MapTo<T_KPointListDto>();
    }







    /// <summary>
    /// 新增或更改培训重点
    /// </summary>
    public async Task CreateOrUpdateT_KPointAsync(CreateOrUpdateT_KPointInput input)
{
    if (input.T_KPointEditDto.Id.HasValue)
{
    await UpdateT_KPointAsync(input.T_KPointEditDto);
    }
    else
{
    await CreateT_KPointAsync(input.T_KPointEditDto);
    }
    }

    /// <summary>
    /// 新增培训重点
    /// </summary>
    [AbpAuthorize(T_KPointAppPermissions.T_KPoint_CreateT_KPoint)]
    public virtual async Task<T_KPointEditDto> CreateT_KPointAsync(T_KPointEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<T_KPoint>();
	
    entity = await _t_KPointRepository.InsertAsync(entity);
    return entity.MapTo<T_KPointEditDto>();
    }

    /// <summary>
    /// 编辑培训重点
    /// </summary>
    [AbpAuthorize(T_KPointAppPermissions.T_KPoint_EditT_KPoint)]
    public virtual async Task UpdateT_KPointAsync(T_KPointEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _t_KPointRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _t_KPointRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除培训重点
    /// </summary>
    [AbpAuthorize(T_KPointAppPermissions.T_KPoint_DeleteT_KPoint)]
    public async Task DeleteT_KPointAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _t_KPointRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除培训重点
    /// </summary>
    [AbpAuthorize(T_KPointAppPermissions.T_KPoint_DeleteT_KPoint)]
    public async Task BatchDeleteT_KPointAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _t_KPointRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion


  









    }
    }
