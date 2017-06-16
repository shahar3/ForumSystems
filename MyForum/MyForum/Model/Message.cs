using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Message
    {
        string content;
        User publisher;

        public Message(User publisher, string content)
        {
            this.publisher = publisher;
            this.content = content;
        }
    }
}
