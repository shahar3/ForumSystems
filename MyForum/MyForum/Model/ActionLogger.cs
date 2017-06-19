using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class ActionLogger :Logger
    {
        private string content;

        /**
         * 
         * @param userId
         */
        public void userConnected(int userId)
        {
        }

        /**
         * 
         * @param userId
         */
        public void updateLogger(int userId)
        {
        }

        /**
         * 
         * @param userId
         * @param message
         */
        public void updateLogger(int userId, int message)
        {
        }

        public void logUserComplain()
        {
        }

        public void AddActionToLoger()
        {
        }
    }
}
