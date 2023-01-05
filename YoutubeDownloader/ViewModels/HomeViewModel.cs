using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;
using Snoopy.Core.Commands;
using Snoopy.Core.Interfaces;
using System.Drawing;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;
using Snoopy.Core.Models;
using Snoopy.Core.Helpers;

namespace Snoopy.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private IOHelper ioHelper { get; }

        public YoutubeClient _ytClient;
        public Stack<History> _history { get; set; } = new();
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand? SearchCommand { get; }
        public ICommand? CancelCommand { get; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(ref _searchQuery, value);
                CanSearch = !string.IsNullOrEmpty(_searchQuery);
            }

        }

        private string _title;
        public string Title
        {
            get => _title;
            set => OnPropertyChanged(ref _title, value);
        }

        private string _author;
        public string Author
        {
            get => _author;
            set => OnPropertyChanged(ref _author, value);
        }

        private string _duration;
        public string Duration
        {
            get => _duration;
            set => OnPropertyChanged(ref _duration, value);
        }

        private string  _thumbNail;
        public string Thumbnail
        {
            get => _thumbNail;
            set => OnPropertyChanged(ref _thumbNail, value);
        }

        private bool _canSearch;
        public bool CanSearch
        {
            get => _canSearch;
            set => OnPropertyChanged(ref _canSearch, value);

        }

        private bool _canDownload;
        public bool CanDownload
        {
            get => _canDownload;
            set => OnPropertyChanged(ref _canDownload, value);
        }
        public HomeViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _ytClient = new YoutubeClient();
            ioHelper = new IOHelper();
            SearchCommand = new RelayCommand(SearchForVideo);
            CancelCommand = new RelayCommand(CancelDownload);
        }

        private void CancelDownload()
        {
            _navigator.CurrentViewModel = new AppViewModel(_navigator);
        }

        private async void SearchForVideo()
        {
            //TODO: create new helper class to handle youtube video searching
            var video = await _ytClient.Videos.GetAsync(SearchQuery);
            Title = $"Title: {video.Title}";
            Author = $"Author: {video.Author}";
            Duration = $"Duration: {video.Duration.ToString()!}";
            Thumbnail = video.Thumbnails.First().Url;

            if (video is not null)
                CanDownload = true;
            var historyModel = new History()
            {
                Id = Guid.NewGuid(),
                Content = SearchQuery,
                IsDownloaded = false,
                DateDownloaded = DateTimeOffset.UtcNow
            };
            await ioHelper.SaveHostoryToFileAsync(historyModel);
            _history.Push(historyModel);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
