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

        public async Task<List<FileDatailVO>> SaveFilesToDisk(List<IFormFile> files)
        {
            List<FileDatailVO> list = new List<FileDatailVO>();
            foreach (IFormFile file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }
            return list;
        }

        public async Task<FileDatailVO> SaveFileToDisk(IFormFile file)
        {
            FileDatailVO fileDatail = new FileDatailVO();
            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" ||
                fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDatail.DocumentName = docName;
                    fileDatail.DocType = fileType;
                    fileDatail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDatail.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }

            return fileDatail;
        }

        public Task<List<FileDatailVO>> SavaFileToList(IList<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
