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
        private IFriendDataProvider _dataProvideder;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }

        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvideder = dataProvider;
            Friends = new ObservableCollection<Friend>();
        }

        private void LoadData()
        {
            var friends = _dataProvideder.LoadFriend();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
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

    }
}
