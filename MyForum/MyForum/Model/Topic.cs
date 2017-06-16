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
        public User messageOwner;
        public int id;

        public Topic(string subject,User user)
        {
            this.subject = subject;
            messageOwner = user;
        }
    }
}
