


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RIA.Train.Application.Dtos;
using RIA.Train.Dto;

namespace RIA.Train.Application
{
	/// <summary>
    /// 考评内容（档次）服务接口
    /// </summary>
    public interface IT_ContentAppService : IApplicationService
    {
        #region 考评内容（档次）管理

        /// <summary>
        /// 根据查询条件获取考评内容（档次）分页列表
        /// </summary>
        Task<PagedResultDto<T_ContentListDto>> GetPagedT_ContentsAsync(GetT_ContentInput input);
        List<T_ContentListDto> GetT_Contents();
        /// <summary>
        /// 通过Id获取考评内容（档次）信息进行编辑或修改 
        /// </summary>
        Task<GetT_ContentForEditOutput> GetT_ContentForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取考评内容（档次）ListDto信息
        /// </summary>
		Task<T_ContentListDto> GetT_ContentByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改考评内容（档次）
        /// </summary>
        Task CreateOrUpdateT_ContentAsync(CreateOrUpdateT_ContentInput input);





        /// <summary>
        /// 新增考评内容（档次）
        /// </summary>
        Task<T_ContentEditDto> CreateT_ContentAsync(T_ContentEditDto input);

        /// <summary>
        /// 更新考评内容（档次）
        /// </summary>
        Task UpdateT_ContentAsync(T_ContentEditDto input);

        /// <summary>
        /// 删除考评内容（档次）
        /// </summary>
        Task DeleteT_ContentAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除考评内容（档次）
        /// </summary>
        Task BatchDeleteT_ContentAsync(List<int> input);

        #endregion




    }
}
