using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class FileCleanUpService : IFileCleanUpService
    {
        FilePathConfig _filePathConfig;

        public FileCleanUpService(IOptions<FilePathConfig> filePathConfig)
        {
            _filePathConfig = filePathConfig.Value;
        }

        public void FileCleanUp()
        {
            Helper.DeleteFiles(_filePathConfig.FilePath);
        }
    }
}
