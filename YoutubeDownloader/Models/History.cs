using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsDownloaded { get; set; }
        public DateTimeOffset DateDownloaded { get; set; }
    }
}
