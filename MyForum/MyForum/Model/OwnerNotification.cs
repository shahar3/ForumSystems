using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class OwnerNotification : Notification
    {
        private string content;
        private DateTime date;
    }
}
