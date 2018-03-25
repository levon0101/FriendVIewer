using FriendVIewer.Commands;
using FriendVIewer.DataProvider;
using FriendVIewer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendVIewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private bool _isLoading;
      

        private IFriendDataProvider _dataProvideder;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }

        public ObservableCollection<Friend> MainAreaFriends { get; set; }

        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvideder = dataProvider;
            Friends = new ObservableCollection<Friend>();
            MainAreaFriends = new ObservableCollection<Friend>();
            CloseMainAreaFriendCommand = new DelegateCommand(OnCloseMainAreaFriendExecuted);

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
                if(_selectedFriend != null)
                {
                    if (MainAreaFriends.Contains(_selectedFriend))
                    {
                        MainAreaFriends.Move(MainAreaFriends.IndexOf(_selectedFriend), 0);
                    }
                    else
                    {
                        MainAreaFriends.Insert(0, _selectedFriend);
                    }
                }
            }
        }

        public ICommand CloseMainAreaFriendCommand { get; private set; }
        private void OnCloseMainAreaFriendExecuted(object obj)
        {
            var friend = obj as Friend;
            if(friend != null && MainAreaFriends.Contains(friend))
            {
                MainAreaFriends.Remove(friend);
                if(SelectedFriend == friend)
                {
                    SelectedFriend = null;
                }
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
