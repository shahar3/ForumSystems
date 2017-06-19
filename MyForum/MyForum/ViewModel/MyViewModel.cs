using MyForum.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private MyModel model;

        private string str;

        public string Str
        {
            get { return Str; }
            set
            {
                Str = value;
                notifyPropertyChanged(str);
            }
        }

        public MyViewModel(MyModel model)
        {
            this.model = model;
        }

        public bool login(string userName, string password)
        {
            return model.login(userName, password);
        }

        #region event handler

        public event PropertyChangedEventHandler PropertyChanged;

        public void notifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        internal List<Topic> getTopics(string forumName)
        {
            return model.getTopics(forumName);
        }

        internal bool register(string firstName, string lastName, string email, string userName, string password)
        {
            return model.register(firstName, lastName, email, userName, password);
        }

        internal void sendNotification(string topicSubject, string topicContent,string forumName,string userName)
        {
            model.sendNotification(topicSubject, topicContent,forumName,userName);
        }

        internal void addTopic(Topic topic, string forumName)
        {
            model.addTopic(topic, forumName);
            //model.sendNotification(forumName,topic.messageOwner.UserName);
        }

        #endregion event handler

        internal RegisteredUser GetUser(string userName)
        {
            return model.getUser(userName);
        }

        internal void close()
        {
            model.close();
        }

        internal void follow(RegisteredUser user,string forumName)
        {
            model.follow(user,forumName);
        }

        //clear the notification list
        internal void clearNotification(string userName)
        {
            model.clearNotification(userName);
        }

        //get report
        internal string getReport(string forumName)
        {
            return model.getReport(forumName);
        }
    }
}