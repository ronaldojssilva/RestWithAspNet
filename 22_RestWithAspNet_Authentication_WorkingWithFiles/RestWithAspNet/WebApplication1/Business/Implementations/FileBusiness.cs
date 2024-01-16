using RestWithAspNet.Data.VO;

namespace RestWithAspNet.Business.Implementations
{
    public class FileBusiness : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusiness(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<FileDatailVO> SavaFileToDisk(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileDatailVO>> SavaFileToList(IList<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
