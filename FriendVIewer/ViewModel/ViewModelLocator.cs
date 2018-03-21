using FriendVIewer.DataProvider;
using FriendVIewer.DesignTimeData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendVIewer.ViewModel
{
    public class ViewModelLocator
    {
        private MainViewModel _mainViewModel;

        public MainViewModel MainViewModel
        {
            get
            {
                if (_mainViewModel == null)
                {
                    IFriendDataProvider dataProvider = DesignerProperties.GetIsInDesignMode(new FrameworkElement())
                        ? (IFriendDataProvider)new DesignFriendDataProvider()
                        : new FriendDataProvider();

                    _mainViewModel = new MainViewModel(dataProvider);
                }
                return _mainViewModel;
            }
        }
    }
}
