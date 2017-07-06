using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using RIA.Train.Core.Authorization;

namespace RIA.Train
{
    [DependsOn(typeof(TrainCoreModule), typeof(AbpAutoMapperModule))]
    public class TrainApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });

           // Configuration.Authorization.Providers.Add<T_DepAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
