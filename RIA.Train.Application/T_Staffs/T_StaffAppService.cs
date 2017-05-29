                                                                    
     
        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:50:33. All Rights Reserved.
//<生成时间>2017-05-25T22:50:33</生成时间>
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
using RIA.Train.Core.Authorization;
using RIA.Train.Core;
using RIA.Train.Entities;

namespace RIA.Train.Application
{
    /// <summary>
    /// 人员信息表服务实现
    /// </summary>
    [AbpAuthorize(T_StaffAppPermissions.T_Staff)]
    public class T_StaffAppService : TrainAppServiceBase, IT_StaffAppService
    {
        private readonly IRepository<T_Staff,int> _t_StaffRepository;
		

		private readonly T_StaffManage _t_StaffManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public T_StaffAppService( IRepository<T_Staff,int> t_StaffRepository	,
T_StaffManage t_StaffManage
	
  )
        {
            _t_StaffRepository = t_StaffRepository;
			 _t_StaffManage = t_StaffManage;
			 
        }

    #region 人员信息表管理

    /// <summary>
    /// 根据查询条件获取人员信息表分页列表
    /// </summary>
    public async Task<PagedResultDto<T_StaffListDto>> GetPagedT_StaffsAsync(GetT_StaffInput input)
{
			
    var query = _t_StaffRepository.GetAll();
    //TODO:根据传入的参数添加过滤条件

    var t_StaffCount = await query.CountAsync();

    var t_Staffs = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var t_StaffListDtos = t_Staffs.MapTo<List<T_StaffListDto>>();
    return new PagedResultDto<T_StaffListDto>(
    t_StaffCount,
    t_StaffListDtos
    );
    }

        /// <summary>
    /// 通过Id获取人员信息表信息进行编辑或修改 
    /// </summary>
    public async Task<GetT_StaffForEditOutput> GetT_StaffForEditAsync(NullableIdDto<int> input)
{
    var output=new GetT_StaffForEditOutput();

    T_StaffEditDto t_StaffEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _t_StaffRepository.GetAsync(input.Id.Value);
    t_StaffEditDto=entity.MapTo<T_StaffEditDto>();
    }
	else 
	{
	t_StaffEditDto=new T_StaffEditDto();	
	}

	output.T_Staff=t_StaffEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取人员信息表ListDto信息
    /// </summary>
    public async Task<T_StaffListDto> GetT_StaffByIdAsync(EntityDto<int> input)
{
    var entity = await _t_StaffRepository.GetAsync(input.Id);

    return entity.MapTo<T_StaffListDto>();
    }







    /// <summary>
    /// 新增或更改人员信息表
    /// </summary>
    public async Task CreateOrUpdateT_StaffAsync(CreateOrUpdateT_StaffInput input)
{
    if (input.T_StaffEditDto.Id.HasValue)
{
    await UpdateT_StaffAsync(input.T_StaffEditDto);
    }
    else
{
    await CreateT_StaffAsync(input.T_StaffEditDto);
    }
    }

    /// <summary>
    /// 新增人员信息表
    /// </summary>
    [AbpAuthorize(T_StaffAppPermissions.T_Staff_CreateT_Staff)]
    public virtual async Task<T_StaffEditDto> CreateT_StaffAsync(T_StaffEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<T_Staff>();
	
    entity = await _t_StaffRepository.InsertAsync(entity);
    return entity.MapTo<T_StaffEditDto>();
    }

    /// <summary>
    /// 编辑人员信息表
    /// </summary>
    [AbpAuthorize(T_StaffAppPermissions.T_Staff_EditT_Staff)]
    public virtual async Task UpdateT_StaffAsync(T_StaffEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _t_StaffRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _t_StaffRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除人员信息表
    /// </summary>
    [AbpAuthorize(T_StaffAppPermissions.T_Staff_DeleteT_Staff)]
    public async Task DeleteT_StaffAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _t_StaffRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除人员信息表
    /// </summary>
    [AbpAuthorize(T_StaffAppPermissions.T_Staff_DeleteT_Staff)]
    public async Task BatchDeleteT_StaffAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _t_StaffRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion


  









    }
    }
