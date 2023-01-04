using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDownloader.Models;

namespace YoutubeDownloader.Helpers
{
    public class IOHelper
    {
        public async Task<bool> SaveHostoryToFileAsync(History history)
        {
            var historyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "history", "history.txt");
            var historyLines = File.ReadAllLines(historyPath);
            foreach (var line in historyLines)
            {
                var details = line.Split('|');
                if (details[0].Equals(history.Id))
                    return false;

                using (var writer = new StreamWriter(historyPath, true))
                {
                    //TODO: finish save history to file method.
                }
            }

            return false; 

        }
    }
}
