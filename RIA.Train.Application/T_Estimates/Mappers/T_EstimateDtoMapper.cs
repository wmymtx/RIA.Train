
using AutoMapper;

namespace RIA.Train.Application.Mappers
{
	/// <summary>
    /// T_EstimateDto映射配置
    /// </summary>
    public class T_EstimateDtoMapper 
    {

    private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
        
		  lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }
    




	    /// <summary>
       ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(T_EstimateDtoMapper.CreateMappings);
      ///注入位置    < see cref = "TrainApplicationModule" /> 
     /// <param name="configuration"></param>
    /// </summary>       
	  private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
	  {
	           
			      //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

	  // Configuration.Modules.AbpAutoMapper().Configurators.Add(T_EstimateDtoMapper.CreateMappings);

	    //    Mapper.CreateMap<T_Estimate,T_EstimateEditDto>();
       //     Mapper.CreateMap<T_Estimate, T_EstimateListDto>();

     //       Mapper.CreateMap<T_EstimateEditDto, T_Estimate>();
    //        Mapper.CreateMap<T_EstimateListDto,T_Estimate>();
  






 	  }


}}