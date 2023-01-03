using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeDownloader.Commands;
using YoutubeDownloader.Interfaces;
using System.Drawing;
using YoutubeExplode.Common;

namespace YoutubeDownloader.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        public YoutubeClient _ytClient;
        public Stack<string> _history { get; set; } = new();
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand? SearchCommand { get; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set => OnPropertyChanged(ref _searchQuery, value);

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
        public HomeViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _ytClient = new YoutubeClient();
            SearchCommand = new RelayCommand(SearchForVideo);
        }

        public async void SearchForVideo()
        {
            //TODO: create new helper class to handle youtube video searching
            var video = await _ytClient.Videos.GetAsync(SearchQuery);
            Title = $"Title: {video.Title}";
            Author = $"Author: {video.Author}";
            Duration = $"Duration: {video.Duration.ToString()!}";
            Thumbnail = video.Thumbnails.First().Url;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
