using Snoopy.Core.Commands;
using Snoopy.Core.Interfaces;
using Snoopy.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snoopy.Core.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private Stack<string> _history;

        public ICommand? DeleteCommand { get; set; }

        private ObservableCollection<History> _historyList;
        public ObservableCollection<History> HistoryList
        {
            get => _historyList;
            set => OnPropertyChanged(ref _historyList, value);
        }

        private History _selectedHistory;
        public History SelectedHistory
        {
            get => _selectedHistory;
            set => OnPropertyChanged(ref _selectedHistory, value);
        }
        public HistoryViewModel(INavigator? navigator)
        {
            _navigator = navigator;
            _history = new Stack<string>();
            DeleteCommand = new RelayCommand(DeleteHistory);
            HistoryList= new ObservableCollection<History>();
            LoadHistory();
        }

        private void DeleteHistory()
        {
            var historyId = SelectedHistory;
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
