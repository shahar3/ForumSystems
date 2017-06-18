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

        #region fields
        private string logo;
        private string forumName;
        private string subject;
        private string description;
        private List<User> moderator;
        private List<Observer> users;
        #endregion

        public string Logo { get => logo; set => logo = value; }
        public string ForumName { get => forumName; set => forumName = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Description { get => description; set => description = value; }
        internal List<User> Moderator { get => moderator; set => moderator = value; }
        internal List<Observer> Users { get => users; set => users = value; }
        internal Dictionary<string, Topic> topics { get => topics; set => topics = value; }

        abstract public void addTopic(Topic topic);
        abstract public void removeTopic(Topic topicToDelete, User user);
    }
}
