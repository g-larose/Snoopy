using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Snoopy.Core.Commands;
using Snoopy.Core.Interfaces;

namespace Snoopy.Core.ViewModels
{
    /// <summary>
    /// Created by the template
    /// make changes as needed
    /// </summary>
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand? NavigateHomeCommand { get; }
        public ICommand? NavigateSettingsCommand { get; }
        public ICommand? NavigateHistoryCommand { get; }
        public AppViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigator, () => new HomeViewModel(_navigator));
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(_navigator, () => new SettingsViewModel());
            NavigateHistoryCommand = new NavigateCommand<HistoryViewModel>(_navigator, () => new HistoryViewModel(_navigator));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
