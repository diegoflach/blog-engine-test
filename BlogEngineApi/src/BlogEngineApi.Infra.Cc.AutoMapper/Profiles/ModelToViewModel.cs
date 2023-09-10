using AutoMapper;

namespace BlogEngineApi.Infra.Cc.AutoMapper.Profiles
{
    public class ModelToViewModel : Profile
    {
        public new string ProfileName => "EntityToViewModel";

        public ModelToViewModel()
        {
        }
    }
}