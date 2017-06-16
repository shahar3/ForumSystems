using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Model;

namespace MyForum.Model
{
    class SubFourom : AForum
    {

        public SubFourom(string logo,string subject,string description,List<User> moderator)
        {
            m_logo = logo;
            m_subject = subject;
            m_description = description;
            m_moderator = moderator;
            m_users = new List<Observer>();
            m_topics = new List<Topic>();
        }

        //add the topic to the topics list
        public override void addTopic(Topic topic)
        {
             m_topics.Add(topic);
            //send notification to all sub forum members
            foreach (Observable user in m_users)
            {
                Notification notification = new Notification();
                //user.update();
            }

        }

        public override void removeTopic()
        {
            throw new NotImplementedException();
        }
    }
}
