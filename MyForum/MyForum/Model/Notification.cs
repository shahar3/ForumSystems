using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class Notification
    {
        List<RegisteredUser> notificated;

        public void sendNotificationToUser()
        {
        }

        /**
         * 
         * @param ModiratorId
         */
        public void sendModeratorNotification(int ModiratorId)
        {
        }
    }
}
