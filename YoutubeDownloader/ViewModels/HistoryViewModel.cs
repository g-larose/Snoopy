using Snoopy.Core.Interfaces;
using Snoopy.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snoopy.Core.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private Stack<string> _history;

        private ObservableCollection<History> _historyList;
        public ObservableCollection<History> HistoryList
        {
            get => _historyList;
            set => OnPropertyChanged(ref _historyList, value);
        }
        public HistoryViewModel(INavigator? navigator)
        {
            _navigator = navigator;
            _history = new Stack<string>();
            HistoryList= new ObservableCollection<History>();
            LoadHistory();
        }

        private void LoadHistory()
        {
            for (int i = 0; i < 10; i++)
            {
                History history = new()
                {
                    Id = Guid.NewGuid(),
                    Content = $"https://www.youtube.com/watch?v=-Vw-ONPfaFk{i}",
                    IsDownloaded = false,
                    DateDownloaded = DateTimeOffset.UtcNow,
                };
                HistoryList.Add(history);
            }
           
        }
    }
}
