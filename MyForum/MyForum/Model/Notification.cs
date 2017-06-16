using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    class Notification
    {
        string msg;
        string title;

        public Notification(string msg, string title)
        {
            this.msg = msg;
            this.title = title;
        }
    }
}
