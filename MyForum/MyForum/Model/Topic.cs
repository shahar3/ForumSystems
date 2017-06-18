using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Topic
    {
        public List<Message> messages;
        public string subject;
        public string content;
        public User messageOwner;
        public int id;

        public Topic(string subject,string content,User user)
        {
            this.content = content;
            this.subject = subject;
            messageOwner = user;
        }
    }
}
