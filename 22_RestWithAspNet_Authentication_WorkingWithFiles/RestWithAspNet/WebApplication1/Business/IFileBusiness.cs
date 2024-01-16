using RestWithAspNet.Data.VO;

namespace RestWithAspNet.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);

        public Task<FileDatailVO> SavaFileToDisk(IFormFile formFile);

        public Task<List<FileDatailVO>> SavaFileToList(IList<IFormFile> files);

    }
}
