using AutoMapper;

using BlogEngineApi.Infra.Cc.AutoMapper.Profiles;

namespace BlogEngineApi.Infra.Cc.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ModelToViewModel>();
                cfg.AddProfile<ViewModelToModel>();
            });
        }
    }
}