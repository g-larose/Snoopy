using AngleSharp.Browser.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private Stack<string> _history;
        public HistoryViewModel(INavigator? navigator)
        {
            _navigator = navigator;
            _history = new Stack<string>();
        }
    }
}
