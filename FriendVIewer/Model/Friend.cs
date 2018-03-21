using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendVIewer.Model
{
    public class Friend
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public string HomePage { get; set; }

        public byte[] Image { get; set; }

        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    }
}
