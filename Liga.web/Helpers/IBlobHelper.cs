using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Liga.web.Helpers
{
    public interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile file,string containerName);
        Task<Guid> UploadBlobAsync(byte[] file, string containerName);
        Task<Guid> UploadBlobAsync(string file, string containerName);

    }
}
