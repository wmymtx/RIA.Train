 
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-05-25T22:44:49. All Rights Reserved.
//<生成时间>2017-05-25T22:44:49</生成时间>
using AutoMapper;

namespace RIA.Train.Application.Mappers
{
	/// <summary>
    /// T_KPointDto映射配置
    /// </summary>
    public class T_KPointDtoMapper 
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
       ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(T_KPointDtoMapper.CreateMappings);
      ///注入位置    < see cref = "TrainApplicationModule" /> 
     /// <param name="configuration"></param>
    /// </summary>       
	  private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
	  {
	           
			      //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

	  // Configuration.Modules.AbpAutoMapper().Configurators.Add(T_KPointDtoMapper.CreateMappings);

	    //    Mapper.CreateMap<T_KPoint,T_KPointEditDto>();
       //     Mapper.CreateMap<T_KPoint, T_KPointListDto>();

     //       Mapper.CreateMap<T_KPointEditDto, T_KPoint>();
    //        Mapper.CreateMap<T_KPointListDto,T_KPoint>();
  






 	  }


}}