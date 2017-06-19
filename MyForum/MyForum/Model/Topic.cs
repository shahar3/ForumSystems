using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    [Serializable]
    internal class Topic
    {
        public List<Message> messages;
        public string subject;
        public string content;
        public RegisteredUser openedBy;
        public string userFirstOpenMsgName;

        public Topic(string subject,string content,RegisteredUser user)
        {
            messages = new List<Message>();
            this.content = content;
            this.subject = subject;
            openedBy = user;
            userFirstOpenMsgName = openedBy.UserName;
        }

        public override string ToString()
        {
            return "subject : " +subject + " by : " + userFirstOpenMsgName;
        }
    }
}
