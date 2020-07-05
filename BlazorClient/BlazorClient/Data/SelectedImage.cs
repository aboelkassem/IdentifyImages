using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Data
{
    public class SelectedImage
    {
        private IFileListEntry _file;
        public ImageClassificationResult ClassificationResult { get; set; }
        public string Name => _file.Name;
        public string Base64Image { get; private set; }
        public double UploadedPercentage => 100.0 * _file.Data.Position / _file.Size;

        public SelectedImage(IFileListEntry file)
        {
            _file = file;
        }

        public async Task<MemoryStream> Upload(Action OnDataRead)
        {
            EventHandler eventHandler = (sender, eventArgs) => OnDataRead();
            _file.OnDataRead += eventHandler;

            var fileStream = new MemoryStream();
            await _file.Data.CopyToAsync(fileStream);

            // Get a base64 so we can render an image preview
            Base64Image = Convert.ToBase64String(fileStream.ToArray());

            _file.OnDataRead -= eventHandler;
            return fileStream;
        }

    }
}
