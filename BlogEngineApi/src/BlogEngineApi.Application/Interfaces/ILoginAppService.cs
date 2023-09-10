using BlogEngineApi.Domain.Dtos;
using BlogEngineApi.Domain.Dtos.Result;

namespace BlogEngineApi.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<LoginResultDto> Login(LoginDto loginDto);
    }
}