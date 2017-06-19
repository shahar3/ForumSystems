using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    abstract class User
    {
        private bool canPublishMsg;
        private bool canDeleteMsg;
        private bool canUpdateMsg;
        private bool canReadMsg;
        private bool canComplain;

        public User()
        {

        }
    }
}
