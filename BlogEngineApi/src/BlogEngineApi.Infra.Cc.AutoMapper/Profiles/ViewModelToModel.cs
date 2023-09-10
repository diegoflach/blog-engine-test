using AutoMapper;

namespace BlogEngineApi.Infra.Cc.AutoMapper.Profiles
{
    public class ViewModelToModel : Profile
    {
        public new string ProfileName => "ViewModelToModel";

        public ViewModelToModel()
        {
        }
    }
}