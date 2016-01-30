using System.Threading.Tasks;

namespace Spectre.Api.Wrapper
{
    public interface ISpectreService
    {
        Task<ByteResponse> GetByteResponseAsync(RequestParameters requestParameters);
        Task<StreamResponse> GetStreamResponseAsync(RequestParameters requestParameters);

    }
}
