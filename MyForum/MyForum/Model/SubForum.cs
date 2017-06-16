using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Model;


namespace MyForum.Model
{
    class SubFourom : AForum
    {

        public SubFourom(string logo, string forumName, string subject, string description, List<User> moderator)
        {
            ForumName = forumName;
            Logo = logo;
            Subject = subject;
            Description = description;
            Moderator = moderator;
            Users = new List<Observer>();
            Topics = new ObservableCollection<Topic>();
        }

        //add the topic to the topics list
        public override void addTopic(Topic topic)
        {
            Topics.Add(topic);
            //send notification to all sub forum members
            string message = "Hello, there is a new topic that was added to forum that you are regisred";
            string title = "New topic was added in " + ForumName;
            foreach (Observable user in Users)
            {
                Notification notification = new Notification(message, title);
                (user as User).update(notification);
            }

        }

        //This function removing specific topic if there is the permissions that demended 
        public override void removeTopic(Topic topicToDelete, User user)
        {
            //check if which user are (admin,moderator,regular user)
            if (user.canDeleteTopic)
            {
                //there is a admin
                deleteTopic(topicToDelete);
            }
            else//there is user
            {
                //check if the message is belong to this user
                if (topicToDelete.messageOwner.UserName == user.UserName)
                {
                    deleteTopic(topicToDelete);
                }
                else
                {
                    //return that has no enough permissions to do this operation
                }
            }
        }

        //remove thr topic
        private void deleteTopic(Topic topicToDelete)
        {
            foreach (Topic topic in Topics)
            {
                if (topic.id == topicToDelete.id)
                {
                    Topics.Remove(topic);
                }
            }
        }
    }
}
