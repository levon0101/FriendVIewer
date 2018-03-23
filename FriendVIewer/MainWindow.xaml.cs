using FriendVIewer.DataProvider;
using FriendVIewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FriendViewer.Extensions;

namespace FriendVIewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainViewModel(new FriendDataProvider());
        }

        private void FriendControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!navigationControl.IsPinned)
            {
                GeneralTransform generalTransform = this.TransformToVisual(navigationGrid);

                Point point = generalTransform.Transform(new Point());

                point.X += navigationTransform.X;
                point.X -= navigationColoumn.ActualWidth;
                point.Y = 0; //point.Y += navigationTransform.Y; // havn't Y value always 0
                navigationTransform.AnimateTo(point);
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            navigationTransform.AnimateTo(new Point());
        }

        private void navigationControl_IsPinnedChanged(object sender, EventArgs e)
        {
            if (navigationControl.IsPinned)
            {
                if(!mainAreaGrid.ColumnDefinitions.Contains(coloumnAddOrRemove))
                {
                    mainAreaGrid.ColumnDefinitions.Insert(0,coloumnAddOrRemove);//insert as first coloumn
                }
                navigationButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (mainAreaGrid.ColumnDefinitions.Contains(coloumnAddOrRemove))
                {
                    mainAreaGrid.ColumnDefinitions.Remove(coloumnAddOrRemove);
                }
                navigationButton.Visibility = Visibility.Visible;
            }
        }
    }
}
