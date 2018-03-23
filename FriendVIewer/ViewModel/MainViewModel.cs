using FriendVIewer.DataProvider;
using FriendVIewer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendVIewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private bool _isLoading;
      

        private IFriendDataProvider _dataProvideder;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }

        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvideder = dataProvider;
            Friends = new ObservableCollection<Friend>();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            IsLoading = true;
            try
            {
                // var friends = _dataProvideder.LoadFriend();

                var task = Task.Run(() => _dataProvideder.LoadFriend());
                IEnumerable<Friend> friends = await task;
                foreach (var friend in friends)
                {
                    Friends.Add(friend);
                }
            }
            finally
            {
                IsLoading = false;
            }


            SelectedFriend = Friends.Count > 0 ? Friends.First() : null;
        }


        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

    }
}
