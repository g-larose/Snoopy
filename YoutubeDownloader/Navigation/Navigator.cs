using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snoopy.Core.Interfaces;
using Snoopy.Core.ViewModels;

namespace Snoopy.Core.Navigation
{
    public class Navigator : INavigator
    {
        public event Action? CurrentViewModelChanged;
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
