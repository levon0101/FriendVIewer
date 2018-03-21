using FriendVIewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendVIewer.DataProvider
{
    public class FriendDataProvider : IFriendDataProvider
    {
        public IEnumerable<Friend> LoadFriend()
        {
            return new List<Friend>()
            {
                new Friend{FirstName="Levon", LastName = "Mardanyan", Email = "levon.ecs@gmail.com"},
                new Friend {FirstName = "Simon", LastName = "Hiener",Email = "simon@...",HomePage = "not created yet", CellPhone = "+49 555666777", },
                new Friend {FirstName = "Andreas", LastName = "Werne",Email = "andi@...",HomePage = "not created yet", CellPhone = "+49 123456789", },
                new Friend {FirstName = "Sandra", LastName = "Matt",Email = "sandra@...",HomePage = "not created yet", CellPhone = "+49 555666777", },
                new Friend {FirstName = "Marcel", LastName = "Zipper",Email = "marcel@...",HomePage = "not created yet", CellPhone = "+49 123456789", }
            };
        }

        private static byte[] GetImage(string fileName)
        {
            var streamResourceInfo = Application.GetResourceStream(new Uri("/DataProvider/Images/" + fileName, UriKind.Relative));
            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int)length);

            return image;
        }

    }
}
