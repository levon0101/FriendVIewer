using FriendVIewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendVIewer.DesignTimeData
{
    public class DesignFriend : Friend  // make it public after chack
    {
        public DesignFriend()
        {
            FirstName = "Levon";
            LastName = "Mardanyan";
            Email = "levon.ecs@gmail.com";
            CellPhone = "055979969";
            HomePage = "none";
           // setImageProperty();
        }

        //private void setImageProperty()
        //{
        //    var streemRecourceInfo = Application.GetResourceStream(
        //        new Uri("FriendViewer,Component/DesignTimeData/Images/Leovn.jpg", UriKind.Relative));

        //    var length = streemRecourceInfo.Stream.Length;
        //    byte[] image = new byte[length];
        //    streemRecourceInfo.Stream.Read(image, 0, (int)length);

        //    Image = image;
        //}
    }
}
