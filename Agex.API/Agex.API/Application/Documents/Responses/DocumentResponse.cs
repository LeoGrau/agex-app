using Agex.API.Application.Common.Response;
using Agex.API.Application.Documents.DTOs;

namespace Agex.API.Application.Documents.Responses;

public class DocumentResponse : BaseResponse<DocumentDto>
{
    public DocumentResponse(DocumentDto data, string message = "") : base(data, message)
    {
    }

    public DocumentResponse(string message = "") : base(message)
    {
    }
}