using Agex.API.Application.Common.Response;
using Agex.API.Application.Documents.DTOs;

namespace Agex.API.Application.Documents.Responses;

public class FileResponse : BaseResponse<FileDto>
{
    public FileResponse(FileDto data, string message = "") : base(data, message)
    {
    }

    public FileResponse(string message = "") : base(message)
    {
    }
}