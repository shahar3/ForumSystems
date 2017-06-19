using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    class Message
    {

        List<Message> response;
        Message ancestor;
        RegisteredUser SendedBy;
        RegisteredUser RecivedBy;
        private string title;
        private string content;
        private DateTime publishDate;
        private string userPublish;

        public Message()
        {

        }
        /**
         * 
         * @param SearchQuery
         */
        public void getRelevantMessage(int SearchQuery)
        {
        }

    }
}
