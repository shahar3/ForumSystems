using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Topic
    {
        List<Message> messages;
        string subject;

        public Topic(string subject)
        {
            this.subject = subject;
        }
    }
}
