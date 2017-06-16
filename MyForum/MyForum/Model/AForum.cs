using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    abstract class AForum
    {
        public string m_logo;
        public string m_forumName;
        public string m_subject;
        public string m_description;
        public List<User> m_moderator;
        public List<Observer> m_users;
        public ObservableCollection<Topic> m_topics;
        

        abstract public void addTopic(Topic topic);
        abstract public void removeTopic(Topic topicToDelete, User user);
    }
}
