using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    abstract class AForum
    {
        public string m_logo;
        public string m_subject;
        public string m_description;
        public List<User> m_moderator;
        public List<Observer> m_users;
        public List<Topic> m_topics;
        

        abstract public void addTopic(Topic topic);
        abstract public void removeTopic();
    }
}
