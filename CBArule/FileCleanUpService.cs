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
        IOptionsMonitor<FilePathConfig> _filePathConfigUpdate;

        public FileCleanUpService(IOptionsMonitor<FilePathConfig> filePathConfig)
        {
            _filePathConfig = filePathConfig.CurrentValue;
            _filePathConfigUpdate = filePathConfig;
        }

        private void UpdateConfig()
        {
            _filePathConfigUpdate.OnChange(x => _filePathConfig = x);
        }

        public void FileCleanUp()
        {
            UpdateConfig();
            Helper.DeleteFiles(_filePathConfig.FilePath);
        }
    }
}
