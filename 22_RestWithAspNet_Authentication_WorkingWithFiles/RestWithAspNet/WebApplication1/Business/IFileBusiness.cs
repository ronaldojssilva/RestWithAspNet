using RestWithAspNet.Data.VO;

namespace RestWithAspNet.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);
        Task<List<FileDatailVO>> SaveFilesToDisk(List<IFormFile> files);
        public Task<FileDatailVO> SaveFileToDisk(IFormFile formFile);

        public Task<List<FileDatailVO>> SavaFileToList(IList<IFormFile> files);

    }
}
